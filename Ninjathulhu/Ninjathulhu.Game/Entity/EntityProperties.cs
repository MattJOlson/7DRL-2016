using System;
using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class EntityProperties
    {
        public readonly ComponentSet FromPrefab;
        public readonly ComponentSet FromSpawn;

        public EntityProperties(ComponentSet prefabProperties, ComponentSet spawnProperties)
        {
            FromPrefab = prefabProperties;
            FromSpawn = spawnProperties;
        }

        public object Get<TComponent>(string propertyName, object defaultValue = null)
        {
            object result;

            result = FromSpawn.GetProperty(typeof(TComponent), propertyName);
            if (result != null) { return result; }

            result = FromPrefab.GetProperty(typeof(TComponent), propertyName);
            if (result != null) { return result; }

            return defaultValue;
        }
    }
}
