using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_POST : IMessage<Vendeur_NouvelleAnnonce_POSTResponse>
    {
        public DateTime Date;
        public string Ville;
        public string Categorie;
    }

    public class Vendeur_NouvelleAnnonce_POSTResponse
    {
        public Link<Vendeur_Annonces_Id_GET> Redirect;
    }

    public class Vendeur_NouvelleAnnonce_POSTHandler : MessageHandler<Vendeur_NouvelleAnnonce_POST, Vendeur_NouvelleAnnonce_POSTResponse>
    {
        public async override Task<Vendeur_NouvelleAnnonce_POSTResponse> ExecuteAsync(Vendeur_NouvelleAnnonce_POST query)
        {
            await Task.CompletedTask;
            var id = Guid.NewGuid();
            return new Vendeur_NouvelleAnnonce_POSTResponse()
            {
                Redirect = Link.New(new Vendeur_Annonces_Id_GET()
                {
                    Id = id
                })
            };
        }
    }
}