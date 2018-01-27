using System;
using OpenTK.Input;

namespace IntegralEngine
{
    public class IntegralEngine
    {
        public IESystem[] systems = new IESystem[5];
        public IntegralEngine()
        {
   
            Window window = new Window();

            MessageBus.Subscribe(window);
            
   
            
            window.Run(0);
        }
    }
}