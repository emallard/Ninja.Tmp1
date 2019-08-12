using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Users_Inscription_GET : IMessage<Users_Inscription_GETResponse>, IQuery
    {
    }

    public class Users_Inscription_GETResponse
    {
        public Submit<Users_Inscription_POST, Users_Inscription_POSTResponse, Vendeur_Dashboard_GET> Submit =
            new Submit<Users_Inscription_POST, Users_Inscription_POSTResponse, Vendeur_Dashboard_GET>(new Vendeur_Dashboard_GET());
    }

}