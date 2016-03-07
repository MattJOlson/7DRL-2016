using System;

namespace Ninjathulhu.Game.Common
{
    // An entity with this component has a position in the game world.
    public class Position : Component
    {
        public int X = 0;
        public int Y = 0;

        // Uses rogue-distance logic, ie. Manhattan distance
        public int DistanceTo(int x, int y)
        {
            return Math.Abs(X - x) + Math.Abs(Y - y);
        }
    }
}
