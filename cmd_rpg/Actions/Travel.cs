using System;

namespace cmd_rpg.Actions
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    partial class Travel : Action
    {
        private Direction Dir { get; set; }

        public Travel (Direction pDir)
        {
            HealthMod = 0;
            ManaMod = 0;
            StaminaMod = -10;
            TimeMod = TimeSpan.FromHours(4);

            Dir = pDir;
        }

        public override string ValidCalls { get { return "travel go"; } }
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
            switch (Dir)
            {
                case Direction.Up:
                    pGD.PlayerData.Pos = pGD.PlayerData.Pos.Add(0, 1);
                    Game.WriteLine("You move north!");
                    break;
                case Direction.Right:
                    pGD.PlayerData.Pos = pGD.PlayerData.Pos.Add(1, 0);
                    Game.WriteLine("You move east!");
                    break;
                case Direction.Down:
                    pGD.PlayerData.Pos = pGD.PlayerData.Pos.Add(0, -1);
                    Game.WriteLine("You move south!");
                    break;
                case Direction.Left:
                    pGD.PlayerData.Pos = pGD.PlayerData.Pos.Add(-1, 0);
                    Game.WriteLine("You move west!");
                    break;
            }

            MapSegment vSegm = pGD.MapData.GetSegment(pGD.PlayerData.Pos);
            Game.WriteLine(string.Format("You entered the {0}", vSegm.MapBiome));
            pGD.MapData.BuildLand(pGD.PlayerData.Pos);
        }
    }
}
