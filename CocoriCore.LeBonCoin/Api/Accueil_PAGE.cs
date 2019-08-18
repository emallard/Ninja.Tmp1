using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Accueil_PAGE : IMessage<Accueil_PAGEResponse>
    {
    }

    public class Accueil_PAGEResponse
    {
        public Link<Users_Connexion_PAGE> Connexion = Link.New(new Users_Connexion_PAGE());
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