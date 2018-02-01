using System;

namespace IntegralEngine.Shading
{
    public class BasicShader : Shader
    {
        public BasicShader() : base("Shading/basicVertex","Shading/basicFragment")
        {
           
        }

        protected override void BindAttributes()
        {  
            BindAttribute(0,"position");
             
        }
    }
}