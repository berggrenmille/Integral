namespace IntegralEngine.Messaging
{
    public interface IMessageObserver
    {
        void OnMessage(Message message);
    }
}