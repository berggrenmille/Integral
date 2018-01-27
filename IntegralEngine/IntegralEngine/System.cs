namespace IntegralEngine
{
    public class IESystem : IMessageObserver
    {
        public virtual void OnMessage(Message message)
        {
            System.Console.WriteLine("base got message");
        }
    }
}