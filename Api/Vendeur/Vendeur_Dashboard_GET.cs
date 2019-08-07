namespace Ninja.Tmp1
{
    public class Vendeur_Dashboard_GET : IMessage<Vendeur_Dashboard_GETResponse>
    {
    }

    public class Vendeur_Dashboard_GETResponse
    {
        public MenuUtilisateur MenuUtilisateur;
        public Link<Vendeur_Reunions_GET> Reunions;
        public Link<Vendeur_Premium_GET> Premium;
    }

    public class Vendeur_Dashboard_GETHandler : IMessageHandler<Vendeur_Dashboard_GET, Vendeur_Dashboard_GETResponse>
    {
        public Vendeur_Dashboard_GETResponse Execute(Vendeur_Dashboard_GET post)
        {
            return new Vendeur_Dashboard_GETResponse();
        }
    }
}