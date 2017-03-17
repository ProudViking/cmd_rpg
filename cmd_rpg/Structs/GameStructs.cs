using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_rpg
{
    public struct Position
    {
        public Position(int pX, int pY)
        {
            X = pX;
            Y = pY;
        }

        public int X;
        public int Y;

        public static bool operator ==(Position pPos1, Position pPos2)
        {
            return (pPos1.X == pPos2.X && pPos1.Y == pPos2.Y);
        }

        public static bool operator !=(Position pPos1, Position pPos2)
        {
            return (pPos1.X != pPos2.X && pPos1.Y != pPos2.Y);
        }

        public static Position operator +(Position pPos1, Position pPos2)
        {
            return new Position(pPos1.X + pPos2.X, pPos1.Y + pPos2.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Position))
                return false;
            else
                if (((Position)obj) == this)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            var vSum = X + Y;
            return vSum.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[x: {0}, y: {1}]", X, Y);
        }
    }

}
