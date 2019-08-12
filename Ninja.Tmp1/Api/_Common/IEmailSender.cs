using System.Threading.Tasks;

namespace Ninja.Tmp1
{
    public interface IEmailSender
    {
        Task Send(MyMailMessage mailMessage);
    }
}