using System;
using System.Collections.Generic;

namespace IntegralEngine
{
    public class GameObject : IMessageObserver
    {
        private List<Component> m_components = new List<Component>();
        public string m_name = "GameObject";

        public void AddComponent(Component comp)
        {
            m_components.Add(comp);
        }

        public bool HasComponent()
        {
            return false;
        }

        public void OnMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}