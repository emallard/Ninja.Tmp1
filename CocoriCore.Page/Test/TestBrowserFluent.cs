using System;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin
{
    public class TestBrowserFluent<TPage>
    {
        private readonly TestBrowser browser;
        public readonly TPage Page;

        public TestBrowserFluent(TestBrowser browser, TPage current)
        {
            this.browser = browser;
            Page = current;
        }

        public TestBrowserFluent<T> Display<T>(Func<TPage, IMessage<T>> a)
        {
            var nextPage = this.browser.Display(a(Page)).Result;
            return new TestBrowserFluent<T>(browser, nextPage);
        }

        public TestBrowserFluent<T> Display<T>(IMessage<T> message)
        {
            var nextPage = this.browser.Display(message).Result;
            return new TestBrowserFluent<T>(browser, nextPage);
        }

        public TestBrowserFluentForm<TPost, TPostResponse> GetForm<TPost, TPostResponse>(
            Func<TPage, Form<TPost, TPostResponse>> form)
            where TPost : IMessage<TPostResponse>
        {
            return new TestBrowserFluentForm<TPost, TPostResponse>(this.browser.GetForm(form(Page)));
        }
    }

    public class TestBrowserFluentForm<TPost, TPostResponse> where TPost : IMessage<TPostResponse>
    {
        private readonly BrowserForm<TPost, TPostResponse> browserForm;

        public TestBrowserFluentForm(BrowserForm<TPost, TPostResponse> browserForm)
        {
            this.browserForm = browserForm;
        }

        public TestBrowserFluentSubmitted<TPost, TPostResponse> Submit(TPost post)
        {
            var postResponse = this.browserForm.Submit(post).Result;
            return new TestBrowserFluentSubmitted<TPost, TPostResponse>(this.browserForm, postResponse);
        }

        /*
                public TestBrowserFluent<T> Follow<T>(TPost post, Func<TPostResponse, IMessage<T>> getMessage)
                {
                    var page = this.browserForm.Follow(post, getMessage).Result;
                    return new TestBrowserFluent<T>(this.browserForm.testBrowser, page);
                }
        */
    }

    public class TestBrowserFluentSubmitted<TPost, TPostResponse> where TPost : IMessage<TPostResponse>
    {
        private readonly BrowserForm<TPost, TPostResponse> browserForm;
        private readonly TPostResponse postResponse;

        public TestBrowserFluentSubmitted(
            BrowserForm<TPost, TPostResponse> browserForm,
            TPostResponse postResponse)
        {
            this.browserForm = browserForm;
            this.postResponse = postResponse;
        }
        public TestBrowserFluent<T> Redirect<T>(Func<TPostResponse, IMessage<T>> getMessage)
        {
            var page = browserForm.testBrowser.ExecuteAsync(getMessage(postResponse)).Result;
            return new TestBrowserFluent<T>(this.browserForm.testBrowser, page);
        }

    }
}
