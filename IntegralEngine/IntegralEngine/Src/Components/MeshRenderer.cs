using System;
using IntegralEngine.Messaging;
using IntegralEngine.Shading;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace IntegralEngine.Components
{
    class MeshRenderer : Component
    {
        public TexturedMesh texturedMesh; //The mesh to be used
        public Shader shader; //The shader to be used

        private Matrix4 projectionMatrix = Matrix4.Identity; //Store projection matrix for optimization
        
        public override void InitializeComponent()
        {
            Camera.OnRender += OnCameraRender;
            Camera.OnChange += OnCameraChange;

            texturedMesh = entity.GetComponent<TexturedMesh>();
            shader = new BasicShader();
            UpdateProjectionMatrix();
        }

        private void UpdateProjectionMatrix()
        {
            if (Camera.GetCurrentCamera() != null)
            {
                projectionMatrix = Camera.GetCurrentCamera().GetProjectionMatrix();
            }
            else
            {
                Console.WriteLine("No active camera to retrieve projection matrix from!");

            }
        }


        public void OnCameraRender()
        {
            shader.Disable();
            if (texturedMesh == null)
            {
                Console.WriteLine("No texturedMesh attached when trying to render entity: " + entity.name);
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
            if (projectionMatrix == Matrix4.Identity)
            {
                UpdateProjectionMatrix();
                return;
            }
            shader.LoadProjectionMatrix(projectionMatrix);
            shader.LoadViewMatrix(Camera.GetCurrentCamera().GetViewMatrix());

            GL.DrawElements(PrimitiveType.Triangles, texturedMesh.GetRawMesh().GetVertexCount(), DrawElementsType.UnsignedInt, 0);

            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            GL.BindVertexArray(0);
        }

        public void OnCameraChange()
        {
             UpdateProjectionMatrix();
        }
    }
}