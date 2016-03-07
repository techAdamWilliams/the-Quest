﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace theQuest
{
    class Bat: Enemy
    {
        public Bat(Game game, Point location, Rectangle boundaries) : base(game, location, boundaries, 6) { }

        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                Point newLocation;
                int movement = random.Next(0, 99);
                if (movement < 50)
                {
                    newLocation = base.Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
                    if (newLocation == this.location) 
                    { newLocation = base.Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries); }
                    location = newLocation;
                    if (NearPlayer()) game.HitPlayer(2, random);
                }
                else
                {
                    newLocation = base.Move((Direction)random.Next(1,5), game.Boundaries);
                    while(newLocation == this.location) newLocation = base.Move((Direction)random.Next(1,5), game.Boundaries);
                    location = newLocation;
                    if (NearPlayer()) game.HitPlayer(2, random);
                }
            }
        }
    }
}
