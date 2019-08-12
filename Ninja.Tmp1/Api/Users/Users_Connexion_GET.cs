using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{

    public class Users_Connexion_GET : IMessage<Users_Connexion_GETResponse>, IQuery
    {

    }

    public class Users_Connexion_GETResponse
    {
        public Link<Users_MotDePasseOublie_GET> MotDePasseOublie;
        public Submit<Users_Connexion_POST, Users_Connexion_POSTResponse, Vendeur_Dashboard_GET> Submit =
            new Submit<Users_Connexion_POST, Users_Connexion_POSTResponse, Vendeur_Dashboard_GET>(new Vendeur_Dashboard_GET(), (rep, red) => { });
    }

    public class Users_Connexion_GETHandler : MessageHandler<Users_Connexion_GET, Users_Connexion_GETResponse>
    {
        public Users_Connexion_GETHandler()
        {
        }

        public override async Task<Users_Connexion_GETResponse> ExecuteAsync(Users_Connexion_GET query)
        {
            await Task.CompletedTask;
            var response = new Users_Connexion_GETResponse();
            response.MotDePasseOublie = Link.New(new Users_MotDePasseOublie_GET());
            response.Submit = new Submit<Users_Connexion_POST, Users_Connexion_POSTResponse, Vendeur_Dashboard_GET>(new Vendeur_Dashboard_GET());
            return response;
        }

    }


}