using System;
using cmd_rpg.Creatures;
using System.Collections.Generic;
using cmd_rpg.Items;
using cmd_rpg.Actions;
using System.Diagnostics;

namespace cmd_rpg
{
    partial class Player : Creature
    {
        public override Gender Gender   { get; set; }
        public override string Name     { get; set; }
        public override int Level       { get; set; }
        public override int Health      { get; set; }
        public override int MaxHealth   { get; set; }
        public override int Stamina     { get; set; }
        public override int MaxStamina  { get; set; }
        public override int Mana        { get; set; }
        public override int MaxMana     { get; set; }
        public override Position Pos    { get; set; }
        public int MaxWeight
        {
            get
            {
                //Todo: add dynamic max weight depending on player str and buffs
                switch (PlayerClass)
                {
                    case Classes.Class.Warrior:
                        return 200;
                    case Classes.Class.Ranger:
                        return 130;
                    case Classes.Class.Mage:
                        return 80;
                    default:
                        throw new ArgumentException("MaxWeight:get{}:: invalid playerclass [" + PlayerClass + "] please report to developer");
                }
            }
        }         //Todo: make improvements to weight system
        public int Weight
        {
            get
            {
                int vWeight = 0;

                foreach(Item vItem in Inventory)
                    vWeight += vItem.Weight;

                foreach(Item vItem in Wearables)
                    vWeight += vItem.Weight;

                return vWeight;
            }
        }
        public Classes.Class PlayerClass{ get; set; }
        public List<Wearable> Wearables { get; set; }
        public List<Item> Inventory     { get; set; }
        public GameData GD;

        public Player(string pName, Gender pGender, Classes.Class pClass)
        {
            Name = pName;
            Gender = pGender;
            PlayerClass = pClass;
            var vBaseStats = Classes.GetBaseStats(pClass);

            Wearables = new List<Wearable>();
            Inventory = new List<Item>();

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

        #region Overrides

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
                Actions.Action vPassout = new Sleep(vRandom.Next(5, 8));
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

        public override void PerformAction(Actions.Action pAction)
        {
            pAction.Perform(GD);
        }

        #endregion

        public bool EquipItem(Wearable pItem)
        {
            //Check item restrictions
            if (PlayerClass != pItem.ClassReq && Level < pItem.LevelReq)
                return false;

            //Check if we already have an item equipped in the same slot as the item we are equipping
            if (Wearables.Exists(v => v.Slot == pItem.Slot))
                UnequipItem(pItem.Slot);

            //Check for Item in inventory and move it to Wearables
            if (Inventory.Exists(v => v.Equals(pItem)))
            {
                Inventory.Remove(pItem);
                Wearables.Add(pItem);
            }
            else
                Debug.Write("Attempted to equip an item which could not be found in the inventory!");

            return true;
        }

        public void UnequipItem(WearableSlot pSlot)
        {
            Wearable vItem = null;

            if (Wearables.Exists(v => v.Slot == pSlot))
            {
                vItem = Wearables.Find(v => v.Slot == pSlot);
                Wearables.Remove(vItem);
                Inventory.Add(vItem);
            }
            else
            {
                Debug.Write("Attempted to Unequip item from slot [" + pSlot + "] but found no such item!");
            }
        }

        public void ConsumeItem(Consumeable pItem)
        {
            throw new NotImplementedException("ConsumeItem() not implemented yet!");
        }
    }
}
