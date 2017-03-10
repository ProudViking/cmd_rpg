using System;
using System.Drawing;

namespace cmd_rpg
{
    public enum Gender
    {
        Unknown,
        Female,
        Male
    }

    class Player
    {
        public string Name;
        public int Health;
        public int MaxHealth;
        public int Stamina;
        public int MaxStamina;
        public Point Location;
        public GameData GD;

        public Player(string pName)
        {
            Name = pName;
            Health = 100;
            MaxHealth = 100;
            Stamina = 80;
            MaxStamina = 80;
            Location = Point.Empty;
        }

        public void ModHP(int pHP)
        {
            Health += pHP;

            if (Health < 10)
                Game.WriteLine("Your health is low!, do you have any potions or food?");
            else if (Health <= 0)
                PlayerDie();

        }
        public void ModStam(int pStam)
        {
            Stamina += pStam;

            if (pStam > 0)
                Game.WriteLine("You gain " + pStam + " stamina");
            else if (pStam < 0)
                Game.WriteLine("You lose " + pStam + " stamina");

            if (Stamina < 10)
                Game.WriteLine("You stamina is critically low!");
            else if (Stamina < 0)
            {
                Random vRandom = new Random();
                Game.WriteLine("You over exerted yourself and passed out!");
                Action vPassout = new Sleep(vRandom.Next(5, 8), GD);
                vPassout.Perform();
            }
        }
        public void PlayerDie()
        {
            Game.WriteLine("You died!");
            //Todo: Add some grim code here
        }

        public void PerformAction(Action pAction)
        {

        }
    }
}
