using System.Drawing;

namespace Ninjathulhu.Game.World
{
    public class Room
    {
        public Rectangle Extents;

        public Rectangle NorthWallExtents
        {
            get
            {
                return new Rectangle(
                    Extents.Left,
                    Extents.Top,
                    Extents.Width - 1,
                    1);
            }
        }

        public Rectangle SouthWallExtents
        {
            get
            {
                return new Rectangle(
                     Extents.Left,
                     Extents.Bottom - 1,
                     Extents.Width - 1,
                     1);
            }
        }

        public Rectangle EastWallExtents
        {
            get
            {
                return new Rectangle(
                    Extents.Right - 1,
                    Extents.Top,
                    1,
                    Extents.Height);
            }
        }

        public Rectangle WestWallExtents
        {
            get
            {
                return new Rectangle(
                    Extents.Left,
                    Extents.Top,
                    1,
                    Extents.Height - 1);
            }
        }

        public Rectangle InteriorExtents
        {
            get
            {
                return new Rectangle(
                    Extents.Left + 1,
                    Extents.Top + 1,
                    Extents.Width - 2,
                    Extents.Height - 2);
            }
        }
    }
}
