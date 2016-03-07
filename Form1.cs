using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theQuest
{
    enum Direction
    {
        Up,Down,Left,Right,
    }
    public partial class Form1 : Form
    {
        private Game game;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 480, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }

        public void UpdateCharacters()
        {
            Player.Location = game.PlayerLocation;
            playerHitPoint.Text = game.PlayerHitPoints.ToString();

            //Handle the enemies
            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;

            int enemiesShown = 0;
            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    bat.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghost)
                {
                    ghost.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    ghoul.Location = enemy.Location;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
            }
            if (showBat) bat.Visible = true;
            else bat.Visible = false;
            if (showGhost) ghost.Visible = true;
            else ghost.Visible = false;
            if (showGhoul) ghoul.Visible = true;
            else ghoul.Visible = false;

            //Handle the weapons(& potions)
            sword.Visible = false;
            bow.Visible = false;
            redPotion.Visible = false;
            bluePotion.Visible = false;
            mace.Visible = false;
            Control weaponControl = null;
            switch (game.WeaponInRoom.Name)
            {
                case  "Sword":
                    weaponControl = sword;
                    break;
                case "Bow":
                    weaponControl = bow;
                    break;
                case "Red Potion":
                    weaponControl = redPotion;
                    break;
                case "Blue Potion":
                    weaponControl = bluePotion;
                    break;
                case "Mace":
                    weaponControl = mace;
                    break;
                default:
                    break;
            }
            //weaponControl.Visible = true;
            UpdateInventory();

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp) weaponControl.Visible = false;
            else weaponControl.Visible = true;
            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }
            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level!");
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void moveLeft_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void moveRight_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void attackUp_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void attackLeft_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void attackRight_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void attackDown_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void inventorySword_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                //inventoryBluePotion.BorderStyle = BorderStyle.None;
                //inventoryBow.BorderStyle = BorderStyle.None;
                //inventoryMace.BorderStyle = BorderStyle.None;
                //inventoryRedPotion.BorderStyle = BorderStyle.None;
                //inventorySword.BorderStyle = BorderStyle.FixedSingle;
                UpdateInventory();
            }
        }

        private void inventoryBluePotion_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Blue Potion"))
            {
                game.Equip("Blue Potion");
                //inventoryBluePotion.BorderStyle = BorderStyle.FixedSingle;
                //inventoryBow.BorderStyle = BorderStyle.None;
                //inventoryMace.BorderStyle = BorderStyle.None;
                //inventoryRedPotion.BorderStyle = BorderStyle.None;
                //inventorySword.BorderStyle = BorderStyle.None;
                UpdateInventory();
            }
        }

        private void inventoryBow_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
                //inventoryBluePotion.BorderStyle = BorderStyle.None;
                //inventoryBow.BorderStyle = BorderStyle.FixedSingle;
                //inventoryMace.BorderStyle = BorderStyle.None;
                //inventoryRedPotion.BorderStyle = BorderStyle.None;
                //inventorySword.BorderStyle = BorderStyle.None;
                UpdateInventory();
            }
        }

        private void inventoryRedPotion_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Red Potion"))
            {
                game.Equip("Red Potion");
                //inventoryBluePotion.BorderStyle = BorderStyle.None;
                //inventoryBow.BorderStyle = BorderStyle.None;
                //inventoryMace.BorderStyle = BorderStyle.None;
                //inventoryRedPotion.BorderStyle = BorderStyle.FixedSingle;
                //inventorySword.BorderStyle = BorderStyle.None;
                UpdateInventory();
            }
        }

        private void inventoryMace_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
                //inventoryBluePotion.BorderStyle = BorderStyle.None;
                //inventoryBow.BorderStyle = BorderStyle.None;
                //inventoryMace.BorderStyle = BorderStyle.FixedSingle;
                //inventoryRedPotion.BorderStyle = BorderStyle.None;
                //inventorySword.BorderStyle = BorderStyle.None;
                UpdateInventory();
            }
        }
        private void UpdateInventory()
        {
            if (game.CheckPlayerInventory("Sword"))
            {
                inventorySword.Visible = true;
                if (game.PlayerEquippedWeapon == "Sword") inventorySword.BorderStyle = BorderStyle.FixedSingle;
                else inventorySword.BorderStyle = BorderStyle.None;
            }
            if (game.CheckPlayerInventory("Bow"))
            {
                inventoryBow.Visible = true;
                if (game.PlayerEquippedWeapon == "Bow") inventoryBow.BorderStyle = BorderStyle.FixedSingle;
                else inventoryBow.BorderStyle = BorderStyle.None;
            }
            if (game.CheckPlayerInventory("Mace"))
            {
                inventoryMace.Visible = true;
                if (game.PlayerEquippedWeapon == "Mace") inventoryMace.BorderStyle = BorderStyle.FixedSingle;
                else inventoryMace.BorderStyle = BorderStyle.None;
            }
            if (game.CheckPlayerInventory("Blue Potion"))
            {
                inventoryBluePotion.Visible = true;
                if (game.PlayerEquippedWeapon == "Blue Potion")
                {
                    inventoryBluePotion.BorderStyle = BorderStyle.FixedSingle;
                    Attack.Text = "Would you like to drink the blue potion?";
                    attackUp.Text = "Drink";
                    attackLeft.Visible = false;
                    attackRight.Visible = false;
                    attackDown.Visible = false;
                }
                else
                {
                    inventoryBluePotion.BorderStyle = BorderStyle.None;
                    Attack.Text = "Attack";
                    attackUp.Text = "Up";
                    attackLeft.Visible = true;
                    attackRight.Visible = true;
                    attackDown.Visible = true;
                }
            }
            else inventoryBluePotion.Visible = false;
            if (game.CheckPlayerInventory("Red Potion"))
            {
                inventoryRedPotion.Visible = true;
                if (game.PlayerEquippedWeapon == "Red Potion")
                {
                    inventoryRedPotion.BorderStyle = BorderStyle.FixedSingle;
                    Attack.Text = "Would you like to drink the red potion?";
                    attackUp.Text = "Drink";
                    attackLeft.Visible = false;
                    attackRight.Visible = false;
                    attackDown.Visible = false;
                }
                else
                {
                    inventoryRedPotion.BorderStyle = BorderStyle.None;
                    Attack.Text = "Attack";
                    attackUp.Text = "Up";
                    attackLeft.Visible = true;
                    attackRight.Visible = true;
                    attackDown.Visible = true;
                }
            }
            else inventoryRedPotion.Visible = false;
        }
    }
}
