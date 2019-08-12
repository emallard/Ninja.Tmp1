using System;
using System.Threading.Tasks;

namespace Ervad.Api.WebApi
{
    public class AppErrorBus : IAppErrorBus
    {
        public async Task HandleException(Exception e)
        {
            await Task.CompletedTask;
        }
    }

}
