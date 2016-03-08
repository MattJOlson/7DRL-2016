using System.Linq;

namespace Ninjathulhu.Game
{
    public class Prefab
    {
        public string ID
        {
            get;
            private set;
        }

        public ComponentSet Components;

        protected Prefab(string id)
        {
            ID = id;
        }

        public static Prefab Define(string id, ComponentSet components)
        {
            var prefab = new Prefab(id) {
                Components = components
            };
            return prefab;
        }

        public static Entity Spawn(Prefab prefab, ComponentSet spawnProperties)
        {
            var entity = new Entity(prefab.Components, spawnProperties);

            var newComponents = prefab.Components.Types.Select(t => entity.Components.Attach(t));

            foreach (var component in newComponents) component.Start();

            return entity;
        }
    }
}
