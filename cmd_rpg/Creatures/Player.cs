using System;
using cmd_rpg.Creatures;
using System.Drawing;

namespace cmd_rpg
{
    partial class Player : Creature
    {
        public override Gender Gender   { get; set; }
        public override string Name     { get; set; }
        public override int Health      { get; set; }
        public override int MaxHealth   { get; set; }
        public override int Stamina     { get; set; }
        public override int MaxStamina  { get; set; }
        public override int Mana        { get; set; }
        public override int MaxMana     { get; set; }
        public override Position Pos    { get; set; }
        public Classes.Class PlayerClass{ get; set; }
        public GameData GD;

        public Player(string pName, Gender pGender, Classes.Class pClass)
        {
            Name = pName;
            Gender = pGender;
            PlayerClass = pClass;
            var vBaseStats = Classes.GetBaseStats(pClass);

            Health =     vBaseStats.Health;
            MaxHealth =  vBaseStats.Health;
            Stamina =    vBaseStats.Stamina;
            MaxStamina = vBaseStats.Stamina;
            Mana =       vBaseStats.Mana;
            MaxMana =    vBaseStats.Mana;
            Pos =        new Position(0, 0);
        }

        public void Die()
        {
            Game.WriteLine("You died!");
            //Todo: Add some grim code here
        }

        public override void ModHP(int pMod)
        {
            Health += pMod;

            if (pMod > 0)
                Game.WriteLine("You gain " + pMod + "HP");
            else if (pMod < 0)
                Game.WriteLine("You lose " + pMod + "HP");

            if (Health < 10)
                Game.WriteLine("Your health is low!, do you have any potions or food?");
            else if (Health <= 0)
                Die();
        }

        public override void ModStam(int pMod)
        {
            //if(pMod > Stamina)
            //{
            //    Console.WriteLine("Not enough Stamina");
            //    return false;
            //}

            Stamina += pMod;

            if (pMod > 0)
                Game.WriteLine("You gain " + pMod + " stamina");
            else if (pMod < 0)
                Game.WriteLine("You lose " + pMod + " stamina");

            if (Stamina < 10)
                Game.WriteLine("You stamina is critically low!");
            else if (Stamina < 0)
            {
                Random vRandom = new Random();
                Game.WriteLine("You over exerted yourself and passed out!");
                Action vPassout = new Sleep(vRandom.Next(5, 8));
                PerformAction(vPassout);
            }

            
        }

        public override bool ModMana(int pMod)
        {
            if(pMod > Mana)
            {
                Game.WriteLine("Not enough mana!");
                return false;
            }

            Mana += pMod;

            if (pMod > 0)
                Game.WriteLine("You gain " + pMod + " mana");
            else if (pMod < 0)
                Game.WriteLine("You lose " + pMod + " mana");

            if (Mana < 10)
                Game.WriteLine("You mana is low!");

            return true;
        }

        public override void PerformAction(Action pAction)
        {
            pAction.Perform(GD);
        }
    }
}
