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

        protected ComponentProperties Properties;

        public virtual void Start() {}

        public virtual void Tick() {}

        public Component GetSibling<TComponent>()
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
