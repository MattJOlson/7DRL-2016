using System;
using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class EntityComponents
    {
        private Entity Entity;

        private Dictionary<Type, Component> Components = new Dictionary<Type, Component>();

        public EntityComponents(Entity entity)
        {
            Entity = entity;
        }

        public Component Get<TComponent>()
            where TComponent : Component
        {
            return Components[typeof(TComponent)];
        }

        public Component Get(Type componentType)
        {
            return Components[componentType];
        }

        public Component Attach<TComponent>()
            where TComponent : Component, new()
        {
            if (Components.ContainsKey(typeof(TComponent)))
            {
                return Components[typeof(TComponent)];
            }

            var newComponent = new TComponent();
            Components[typeof(TComponent)] = newComponent;
            newComponent.AttachTo(Entity);
            return newComponent;
        }

        public Component Attach(Type type)
        {
            if (Components.ContainsKey(type))
            {
                return Components[type];
            }

            Component newComponent = Activator.CreateInstance(type) as Component;
            if (newComponent == null) { return null; }
            Components[type] = newComponent;
            newComponent.AttachTo(Entity);
            return newComponent;
        }

        public bool Remove<TComponent>()
            where TComponent : Component
        {
            Component component = Components[typeof(TComponent)];
            component.RemoveFrom(Entity);
            return Components.Remove(typeof(TComponent));
        }

        public bool Remove(Type componentType)
        {
            Component component = Components[componentType];
            component.RemoveFrom(Entity);
            return Components.Remove(componentType);
        }
    }

    public class EntityProperties
    {
        public Dictionary<Type, ComponentProperties> FromPrefab = new Dictionary<Type, ComponentProperties>();

        public Dictionary<Type, ComponentProperties> FromSpawn = new Dictionary<Type, ComponentProperties>();
    }

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
}
