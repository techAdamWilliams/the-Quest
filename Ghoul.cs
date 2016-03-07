using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace theQuest
{
    class Ghoul: Enemy
    {
        public Ghoul(Game game, Point location, Rectangle boundaries) : base(game, location, boundaries, 10) { }

        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                int movement = random.Next(0, 99);
                Point newLocation;
                if (movement < 34)
                {
                    newLocation = base.Move((Direction)random.Next(1, 5), game.Boundaries);
                    if (newLocation == this.location) newLocation = base.Move((Direction)random.Next(1, 5), game.Boundaries);
                    location = newLocation;
                    if (NearPlayer()) game.HitPlayer(3, random);
                }
                else
                { if (NearPlayer()) game.HitPlayer(3, random); }
            }
        }
    }
}
