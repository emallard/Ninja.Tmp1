using CocoriCore;

namespace Ninja.Tmp1
{
    public class Accueil_PAGE : IMessage<Accueil_PAGEResponse>
    {
    }

    public class Accueil_PAGEResponse
    {
        public Link<Users_Connexion_PAGE> Connexion;
    }
}