using System;
using System.Threading.Tasks;

namespace Ninja.Tmp1.Api
{
    public interface IAppErrorBus
    {
        Task HandleException(Exception e);
    }
}