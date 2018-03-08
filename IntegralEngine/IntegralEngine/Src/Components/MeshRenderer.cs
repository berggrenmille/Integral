using System;
using IntegralEngine.Messaging;
using IntegralEngine.Shading;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace IntegralEngine
{
    public class MeshRenderer : Component
    {
        public TexturedMesh texturedMesh;
        public Shader shader;

        public override void InitializeComponent()
        {
            texturedMesh = entity.GetComponent<TexturedMesh>();
            shader = new BasicShader();
        }

        public void Render()
        {
            shader.Disable();
            if (texturedMesh == null)
            {
                Console.WriteLine("No texturedMesh attached when trying to render entity: "+entity.name);
                texturedMesh = entity.GetComponent<TexturedMesh>();
                return;
            }
            GL.BindVertexArray(texturedMesh.GetRawMesh().GetVaoID());
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, texturedMesh.GetTexture().GetID());

            shader.Enable();
            shader.LoadTranformMatrix(entity.transform.GetTransformMatrix());
            shader.LoadProjectionMatrix(Camera.GetCurrentCamera().GetProjectionMatrix());
            GL.DrawElements(PrimitiveType.Triangles, texturedMesh.GetRawMesh().GetVertexCount(),DrawElementsType.UnsignedInt,0);

            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            GL.BindVertexArray(0);
        }

        public override void OnMessage(Message message)
        {
     
            if (message.type == MessageType.RENDER)
                Render();
        }
    }
}