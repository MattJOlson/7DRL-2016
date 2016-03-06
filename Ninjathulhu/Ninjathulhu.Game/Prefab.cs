using System;
using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class Prefab
    {
        public string ID
        {
            get;
            private set;
        }

        public HashSet<Type> Components;

        public Dictionary<Type, ComponentProperties> Properties;

        protected Prefab(string id)
        {
            ID = id;
        }

        public static Prefab Define(string id, HashSet<Type> components, Dictionary<Type, ComponentProperties> properties)
        {
            var prefab = new Prefab(id);
            prefab.Components = components;
            prefab.Properties = properties;

            return prefab;
        }

        public static Entity Spawn(Prefab prefab, Dictionary<Type, ComponentProperties> spawnProperties)
        {
            var entity = new Entity();

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
