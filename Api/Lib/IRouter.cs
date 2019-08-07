using System;

namespace Ninja.Tmp1
{
    public interface IRouter
    {
        ILink<T> CreateLink<T>(T t);
    }
}