using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace theQuest
{
    class Player: Mover // Some of this class is provided by the book
    {
        private Weapon equippedWeapon;
        private int hitPoints;
        public int HitPoints { get { return hitPoints; } }
        public string EquippedWeapon { get { return equippedWeapon.Name; } }

        public List<Weapon> inventory = new List<Weapon>();
        
        public List<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                {
                    names.Add(weapon.Name);
                }
                return names;
            }
        }

        public Player(Game game, Point location, Rectangle boundaries)  : base(game, location)
        {
            hitPoints = 10;
        }

        public void Hit(int maxDamage, Random random)
        { hitPoints -= random.Next(1, maxDamage); }

        public void IncreaseHealth(int health, Random random)
        { hitPoints += random.Next(1, health); }

        public void Equip(string weaponName)
        {
            foreach(Weapon weapon in inventory)
            {
                if (weaponName == weapon.Name) equippedWeapon = weapon;
            }
        }

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            { //The rest of this code I wrote in this method
                if(this.Nearby(game.WeaponInRoom.Location, 10))
                {
                    this.inventory.Add(game.WeaponInRoom);
                    game.WeaponInRoom.PickUpWeapon();
                    if (this.inventory.Count == 1) this.Equip(game.WeaponInRoom.Name);
                }
            }
        }

        public void Attack(Direction direction, Random random)
        { //The rest of this code I wrote in this method
            if(inventory.Count > 0)
            {
                equippedWeapon.Attack(direction, random);
                //if(equippedWeapon is Sword) (equippedWeapon as Sword).Attack(direction, random);
                //else if (equippedWeapon is Bow) (equippedWeapon as Bow).Attack(direction, random);
                //else if (equippedWeapon is Mace) (equippedWeapon as Mace).Attack(direction, random);
                if (equippedWeapon is IPotion) 
                {
                    //if (equippedWeapon is BluePotion) (equippedWeapon as BluePotion).Attack(direction, random);
                    //else (equippedWeapon as RedPotion).Attack(direction, random);
                    inventory.Remove(equippedWeapon);
                }
            }
        }
    }
}
