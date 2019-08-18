using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.Page
{

    public class TestBrowser : IBrowser
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public TestBrowser(
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<T> Click<T>(ILink<IMessage<T>> a)
        {
            return await this.ExecuteAsync(a.Message);
        }

        public async Task<T> Display<T>(IMessage<T> message)
        {
            return await this.ExecuteAsync(message);
        }

        public async Task<T> ExecuteAsync<T>(IMessage<T> message)
        {
            return (T)(await this.ExecuteAsync((IMessage)message));
        }

        public async Task<object> ExecuteAsync(IMessage message)
        {
            using (var unitOfWork = unitOfWorkFactory.NewUnitOfWork())
            {
                var messagebus = unitOfWork.Resolve<IMessageBus>();
                var response = await messagebus.ExecuteAsync(message);
                return response;
            }
        }

        public BrowserForm<TPost, TPostResponse> GetForm<TPost, TPostResponse>(Form<TPost, TPostResponse> form) where TPost : IMessage<TPostResponse>
        {
            return new BrowserForm<TPost, TPostResponse>(this, form);
        }
    }

    public class BrowserForm<TPost, TPostResponse> where TPost : IMessage<TPostResponse>
    {
        public readonly TestBrowser testBrowser;
        private readonly Form<TPost, TPostResponse> form;

        public BrowserForm(TestBrowser testBrowser, Form<TPost, TPostResponse> form)
        {
            this.testBrowser = testBrowser;
            this.form = form;
        }

        public async Task<TPostResponse> Submit(TPost post)
        {
            return await this.testBrowser.ExecuteAsync(post);
        }

        public async Task<T> Follow<T>(TPost post, Func<TPostResponse, ILink<IMessage<T>>> getLink)
        {
            var postResponse = await this.testBrowser.ExecuteAsync(post);
            var link = getLink(postResponse);
            return await testBrowser.ExecuteAsync(link.Message);
        }
    }
}
