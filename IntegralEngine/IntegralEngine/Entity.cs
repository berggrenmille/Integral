using System;
using System.Collections.Generic;

namespace IntegralEngine
{
    public class Entity : IMessageObserver
    {
        private readonly List<Component> m_components = new List<Component>();
        public string m_name = "Entity";

        public Entity()
        {
            //Add Transform
            //Add Renderer
           
        }
        public void AddComponent(Component comp)
        {
            comp.host = this;
            comp.InitializeComponent();
            MessageBus.Subscribe(comp);
            m_components.Add(comp);
        }

        public void RemoveComponent(Component comp)
        {
            for (int i = 0; i < m_components.Count; i++)
            {
                if(m_components[i].id == comp.id)
                    m_components.RemoveAt(i);
            }
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