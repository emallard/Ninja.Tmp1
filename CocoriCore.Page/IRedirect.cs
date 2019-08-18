namespace CocoriCore
{
    public interface IRedirect<T>
    {
        ILink<T> Redirect { get; }
    }
}