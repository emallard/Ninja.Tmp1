using System;
using System.Linq;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce__Test : TestBase
    {

        void EnTantQueVendeur()
        {

        }

        /*
        public async Task NouvelleReunion()
        {
            
            var browser = CreateUser();
            //browser.EnTantQueVendeur();
            var nouvelleReunion = await browser.Display(new Vendeur_NouvelleAnnonce_GET());
            var reunions = await browser.Display(await browser.Submit(nouvelleReunion.Submit, new Vendeur_NouvelleAnnonce_POST()
            {
                Date = new DateTime(),
                Ville = "Paris",
                Categorie = "Cosmetiques"
            }));

            var reunion = await browser.Click(reunions.Reunions.First().LinkReunion);
            var reunionEdit = await browser.Click(reunion.Edit);
        }
        */
    }
}