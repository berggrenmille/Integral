using System.Data;
using OpenTK.Graphics.OpenGL4;

namespace IntegralEngine
{
    public class Application : IMessageObserver
    {
        private Renderer renderer;

        private float[] v1 =
        {
            -0.5f, 0.5f, 0,
            -0.5f, -0.5f, 0,
            0.5f, -0.5f, 0f,
        };
        private float[] v2 =
        {
            0.5f, -0.5f, 0,
            0.5f, 0.5f, 0,
            -0.5f, 0.5f, 0f
        };

        private RawModel model1;
        private RawModel model2;

        public void Init()
        {
            GL.DeleteBuffer(0);
            GL.DeleteBuffer(1);
            GL.DeleteVertexArray(0);
            GL.DeleteVertexArray(1);
            renderer = new Renderer();
            model1 = RawModel.LoadToVao(v1);
            model2 = RawModel.LoadToVao(v2);
        }
        public void Update()
        {
            
        }

        public void Render()
        {
            renderer.Render(model1);
            renderer.Render(model2);
        }

        public void Cleanup()
        {
    
        }

        public void OnMessage(Message message)
        {
            if (message.id == MessageEvent.INIT)
                Init();
          //  if (message.id == MessageEvent.UPDATE)
              //  Update();
            if (message.id == MessageEvent.RENDER)
               Render();
          //  if (message.id == MessageEvent.CLEANUP)
             //   Cleanup();
        }
    }
}