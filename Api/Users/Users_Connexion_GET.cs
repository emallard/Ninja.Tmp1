using System;
using System.Linq;

namespace Ninja.Tmp1
{

    public class Users_Connexion_GET : IMessage<Users_Connexion_GETResponse>
    {

    }

    public class Users_Connexion_GETResponse
    {
        public Link<Users_MotDePasseOublie_GET> MotDePasseOublie;
        public ISubmit<Users_Connexion_POST, Vendeur_Dashboard_GET> Submit;
    }

    public class Users_Connexion_GETHandler : IMessageHandler<Users_Connexion_GET, Users_Connexion_GETResponse>
    {
        public Users_Connexion_GETHandler()
        {
        }

        public Users_Connexion_GETResponse Execute(Users_Connexion_GET post)
        {
            var response = new Users_Connexion_GETResponse();
            response.MotDePasseOublie = Link.New(new Users_MotDePasseOublie_GET());
            response.Submit = new Submit<Users_Connexion_POST, Vendeur_Dashboard_GET>();
            return response;
        }
    }


}