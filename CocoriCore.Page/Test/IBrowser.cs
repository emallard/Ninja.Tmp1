using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.Page
{
    public interface IBrowser
    {
        Task<T> Click<T>(ILink<IMessage<T>> a);

        Task<T> Display<T>(IMessage<T> message);

    }
}