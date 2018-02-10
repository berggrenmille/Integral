using System;
using IntegralEngine.Messaging;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;

namespace IntegralEngine.TestScripts
{
    public class Move : LogicScript
    {
        private Transform transform;
        private MeshRenderer renderer;
        private int shaderHandel;
       
        protected override void Update()
        {
            if (Input.GetKeyHold(Key.D))
                transform.position.X += 1 * (float)Time.deltaTime;
            if (Input.GetKeyHold(Key.A))
                transform.position.X -= 1 * (float)Time.deltaTime;
            if (Input.GetKeyHold(Key.W))
                transform.position.Y += 1 * (float)Time.deltaTime;
            if (Input.GetKeyHold(Key.S))
                transform.position.Y -= 1 * (float)Time.deltaTime;

            Console.WriteLine(entity.GetComponent<Transform>().position.X);
            renderer.shader.LoadVector3(shaderHandel, transform.position);
            
        }

        public override void InitializeComponent()
        {

       
            transform = entity.GetComponent<Transform>();
            renderer = entity.GetComponent<MeshRenderer>();
            shaderHandel = GL.GetUniformLocation(renderer.shader.GetProgramID(), "inPosition");
        }


    }
}