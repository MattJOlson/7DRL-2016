using System.Drawing;

namespace Ninjathulhu.Game.World
{
    public enum CorridorOrientation
    {
        HORIZONTAL,
        VERTICAL,
    }

    public class Corridor
    {
        public Point Start;
        public int Length;
        public CorridorOrientation Orientation;
    }
}
