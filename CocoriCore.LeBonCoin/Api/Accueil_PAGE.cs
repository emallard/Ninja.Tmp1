using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Accueil_PAGE : IPage<Accueil_PAGEResponse>
    {
    }

    public class Accueil_PAGEResponse
    {
        public Users_Connexion_PAGE Connexion = new Users_Connexion_PAGE();
        public Users_Inscription_PAGE Inscription = new Users_Inscription_PAGE();
        public Form<Annonces_POST, Annonces_POSTResponse> Form = new Form<Annonces_POST, Annonces_POSTResponse>();
        public Form<Villes_GET, Villes_GETResponse> RechercheVille = new Form<Villes_GET, Villes_GETResponse>();
        public string[] Categories;
    }

    public class Accueil_PAGEHandler : MessageHandler<Accueil_PAGE, Accueil_PAGEResponse>
    {
        public async override Task<Accueil_PAGEResponse> ExecuteAsync(Accueil_PAGE query)
        {
            await Task.CompletedTask;
            return new Accueil_PAGEResponse();
        }
    }
}