using System;

namespace Ninja.Tmp1
{
    public class TestBrowser : IBrowser
    {
        private readonly IMessageBus messageBus;

        public TestBrowser(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }

        public T Click<T>(ILink<IMessage<T>> a)
        {
            return messageBus.Execute(a.Message);
        }

        public T Display<T>(IMessage<T> message)
        {
            return messageBus.Execute(message);
        }

        public TGet Submit<TPost, TGet>(ISubmit<TPost, TGet> submit, TPost post) where TGet : new()
        {
            var response = messageBus.Execute(post);
            return new TGet();
        }
    }
}
