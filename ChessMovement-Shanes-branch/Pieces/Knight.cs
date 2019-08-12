using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    class Knight : Piece
    {

        public override bool IsValidTest(Piece p, int endX, int endY)
        {
            bool result = false;
            p.AbsX = Util.GetAbsValue(p.x, endX);
            p.AbsY = Util.GetAbsValue(p.y, endY);
            Util util = new Util();
            Piece[,] temp = util.GetBoard();
            if ((p.AbsX == 1 && p.AbsY == 2) || (p.AbsX == 2 && p.AbsY == 1) && (endX >= 0 && endX <= 7) && (endY >= 0 && endY <= 7))
            {
                if (temp[endX, endY] != null)
                {
                    if (temp[endX, endY].color != p.color)
                    {
                        result = true;
                    }
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }
    }

}
