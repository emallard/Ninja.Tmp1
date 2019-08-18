using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Dashboard_PAGE : IMessage<Vendeur_Dashboard_PAGEResponse>, IQuery
    {
    }

    public class Vendeur_Dashboard_PAGEResponse
    {
        public string Nom;
        public string Prenom;
        public Vendeur_NouvelleAnnonce_PAGE NouvelleAnnonce = new Vendeur_NouvelleAnnonce_PAGE();
        public Vendeur_Annonces_PAGE Reunions = new Vendeur_Annonces_PAGE();
        public MenuUtilisateur MenuUtilisateur = new MenuUtilisateur();
    }

    public class Vendeur_Dashboard_PAGEHandler : MessageHandler<Vendeur_Dashboard_PAGE, Vendeur_Dashboard_PAGEResponse>
    {
        public override async Task<Vendeur_Dashboard_PAGEResponse> ExecuteAsync(Vendeur_Dashboard_PAGE query)
        {
            await Task.CompletedTask;
            return new Vendeur_Dashboard_PAGEResponse()
            {
                Nom = "Dupont",
                Prenom = "Jean"
            };
        }
    }
}