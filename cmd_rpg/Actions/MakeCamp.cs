using System;

namespace cmd_rpg.Actions
{
    partial class MakeCamp : Action
    {
        public override string ValidCalls { get { return "Camp MakeCamp";  } }
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
            throw new NotImplementedException("MakeCamp.Perform() not implemented yet!");
        }
    }
}
