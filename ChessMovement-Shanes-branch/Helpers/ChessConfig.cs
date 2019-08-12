using System;

namespace ChessMovement.Helpers
{
    public class ChessConfig
    {
        public static string ParseInput(string input, Util util)
        {
            String value = null;
            if (string.IsNullOrEmpty(input)) throw new ArgumentException();
            if (!input.Contains(" ")) throw new ArgumentException();
            util.GetBoard();
            return value;
        }
    }
}