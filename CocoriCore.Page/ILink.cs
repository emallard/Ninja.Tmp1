namespace CocoriCore
{
    public interface ILink
    {
        object GetMessage { get; }
    }
}
namespace CocoriCore
{
    public interface ILink<out T> : ILink
    {
        T Message { get; }
    }
}