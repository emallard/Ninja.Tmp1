using System.Net.Mail;
using System.Threading.Tasks;

namespace Ninja.Tmp1
{

    public interface IEmailReader
    {
        Task<MyMailMessage> Read(string email);
    }
}