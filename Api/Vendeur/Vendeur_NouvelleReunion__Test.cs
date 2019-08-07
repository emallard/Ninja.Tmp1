using System;
using System.Linq;

namespace Ninja.Tmp1
{
    public class Vendeur_NouvelleReunion__Test
    {
        protected T Get<T>()
        {
            return default(T);
        }

        void EnTantQueVendeur()
        {

        }

        public void NouvelleReunion()
        {
            var browser = Get<IBrowser>();
            EnTantQueVendeur();
            var nouvelleReunion = browser.Display(new Vendeur_NouvelleReunion_GET());
            var reunions = browser.Display(browser.Submit(nouvelleReunion.Submit, new Vendeur_NouvelleReunion_POST()
            {
                Date = new DateTime(),
                Ville = "Paris",
                Categorie = "Cosmetiques"
            }));

            var reunion = browser.Click(reunions.Reunions.First().LinkReunion);
            var reunionEdit = browser.Click(reunion.Edit);
        }
    }
}