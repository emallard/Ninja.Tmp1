using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin
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

        public async Task<TPage> Submit<TPost, TPostResponse, TPage>(Form<TPost, TPostResponse, TPage> submit, TPost post) where TPost : IMessage<TPostResponse> where TPage : IPage
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

        public async Task<TPage> Submit<TPost, TPage>(ISubmit<TPost, TPage> submit, TPost post) where TPage : new() where TPost : IMessage
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
