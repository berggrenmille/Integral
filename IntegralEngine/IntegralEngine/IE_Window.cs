using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;

namespace IntegralEngine
{
    public sealed class IE_Window : GameWindow
    {
        public IE_System msgBus;
        public IE_Window()
            : base(1280, // width
                720, // height
                GraphicsMode.Default,
                "Integral",  // title
                GameWindowFlags.Default,
                DisplayDevice.Default,
                4, // OpenGL major version
                0, // OpenGL minor version
                GraphicsContextFlags.ForwardCompatible)
        {
            Console.WriteLine("OpenGL Version: " + GL.GetString(StringName.Version));
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnLoad(EventArgs e)
        {
            CursorVisible = true;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";

            Color4 backColor;
            backColor.A = 1.0f;
            backColor.R = 0.1f;
            backColor.G = 0.1f;
            backColor.B = 0.3f;
            GL.ClearColor(backColor);
  
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SwapBuffers();
        }

    }
}