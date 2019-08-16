namespace CocoriCore
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
}