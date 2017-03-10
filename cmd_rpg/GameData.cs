using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_rpg
{
    public enum GameState
    {
        Init,
        Menu,
        Freeroam,
        Combat
    }

    class GameData
    {
        public GameState State      { get; set; }
        public DateTime Time        { get; set; }
        public Player PlayerData    { get; set; }
        public Random Rand          { get; set; }
        public Map MapData          { get; set; }

        public GameData(Player pPlayer, string pMapName, int pSeed = 0)
        {
            State = GameState.Init;
            Time = new DateTime(100, 5, 3, 12, 0, 0);
            PlayerData = pPlayer;
            PlayerData.GD = this;

            if (pMapName == "") pMapName = "Eyranor";
            if (pSeed == 0) pSeed = DateTime.Now.Millisecond;

            Rand = new Random(pSeed);
            MapData = new Map(pMapName, Rand);
        }

        public void ModTime(TimeSpan pTime)
        {
            Time += pTime;
        }
        public void TelePlayer(Point pPos)
        {
            Game.WriteLine("You teleported to: " + pPos);
            PlayerData.Location = pPos;
        }
    }
}
