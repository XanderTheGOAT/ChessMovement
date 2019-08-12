using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    class Pawn : Piece
    {

        public override bool IsValidTest(Piece p, int endX, int endY)
        {
            bool result = false;
            p.AbsX = Util.getAbsValue(p.x, endX);
            p.AbsY = Util.getAbsValue(p.y, endY);
            Util util = new Util();

            Piece[,] temp = util.GetBoard();
            if (p.color == 'l')
            {
                if (endX == p.x && (endY == ((p.y - 1))))
                {
                    result = true;
                }
                else if (p.TimesMoved == 0 && endX == p.x && (p.AbsY == 2) && temp[endX, endY + 1] == null)
                {
                    result = true;
                }
                else if (temp[endX, endY] != null)
                {
                    if (temp[endX, endY].color == 'd' && p.AbsX == 1 && (p.AbsY == 1))
                    {
                        result = true;
                    }
                }

            }
            else if (p.color == 'd')
            {
                if (endX == p.x && (p.AbsY == 1))
                {
                    result = true;
                }
                else if (p.TimesMoved == 0 && endX == p.x && (p.AbsY == 2) && temp[endX, endY - 1] == null)
                {
                    result = true;
                }
                else if (temp[endX, endY] != null)
                {
                    if (temp[endX, endY].color == 'l' && p.AbsX == 1 && (p.AbsY == 1))
                    {
                        result = true;
                    }
                }

            }
            return result;
        }
    }
}
