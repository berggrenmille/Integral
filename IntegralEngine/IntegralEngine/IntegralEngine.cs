using System;

namespace IntegralEngine
{
    public class IntegralEngine
    {
        public IE_System[] systems = new IE_System[5];
        public IntegralEngine()
        {
            IE_MsgBus msgBus = new IE_MsgBus();
            IE_Window window = new IE_Window();
            window.msgBus = msgBus;
            
            window.Run(0);
        }
    }
}