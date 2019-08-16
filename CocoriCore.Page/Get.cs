namespace CocoriCore
{
    public interface IGet
    {
        object GetMessage { get; }
    }

    public class Get
    {
        public static Get<TGetResponse> New<TGetResponse>(IMessage<TGetResponse> message)
        {
            return new Get<TGetResponse>(message);
        }
    }

    public class Get<TGetResponse> : IGet
    {
        public Get(IMessage<TGetResponse> message)
        {
            Message = message;
        }

        public object GetMessage => Message;

        public IMessage<TGetResponse> Message { get; }
    }
}