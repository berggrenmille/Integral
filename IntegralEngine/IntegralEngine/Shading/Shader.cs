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
            programID = GL.CreateProgram();

            int vertexShader;
            LoadShader(vertexShaderLocation, ShaderType.VertexShader, programID, out vertexShader);

            int fragmentShader;
            LoadShader(fragmentShaderLocation, ShaderType.FragmentShader, programID, out fragmentShader);

            GL.LinkProgram(programID);
            int status;
            GL.GetProgram(programID, GetProgramParameterName.LinkStatus, out status);
            if (status == 0)
                throw new GraphicsException(String.Format("Error linking program: {0}", GL.GetProgramInfoLog(programID)));
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

        void LoadInt(int location, int value)
        {
            GL.Uniform1(location, value);
        }

        void LoadFloat(int location, float value)
        {
            GL.Uniform1(location, value);
        }

        void LoadVector2(int location, Vector2 vect)
        {
            GL.Uniform2(location, vect);
        }

        public void LoadVector3(int location, Vector3 vect)
        {
            GL.Uniform3(location, vect);
        }

        void LoadVector4(int location, Vector4 vect)
        {
            GL.Uniform4(location, vect);
        }

        void LoadMatrix4(int location,ref Matrix4 matrix)
        {
            GL.UniformMatrix4(location, false, ref matrix);
        }
        
        
        void LoadShader(String filepath, ShaderType type, int program, out int address)
        {
            filepath= @"" + filepath;
            address = GL.CreateShader(type);
            string end;
            if (type == ShaderType.VertexShader)
                end = vertEnd;
            else
            {
                end = fragEnd;
            }

            using (StreamReader sr = new StreamReader(filepath+end))
            {
                GL.ShaderSource(address, sr.ReadToEnd());
            }
            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Console.WriteLine(GL.GetShaderInfoLog(address));
        }

        public int GetProgramID()
        {
            return programID;
        }
    }
}