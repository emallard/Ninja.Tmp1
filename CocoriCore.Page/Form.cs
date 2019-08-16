using System;

namespace CocoriCore
{

    public class Form<TPost, TPostResponse, TRedirectGet> : IForm where TRedirectGet : IPage
    {
        public Form(TRedirectGet redirectMessage)
        {
            RedirectMessage = redirectMessage;
        }

        public Form(TRedirectGet redirectMessage, Action<TPostResponse, TRedirectGet> createTRedirectGet)
        {
            RedirectMessage = redirectMessage;
            CreateTRedirectGet = createTRedirectGet;
        }

        public Action<TPostResponse, TRedirectGet> CreateTRedirectGet { get; }
        public TRedirectGet RedirectMessage { get; }

        public Type GetPostType()
        {
            return typeof(TPost);
        }

        public object GetRedirectMessage()
        {
            return RedirectMessage;
        }
    }
}