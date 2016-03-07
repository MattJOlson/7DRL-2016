using System;
using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class EntityProperties
    {
        public Dictionary<Type, ComponentProperties> FromPrefab = new Dictionary<Type, ComponentProperties>();

        public Dictionary<Type, ComponentProperties> FromSpawn = new Dictionary<Type, ComponentProperties>();

        private static object Get(Dictionary<Type, ComponentProperties> properties, Type componentType, string propertyName)
        {
            if (properties.ContainsKey(componentType) &&
                properties[componentType].Values.ContainsKey(propertyName))
            {
                return properties[componentType].Values[propertyName];
            }

            return null;
        }

        public object Get<TComponent>(string propertyName, object defaultValue = null)
        {
            object result;

            result = Get(FromSpawn, typeof(TComponent), propertyName);
            if (result != null) { return result; }

            result = Get(FromPrefab, typeof(TComponent), propertyName);
            if (result != null) { return result; }

            return defaultValue;
        }
    }
}
