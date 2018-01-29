using System;
using System.Data;
using OpenTK.Graphics.OpenGL4;

namespace IntegralEngine
{
    public class Application : IMessageObserver
    {

        private RawModel model1;
        private RawModel model2;
        private Entity ent;

        public void Init()
        {
            ent = new Entity();
            ent.AddComponent(new Renderer());
        }
        public void Update()
        {
            
        }

        public void Cleanup()
        {
    
        }

        public void OnMessage(Message message)
        {
            if (message.id == MessageEvent.INIT)
                Init();
            if (message.id == MessageEvent.UPDATE)
                Update();
          //  if (message.id == MessageEvent.CLEANUP)
             //   Cleanup();
        }
    }
}