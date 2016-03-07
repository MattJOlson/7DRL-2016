using System;

namespace Ninjathulhu.Game.Common
{
    // An entity with this component has a position in the game world.
    public class Position : Component
    {
        public static string PositionXPropertyName = "position x";
        public static string PositionYPropertyName = "position y";
        public int X = 0;
        public int Y = 0;

        // Uses rogue-distance logic, ie. Manhattan distance
        public int DistanceTo(int x, int y)
        {
            return Math.Abs(X - x) + Math.Abs(Y - y);
        }

        public override void Start()
        {
            object x = Entity.Properties.Get<Position>(PositionXPropertyName, 0);
            if (x != null) { X = Convert.ToInt32(x);  }

            object y = Entity.Properties.Get<Position>(PositionYPropertyName, 0);
            if (y != null) { Y = Convert.ToInt32(y); }
        }
    }
}
