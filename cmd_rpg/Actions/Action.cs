using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_rpg
{
    abstract class Action
    {
        #region Parameters
        public abstract int StaminaMod  { get; set; }
        public abstract int HealthMod   { get; set; }
        public abstract int ManaMod     { get; set; }
        public abstract TimeSpan TimeMod{ get; set; }
        #endregion

        #region Methods
        public abstract void Perform(GameData pGD);
        #endregion
    }
}
