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

        public async Task<TGet> Submit<TPost, TPostResponse, TGet>(Form<TPost, TPostResponse, TGet> form, TPost post) where TPost : IMessage<TPostResponse> where TGet : IPage
        {
            var response = await this.ExecuteAsync(post);
            var redirect = form.RedirectMessage;
            form.FillRedirect(response, redirect);
            return redirect;
        }

        private async Task<T> ExecuteAsync<T>(IMessage<T> message)
        {
            return (T)(await this.ExecuteAsync((IMessage)message));
        }

        private async Task<object> ExecuteAsync(IMessage message)
        {
            using (var unitOfWork = unitOfWorkFactory.NewUnitOfWork())
            {
                var messagebus = unitOfWork.Resolve<IMessageBus>();
                var response = await messagebus.ExecuteAsync(message);
                return response;
            }
        }
    }
}
