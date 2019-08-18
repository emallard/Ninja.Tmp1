using System;
using System.Threading.Tasks;
using CocoriCore.Page;
using FluentAssertions;
using Xunit;

namespace CocoriCore.LeBonCoin
{
    public class Annonces__Test : TestBase
    {

        [Fact]
        public void RechercheParCategorie()
        {
            var vendeur = CreateUserFluent();
            //user.EnTantQueVendeur();
            var vendeurAnnonce = vendeur.Display(new Vendeur_Dashboard_PAGE())
                .Result.Click(p => p.NouvelleAnnonce)
                .Result.GetForm(p => p.Form)
                    .Follow(new Vendeur_NouvelleAnnonce_POST()
                    {
                        Ville = "Paris",
                        Categorie = "Voitures"
                    }, r => r.Redirect)
                .Result.Page;

            var visiteur = CreateUserFluent();
            var annonces = visiteur.Display(new Accueil_PAGE())
                .Result.GetForm(p => p.Form)
                    .Follow(new Annonces_POST()
                    {
                        Ville = "Paris",
                        Categorie = ""
                    }, r => r.Redirect)
                .Result.Page;

            annonces.Items.Should().HaveCount(1);
            annonces.Items[0].Ville.Should().Be("Paris");
            annonces.Items[0].Categorie.Should().Be("Voiture");
        }
    }
}