namespace CocoriCore.LeBonCoin
{
    public class MyMailMessage
    {
        public MyMailMessage(string from, string to, string subject, object body)
        {
            From = from;
            To = to;
            Subject = subject;
            Body = body;
        }

        public string From { get; }
        public string To { get; }
        public string Subject { get; }
        public object Body { get; }
    }
}