using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement.Helpers
{
    public static class Randomizer
    {
        public static int ChooseNumberThenRemove(ref List<int> values)
        {
            Random rnJesus = new Random();
            int randomNumber = rnJesus.Next(values.Count);
            int value = values[randomNumber];
            values.Remove(value);
            return value;
        }
    }
}
