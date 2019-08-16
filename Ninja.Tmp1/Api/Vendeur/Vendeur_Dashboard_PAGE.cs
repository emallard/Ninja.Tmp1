using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Vendeur_Dashboard_PAGE : IPage<Vendeur_Dashboard_PAGEResponse>, IQuery
    {
    }

    public class Vendeur_Dashboard_PAGEResponse
    {
        public Get<Vendeur_Dashboard_GETResponse> Data = Get.New(new Vendeur_Dashboard_GET());
        public MenuUtilisateur MenuUtilisateur;
        public Link<Vendeur_Reunions_GET> Reunions;
        public Link<Vendeur_Premium_GET> Premium;
    }

    public class Vendeur_Dashboard_PAGEHandler : MessageHandler<Vendeur_Dashboard_PAGE, Vendeur_Dashboard_PAGEResponse>
    {
        public override async Task<Vendeur_Dashboard_PAGEResponse> ExecuteAsync(Vendeur_Dashboard_PAGE query)
        {
            await Task.CompletedTask;
            return new Vendeur_Dashboard_PAGEResponse();
        }
    }
}