using System;

namespace Ninjathulhu.Game.Common
{
    public class CombatStats : Component
    {
        public static string HitPointsPropertyName = "hit points";
        public int HitPoints;

        public override void Start()
        {
            object hitPoints = Entity.Properties.Get<CombatStats>(HitPointsPropertyName, 0);
            if (hitPoints != null) { HitPoints = Convert.ToInt32(hitPoints); }
        }
    }
}
