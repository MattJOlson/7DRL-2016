using System;
using System.Collections.Generic;

using Ninjathulhu.Game;

namespace Ninjathulhu
{
    class ConsoleMain
    {
        static Dictionary<MapCell.CellType, char> MapCharSet = new Dictionary<MapCell.CellType, char>()
        {
            { MapCell.CellType.EMPTY, '.' },
            { MapCell.CellType.FLOOR, '.' },
            { MapCell.CellType.WALL, '#' },
        };

        static void RenderMap(Game.Map currentMap)
        {
            Console.SetWindowSize(currentMap.Width + 1, currentMap.Height + 1);
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < currentMap.Height; y++)
            {
                for (int x = 0; x < currentMap.Width; x++)
                {
                    Console.Write(MapCharSet[currentMap.Get(x, y).Type]);
                }
                Console.Write("\n");
            }
        }

        static void Main()
        {
            Sim sim = new Sim();

            bool gameIsDone = false;
            while (!gameIsDone)
            {
                RenderMap(sim.CurrentMap);

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.KeyChar == 'q')
                {
                    gameIsDone = true;
                }
            }
        }
    }
}
