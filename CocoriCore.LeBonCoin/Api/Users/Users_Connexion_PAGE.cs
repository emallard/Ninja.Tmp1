using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_Connexion_PAGE : IPage<Users_Connexion_PAGEResponse>, IQuery
    {

    }

    public class Users_Connexion_PAGEResponse
    {
        public Link<Users_MotDePasseOublie_PAGE> MotDePasseOublie;
        public Form<Users_Connexion_POST, Users_Connexion_POSTResponse, Vendeur_Dashboard_PAGE> Form;
    }

    public class Users_Connexion_GETHandler : MessageHandler<Users_Connexion_PAGE, Users_Connexion_PAGEResponse>
    {
        public Users_Connexion_GETHandler()
        {
        }

        public override async Task<Users_Connexion_PAGEResponse> ExecuteAsync(Users_Connexion_PAGE query)
        {
            await Task.CompletedTask;
            var response = new Users_Connexion_PAGEResponse();
            response.MotDePasseOublie = Link.New(new Users_MotDePasseOublie_PAGE());
            response.Form = new Form<Users_Connexion_POST, Users_Connexion_POSTResponse, Vendeur_Dashboard_PAGE>(
                new Vendeur_Dashboard_PAGE(), (rep, red) => { });
            return response;
        }

    }


}