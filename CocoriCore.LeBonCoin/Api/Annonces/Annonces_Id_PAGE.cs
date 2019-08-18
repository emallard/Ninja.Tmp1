using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Annonces_Id_PAGE : IPage<Annonces_Id_PAGEResponse>, IQuery
    {
        public Guid Id;
    }

    public class Annonces_Id_PAGEResponse
    {
        public string Ville;
        public string Categorie;
        public string Text;
    }

    public class Annonces_Id_PAGEHandler : MessageHandler<Annonces_Id_PAGE, Annonces_Id_PAGEResponse>
    {
        public Annonces_Id_PAGEHandler()
        {
        }

        public override async Task<Annonces_Id_PAGEResponse> ExecuteAsync(Annonces_Id_PAGE query)
        {
            await Task.CompletedTask;
            var response = new Annonces_Id_PAGEResponse();
            return response;
        }

    }


}