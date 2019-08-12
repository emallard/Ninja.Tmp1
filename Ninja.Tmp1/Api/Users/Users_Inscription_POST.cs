using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{

    public class Users_Inscription_POST : ICommand, IMessage<Users_Inscription_POSTResponse>
    {
        public string Email;
        public string Password;
        public string PasswordConfirmation;
        public string Nom;
        public string Prenom;
        public string DateNaissance;
    }

    public class Users_Inscription_POSTResponse
    {
        public string jwt;
    }

    public class Users_Inscription_POSTHandler : MessageHandler<Users_Inscription_POST, Users_Inscription_POSTResponse>
    {
        public override async Task<Users_Inscription_POSTResponse> ExecuteAsync(Users_Inscription_POST command)
        {
            await Task.CompletedTask;
            return new Users_Inscription_POSTResponse() { jwt = "jwt" };
        }
    }
}