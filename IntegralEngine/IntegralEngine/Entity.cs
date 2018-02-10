using System;
using System.Collections.Generic;
using IntegralEngine.Messaging;

namespace IntegralEngine
{
    public class Entity : IMessageObserver
    {
        public string name = "Entity";
        public Transform transform { get; private set; }

        private readonly List<Component> m_components = new List<Component>();

        public void AddComponent(Component comp)
        {
            comp.entity = this;
            comp.InitializeComponent();
            MessageBus.Subscribe(comp);
            m_components.Add(comp);
        }

        public void RemoveComponent(Component comp)
        {
            int index = m_components.IndexOf(comp);
            m_components[index].Cleanup();
            m_components.RemoveAt(index);
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
                    return true;
                }
            }
            return false;
        }

        public void Cleanup()
        {
            for(int i = 0; i<m_components.Count; i++)
                RemoveComponent(m_components[0]);
        }
        public void OnMessage(Message message)
        {
          
        }
    }
}