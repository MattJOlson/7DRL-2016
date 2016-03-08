using System;
using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class ComponentProperties
    {
        public Dictionary<string, object> Values;

        public ComponentProperties(Dictionary<string, object> values)
        {
            Values = values;
        }
    }

    public class ComponentSet
    {
        private readonly Dictionary<Type, ComponentProperties> Members;

        public ComponentSet(Dictionary<Type, ComponentProperties> members)
        {
            Members = members;
        }

        public IEnumerable<Type> Types
        {
            get
            {
                return Members.Keys;
            }
        }

        public object GetProperty(Type componentType, string propertyName)
        {
            if (!Members.ContainsKey(componentType))
            {
                return null;
            }

            var component = Members[componentType];
            if (component.Values.ContainsKey(propertyName))
            {
                return component.Values[propertyName];
            }

            return null;
        }
    }

    public class Component
    {
        protected Entity Entity;

        public bool Enabled;

        protected ComponentProperties Properties;

        public virtual void Start() {}

        public virtual void Tick() {}

        public TComponent GetSibling<TComponent>()
            where TComponent : Component
        {
            return Entity?.Components.Get<TComponent>();
        }

        public bool IsSibling(Component other)
        {
            return Entity != null && Entity == other.Entity;
        }

        public virtual void AttachTo(Entity entity)
        {
            Entity = entity;
        }

        public virtual void RemoveFrom(Entity entity)
        {
            Entity = null;
        }
    }
}
