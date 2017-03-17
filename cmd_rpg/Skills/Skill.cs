using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_rpg.Skills
{
    abstract class Skill
    {
        public abstract int LevelReq            { get; set; }
        public abstract Classes.Class  ClassReq { get; set; }

        public abstract void Use(GameData pGD);
    }
}
