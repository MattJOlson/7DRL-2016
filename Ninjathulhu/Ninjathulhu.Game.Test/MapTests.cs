using System.Drawing;

using NUnit.Framework;
using FluentAssertions;

using Ninjathulhu.Game.World;

namespace Ninjathulhu.Game.Test
{
    [TestFixture]
    public class MapTests
    {
        [Test]
        public void a_new_map_is_empty()
        {
            var map = new Map();
            var wholeMapRect = new Rectangle(0, 0, map.Width-1, map.Height-1);

            map.IsEmpty(wholeMapRect).Should().BeTrue();
        }

        [Test]
        public void empty_map_rect_is_empty()
        {
            var map = new Map();
            var emptyMapRect = new Rectangle(0, 0, 0, 0);

            map.IsEmpty(emptyMapRect).Should().BeTrue();
        }

        [Test]
        public void invalid_map_rect_is_not_empty()
        {
            var map = new Map();
            var invalidMapRect = new Rectangle(-1, 0, 0, 0);

            map.IsEmpty(invalidMapRect).Should().BeFalse();

            invalidMapRect = new Rectangle(0, -1, 0, 0);
            map.IsEmpty(invalidMapRect).Should().BeFalse();

            invalidMapRect = new Rectangle(map.Width, 0, 0, 0);
            map.IsEmpty(invalidMapRect).Should().BeFalse();

            invalidMapRect = new Rectangle(0, map.Height, 0, 0);
            map.IsEmpty(invalidMapRect).Should().BeFalse();
        }

        [Test]
        public void map_with_room_is_not_empty()
        {
            var map = new Map();
            var room = new Room();
            var wholeMapRect = new Rectangle(0, 0, map.Width, map.Height);

            room.Extents = new Rectangle(1, 1, 10, 10);
            map.AddRoom(room);

            map.IsEmpty(wholeMapRect).Should().BeFalse();
        }

        [Test]
        public void room_has_walls_and_floor()
        {
            var map = new Map();
            var room = new Room();

            room.Extents = new Rectangle(1, 1, 10, 10);
            map.AddRoom(room);

            map.Get(1, 1).Equals(MapCell.CellType.WALL);
            map.Get(1, 10).Equals(MapCell.CellType.WALL);
            map.Get(10, 1).Equals(MapCell.CellType.WALL);
            map.Get(10, 10).Equals(MapCell.CellType.WALL);

            map.Get(2, 2).Equals(MapCell.CellType.FLOOR);
            map.Get(2, 9).Equals(MapCell.CellType.FLOOR);
            map.Get(9, 2).Equals(MapCell.CellType.FLOOR);
            map.Get(9, 9).Equals(MapCell.CellType.FLOOR);
        }
    }
}
