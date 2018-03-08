using System;

namespace IntegralEngine.Shading
{
    public class BasicShader : Shader
    {
        public BasicShader() : base("Res/Shaders/basicVertex", "Res/Shaders/basicFragment")
        {
           
        }

        protected override void BindAttributes()
        {  
            BindAttribute(0,"vPosition");
            BindAttribute(1, "vTextCoords");
        }

        protected override void GetUniformLocations()
        {
            base.GetUniformLocations();
        }
    }
}