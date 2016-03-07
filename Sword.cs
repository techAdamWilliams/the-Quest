using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace theQuest
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location) : base(game, location){}

        public override string Name
        {
            get 
            {
                return "Sword";
                throw new NotImplementedException(); 
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            bool hit = false;
            hit = base.DamageEnemy(direction, 10, 3, random);
            if (!hit)
            {
                switch (direction)
                {
                    case Direction.Up:
                        hit = base.DamageEnemy(Direction.Right, 10, 3, random);
                        if (!hit) base.DamageEnemy(Direction.Left, 10, 3, random);
                        break;
                    case Direction.Down:
                        hit = base.DamageEnemy(Direction.Left, 10, 3, random);
                        if (!hit) base.DamageEnemy(Direction.Right, 10, 3, random);
                        break;
                    case Direction.Left:
                        hit = base.DamageEnemy(Direction.Up, 10, 3, random);
                        if (!hit) base.DamageEnemy(Direction.Down, 10, 3, random);
                        break;
                    case Direction.Right:
                        hit = base.DamageEnemy(Direction.Down, 10, 3, random);
                        if (!hit) base.DamageEnemy(Direction.Up, 10, 3, random);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
