using System;
using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1.Api
{
    public class AppErrorBus : IErrorBus
    {
        public Task HandleAsync(Exception exception)
        {
            throw new NotImplementedException();
        }
    }

}
