using System;
using cmd_rpg.Actions;

namespace cmd_rpg
{
    class Game
    {
        private const int KEYDELAY = 25;

        static void Main(string[] args)
        {
            WriteLine("Welcome adventurer!");

            //Enter your playerdata
            Creatures.Gender vGender = Creatures.Gender.Unknown;
            while(vGender == Creatures.Gender.Unknown)
            {
                var vRes = Enum.TryParse(Request("Are you male or female?"), out vGender);
                if (!vRes || vGender == Creatures.Gender.Unknown)
                    WriteLine("Invalid gender, valid genders: Male/Female");
            }

            string vName = Request("What is your name?");

            Classes.Class vClass =  Classes.Class.Unknown;
            while (vClass == Classes.Class.Unknown)
            {
                var vRes = Enum.TryParse(Request("What is your class?"), out vClass);
                if (!vRes || vClass == Classes.Class.Unknown)
                    WriteLine("Invalid class, valid classes: Warrior, Ranger, Mage");
            }

            //Create base playerdata
            Player vPlayer = new Player(vName, vGender, vClass);
            WriteLine("Greetings " + vPlayer.Name + Environment.NewLine);

            //Enter a name for your world
            string vMapName = Request("What is the name of these lands?");
            WriteLine("Welcome to the lands of " + vMapName);

            //Create Base Gamedata
            GameData vGameData = new GameData(vPlayer, vMapName);
            vGameData.State = GameState.Freeroam;

            //Enter game loop
            GameLoop(vGameData);

            //Exited from game loop.
            WriteLine("Good bye adventurer.");
        }

        static void GameLoop(GameData pGameData)
        {
            WriteLine(String.Format("Location: {0}\tHP: {1}\tStamina: {2}\tTime: {3}\tDate: {4}", 
                pGameData.PlayerData.Pos,           //0
                pGameData.PlayerData.Health,        //1
                pGameData.PlayerData.Stamina,       //2
                pGameData.Time.ToShortTimeString(), //3
                pGameData.Time.ToShortDateString()  //4
                ), true);

            var vCmd = "";
            while (String.IsNullOrEmpty(vCmd))
                vCmd = Request("What do you do next?");

            var vCmdSegments = vCmd.Split(' ');

            Actions.ActionParser.Parse(vCmdSegments[0]);

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
                case "Scan":
                    ScanArea vScan = new ScanArea(ScanArea.ScanMode.Normal);
                    pGameData.PlayerData.PerformAction(vScan);
                    break;
                case "quit":
                case "exit":
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
            Actions.Action vAction = null;

            switch(pSubCommmands[1])
            {
                case "12":
                case "up":
                case "north":
                case "n":
                    vAction = new Travel(Direction.Up);
                    break;
                case "3":
                case "right":
                case "east":
                case "e":
                    vAction = new Travel(Direction.Right);
                    break;
                case "6":
                case "down":
                case "south":
                case "s":
                    vAction = new Travel(Direction.Down);
                    break;
                case "9":
                case "left":
                case "west":
                case "w":
                    vAction = new Travel(Direction.Left);
                    break;
            }

            pGD.PlayerData.PerformAction(vAction);
            return false;
        }

        private static void Sleep(string[] pCmdSegments, GameData pGameData)
        {
            int vSleepAmount = 0;
            if (pCmdSegments.Length >= 2 && int.TryParse(pCmdSegments[1], out vSleepAmount))
                if (vSleepAmount <= 24)
                {
                    Actions.Action vAction = new Sleep(vSleepAmount);
                    pGameData.PlayerData.PerformAction(vAction);
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
        public static Position Add(this Position pPosition, Position pPosition2)
        {
            return new Position(pPosition.X + pPosition2.X, pPosition.Y + pPosition2.Y);
        }

        public static Position Add (this Position pPosition, int pX, int pY)
        {
            return new Position(pPosition.X + pX, pPosition.Y + pY);
        }
    }
}
