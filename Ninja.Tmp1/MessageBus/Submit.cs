using System;

namespace Ninja.Tmp1
{
    public class Submit<TPost, TPostResponse, TRedirectGet> : ISubmit
    {
        public Submit(TRedirectGet redirectMessage)
        {
            RedirectMessage = redirectMessage;
        }

        public Submit(TRedirectGet redirectMessage, Action<TPostResponse, TRedirectGet> createTRedirectGet)
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

    public interface ISubmit
    {
        Type GetPostType();
        object GetRedirectMessage();
    }
}