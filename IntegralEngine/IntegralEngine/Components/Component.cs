using System.Collections.Generic;
using IntegralEngine.Messaging;

namespace IntegralEngine
{
    public class Component : IMessageObserver
    {

        public Entity entity;

        public virtual void InitializeComponent()
        {
            
        }

        public virtual void UpdateComponent()
        {
            
        }
  
        public virtual void CleanupComponent()
        {

        }


        public virtual void OnMessage(Message message)
        {
            
        }
    }
}