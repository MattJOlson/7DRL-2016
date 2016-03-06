using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class ComponentProperties
    {
        public Dictionary<string, object> Values;
    }

    public class Component
    {
        protected Entity Entity;

        public bool Enabled;

        ComponentProperties Properties;

        public virtual void Start() {}

        public virtual void Update() {}

        public Component Get<TComponent>()
            where TComponent : Component
        {
            return Entity != null ? Entity.Components.Get<TComponent>() : null;
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
