using System;
using OpenTK.Input;
namespace IntegralEngine
{
    public static class Input
    {
        private static KeyboardState keyState;
        private static MouseState mouseState;

    public static void UpdateInput()
        {
            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            if (keyState.IsKeyDown(Key.Escape))
            {
                Console.WriteLine("Exit");
            }
        }
    }
}