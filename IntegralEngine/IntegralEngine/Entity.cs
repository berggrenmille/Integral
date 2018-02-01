using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using IntegralEngine.Messaging;

namespace IntegralEngine
{
    public class Entity : IMessageObserver
    {
        private readonly List<Component> m_components = new List<Component>();
        public string m_name = "Entity";
        public void AddComponent(Component comp)
        {
            comp.entity = this;
            comp.InitializeComponent();
            MessageBus.Subscribe(comp);
            m_components.Add(comp);
        }

        public void RemoveComponent(Component comp)
        {
            m_components.Remove(comp);
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (var comp in m_components)
            {
                if (comp.GetType() == typeof(T))
                {
                    return (T)Convert.ChangeType(comp, typeof(T));
                }
            }
            return null;
        }


        public bool HasComponentOfType<T>()
        {
            foreach (var comp in m_components)
            {
                if (comp.GetType() == typeof(T))
                {
                    comp.Cleanup();
                    m_components.Remove(comp);
                }
            }
            return false;
        }

        public void OnMessage(Message message)
        {
          
        }
    }
}