using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class TestUser
    {
        private readonly IBrowser browser;

        public TestUser(IBrowser browser)
        {
            this.browser = browser;
        }

        public async Task<T> Click<T>(ILink<IMessage<T>> a)
        {
            return await this.browser.Click(a);
        }

        public async Task<T> Display<T>(IMessage<T> message)
        {
            return await this.browser.Display(message);
        }

        public async Task<TGet> Submit<TPost, TPostResponse, TGet>(Submit<TPost, TPostResponse, TGet> submit, TPost post) where TPost : IMessage<TPostResponse>
        {
            return await this.browser.Submit(submit, post);
        }
    }
    /*
    public class TestUserDisplay<TResponse>
    {
        private readonly TestUser user;
        private readonly TResponse response;

        public TestUserDisplay(TestUser user, TResponse response)
        {
            this.user = user;
            this.response = response;
        }

        public async Task<TGet> Submit<TPost, TGet>(ISubmit<TPost, TGet> submit, TPost post) where TGet : new() where TPost : IMessage
        {
            return user.Submit(submit, post);
        }
    }

    public class TestUserSubmit<T>
    {
        public TestUserSubmit()
        {

        }

        public async Task<TestUserSubmit> Display()
        {
            Click<T>(ILink < IMessage < T >> a)
        }
    }*/
}
