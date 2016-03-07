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

        public Dictionary<Type, ComponentProperties> Components;

        protected Prefab(string id)
        {
            ID = id;
        }

        public static Prefab Define(string id, Dictionary<Type, ComponentProperties> components)
        {
            var prefab = new Prefab(id);
            prefab.Components = components;
            return prefab;
        }

        public static Entity Spawn(Prefab prefab, Dictionary<Type, ComponentProperties> spawnProperties)
        {
            var entity = new Entity(prefab.Components, spawnProperties);

            var newComponents = prefab.Components.Keys.Select(t => entity.Components.Attach(t));

            foreach (var component in newComponents) component.Start();

            return entity;
        }
    }
}
