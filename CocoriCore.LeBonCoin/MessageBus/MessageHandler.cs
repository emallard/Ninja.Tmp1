using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public abstract class MessageHandler<TQuery, TResponse> : IHandler<TQuery, TResponse> where TQuery : IMessage<TResponse>
    {
        public async Task<object> HandleAsync(IMessage query)
        {
            return await ExecuteAsync((TQuery)query);
        }

        public abstract Task<TResponse> ExecuteAsync(TQuery query);
    }
}