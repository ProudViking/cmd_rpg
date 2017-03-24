using System;
using System.Threading;

namespace cmd_rpg.Actions
{
    partial class ScanArea : Action
    {
        public enum ScanMode
        {
            Rough,
            Normal,
            Careful
        }

        public ScanArea(ScanMode pMode)
        {
            switch(pMode)
            {
                case ScanMode.Careful:
                    TimeMod = TimeSpan.FromHours(2);
                    break;
                case ScanMode.Normal:
                    TimeMod = TimeSpan.FromHours(1);
                    break;
                case ScanMode.Rough:
                    TimeMod = TimeSpan.FromMinutes(15);
                    break;
            }
        }

        public override string ValidCalls { get; }
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

        public override void Perform(GameData pGD)
        {
            var vMapSegment = pGD.MapData.GetSegment(pGD.PlayerData.Pos);

            Game.WriteLine("Your eyes scan the " + vMapSegment.MapBiome + " for useful resources");
            double vDelay = TimeMod.TotalMinutes;
            for (double I = 0; I < vDelay; I++)
            {
                pGD.ModTime(TimeSpan.FromMinutes(1));
                Game.Write(".", true);
                Thread.Sleep(50);
            }
            Game.Write(Environment.NewLine);

            //Todo: Add dynamic resources in the mapsegments and read them all in a loop and report them.
            Game.WriteLine("You find " + vMapSegment.Trees + " Tree's in the area!");
        }
    }
}
