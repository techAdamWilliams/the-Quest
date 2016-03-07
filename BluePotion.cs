using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace theQuest
{
    class BluePotion : Weapon, IPotion
    {
        private bool used;
        public bool Used { get { return used; } }
        public override string Name
        {
            get 
            {
                return "Blue Potion";
            }
        }

        public BluePotion(Game game, Point location):base(game, location)
        { used = false; }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(5, random);
            used = true;
        }
    }
}
