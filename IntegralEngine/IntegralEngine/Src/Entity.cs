using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using IntegralEngine.Messaging;

namespace IntegralEngine
{
    public class Entity : IMessageObserver
    {
        public string name = "Entity";
        public Transform transform { get; private set; }

        private readonly List<Component> m_components = new List<Component>();

        public void Initialize() //Setup public references
        {
            this.transform = this.GetComponent<Transform>();

        }

        public void AddComponent(Component comp)
        {
            if (HasComponent(comp))
                return;
            comp.entity = this;
            comp.InitializeComponent();
            MessageBus.Subscribe(comp);
            m_components.Add(comp);
        }

        public void RemoveComponent(Component comp)
        {
            int index = m_components.IndexOf(comp);
            m_components[index].CleanupComponent();
            m_components.RemoveAt(index);
        }

        /// <summary>
        /// GetComponent tries to return a component. Returns null if nothing was found.
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : Component
        {
            return (from comp in m_components where comp.GetType() == typeof(T) select (T) Convert.ChangeType(comp, typeof(T))).FirstOrDefault();
        }

        /// <summary>
        /// HasComponentOfType return a bool indicating if an entity has a specific component attached;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool HasComponentOfType<T>()
        {
            return m_components.Any(comp => comp.GetType() == typeof(T));
        }
        public bool HasComponent(Component comp)
        {
            return m_components.Any(listComp => listComp.GetType() == comp.GetType());
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