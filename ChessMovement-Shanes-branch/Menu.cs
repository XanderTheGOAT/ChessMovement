using ChessMovement.Helpers;
using CSC160_ConsoleMenu;
using System;

namespace ChessMovement
{
    internal class Menu
    {
        private static readonly Util util = new Util(); // Sets up the Util class so we can call our needed methodd

        public static void LoadGame(string[] args)
        {
            if (util.ArgCheck(args)) //Checks if an argument is present and if it leads to a valid file
            {
                util.GeneralSetup();
                util.ProcessInput(args[0]);
            }
        }

        public static void NewGame()
        {
            string[] options = { "Standard", "Chess 960", "Pawn Setup" };

            int option = CIO.PromptForMenuSelection(options, true);
            switch (option)
            {
                case 1:
                    util.GeneralSetup();
                    break;
                case 2:
                    util.FischerRandomSetup();
                    break;
                case 3:
                    util.PawnSetup();
                    break;
            }
            Start();
        }

        private static void Start()
        {
            bool stop = true;
            do
            {
                util.PrintBoard("Press Enter to Continue...");
                string input = CIO.PromptForInput("Enter starting location followed by end location to move\r\nExample: A1 A3\r\n\r\nEnter 0 to stop", false);
                if (!input.Equals(0))
                {
                    try
                    {
                        util.ProcessInput(input);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Format Your String correctly please");
                    }
                }
                Console.Clear();
            } while (stop);
        }
    }
}
