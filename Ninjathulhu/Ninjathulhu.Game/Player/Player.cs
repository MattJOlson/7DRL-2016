using MattUtils.Demands;
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
            Demand.That(Position != null).Because("Player requires position component");

            Movement = GetSibling<Movement>();
            Demand.That(Movement != null).Because("Player requires movement component");

            CombatStats = GetSibling<CombatStats>();
            Demand.That(CombatStats != null).Because("Player requires combat stats component");
        }
    }
}
