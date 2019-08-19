using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin
{
    public class EnTantQueVendeur : IScenario<Accueil_PAGEResponse, Vendeur_Dashboard_PAGEResponse>
    {
        public TestBrowserFluent<Vendeur_Dashboard_PAGEResponse> Play(TestBrowserFluent<Accueil_PAGEResponse> browserFluent)
        {
            var dashboard = browserFluent.Display(new Users_Inscription_PAGE())
                .GetForm(p => p.Form)
                .Submit(new Users_Inscription_POST()
                {
                    Email = "aa@aa.aa",
                    Password = "azerty",
                    PasswordConfirmation = "azerty"
                })
                .Redirect(r => r.Redirect);

            return dashboard;
        }
    }
}
