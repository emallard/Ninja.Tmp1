using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Users_Inscription_PAGE : IMessage<Users_Inscription_PAGEResponse>, IQuery
    {
    }

    public class Users_Inscription_PAGEResponse
    {
        public Form<Users_Inscription_POST, Users_Inscription_POSTResponse, Vendeur_Dashboard_PAGE> Form =
            new Form<Users_Inscription_POST, Users_Inscription_POSTResponse, Vendeur_Dashboard_PAGE>(new Vendeur_Dashboard_PAGE());
    }

}