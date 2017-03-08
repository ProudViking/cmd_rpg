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
        public int Stamina;
        public Point Location;

        public Player(string pName)
        {
            Name = pName;
            Health = 100;
            Stamina = 80;
            Location = Point.Empty;
        }
    }
}
