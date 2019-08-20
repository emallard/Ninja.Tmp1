using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_POST : IMessage<Vendeur_NouvelleAnnonce_POSTResponse>
    {
        public string Ville;
        public string Categorie;
    }

    public class Vendeur_NouvelleAnnonce_POSTResponse
    {
        public Vendeur_Annonces_Id_PAGE Vendeur_Annonces_Id;
    }

    public class Vendeur_NouvelleAnnonce_POSTHandler : MessageHandler<Vendeur_NouvelleAnnonce_POST, Vendeur_NouvelleAnnonce_POSTResponse>
    {
        public async override Task<Vendeur_NouvelleAnnonce_POSTResponse> ExecuteAsync(Vendeur_NouvelleAnnonce_POST query)
        {
            await Task.CompletedTask;
            var id = Guid.NewGuid();
            return new Vendeur_NouvelleAnnonce_POSTResponse()
            {
                Vendeur_Annonces_Id = new Vendeur_Annonces_Id_PAGE { Id = id }
            };
        }
    }
}