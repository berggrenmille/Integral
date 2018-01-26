namespace IntegralEngine
{
    public class IESystem : IMsgObserver
    {
        public virtual void OnMsg(Msg msg)
        {
            System.Console.WriteLine("base got message");
        }
    }
}