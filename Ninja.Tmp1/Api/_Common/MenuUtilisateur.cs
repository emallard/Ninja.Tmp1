using CocoriCore;

namespace Ninja.Tmp1
{
    public class MenuUtilisateur
    {
        public Link<Accueil_PAGE> Deconnexion = Link.New(new Accueil_PAGE());
        public Link<Users_Connexion_PAGE> Connexion = Link.New(new Users_Connexion_PAGE());
        public Link<Users_Inscription_PAGE> Inscription = Link.New(new Users_Inscription_PAGE());
    }
}