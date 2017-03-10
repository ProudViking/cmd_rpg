using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_rpg
{
    partial class Sleep : Action
    {
        private Player Player       { get; set; }
        private GameData GD         { get; set; }

        public override int HealthMod
        {
            get; set;
        }
        public override int ManaMod
        {
            get; set;
        }
        public override int StaminaMod
        {
            get; set;
        }
        public override TimeSpan TimeMod
        {
            get; set;
        }

        public Sleep(int pHours, GameData pGD)
        {
            TimeMod = TimeSpan.FromHours(pHours);
            Player = pGD.PlayerData;
        }

        public override void Perform()
        {
            Game.WriteLine("You sleep for " + TimeMod.ToString());
            Player.ModStam((int)TimeMod.TotalHours + 10);
            GD.ModTime(TimeMod);
        }
    }
}
