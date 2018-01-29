namespace IntegralEngine
{
    public class Component : IMessageObserver
    {
        private static int numComponents = 0;
        public int id = 0;
        public Entity host;

        public Component()
        {
            id = numComponents++;
        }

        public virtual void InitializeComponent()
        {
            
        }

        public virtual void UpdateComponent()
        {
            
        }

        public virtual void OnMessage(Message message)
        {
            
        }
    }
}