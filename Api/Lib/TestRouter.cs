using System;

namespace Ninja.Tmp1
{
    public class TestRouter : IRouter
    {
        public ILink<T> CreateLink<T>(T t)
        {
            return new Link<T>(t);
        }
    }
}