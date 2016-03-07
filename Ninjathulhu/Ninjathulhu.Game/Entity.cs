using System;
using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class Entity
    {
        public Entity Parent;

        public readonly EntityComponents Components;

        public readonly EntityProperties Properties;

        public Entity(
            Dictionary<Type, ComponentProperties> prefabProperties,
            Dictionary<Type, ComponentProperties> spawnProperties)
        {
            Components = new EntityComponents(this);
            Properties = new EntityProperties(prefabProperties, spawnProperties);
        }
    }

    internal static class TypeExtensions
    {
        public static Component MaybeComponent(this Type type)
        {
            return Activator.CreateInstance(type) as Component;
        }
    }
}
