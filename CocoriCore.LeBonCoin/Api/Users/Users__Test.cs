using System;
using System.Threading.Tasks;
using CocoriCore.Page;
using FluentAssertions;
using Xunit;

namespace CocoriCore.LeBonCoin
{
    public class Users__Test : TestBase
    {

        [Fact]
        public void InscriptionConnexion()
        {
            var user = CreateUser("vendeur");

            var dashboard =
            user.Display(new Users_Inscription_PAGE())
                .GetForm(p => p.Form)
                .Submit(new Users_Inscription_POST()
                {
                    Email = "aa@aa.aa",
                    Password = "azerty",
                    PasswordConfirmation = "azerty"
                })
                .Redirect(r => r.Redirect);
            /*
            var dashboard = await user.Display(await user.Submit(inscription.Form, new Users_Inscription_POST()
            {
                Email = "aa@aa.aa",
                Password = "azerty",
                PasswordConfirmation = "azerty"
            }));
            */
            dashboard.Page.Should().NotBeNull();
            /*

            var accueil = await user.Click(dashboard.MenuUtilisateur.Deconnexion);
            var connexion = await user.Click(accueil.Connexion);

            var connexionGet = user.Submit(connexion.Submit, new Users_Connexion_POST()
            {
                Email = new Email { Value = "aa@aa.aa" },
                Password = new Password { Value = "azerty" }
            });

            connexionGet.Should().NotBeNull();
            */
        }

        [Fact]
        public void MauvaisMotDePasse()
        {
            var user = CreateUser("vendeur");
            var connexion =
            user.Display(new Accueil_PAGE())
                .Follow(p => p.Connexion);

            Action a = () => connexion
                .GetForm(p => p.Form)
                .Submit(new Users_Connexion_POST()
                {
                    Email = "aa@aa.aa",
                    Password = "azerty"
                });


            //a.Should().Throw();
        }

        /*
        public async Task MotDePasseOublie()
        {

            var user = CreateUser();
            var emails = GetEmailReader();

            var inscription = await user.Display(new Users_Inscription_PAGE());
            var dashboard = await user.Display(await user.Submit(inscription.Form, new Users_Inscription_POST()
            {
                Email = "aa@aa.aa",
                Password = "azerty",
                PasswordConfirmation = "azerty"
            }));

            var accueil = await user.Click(dashboard.MenuUtilisateur.Deconnexion);
            var connexion = await user.Click(accueil.Connexion);
            var motDePasseOublie = await user.Click(connexion.MotDePasseOublie);
            var confirmation = await user.Display(await user.Submit(motDePasseOublie.Form, new Users_MotDePasseOublie_POST()
            {
                Email = new Email { Value = "aa@aa.aa" }
            }));


            confirmation.Should().NotBeNull();

            var email = (EmailMotDePasseOublie)(await emails.Read("aa@aa.aa")).Body;
            await user.Display(new Users_SaisieNouveauMotDePasse_Token_PAGE() { Token = email.Token });
        }
        */

        [Fact]
        public async Task MotDePasseOublie()
        {

            var user = CreateUser("vendeur");
            var emailReader = GetEmailReader();

            var confirmation =
            user.Display(new Users_Inscription_PAGE())
                    .GetForm(p => p.Form)
                    .Submit(new Users_Inscription_POST()
                    {
                        Email = "aa@aa.aa",
                        Password = "azerty",
                        PasswordConfirmation = "azerty"
                    })
                    .Redirect(r => r.Redirect)
                .Follow(p => p.MenuUtilisateur.Deconnexion)
                .Follow(p => p.Connexion)
                .Follow(p => p.MotDePasseOublie)
                    .GetForm(p => p.Form)
                    .Submit(new Users_MotDePasseOublie_POST()
                    {
                        Email = "aa@aa.aa"
                    })
                    .Redirect(r => r.Redirect)
                .Page;

            confirmation.Should().NotBeNull();

            var emails = await emailReader.Read<EmailMotDePasseOublie>("aa@aa.aa");
            emails.Should().HaveCount(1);
            var lien = emails[0].Body.Lien;
            var dashboard = user.Display(lien)
                .GetForm(p => p.Form)
                .Submit(new Users_SaisieNouveauMotDePasse_Token_POST
                {
                    Token = lien.Token,
                    MotDePasse = "nouveauPassw0rd",
                    Confirmation = "nouveauPassw0rd",
                })
                .Redirect(r => r.Redirect)
                .GetForm(p => p.Form)
                .Submit(new Users_Connexion_POST()
                {
                    Email = "aa@aa.aa",
                    Password = "nouveauPassw0rd",
                })
                .Redirect(r => r.Redirect);

            dashboard.Should().NotBeNull();
        }
    }
}