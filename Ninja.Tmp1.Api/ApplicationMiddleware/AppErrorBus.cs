using System;
using System.Threading.Tasks;

namespace Ninja.Tmp1.Api
{
    public class AppErrorBus : IAppErrorBus
    {
        public async Task HandleException(Exception e)
        {
            await Task.CompletedTask;
        }
    }

}
