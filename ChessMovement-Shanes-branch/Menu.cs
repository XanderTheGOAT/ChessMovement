using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    class Menu
    {
        private static Util util = new Util(); // Sets up the Util class so we can call our needed methodd

        public static void LoadGame(String[] args)
        {
            if (util.ArgCheck(args)) //Checks if an argument is present and if it leads to a valid file
            {
                util.setupBoard();
                util.FileReader(args[0]);
            }
        }

        public static void NewGame()
        {
            util.setupBoard();
        }

    }
}
