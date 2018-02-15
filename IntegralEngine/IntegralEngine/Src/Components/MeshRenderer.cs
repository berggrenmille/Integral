using System;
using IntegralEngine.Messaging;
using IntegralEngine.Shading;
using OpenTK.Graphics.OpenGL4;

namespace IntegralEngine
{
    public class MeshRenderer : Component
    {
        public Mesh mesh;
        public Shader shader;
        public override void InitializeComponent()
        {
            mesh = entity.GetComponent<Mesh>();
            shader = new BasicShader();
        }

        public void Render()
        {
            if (mesh == null)
            {
                Console.WriteLine("No mesh attached when trying to render entity: "+entity.name);
                mesh = entity.GetComponent<Mesh>();
                return;
            }
            GL.BindVertexArray(mesh.model.GetVaoID());
            GL.EnableVertexAttribArray(0);
            shader.Enable();
            GL.DrawElements(PrimitiveType.Triangles, mesh.model.GetVertexCount(),DrawElementsType.UnsignedInt,0);
            
            GL.DisableVertexAttribArray(0);
            GL.BindVertexArray(0);
        }

        public override void OnMessage(Message message)
        {
     
            if (message.type == MessageType.RENDER)
                Render();
        }
    }
}