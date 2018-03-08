using System;
using IntegralEngine.Messaging;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using Console = System.Console;

namespace IntegralEngine
{
    public sealed class Window : GameWindow, IMessageObserver
    {
        public static int width = 1280;
        public static int height = 720;
        public Window()
            : base(1280, // width
                720, // height
                GraphicsMode.Default,
                "Integral", // title
                GameWindowFlags.Default,
                DisplayDevice.Default,
                4, // OpenGL major version
                0, // OpenGL minor version
                GraphicsContextFlags.ForwardCompatible)
        {
            Console.WriteLine("OpenGL Version: " + GL.GetString(StringName.Version));
            Application app = new Application();
            MessageBus.Subscribe(app);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            width = Width;
            height = Height;
        }

        protected override void OnLoad(EventArgs e)
        {
            CursorVisible = true;

            MessageBus.SendMessage(new Message(MessageType.INIT));
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (Input.GetKeyUp(Key.Escape))
                MessageBus.SendMessage(new Message(MessageType.EXIT));

            Input.UpdateInput();
            Time.deltaTime = e.Time;
            Time.time += e.Time;
            MessageBus.SendMessage(new Message(MessageType.UPDATE));
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            MessageBus.SendMessage(new Message(MessageType.DELAYED_UPDATE));

            Title = $"(Vsync: {VSync = VSyncMode.Off}) FPS: {1f / e.Time:0}";
            Color4 backColor = new Color4(1f, .1f, .3f, 1.0f);
            GL.ClearColor(backColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            MessageBus.SendMessage(new Message(MessageType.RENDER));
            SwapBuffers();

        }

        public override void Exit()
        {
            MessageBus.SendMessage(new Message(MessageType.CLEANUP));
            base.Exit();
        }

        public void OnMessage(Message message)
        {
            if (message.type == MessageType.EXIT)
                Exit();

        }
    }
}