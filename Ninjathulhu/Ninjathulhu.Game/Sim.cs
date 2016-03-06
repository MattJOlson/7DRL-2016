
namespace Ninjathulhu.Game
{
    public class Sim
    {
        public Map CurrentMap;

        public Sim()
        {
            CurrentMap = new Map();
            CurrentMap.Generate();
        }
    }
}
