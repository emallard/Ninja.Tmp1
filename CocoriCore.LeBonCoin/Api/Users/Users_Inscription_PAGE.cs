using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Users_Inscription_PAGE : IMessage<Users_Inscription_PAGEResponse>, IQuery
    {
    }

    public class Users_Inscription_PAGEResponse
    {
        public Form<Users_Inscription_POST, Users_Inscription_POSTResponse> Form = new Form<Users_Inscription_POST, Users_Inscription_POSTResponse>();
    }

    public class Users_Inscription_PAGEHandler : MessageHandler<Users_Inscription_PAGE, Users_Inscription_PAGEResponse>
    {
        public override async Task<Users_Inscription_PAGEResponse> ExecuteAsync(Users_Inscription_PAGE query)
        {
            await Task.CompletedTask;
            return new Users_Inscription_PAGEResponse()
            {
            };
        }
    }

}