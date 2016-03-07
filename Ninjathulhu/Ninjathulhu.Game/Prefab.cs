using System;
using System.Collections.Generic;
using System.Linq;

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
            var prefab = new Prefab(id) {
                Components = components,
                Properties = properties
            };

            return prefab;
        }

        public static Entity Spawn(Prefab prefab, Dictionary<Type, ComponentProperties> spawnProperties)
        {
            var entity = new Entity();

            var newComponents = prefab.Components.Select(t => entity.Components.Attach(t));

            foreach (var component in newComponents) component.Start();

            return entity;
        }
    }
}
