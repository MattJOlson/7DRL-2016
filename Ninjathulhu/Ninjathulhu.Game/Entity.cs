using System;
using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class Entity
    {
        public Entity Parent;

        public EntityComponents Components;

        public EntityProperties Properties;

        public Entity()
        {
            Components = new EntityComponents(this);
            Properties = new EntityProperties();
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
