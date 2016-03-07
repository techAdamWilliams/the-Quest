using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace theQuest
{
    class Mace : Weapon
    {
        public Mace(Game game, Point location) : base(game, location) { }
        public override string Name
        {
            get
            {
                return "Mace";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            bool hit = false;
            hit = base.DamageEnemy(direction, 20, 6, random);
            if (!hit)
            {
                switch (direction)
                {
                    case Direction.Up:
                        hit = base.DamageEnemy(Direction.Left, 20, 6, random);
                        if (!hit) hit = base.DamageEnemy(Direction.Down, 20, 6, random);
                        if (!hit) hit = base.DamageEnemy(Direction.Right, 20, 6, random);
                        break;
                    case Direction.Down:
                        hit = base.DamageEnemy(Direction.Right, 20, 6, random);
                        if (!hit) hit = base.DamageEnemy(Direction.Up, 20, 6, random);
                        if (!hit) hit = base.DamageEnemy(Direction.Left, 20, 6, random);
                        break;
                    case Direction.Left:
                        hit = base.DamageEnemy(Direction.Down, 20, 6, random);
                        if (!hit) hit = base.DamageEnemy(Direction.Right, 20, 6, random);
                        if (!hit) hit = base.DamageEnemy(Direction.Up, 20, 6, random);
                        break;
                    case Direction.Right:
                        hit = base.DamageEnemy(Direction.Up, 20, 6, random);
                        if (!hit) hit = base.DamageEnemy(Direction.Left, 20, 6, random);
                        if (!hit) hit = base.DamageEnemy(Direction.Down, 20, 6, random);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
