using System;
using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class EntityComponents
    {
        private readonly Entity _entity;

        private readonly Dictionary<Type, Component> _components = new Dictionary<Type, Component>();

        public EntityComponents(Entity entity)
        {
            _entity = entity;
        }

        public TComponent Get<TComponent>()
            where TComponent : Component
        {
            return Get(typeof (TComponent)) as TComponent;
        }

        public Component Get(Type componentType)
        {
            if(_components.ContainsKey(componentType))
                return _components[componentType];
            return null;
        }

        public Component Attach<TComponent>()
            where TComponent : Component, new()
        {
            return Attach(typeof (TComponent));
        }

        public Component Attach(Type type)
        {
            if (_components.ContainsKey(type))
            {
                return _components[type];
            }

            var newComponent = Activator.CreateInstance(type) as Component;
            if (newComponent == null) { return null; }
            _components[type] = newComponent;
            newComponent.AttachTo(_entity);
            return newComponent;
        }

        public bool Remove<TComponent>()
            where TComponent : Component
        {
            return Remove(typeof (TComponent));
        }

        public bool Remove(Type componentType)
        {
            if (!_components.ContainsKey(componentType))
                return true;

            var component = _components[componentType];
            component.RemoveFrom(_entity);
            return _components.Remove(componentType);
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
