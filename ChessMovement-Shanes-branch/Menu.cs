using CSC160_ConsoleMenu;


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
            string[] options = { "Standard", "Chess 960" };

            int option = CIO.PromptForMenuSelection(options, true);
            switch (option)
            {
                case 1:
                    util.GeneralSetup();
                    break;
                case 2:
                    break;
            }
        }

    }
}
