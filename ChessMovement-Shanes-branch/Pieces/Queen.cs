using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    class Queen : Piece
    {

        public override bool IsValidTest(Piece p, int endX, int endY)
        {
            bool result = false;
            p.AbsX = Util.GetAbsValue(p.x, endX);
            p.AbsY = Util.GetAbsValue(p.y, endY);
            Util util = new Util();
            Piece[,] temp = util.GetBoard();
            if (p.AbsX == p.AbsY && (endX >= 0 && endX <= 7) && (endY >= 0 && endY <= 7))
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
            else if (endX == p.x || (endY == p.y) && (endX >= 0 && endX <= 7) && (endY >= 0 && endY <= 7))
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
        public override bool IsPieceInWay(int EndX, int EndY, Piece p)
        {
            bool result = false;
            if (p.AbsX == p.AbsY)
            {
                if (EndX > p.x && EndY < p.y)
                {
                    result = CheckUpRight(EndX, EndY, p.x + 1, p.y - 1, Util.board);
                }
                else if (EndX < p.x && EndY < p.y)
                {
                    result = CheckUpLeft(EndX, EndY, p.x - 1, (p.y - 1), Util.board);
                }
                else if (EndX < p.x && EndY > p.y)
                {
                    result = CheckDownLeft(EndX, EndY, p.x - 1, p.y + 1, Util.board);
                }
                else if (EndX > p.x && EndY > p.y)
                {
                    result = CheckDownRight(EndX, EndY, p.x + 1, p.y + 1, Util.board);
                }

            }
            else if (EndX == p.x || (EndY == p.y))
            {
                if (EndX > p.x)
                {
                    //Going Right
                    result = CheckRight(EndX, EndY, p.x + 1, p.y, Util.board);
                }
                else if (EndX < p.x)
                {
                    //Going Left
                    result = CheckLeft(EndX, EndY, p.x - 1, p.y, Util.board);
                }
                else if (EndY > p.y)
                {
                    //Going down
                    result = CheckDown(EndX, EndY, p.x, p.y + 1, Util.board);

                }
                else if (EndY < p.y)
                {
                    //Going up
                    result = CheckUp(EndX, EndY, p.x, p.y - 1, Util.board);

                }
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
        public bool CheckUpRight(int EndX, int EndY, int CheckedX, int CheckedY, Piece[,] temp)
        {
            bool result = true;
            if (temp[CheckedX, CheckedY] == null && (CheckedX != EndX && CheckedY != EndY))
            {
                result = CheckUpRight(EndX, EndY, CheckedX + 1, (CheckedY - 1), temp);
            }
            else if (CheckedX == EndX && CheckedY == EndY)
            {
                result = false;
            }


            return result;
        }
        public bool CheckUpLeft(int EndX, int EndY, int CheckedX, int CheckedY, Piece[,] temp)
        {
            bool result = true;
            if (temp[CheckedX, CheckedY] == null && (CheckedX != EndX && CheckedY != EndY))
            {
                result = CheckUpLeft(EndX, EndY, CheckedX - 1, (CheckedY - 1), temp);
            }
            else if (CheckedX == EndX && CheckedY == EndY)
            {
                result = false;
            }


            return result;
        }
        public bool CheckDownLeft(int EndX, int EndY, int CheckedX, int CheckedY, Piece[,] temp)
        {
            bool result = true;
            if (temp[CheckedX, CheckedY] == null && (CheckedX != EndX && CheckedY != EndY))
            {
                result = CheckDownLeft(EndX, EndY, CheckedX - 1, (CheckedY + 1), temp);
            }
            else if (CheckedX == EndX && CheckedY == EndY)
            {
                result = false;
            }


            return result;
        }
        public bool CheckDownRight(int EndX, int EndY, int CheckedX, int CheckedY, Piece[,] temp)
        {
            bool result = true;
            if (temp[CheckedX, CheckedY] == null && (CheckedX != EndX && CheckedY != EndY))
            {
                result = CheckDownRight(EndX, EndY, CheckedX + 1, (CheckedY + 1), temp);
            }
            else if (CheckedX == EndX && CheckedY == EndY)
            {
                result = false;
            }


            return result;
        }

    }

}