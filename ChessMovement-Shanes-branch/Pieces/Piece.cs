using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    class Piece
    {
        Util util = new Util();

        public char name;
        public char color;
        public int TimesMoved;
        public int x;
        public int y;
        public int AbsX;
        public int AbsY;

        public virtual bool IsValidTest(Piece p, int endX, int endY)
        {
            return false;
        }
        public virtual bool IsPieceInWay(int endX, int endY, Piece p) //Idea - Run to check each tile before end location. If true move on to the nexr. if false, move invalid.
        {
            return false;
        }
    }
}