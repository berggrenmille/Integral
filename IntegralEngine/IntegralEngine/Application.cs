using System;
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
            if(Input.GetKeyDown(Key.A))
                Console.WriteLine("test 1");
            if(Input.GetKeyUp(Key.D))
                Console.WriteLine("test");
        }

        public void Cleanup()
        {
    
        }

        public void OnMessage(Message message)
        {
            switch (message.type)
            {
                    
            }
            if (message.type == MessageType.INIT)
                Init();
            if (message.type == MessageType.UPDATE)
                Update();
            if (message.type == MessageType.CLEANUP)
                Cleanup();
        }
    }
}