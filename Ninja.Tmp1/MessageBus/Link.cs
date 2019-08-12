namespace Ninja.Tmp1
{

    public class Link
    {
        public static Link<U> New<U>(U u)
        {
            return new Link<U>(u);
        }
    }

    public class Link<T> : ILink<T>
    {
        public Link(T t)
        {
            Message = t;
        }

        public T Message { get; set; }
        public object GetMessage => Message;
    }

    public interface ILink<out T> : ILink
    {
        T Message { get; }
    }

    public interface ILink
    {
        object GetMessage { get; }
    }
}