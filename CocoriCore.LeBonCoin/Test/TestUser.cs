using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin
{
    public class TestUser
    {
        private readonly TestBrowser browser;

        public TestUser(TestBrowser browser)
        {
            this.browser = browser;
        }

        public async Task<T> Display<T>(IMessage<T> message)
        {
            return await this.browser.Display(message);
        }

        /*
        public async Task<TPage> Submit<TPost, TPostResponse, TPage>(Form<TPost, TPostResponse, TPage> submit, TPost post) where TPost : IMessage<TPostResponse> where TPage : IPage
        {
            return await this.browser.Submit(submit, post);
        }*/

        public BrowserForm<TPost, TPostResponse> GetForm<TPost, TPostResponse>(Form<TPost, TPostResponse> form) where TPost : IMessage<TPostResponse>
        {
            return this.browser.GetForm(form);
        }
    }
}
