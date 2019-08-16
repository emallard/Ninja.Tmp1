using System;
using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{
    public interface IBrowser
    {
        Task<T> Click<T>(ILink<IMessage<T>> a);

        Task<T> Display<T>(IMessage<T> message);

        Task<TPage> Submit<TPost, TPostResponse, TPage>(Form<TPost, TPostResponse, TPage> form, TPost post) where TPost : IMessage<TPostResponse> where TPage : IPage;
    }
}