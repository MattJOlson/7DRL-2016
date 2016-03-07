using MattUtils.Demands;
using Ninjathulhu.Game.Common;

namespace Ninjathulhu.Game.Player
{
    public class Movement : Component
    {
        public Position Position;

        public Sim Sim;

        public override void Start()
        {
            Position = GetSibling<Position>();
            Demand.That(Position != null).Because("Player movement controller requires position component");
        }

        public int MaxMoveLength = 1;

        public bool CanMoveTo(int x, int y)
        {
            if (Position.DistanceTo(x, y) > MaxMoveLength)
            {
                return false;
            }

            return Sim.CurrentMap.Get(x, y).CanBeOccupied();
        }
    }
}
