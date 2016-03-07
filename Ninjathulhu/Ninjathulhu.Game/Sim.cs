using System;
using System.Collections.Generic;

namespace Ninjathulhu.Game
{
    public class Sim
    {
        public Map CurrentMap;

        public Sim()
        {
            DefinePrefabs();

            // TODO: some kind of "world manager" should determine the current map
            CurrentMap = new Map();
            CurrentMap.Generate();

            // TODO: loading the current map should generate spawn calls
            Prefab.Spawn(
                "player",
                new Dictionary<Type, ComponentProperties>()
                {
                    { typeof(Common.Position),
                        new ComponentProperties(new Dictionary<string, object>()
                        {
                            { "position x", 10 },
                            { "position y", 12 },
                        }) },
                });
            Prefab.Spawn(
                "cultist",
                new Dictionary<Type, ComponentProperties>()
                {
                    { typeof(Common.Position),
                        new ComponentProperties(new Dictionary<string, object>()
                        {
                            { "position x", 15 },
                            { "position y", 20 },
                        }) },
                });
        }

        private void DefinePrefabs()
        {
            Prefab.Define(
                "player",
                new List<Type>()
                {
                    typeof(Common.CombatStats),
                    typeof(Common.Inventory),
                    typeof(Common.Position),
                    typeof(Player.Movement),
                    typeof(Player.Player),
                },
                new Dictionary<Type, ComponentProperties>()
                {
                    { typeof(Common.CombatStats),
                        new ComponentProperties(new Dictionary<string, object>()
                        {
                            { "hit points", 20 },
                        }) },
                });

            Prefab.Define(
                "cultist",
                new List<Type>()
                {
                    typeof(Common.CombatStats),
                    typeof(Common.Position),
                    typeof(Common.WanderMovement),
                    typeof(Monster.Cultist),
                },
                new Dictionary<Type, ComponentProperties>()
                {
                    { typeof(Common.CombatStats),
                        new ComponentProperties(new Dictionary<string, object>()
                        {
                            { "hit points", 5 },
                        }) },
                });
        }
    }
}
