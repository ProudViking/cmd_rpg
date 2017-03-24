using cmd_rpg.Actions;

namespace cmd_rpg.Creatures
{
    public enum Gender
    {
        Unknown,
        Female,
        Male
    }

    abstract class Creature
    {
        public abstract Gender Gender { get; set; }
        public abstract string Name { get; set; }
        public abstract int Level { get; set; }
        public abstract int Health { get; set; }
        public abstract int MaxHealth { get; set; }
        public abstract int Stamina { get; set; }
        public abstract int MaxStamina { get; set; }
        public abstract int Mana { get; set; }
        public abstract int MaxMana { get; set; }
        public abstract Position Pos { get; set; }

        public abstract void ModHP(int pMod);
        public abstract void ModStam(int pMod);
        public abstract bool ModMana(int pMod);

        public abstract void PerformAction(Action pAction);
    }
}
