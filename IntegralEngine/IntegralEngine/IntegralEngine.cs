using System;
using OpenTK.Input;

namespace IntegralEngine
{
    public class IntegralEngine
    {
       
        public IntegralEngine()
        {
            
            Window window = new Window();
            
            MessageBus.Subscribe(window);
           
            window.Run(0);
        }
    }
}