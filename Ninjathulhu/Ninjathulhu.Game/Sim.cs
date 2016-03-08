using System;
using System.Collections.Generic;
using System.Drawing; // for Rectangle

using Ninjathulhu.Game.World;

namespace Ninjathulhu.Game
{
    public class Sim
    {
        public Map CurrentMap;

        private Prefab PlayerPrefab;
        private Prefab CultistPrefab;

        public Sim()
        {
            DefinePrefabs();

            // TODO: some kind of "world manager" should determine the current map
            CurrentMap = new Map();
            CurrentMap.AddRoom(new Room()
                {
                    Extents = new Rectangle(3, 3, 8, 6)
                }); // test code

            // TODO: loading the current map should generate spawn calls
            Prefab.Spawn(
                PlayerPrefab,
                new ComponentSet(new Dictionary<Type, ComponentProperties>()
                {
                    { typeof(Common.Position),
                        new ComponentProperties(new Dictionary<string, object>()
                        {
                            { Common.Position.PositionXPropertyName, 10 },
                            { Common.Position.PositionYPropertyName, 12 },
                        }) },
                }));
            Prefab.Spawn(
                CultistPrefab,
                new ComponentSet(new Dictionary<Type, ComponentProperties>()
                {
                    { typeof(Common.Position),
                        new ComponentProperties(new Dictionary<string, object>()
                        {
                            { Common.Position.PositionXPropertyName, 15 },
                            { Common.Position.PositionYPropertyName, 20 },
                        }) },
                }));
        }

        private void DefinePrefabs()
        {
            PlayerPrefab = Prefab.Define(
                "player",
                new ComponentSet(new Dictionary<Type, ComponentProperties>()
                {
                    { typeof(Common.CombatStats),
                        new ComponentProperties(new Dictionary<string, object>()
                        {
                            { Common.CombatStats.HitPointsPropertyName, 20 },
                        }) },
                    { typeof(Common.Inventory), null },
                    { typeof(Common.Position), null },
                    { typeof(Player.Movement), null },
                    { typeof(Player.Player), null },
                }));

            CultistPrefab = Prefab.Define(
                "cultist",
                new ComponentSet(new Dictionary<Type, ComponentProperties>()
                {
                    { typeof(Common.CombatStats),
                        new ComponentProperties(new Dictionary<string, object>()
                        {
                            { Common.CombatStats.HitPointsPropertyName, 5 },
                        }) },
                    { typeof(Common.Position), null },
                    { typeof(Common.WanderMovement), null },
                    { typeof(Monster.Cultist), null },
                }));
        }
    }
}
