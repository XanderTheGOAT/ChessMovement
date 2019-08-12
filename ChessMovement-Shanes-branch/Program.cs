using CSC160_ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    class Program
    {
        static void Main(string[] args)
        {

            String[] options = { "New Game", "Load Game" };
            int option = CIO.PromptForMenuSelection(options, true);
            switch (option)
            {
                case 1:
                    Menu.NewGame();
                    break;
                case 2:
                    Menu.LoadGame(args);
                    break;
                default:
                    break;
            }
        }
    }
}
