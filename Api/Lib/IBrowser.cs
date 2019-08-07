using System;

namespace Ninja.Tmp1
{
    public interface IBrowser
    {
        T Click<T>(ILink<IMessage<T>> a);

        T Display<T>(IMessage<T> message);

        // TGet Submit<TPost, TGet>(ISubmit<TPost, TGet> submit, TPost post);
        TGet Submit<TPost, TGet>(ISubmit<TPost, TGet> submit, TPost post) where TGet : new();
    }
}