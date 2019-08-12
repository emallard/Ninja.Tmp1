namespace Ninja.Tmp1
{
    public class Accueil_GET : IMessage<Accueil_GETResponse>
    {
    }

    public class Accueil_GETResponse
    {
        public Link<Users_Connexion_GET> Connexion;
    }
}