using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cmd_rpg
{
    class Game
    {
        private const int KEYDELAY = 25;

        static void Main(string[] args)
        {
            WriteLine("Welcome adventurer!");
            Player vPlayer = new Player(Request("What is your name?"));
            WriteLine("Greetings " + vPlayer.Name + Environment.NewLine);
            string vMapName = Request("What is the name of these lands?");
            WriteLine("Welcome to the lands of " + vMapName);
            GameData vGameData = new GameData(vPlayer, vMapName);
            vGameData.State = GameState.Freeroam;
            GameLoop(vGameData);
            WriteLine("Good bye adventurer.");
        }

        static void GameLoop(GameData pGameData)
        {
            WriteLine(String.Format("Location: {0}\tHP: {1}\tStamina: {2}\tTime: {3}\tDate: {4}", 
                pGameData.PlayerData.Location,      //0
                pGameData.PlayerData.Health,        //1
                pGameData.PlayerData.Stamina,       //2
                pGameData.Time.ToShortTimeString(), //3
                pGameData.Time.ToShortDateString()  //4
                ), true);

            var vCmd = "";
            while (String.IsNullOrEmpty(vCmd))
                vCmd = Request("What do you do next?");

            var vCmdSegments = vCmd.Split(' ');

            switch(vCmdSegments[0])
            {
                case "go":
                case "walk":
                case "travel":
                    Go(vCmdSegments, pGameData);
                    break;
                case "sleep":
                case "rest":
                    Sleep(vCmdSegments, pGameData);
                    break;
                case "quit":
                    return;
            }

            //Loop Method
            GameLoop(pGameData);
        }

        /// <summary>
        /// Moves the player in given direction
        /// Advances time by 4 hours.
        /// Removes 10 Stam.
        /// </summary>
        /// <param name="pSubCommmands"></param>
        /// <param name="pGD"></param>
        /// <returns></returns>
        static bool Go(string[] pSubCommmands, GameData pGD)
        {
            Action vAction = null;

            switch(pSubCommmands[1])
            {
                case "12":
                case "up":
                case "north":
                case "n":
                    vAction = new Travel(Travel.Direction.Up, pGD);
                    break;
                case "3":
                case "right":
                case "east":
                case "e":
                    vAction = new Travel(Travel.Direction.Right, pGD);
                    break;
                case "6":
                case "down":
                case "south":
                case "s":
                    vAction = new Travel(Travel.Direction.Down, pGD);
                    break;
                case "9":
                case "left":
                case "west":
                case "w":
                    vAction = new Travel(Travel.Direction.Left, pGD);
                    break;
            }

            vAction.Perform();
            return false;
        }

        private static void Sleep(string[] pCmdSegments, GameData pGameData)
        {
            int vSleepAmount = 0;
            if (pCmdSegments.Length >= 2 && int.TryParse(pCmdSegments[1], out vSleepAmount))
                if (vSleepAmount <= 24)
                {
                    pGameData.PlayerSleep(TimeSpan.FromHours(vSleepAmount));
                    return;
                }

            Console.WriteLine("Sleep must be in format: :> sleep <hours> max 24");
            Console.WriteLine("example: :> sleep 8");
        }


        #region Input
        static string Request(string pRequest)
        {
            WriteLine(pRequest);
            Write(":> ");
            return Console.ReadLine();
        }
        #endregion
        #region Output
        public static void Write(string pOut, bool pInstant = false)
        {
            if (!pInstant)
                TypeWriter(pOut, KEYDELAY);
            else
                Console.Write(pOut);
        }
        public static void WriteLine(string pOut, bool pInstant = false)
        {
            if (!pInstant)
                TypeWriter(pOut + Environment.NewLine, KEYDELAY);
            else
                Console.WriteLine(pOut);
        }
        static void TypeWriter(string pOut, int pKeyDelay)
        {
            foreach(char vChar in pOut)
            {
                Console.Write(vChar);
                Console.Beep(500, 25);
                //Thread.Sleep(pKeyDelay);
            }
        }
        #endregion
    }

    static class CustomExtensions
    {
        public static Point Add(this Point pPoint, Point pPoint2)
        {
            return new Point(pPoint.X + pPoint2.X, pPoint.Y + pPoint2.Y);
        }

        public static Point Add (this Point pPoint, int pX, int pY)
        {
            return new Point(pPoint.X + pX, pPoint.Y + pY);
        }
    }
}
