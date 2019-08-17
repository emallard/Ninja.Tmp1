using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Users_MotDePasseOublie_Confirmation_PAGE : IPage<Void>
    {
    }


    public class Users_MotDePasseOublie_Confirmation_PAGEHandler : MessageHandler<Users_MotDePasseOublie_Confirmation_PAGE, Void>
    {
        public override async Task<Void> ExecuteAsync(Users_MotDePasseOublie_Confirmation_PAGE query)
        {
            await Task.CompletedTask;
            return new Void();
        }
    }
}