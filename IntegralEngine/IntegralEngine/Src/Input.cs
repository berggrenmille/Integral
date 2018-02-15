using System;
using System.Runtime.Remoting.Messaging;
using OpenTK.Input;
namespace IntegralEngine
{
    public static class Input
    {
        private static KeyboardState keyState;
        private static KeyboardState lastKeyState;
        private static MouseState mouseState;

        public static void UpdateInput()
        {
            lastKeyState = keyState;
            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }

        public static bool GetKeyHold(Key key)
        {
            return keyState.IsKeyDown(key);
        }

        public static bool GetKeyDown(Key key)
        {
            if (keyState.IsKeyDown(key) && !lastKeyState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        public static bool GetKeyUp(Key key)
        {
            if (keyState.IsKeyUp(key) && !lastKeyState.IsKeyUp(key))
            {
                return true;
            }
            return false;
        }
    }
}