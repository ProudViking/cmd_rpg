using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cmd_rpg
{
    class Program
    {
        private enum GameState
        {
            Init,
            Menu,
            Freeroam,
            Combat
        }
        private const int KEYDELAY = 25;

        static void Main(string[] args)
        {
            WriteLine("Welcome adventurer!");
            Player vPlayer = new Player(Request("What is your name?"));
            WriteLine("Greetings " + vPlayer.Name + Environment.NewLine);
            GameLoop(vPlayer);
            WriteLine("Good bye adventurer.");
        }

        static void GameLoop(Player pPlayerData)
        {
            GameState vState = GameState.Freeroam;

            WriteLine(String.Format("Location: {0}\tHP: {1}\tStamina: {2}",pPlayerData.Location, pPlayerData.Health, pPlayerData.Stamina), true);

            var vCmd = "";
            while (String.IsNullOrEmpty(vCmd))
                vCmd = Request("What do you do next?");

            var vCmdSegments = vCmd.Split(' ');

            switch(vCmdSegments[0])
            {
                case "go":
                    Go(vCmdSegments, pPlayerData);
                    break;
                case "quit":
                    return;
            }

            //Loop Method
            GameLoop(pPlayerData);
        }

        static string Request(string pRequest)
        {
            WriteLine(pRequest);
            Write(":> ");
            return Console.ReadLine();
        }

        static bool Go(string[] pSubCommmands, Player pPlayer)
        {
            switch(pSubCommmands[1])
            {
                case "12":
                case "up":
                case "north":
                case "n":
                    pPlayer.Location = pPlayer.Location.Add(0, 1);
                    break;
                case "3":
                case "right":
                case "east":
                case "e":
                    pPlayer.Location = pPlayer.Location.Add(1, 0);
                    break;
                case "6":
                case "down":
                case "south":
                case "s":
                    pPlayer.Location = pPlayer.Location.Add(0, -1);
                    break;
                case "9":
                case "left":
                case "west":
                case "w":
                    pPlayer.Location = pPlayer.Location.Add(-1, 0);
                    break;
            }

            pPlayer.Stamina -= 10;
            return false;
        }

        static void Write(string pOut, bool pInstant = false)
        {
            if (!pInstant)
                TypeWriter(pOut, KEYDELAY);
            else
                Console.Write(pOut);
        }

        static void WriteLine(string pOut, bool pInstant = false)
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
                Thread.Sleep(pKeyDelay);
            }
        }
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
