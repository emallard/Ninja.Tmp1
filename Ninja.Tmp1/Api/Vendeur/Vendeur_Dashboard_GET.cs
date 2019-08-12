using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Vendeur_Dashboard_GET : IMessage<Vendeur_Dashboard_GETResponse>, IQuery
    {
    }

    public class Vendeur_Dashboard_GETResponse
    {
        public MenuUtilisateur MenuUtilisateur;
        public Link<Vendeur_Reunions_GET> Reunions;
        public Link<Vendeur_Premium_GET> Premium;
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