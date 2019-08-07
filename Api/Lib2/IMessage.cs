namespace Ninja.Tmp1
{
    public interface IMessage<TResponse>
    {
    }

    public interface IMessageHandler<TPost, TResponse> //where TPost : IPost<TResponse>
    {
        TResponse Execute(TPost post);
    }

    public interface IResponse<TMessage>
    {

    }
}