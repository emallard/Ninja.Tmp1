using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Dashboard_GET : IMessage<Vendeur_Dashboard_GETResponse>, IQuery
    {
    }

    public class Vendeur_Dashboard_GETResponse
    {
        public string Nom;
        public string Prenom;
        public DateTime DateFinPremium;
    }

    public class Vendeur_Dashboard_GETHandler : MessageHandler<Vendeur_Dashboard_GET, Vendeur_Dashboard_GETResponse>
    {
        public override async Task<Vendeur_Dashboard_GETResponse> ExecuteAsync(Vendeur_Dashboard_GET query)
        {
            await Task.CompletedTask;
            return new Vendeur_Dashboard_GETResponse();
        }
    }
}