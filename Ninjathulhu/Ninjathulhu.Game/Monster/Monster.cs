using System;

using Ninjathulhu.Game.Common;

namespace Ninjathulhu.Game.Monster
{
    public abstract class Monster : Component
    {
        public Position Position;
        public CombatStats CombatStats;

        public override void Start()
        {
            Position = GetSibling<Position>();
            if (Position == null)
            {
                throw new Exception("monster lacks position component");
            }

            CombatStats = GetSibling<CombatStats>() as CombatStats;
            if (CombatStats == null)
            {
                throw new Exception("monster lacks combat stats component");
            }
        }
    }
}
