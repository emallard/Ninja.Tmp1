using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_MotDePasseOublie_POST : IMessage<Users_MotDePasseOublie_POSTResponse>, ICommand
    {
        public string Email;
    }

    public class Users_MotDePasseOublie_POSTResponse
    {
        public ILink<Users_MotDePasseOublie_Confirmation_PAGE> Redirect = Link.New(new Users_MotDePasseOublie_Confirmation_PAGE());
    }

    public class Users_MotDePasseOublie_POSTHandler : MessageHandler<Users_MotDePasseOublie_POST, Users_MotDePasseOublie_POSTResponse>
    {
        public async override Task<Users_MotDePasseOublie_POSTResponse> ExecuteAsync(Users_MotDePasseOublie_POST query)
        {
            await Task.CompletedTask;
            return new Users_MotDePasseOublie_POSTResponse();
        }
    }
}