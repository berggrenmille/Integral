using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using Console = System.Console;

namespace IntegralEngine
{
    public sealed class Window : GameWindow, IMsgObserver
    {
        public Window()
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
            Input.UpdateInput();
            MsgBus.SendMessage(new Msg(null,MsgEvent.UPDATE));
        }
        protected override void OnRenderFrame(FrameEventArgs e)     
        {
            MsgBus.SendMessage(new Msg(null,MsgEvent.DELAYED_UPDATE));
            MsgBus.SendMessage(new Msg(null,MsgEvent.RENDER));
            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";

            Color4 backColor = new Color4(.1f, .1f, .3f, 1.0f);
            GL.ClearColor(backColor);
  
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SwapBuffers();
        }

        public void OnMsg(Msg msg)
        {
          
        }
    }
}