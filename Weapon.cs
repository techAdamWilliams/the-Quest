using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace theQuest
{
    abstract class Weapon : Mover //code provided by the book
    {
        private bool pickedUp;
        public bool PickedUp { get { return pickedUp; } }

        public Weapon(Game game, Point location):base(game, location)
        { pickedUp = false; }

        public void PickUpWeapon() { pickedUp = true; }
        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);
        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            //MessageBox.Show("You attack the enemy");
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++)
            {
                foreach(Enemy enemy in game.Enemies) 
                {
                    if(Nearby(enemy.Location, target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                target = Move(direction, target, game.Boundaries);
            }
            return false;
        }
    }
}
