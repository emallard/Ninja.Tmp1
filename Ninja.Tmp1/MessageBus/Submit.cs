using System;

namespace Ninja.Tmp1
{
    public class Submit<TPost, TPostResponse, TRedirectGet>
    {
        public Submit()
        {
        }

        public Submit(Func<TPostResponse, TRedirectGet> createTRedirectGet)
        {
            CreateTRedirectGet = createTRedirectGet;
        }

        public Func<TPostResponse, TRedirectGet> CreateTRedirectGet { get; }

    }

}