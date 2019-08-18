using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Accueil_PAGE : IPage<Accueil_PAGEResponse>
    {
    }

    public class Accueil_PAGEResponse
    {
        public Link<Users_Connexion_PAGE> Connexion = Link.New(new Users_Connexion_PAGE());
        public Link<Users_Inscription_PAGE> Inscription = Link.New(new Users_Inscription_PAGE());
        public Form<Annonces_POST, Annonces_POSTResponse> Form;
        public Form<Villes_GET, Villes_GETResponse> RechercheVille;
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