using System;

using Ninjathulhu.Game.Common;

namespace Ninjathulhu.Game.Monster
{
    public class Cultist : Monster
    {
        public WanderMovement Movement;

        public override void Start()
        {
            Movement = GetSibling<WanderMovement>();
            if (Movement == null)
            {
                throw new Exception("cultist lacks movement component");
            }
        }
    }
}
