namespace Ninja.Tmp1
{
    public interface IMessageBus
    {
        T Execute<T>(IMessage<T> t);

        object Execute(object o);
    }
}