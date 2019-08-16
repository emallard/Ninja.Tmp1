using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1.Api
{
    public class Tracer : ITracer
    {
        public async Task Trace(object obj)
        {
            await Task.CompletedTask;
        }
    }
}