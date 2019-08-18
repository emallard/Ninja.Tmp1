using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Annonces_PAGEItem
    {
        public Guid Id;
        public string Ville;
        public string Categorie;
        public string Text;
        public Link<Annonces_Id_PAGE> Lien;
    }

    public class Annonces_PAGE : IPage<Annonces_PAGEResponse>, IQuery
    {
        public string Ville;
        public string Categorie;
        public Form<Villes_GET, Villes_GETResponse> RechercheVille;
        public string[] Categories;
    }

    public class Annonces_PAGEResponse
    {
        public Annonces_PAGEItem[] Items;
        public Form<Annonces_POST, Annonces_POSTResponse> Form;
    }

    public class Annonces_PAGEHandler : MessageHandler<Annonces_PAGE, Annonces_PAGEResponse>
    {
        public Annonces_PAGEHandler()
        {
        }

        public override async Task<Annonces_PAGEResponse> ExecuteAsync(Annonces_PAGE query)
        {
            await Task.CompletedTask;
            var response = new Annonces_PAGEResponse();
            return response;
        }

    }


}