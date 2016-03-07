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
            Prefab.Spawn("player", null);
            Prefab.Spawn("cultist", null);
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
                });
        }
    }
}
