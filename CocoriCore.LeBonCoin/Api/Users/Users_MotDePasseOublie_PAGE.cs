using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Users_MotDePasseOublie_PAGE : IPage<Users_MotDePasseOublie_PAGEResponse>
    {

    }

    public class Users_MotDePasseOublie_PAGEResponse
    {
        public Form<Users_MotDePasseOublie_POST, Users_MotDePasseOublie_POSTResponse> Form = new Form<Users_MotDePasseOublie_POST, Users_MotDePasseOublie_POSTResponse>();
    }

    public class Users_MotDePasseOublie_PAGEHandler : MessageHandler<Users_MotDePasseOublie_PAGE, Users_MotDePasseOublie_PAGEResponse>
    {
        public override async Task<Users_MotDePasseOublie_PAGEResponse> ExecuteAsync(Users_MotDePasseOublie_PAGE query)
        {
            await Task.CompletedTask;
            return new Users_MotDePasseOublie_PAGEResponse();
        }
    }

}