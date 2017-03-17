using System;

namespace cmd_rpg
{
    partial class Sleep : Action
    {
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

        public Sleep(int pHours)
        {
            TimeMod = TimeSpan.FromHours(pHours);
        }

        public override void Perform(GameData pGD)
        {
            Game.WriteLine("You sleep for " + TimeMod.ToString());
            pGD.PlayerData.ModStam((int)TimeMod.TotalHours + 10);
            pGD.ModTime(TimeMod);
        }
    }
}
