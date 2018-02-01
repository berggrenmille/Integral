using System;
using IntegralEngine.Messaging;
using IntegralEngine.Shading;
using OpenTK.Graphics.OpenGL4;

namespace IntegralEngine
{
    public class Renderer : Component
    {
        private float[] v1 =
        {
            -0.5f, 0.5f, 0,
            -0.5f, -0.5f, 0,
            0.5f, -0.5f, 0,
            0.5f, 0.5f, 0
        };

        private int[] indices =
        {
            0, 1, 3,
            3, 1, 2
        };

        private RawModel model;
        private Shader shader;
        public override void InitializeComponent()
        {
            model = RawModel.LoadToVao(v1, indices);
            shader = new BasicShader();
        }

        public void Render(RawModel model)
        {
            GL.BindVertexArray(model.GetVaoID());
            GL.EnableVertexAttribArray(0);
            shader.Enable();
            GL.DrawElements(PrimitiveType.Triangles, model.GetVertexCount(),DrawElementsType.UnsignedInt,0);
            
            GL.DisableVertexAttribArray(0);
            GL.BindVertexArray(0);
        }

        public override void OnMessage(Message message)
        {
     
            if (message.type == MessageType.RENDER)
                Render(model);
        }
    }
}