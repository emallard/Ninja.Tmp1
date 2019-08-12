using System;
using System.Threading.Tasks;

namespace Ervad.Api.WebApi
{
    public interface IAppErrorBus
    {
        Task HandleException(Exception e);
    }
}