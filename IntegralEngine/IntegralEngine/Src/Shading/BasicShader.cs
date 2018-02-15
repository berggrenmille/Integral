using System;

namespace IntegralEngine.Shading
{
    public class BasicShader : Shader
    {
        public BasicShader() : base("Src/Shading/basicVertex", "Src/Shading/basicFragment")
        {
           
        }

        protected override void BindAttributes()
        {  
            BindAttribute(0,"position");
             
        }
    }
}