using System;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
namespace IntegralEngine.Shading
{
    public class Shader
    {
        private const string fragEnd = ".frag";
        private const string vertEnd = ".vert";

        protected string vertexShaderLocation;
        protected string fragmentShaderLocation;

        protected int programID;
        
        protected Shader(string vertex, string fragment)
        {
            vertexShaderLocation = vertex;
           
            fragmentShaderLocation = fragment;

            CompileShaders();
            BindAttributes();
        }

        public void Enable()
        {
            GL.UseProgram(programID);
        }
        public void Disable()
        {
            GL.UseProgram(0);
        }

        protected void CompileShaders()
        {
            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, File.ReadAllText(@""+vertexShaderLocation+vertEnd));
            GL.CompileShader(vertexShader);
            int vertStatus;
            GL.GetShader(programID, ShaderParameter.CompileStatus, out vertStatus);
            if (vertStatus == 0)
            {
                Console.WriteLine(
                GL.GetShaderInfoLog(programID));
                throw new GraphicsException(
                    String.Format("Error compiling {0} shader: {1}", "vertex", GL.GetShaderInfoLog(programID)));
                
            }


            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, File.ReadAllText(@""+fragmentShaderLocation+fragEnd));
            GL.CompileShader(fragmentShader);
            int fragStatus;
            GL.GetShader(programID, ShaderParameter.CompileStatus, out fragStatus);
            if (fragStatus == 0)
                throw new GraphicsException(
                    String.Format("Error compiling {0} shader: {1}", "fragment", GL.GetShaderInfoLog(programID)));


            programID = GL.CreateProgram();
            GL.AttachShader(programID,vertexShader);
            GL.AttachShader(programID, fragmentShader);
            GL.LinkProgram(programID);
            int status;
       
            GL.GetProgram(programID, GetProgramParameterName.LinkStatus, out status);
            if (status == 0)
                throw new GraphicsException(
                    String.Format("Error linking program: {0}", GL.GetProgramInfoLog(programID)));
            GL.DetachShader(programID,vertexShader);
            GL.DetachShader(programID, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
          
            Enable();
        }

        protected virtual void BindAttributes()
        {
           
        }

        protected void BindAttribute(int slot, string name)
        {
            GL.BindAttribLocation(programID,slot,name);
            Console.WriteLine(programID);
        }
    }
}