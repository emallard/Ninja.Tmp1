using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin
{
    public interface IEmailSender
    {
        Task Send(MyMailMessage mailMessage);
    }
}