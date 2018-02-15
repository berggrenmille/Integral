using IntegralEngine.Messaging;

namespace IntegralEngine
{
    public class LogicScript : Component
    {
        public override void InitializeComponent()
        {
            Init();
        }

        public override void OnMessage(Message message)
        {
            switch (message.type)
            {
                case MessageType.EARLY_INIT:
                    EarlyInit();
                    break;
                case MessageType.UPDATE:
                    Update();
                    break;
                case MessageType.DELAYED_UPDATE:
                    DelayedUpdate();
                    break;
            }
           
        }

        protected virtual void Update()
        {
            
        }

        protected virtual void Init()
        {
            
        }

        protected virtual void EarlyInit()
        {
            
        }

        protected virtual void DelayedUpdate()
        {
            
        }
    }
}