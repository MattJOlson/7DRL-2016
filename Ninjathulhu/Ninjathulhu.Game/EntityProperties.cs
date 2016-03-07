using System;
using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class EntityProperties
    {
        public readonly Dictionary<Type, ComponentProperties> FromPrefab;

        public readonly Dictionary<Type, ComponentProperties> FromSpawn;

        public EntityProperties(
            Dictionary<Type, ComponentProperties> prefabProperties,
            Dictionary<Type, ComponentProperties> spawnProperties)
        {
            FromPrefab = prefabProperties;
            FromSpawn = spawnProperties;
        }

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
