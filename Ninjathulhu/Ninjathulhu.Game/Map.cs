using System;

namespace Ninjathulhu.Game
{
    public class MapCell
    {
        public enum CellType
        {
            EMPTY,
            FLOOR,
            WALL,
        }

        public CellType Type = CellType.EMPTY;
    }

    public class Map
    {
        public const int DefaultHeight = 20;
        public const int DefaultWidth = 80;

        public int Height
        {
            get;
            private set;
        }

        public int Width
        {
            get;
            private set;
        }

        private MapCell[] Cells;

        public MapCell Get(int x, int y)
        {
            return Cells[y * Width + x];
        }

        public void Generate(int height = DefaultHeight, int width = DefaultWidth)
        {
            if (width < 1 || height < 1)
            {
                throw new Exception("invalid map dimensions");
            }

            Width = width;
            Height = height;

            Cells = new MapCell[Width * Height];
            for (int i = 0; i < Width * Height; i++)
            {
                Cells[i] = new MapCell();
            }
        }
    }
}
