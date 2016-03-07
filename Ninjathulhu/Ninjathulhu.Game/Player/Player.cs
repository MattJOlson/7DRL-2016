using System;

using Ninjathulhu.Game.Common;

namespace Ninjathulhu.Game.Player
{
    public class Player : Component
    {
        public Position Position;
        public Movement Movement;
        public CombatStats CombatStats;

        public override void Start()
        {
            Position = GetSibling<Position>();
            if (Position == null)
            {
                throw new Exception("player lacks position component");
            }

            Movement = GetSibling<Movement>();
            if (Movement == null)
            {
                throw new Exception("player lacks movement component");
            }

            CombatStats = GetSibling<CombatStats>();
            if (CombatStats == null)
            {
                throw new Exception("player lacks combat stats component");
            }
        }
    }
}
