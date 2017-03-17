using System;

namespace cmd_rpg
{
    class Classes
    {
        public enum Class
        {
            Unknown,
            Warrior,
            Ranger,
            Mage
        }
        
        public static class Warrior
        {
            public static string Description = @"Warriors are excellent allround close quarter fighters but they lack range and can't use spells.
High health and medium stamina.
Wears all types of armor";
            public static int BaseHP      = 150;  //Level 1 HP
            public static int BaseStam    = 110;  //Level 1 Stamina
            public static int BaseMana    = 0;    //Level 1 Mana Warriors can't use spells
            public static int 
        }

        public static class Ranger
        {
            public static string Description = @"Rangers are experts of nature and excellent archers.
Medium health and high stamina.
Wears Cloth and Leather armor";
            public static int BaseHP = 120;       //Level 1 HP
            public static int BaseStam = 180;     //Level 1 Stamina
            public static int BaseMana = 0;       //Level 1 Mana Warriors can't use spells
        }

        public static class Mage
        {
            public static string Description = @"Mages wield powerful spells and excell at long to mid range combat.
Low health and stamina.
Wears only Cloth armor";
            public static int BaseHP = 80;        //Level 1 HP
            public static int BaseStam = 80;      //Level 1 Stamina
            public static int BaseMana = 200;     //Level 1 Mana
        }

        public static ClassStats GetBaseStats (Class pClass)
        {
            switch(pClass)
            {
                case Class.Warrior:
                    return new ClassStats(Warrior.BaseHP, Warrior.BaseStam, Warrior.BaseMana);
                case Class.Ranger:
                    return new ClassStats(Ranger.BaseHP, Ranger.BaseStam, Ranger.BaseMana);
                case Class.Mage:
                    return new ClassStats(Mage.BaseHP, Mage.BaseStam, Mage.BaseMana);
                default:
                    throw new NotImplementedException("Unknown class, [" + pClass + "] please report to developer");
            }
        }

        public struct ClassStats
        {
            public ClassStats(int pHP, int pStam, int pMana)
            {
                Health = pHP;
                Stamina = pStam;
                Mana = pMana;
            }

            public int Health;
            public int Stamina;
            public int Mana;
        }
    }
}
