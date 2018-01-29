using OpenTK.Graphics.OpenGL4;

namespace IntegralEngine
{
    public class Renderer
    {
        public void Init()
        {
            GL.ClearColor(1,0,0,1);
        
        }

        public void Render(RawModel model)
        {
            GL.BindVertexArray(model.GetVaoID());
            GL.EnableVertexAttribArray(0);
            GL.DrawArrays(PrimitiveType.Triangles,0,model.GetVertexCount());
            GL.DisableVertexAttribArray(0);
            GL.BindVertexArray(0);
        }
    }
}