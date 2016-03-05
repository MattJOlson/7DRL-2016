using System;
using System.Collections.Generic;

namespace rogue.src.sim
{
    class Prefab
    {
        public string ID
        {
            get;
            private set;
        }

        public List<Type> Components;

        public Dictionary<Type, ComponentProperties> Properties;

        protected Prefab(string id)
        {
            ID = id;
        }

        static public Dictionary<string, Prefab> Definitions;

        static public void Define(string id, List<Type> components, Dictionary<Type, ComponentProperties> properties)
        {
            Prefab prefab = new Prefab(id);
            prefab.Components = components;
            prefab.Properties = properties;

            Definitions[id] = prefab;
        }

        static public Entity Spawn(string id, Dictionary<Type, ComponentProperties> spawnProperties)
        {
            Prefab prefab = Definitions[id];
            Entity entity = new Entity();

            var newComponents = new List<Component>();

            foreach (var type in prefab.Components)
            {
                Component component = entity.Components.Attach(type);
                if (component == null) { continue; }
                newComponents.Add(component);
            }

            foreach (var component in newComponents)
            {
                component.Start();
            }

            return entity;
        }
    }
}
