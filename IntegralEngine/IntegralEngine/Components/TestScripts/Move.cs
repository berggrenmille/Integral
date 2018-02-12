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
        private int shaderPosHandle;
        private int shaderScaleHandle;

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

            if (Input.GetKeyDown(Key.Up))
                transform.scale *= 1.1f;
            if (Input.GetKeyDown(Key.Down))
                transform.scale *= 0.9f;

            renderer.shader.LoadVector3(shaderScaleHandle, transform.scale);
            renderer.shader.LoadVector3(shaderPosHandle, transform.position);
            
        }

        public override void InitializeComponent()
        {
            transform = entity.GetComponent<Transform>();
            renderer = entity.GetComponent<MeshRenderer>();
            shaderPosHandle = GL.GetUniformLocation(renderer.shader.GetProgramID(), "inPosition");
            shaderScaleHandle = GL.GetUniformLocation(renderer.shader.GetProgramID(), "inScale");
        }


    }
}