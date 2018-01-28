using System.IO;
using OpenTK.Graphics.OpenGL4;
namespace IntegralEngine
{
    public class Shader
    {
        private const string fragEnd = ".frag";
        private const string vertEnd = ".vert";

        protected string vertexShaderLocation;
        protected string fragmentShaderLocation;

        protected int ProgramID;
        
        protected Shader(string vertex, string fragment)
        {
            vertexShaderLocation = vertex;
            fragmentShaderLocation = fragment;

            ProgramID = CompileShaders();
        }

        protected int CompileShaders()
        {
            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, File.ReadAllText(@""+vertexShaderLocation+vertEnd));
            GL.CompileShader(vertexShader);

            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, File.ReadAllText(@""+fragmentShaderLocation+fragEnd));
            GL.CompileShader(fragmentShader);

            var program = GL.CreateProgram();
            GL.AttachShader(program, vertexShader);
            GL.AttachShader(program, fragmentShader);
            GL.LinkProgram(program);

            GL.DetachShader(program, vertexShader);
            GL.DetachShader(program, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
            return program;
        }
    }
}