using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{
    public abstract class MessageHandler<TQuery, TResponse> : IHandler<TQuery, TResponse>
    {
        public async Task<object> HandleAsync(IMessage query)
        {
            return await ExecuteAsync((TQuery)query);
        }

        public abstract Task<TResponse> ExecuteAsync(TQuery query);
    }
}