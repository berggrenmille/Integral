using System.Collections.Generic;

namespace IntegralEngine
{
    public static class EntityFactory
    {
        private static List<Entity> entityList = new List<Entity>(); 
        public static Entity CreateEntity()
        {
            Entity ent = new Entity();
            ent.AddComponent(new Transform());
            ent.Initialize();
            entityList.Add(ent);
            return ent;
        }

    }
}