using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_rpg
{
    partial class Travel : Action
    {
        public enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }
        private Player Player { get; set; }
        private Direction Dir { get; set; }
        private Map MapData   { get; set; }

        public Travel (Direction pDir, GameData pGD)
        {
            HealthMod = 0;
            ManaMod = 0;
            StaminaMod = -10;
            TimeMod = TimeSpan.FromHours(4);

            MapData = pGD.MapData;
            Player = pGD.PlayerData;
            Dir = pDir;
        }

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
                    Player.Pos = Player.Pos.Add(0, 1);
                    Game.WriteLine("You move north!");
                    break;
                case Direction.Right:
                    Player.Pos = Player.Pos.Add(1, 0);
                    Game.WriteLine("You move east!");
                    break;
                case Direction.Down:
                    Player.Pos = Player.Pos.Add(0, -1);
                    Game.WriteLine("You move south!");
                    break;
                case Direction.Left:
                    Player.Pos = Player.Pos.Add(-1, 0);
                    Game.WriteLine("You move west!");
                    break;
            }

            MapSegment vSegm = MapData.GetSegment(Player.Pos);
            Game.WriteLine(string.Format("You entered the {0}", vSegm.MapBiome));
            MapData.BuildLand(Player.Pos);
        }
    }
}
