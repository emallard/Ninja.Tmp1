using System;
using System.Threading.Tasks;

namespace Ninja.Tmp1
{
    public class Emails : IEmailReader, IEmailSender
    {
        public Task<MyMailMessage> Read(string email)
        {
            throw new NotImplementedException();
        }

        public Task Send(MyMailMessage mailMessage)
        {
            throw new NotImplementedException();
        }
    }
}