using System;
using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{
    public interface IBrowser
    {
        Task<T> Click<T>(ILink<IMessage<T>> a);

        Task<T> Display<T>(IMessage<T> message);

        //Task<TGet> Submit<TPost, TGet>(ISubmit<TPost, TGet> submit, TPost post) where TGet : new() where TPost : IMessage;

        Task<TGet> Submit<TPost, TPostResponse, TGet>(Submit<TPost, TPostResponse, TGet> submit, TPost post) where TPost : IMessage<TPostResponse>;
    }
}