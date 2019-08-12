namespace Ninja.Tmp1
{
    public class MenuUtilisateur
    {
        public Link<Accueil_GET> Deconnexion = Link.New(new Accueil_GET());
        public Link<Users_Connexion_GET> Connexion = Link.New(new Users_Connexion_GET());
        public Link<Users_Inscription_GET> Inscription = Link.New(new Users_Inscription_GET());
    }
}