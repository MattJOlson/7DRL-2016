﻿using System;
using System.Drawing;

namespace Ninjathulhu.Game.World
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

        public bool CanBeOccupied()
        {
            return Type == CellType.FLOOR;
        }

        public bool IsEmpty()
        {
            return Type == CellType.EMPTY;
        }
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

        private void Set(int x, int y, MapCell.CellType cellType)
        {
            Cells[y * Width + x].Type = cellType;
        }

        private void Set(Rectangle rect, MapCell.CellType cellType)
        {
            for (int y = rect.Top; y < rect.Bottom; y++)
            {
                for (int x = rect.Left; x < rect.Right; x++)
                {
                    Set(x, y, cellType);
                }
            }
        }

        public Map(int height = DefaultHeight, int width = DefaultWidth)
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

        public bool IsEmpty(int x, int y)
        {
            return Get(x, y).IsEmpty();
        }

        public bool IsEmpty(Rectangle rect)
        {
            if (rect.Left < 0 || rect.Right >= Width ||
                rect.Bottom < 0 || rect.Top >= Height)
            {
                return false;
            }

            for (int y = rect.Top; y <= rect.Bottom; y++)
            {
                for (int x = rect.Left; x <= rect.Right; x++)
                {
                    if (!IsEmpty(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void AddRoom(Room room)
        {
            if (room.Extents.Width < 1 ||
                room.Extents.Height < 1)
            {
                return;
            }

            Set(new Rectangle(
                    room.Extents.Left,
                    room.Extents.Top,
                    room.Extents.Width,
                    1),
                MapCell.CellType.WALL);

            Set(new Rectangle(
                    room.Extents.Left,
                    room.Extents.Bottom,
                    room.Extents.Width,
                    1),
                MapCell.CellType.WALL);

            Set(new Rectangle(
                    room.Extents.Left,
                    room.Extents.Top,
                    1,
                    room.Extents.Height),
                MapCell.CellType.WALL);

            Set(new Rectangle(
                    room.Extents.Right,
                    room.Extents.Top,
                    1,
                    room.Extents.Height),
                MapCell.CellType.WALL);

            Set(new Rectangle(
                    room.Extents.Left+1,
                    room.Extents.Top-1,
                    room.Extents.Width-2,
                    room.Extents.Height-2),
                MapCell.CellType.FLOOR);
        }
    }
}
