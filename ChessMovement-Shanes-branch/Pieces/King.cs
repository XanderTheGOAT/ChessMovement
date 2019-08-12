using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class King : Piece
    {

        public override bool IsValidTest(Piece p, int endX, int endY)
        {
            bool result = false;

            p.AbsX = Util.GetAbsValue(p.x, endX);
            p.AbsY = Util.GetAbsValue(p.y, endY);
            Util util = new Util();
            Piece[,] temp = util.GetBoard();
            if ((p.AbsX <= 1 && p.AbsY <= 1) && (0 <= endX && endX <= 7) && (0 <= endY && endY <= 7))
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

