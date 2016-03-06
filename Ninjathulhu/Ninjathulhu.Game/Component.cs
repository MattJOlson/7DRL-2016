using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rogue.src.sim
{
    class ComponentProperties
    {
        public Dictionary<string, object> Values;
    }

    class Component
    {
        protected Entity Entity;

        public bool Enabled;

        ComponentProperties Properties;

        public virtual void Start() {}

        public virtual void Update(float elapsed) {}

        public Component Get<TComponent>()
            where TComponent : Component
        {
            return Entity != null ? Entity.Components.Get<TComponent>() : null;
        }

        public bool IsSibling(Component other)
        {
            return Entity != null && Entity == other.Entity;
        }

        public virtual void HandleAttachToEntity(Entity entity)
        {
            Entity = entity;
        }

        public virtual void HandleRemoveFromEntity(Entity entity)
        {
            Entity = null;
        }
    }
}
