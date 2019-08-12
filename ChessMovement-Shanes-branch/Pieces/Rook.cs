using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    class Rook : Piece
    {

        public override bool IsValidTest(Piece p, int endX, int endY)
        {

            Util util = new Util();
            bool result = false;
            Piece[,] temp = util.GetBoard();
            if ((endX == p.x || (endY == p.y)) && (endX >= 0 && endX <= 7) && (endY >= 0 && endY <= 7))
            {
                if (!IsPieceInWay(endX, endY, p))
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

            }

            return result;
        }
        public override bool IsPieceInWay(int endX, int endY, Piece p)
        {
            bool result = true;
            if (endX > p.x)
            {
                //Going Right
                result = CheckRight(endX, endY, p.x + 1, p.y, Util.board);
            }
            else if (endX < p.x)
            {
                //Going Left
                result = CheckLeft(endX, endY, p.x - 1, p.y, Util.board);
            }
            else if (endY > p.y)
            {
                //Going down
                result = CheckDown(endX, endY, p.x, p.y + 1, Util.board);

            }
            else if (endY < p.y)
            {
                //Going up
                result = CheckUp(endX, endY, p.x, p.y - 1, Util.board);

            }


            return result;
        }
        public bool CheckRight(int EndX, int EndY, int CheckedX, int CheckedY, Piece[,] temp)
        {
            bool result = true;

            if (temp[CheckedX, CheckedY] == null && (CheckedX != EndX || CheckedY != EndY))
            {
                result = CheckRight(EndX, EndY, CheckedX + 1, CheckedY, temp);
            }
            else if (CheckedX == EndX && CheckedY == EndY)
            {
                result = false;
            }

            return result;
        }
        public bool CheckLeft(int EndX, int EndY, int CheckedX, int CheckedY, Piece[,] temp)
        {
            bool result = true;

            if (temp[CheckedX, CheckedY] == null && (CheckedX != EndX || CheckedY != EndY))
            {
                result = CheckLeft(EndX, EndY, CheckedX - 1, CheckedY, temp);
            }
            else if (CheckedX == EndX && CheckedY == EndY)
            {
                result = false;
            }

            return result;
        }
        public bool CheckUp(int EndX, int EndY, int CheckedX, int CheckedY, Piece[,] temp)
        {
            bool result = true;

            if (temp[CheckedX, CheckedY] == null && (CheckedX != EndX || CheckedY != EndY))
            {
                result = CheckUp(EndX, EndY, CheckedX, CheckedY - 1, temp);
            }
            else if (CheckedX == EndX && CheckedY == EndY)
            {
                result = false;
            }

            return result;
        }
        public bool CheckDown(int EndX, int EndY, int CheckedX, int CheckedY, Piece[,] temp)
        {
            bool result = true;

            if (temp[CheckedX, CheckedY] == null && (CheckedX != EndX || CheckedY != EndY))
            {
                result = CheckDown(EndX, EndY, CheckedX, CheckedY + 1, temp);
            }
            else if (CheckedX == EndX && CheckedY == EndY)
            {
                result = false;
            }

            return result;
        }
    }
}
