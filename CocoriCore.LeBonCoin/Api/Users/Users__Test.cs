using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CocoriCore.LeBonCoin
{
    public class Users__Test : TestBase
    {

        [Fact]
        public async Task InscriptionConnexion()
        {
            var user = CreateUser();

            var inscription = await user.Display(new Users_Inscription_PAGE());
            // inscription.Submit(new Users_Inscription_POST());

            var dashboard = await user.Display(await user.Submit(inscription.Form, new Users_Inscription_POST()
            {
                Email = "aa@aa.aa",
                Password = "azerty",
                PasswordConfirmation = "azerty"
            }));

            dashboard.Should().NotBeNull();
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

        public async Task MauvaisMotDePasse()
        {
            var browser = CreateUser();
            var accueil = await browser.Display(new Accueil_PAGE());

            var connexion = await browser.Click(accueil.Connexion);

            Func<Task> a = async () => await browser.Submit(connexion.Form, new Users_Connexion_POST()
            {
                Email = "aa@aa.aa",
                Password = "azerty"
            });

            //Action a = () => browser.Click(connexion.Formulaire.Submit);
            //a.Should().Throw();
        }

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

    }
}