using System.Net.Mail;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin
{

    public interface IEmailReader
    {
        Task<MyMailMessage> Read(string email);
    }
}