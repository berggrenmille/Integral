using System;
using System.Collections.Generic;
using System.Data;
using IntegralEngine.Messaging;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
    
namespace IntegralEngine
{
    public class Application : IMessageObserver
    {
        
        public void Init()
        {
            Entity ent = EntityFactory.CreateEntity();

        }

        public void Update()
        {
            
        }

        public void Cleanup()
        {
    
        }

        public void OnMessage(Message message)
        {
            switch (message.type)
            {
                case MessageType.INIT:
                    Init();
                    break;
                case MessageType.UPDATE:
                    Update();
                    break;
                case MessageType.CLEANUP:
                    Cleanup();
                    break;

                    
            }
        }
    }
}