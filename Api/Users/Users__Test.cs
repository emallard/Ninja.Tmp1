using System;
using FluentAssertions;
using Xunit;

namespace Ninja.Tmp1
{
    public class Users__Test
    {
        protected T Get<T>()
        {
            return default(T);
        }

        [Fact]
        public void InscriptionConnexion()
        {
            IBrowser browser = new TestBrowser(new MessageBus());

            var inscription = browser.Display(new Users_Inscription_GET());
            var dashboard = browser.Display(browser.Submit(inscription.Submit, new Users_Inscription_POST()
            {
                Email = "aa@aa.aa",
                Password = "azerty",
                PasswordConfirmation = "azerty"
            }));

            dashboard.Should().NotBeNull();
            /*
                        var accueil = browser.Click(dashboard.MenuUtilisateur.Deconnexion);
                        var connexion = browser.Click(accueil.Connexion);

                        var connexionGet = browser.Submit(connexion.Submit, new Users_Connexion_POST()
                        {
                            Email = new Email { Value = "aa@aa.aa" },
                            Password = new Password { Value = "azerty" }
                        });

                        connexionGet.Should().NotBeNull();
            */
        }

        public void MauvaisMotDePasse()
        {
            var browser = Get<IBrowser>();
            var accueil = browser.Display(new Accueil_GET());

            var connexion = browser.Click(accueil.Connexion);

            Action a = () => browser.Submit(connexion.Submit, new Users_Connexion_POST()
            {
                Email = new Email { Value = "aa@aa.aa" },
                Password = new Password { Value = "azerty" }
            });

            //Action a = () => browser.Click(connexion.Formulaire.Submit);
            //a.Should().Throw();
        }

        public void MotDePasseOublie()
        {

            var browser = Get<IBrowser>();
            var emails = Get<IEmails>();

            var inscription = browser.Display(new Users_Inscription_GET());
            var dashboard = browser.Display(browser.Submit(inscription.Submit, new Users_Inscription_POST()
            {
                Email = "aa@aa.aa",
                Password = "azerty",
                PasswordConfirmation = "azerty"
            }));

            var accueil = browser.Click(dashboard.MenuUtilisateur.Deconnexion);
            var connexion = browser.Click(accueil.Connexion);
            var motDePasseOublie = browser.Click(connexion.MotDePasseOublie);
            browser.Submit(motDePasseOublie.Submit, new Users_MotDePasseOublie_POSTBody()
            {
                Email = new Email { Value = "aa@aa.aa" }
            });

            var email = (EmailMotDePasseOublie)emails.Read("aa@aa.aa");
            browser.Display(new Users_SaisieNouveauMotDePasse_Token_GET(email.Token));
        }

    }
}