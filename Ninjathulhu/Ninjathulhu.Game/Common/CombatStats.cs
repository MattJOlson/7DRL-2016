using System;

namespace Ninjathulhu.Game.Common
{
    public class CombatStats : Component
    {
        public int HitPoints;

        public override void Start()
        {
            object hitPoints = Entity.Properties.Get<CombatStats>("hit points", 0);
            if (hitPoints != null) { HitPoints = Convert.ToInt32(hitPoints); }
        }
    }
}
