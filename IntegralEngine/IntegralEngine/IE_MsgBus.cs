using System.Collections.Generic;

namespace IntegralEngine
{
    public class IE_MsgBus : IE_System
    {
        private List<IE_System> systems = new List<IE_System>();
        public void Subscribe(IE_System sys)
        {
            
        }
        public void Unsubscribe(IE_System sys)
        { }
    }
}