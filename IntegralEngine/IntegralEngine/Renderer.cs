using System;
using OpenTK.Graphics.OpenGL4;

namespace IntegralEngine
{
    public class Renderer : Component
    {
        private float[] v1 =
        {
            -0.5f, 0.5f, 0,
            -0.5f, -0.5f, 0,
            0.5f, -0.5f, 0f,
            0.5f, -0.5f, 0,
            0.5f, 0.5f, 0,
            -0.5f, 0.5f, 0f
        };

        private RawModel model;

        public override void InitializeComponent()
        {
            model = RawModel.LoadToVao(v1);
        }

        public void Render(RawModel model)
        {
            GL.BindVertexArray(model.GetVaoID());
            GL.EnableVertexAttribArray(0);
            GL.DrawArrays(PrimitiveType.Triangles,0,model.GetVertexCount());
            GL.DisableVertexAttribArray(0);
            GL.BindVertexArray(0);
        }

        public override void OnMessage(Message message)
        {
     
            if (message.id == MessageEvent.RENDER)
                Render(model);
        }
    }
}