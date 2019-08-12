using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using ChessMovement.Helpers;

namespace ChessMovement
{
    public class Util
    {


        public char lastPieceMovedColor;
        public bool gameEnd = false;
        public static Piece[,] board = new Piece[8, 8];


        public void GeneralSetup() // Creates a Piece for every piece a chess board is supposed to have with pawns commented out for later. For every piece created, it places it on the board.
        {

            //Dark Pieces
            Piece DarkKing = new King();
            DarkKing.x = 4;
            DarkKing.y = 0;
            DarkKing.name = 'K';
            DarkKing.color = 'd';
            PiecePlace(DarkKing.x, DarkKing.y, DarkKing);

            Piece DarkQueen = new Queen();
            DarkQueen.x = 3;
            DarkQueen.y = 0;
            DarkQueen.name = 'Q';
            DarkQueen.color = 'd';
            PiecePlace(DarkQueen.x, DarkQueen.y, DarkQueen);

            Piece DarkKnight1 = new Knight();
            DarkKnight1.x = 1;
            DarkKnight1.y = 0;
            DarkKnight1.name = 'N';
            DarkKnight1.color = 'd';
            PiecePlace(DarkKnight1.x, DarkKnight1.y, DarkKnight1);


            Piece DarkKnight2 = new Knight();
            DarkKnight2.x = 6;
            DarkKnight2.y = 0;
            DarkKnight2.name = 'N';
            DarkKnight2.color = 'd';
            PiecePlace(DarkKnight2.x, DarkKnight2.y, DarkKnight2);

            Piece DarkRook1 = new Rook();
            DarkRook1.x = 0;
            DarkRook1.y = 0;
            DarkRook1.name = 'R';
            DarkRook1.color = 'd';
            PiecePlace(DarkRook1.x, DarkRook1.y, DarkRook1);

            Piece DarkRook2 = new Rook();
            DarkRook2.x = 7;
            DarkRook2.y = 0;
            DarkRook2.name = 'R';
            DarkRook2.color = 'd';
            PiecePlace(DarkRook2.x, DarkRook2.y, DarkRook2);

            Piece DarkBishop1 = new Bishop();
            DarkBishop1.x = 2;
            DarkBishop1.y = 0;
            DarkBishop1.name = 'B';
            DarkBishop1.color = 'd';
            PiecePlace(DarkBishop1.x, DarkBishop1.y, DarkBishop1);

            Piece DarkBishop2 = new Bishop();
            DarkBishop2.x = 5;
            DarkBishop2.y = 0;
            DarkBishop2.name = 'B';
            DarkBishop2.color = 'd';
            PiecePlace(DarkBishop2.x, DarkBishop2.y, DarkBishop2);

            for (int i = 0; i < 8; i++)
            {
                Piece DarkPawn = new Pawn()
                {
                    x = i,
                    y = 1,
                    name = 'P',
                    color = 'd'
                };
                PiecePlace(DarkPawn.x, DarkPawn.y, DarkPawn);
            }

            //Light Pieces
            Piece LightKing = new King();
            LightKing.x = 4;
            LightKing.y = 7;
            LightKing.name = 'k';
            LightKing.color = 'l';
            PiecePlace(LightKing.x, LightKing.y, LightKing);

            Piece LightQueen = new Queen();
            LightQueen.x = 3;
            LightQueen.y = 7;
            LightQueen.name = 'q';
            LightQueen.color = 'l';
            PiecePlace(LightQueen.x, LightQueen.y, LightQueen);

            Piece LightKnight1 = new Knight();
            LightKnight1.x = 1;
            LightKnight1.y = 7;
            LightKnight1.name = 'n';
            LightKnight1.color = 'l';
            PiecePlace(LightKnight1.x, LightKnight1.y, LightKnight1);

            Piece LightKnight2 = new Knight();
            LightKnight2.x = 6;
            LightKnight2.y = 7;
            LightKnight2.name = 'n';
            LightKnight2.color = 'l';
            PiecePlace(LightKnight2.x, LightKnight2.y, LightKnight2);

            Piece LightRook1 = new Rook();
            LightRook1.x = 0;
            LightRook1.y = 7;
            LightRook1.name = 'r';
            LightRook1.color = 'l';
            PiecePlace(LightRook1.x, LightRook1.y, LightRook1);

            Piece LightRook2 = new Rook();
            LightRook2.x = 7;
            LightRook2.y = 7;
            LightRook2.name = 'r';
            LightRook2.color = 'l';
            PiecePlace(LightRook2.x, LightRook2.y, LightRook2);

            Piece LightBishop1 = new Bishop();
            LightBishop1.x = 2;
            LightBishop1.y = 7;
            LightBishop1.name = 'b';
            LightBishop1.color = 'l';
            PiecePlace(LightBishop1.x, LightBishop1.y, LightBishop1);

            Piece LightBishop2 = new Bishop();
            LightBishop2.x = 5;
            LightBishop2.y = 7;
            LightBishop2.name = 'b';
            LightBishop2.color = 'l';
            PiecePlace(LightBishop2.x, LightBishop2.y, LightBishop2);
            for (int i = 0; i < 8; i++)
            {
                Piece LightPawn = new Pawn()
                {
                    x = i,
                    y = 6,
                    name = 'p',
                    color = 'l'
                };
                PiecePlace(LightPawn.x, LightPawn.y, LightPawn);
            }
        }

        public void PawnSetup()
        {
            //-------------------------
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Piece LightPawn = new Pawn()
                    {
                        x = i,
                        y = j + 6,
                        name = 'p',
                        color = 'l'
                    };
                    PiecePlace(LightPawn.x, LightPawn.y, LightPawn);
                }
            }
            Piece LightKing = new King();
            LightKing.x = 4;
            LightKing.y = 7;
            LightKing.name = 'k';
            LightKing.color = 'l';
            PiecePlace(LightKing.x, LightKing.y, LightKing);



            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Piece DarkPawn = new Pawn()
                    {
                        x = i,
                        y = j,
                        name = 'P',
                        color = 'd'
                    };
                    PiecePlace(DarkPawn.x, DarkPawn.y, DarkPawn);
                }
            }
            Piece DarkKing = new King();
            DarkKing.x = 4;
            DarkKing.y = 0;
            DarkKing.name = 'K';
            DarkKing.color = 'd';
            PiecePlace(DarkKing.x, DarkKing.y, DarkKing);


        }

        public void FischerRandomSetup()
        {
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };

            //Dark Pieces
            Piece DarkBishop1 = new Bishop();
            int value = numbers[new Random().Next(7)];
            value = value % 2 == 0 ? value : value+1;
            numbers.Remove(value);
            DarkBishop1.x = value;
            DarkBishop1.y = 0;
            DarkBishop1.name = 'B';
            DarkBishop1.color = 'd';
            PiecePlace(DarkBishop1.x, DarkBishop1.y, DarkBishop1);

            Piece DarkBishop2 = new Bishop();
            value = numbers[new Random().Next(6)];
            value = value % 2 == 0 ? value+1 : value;
            numbers.Remove(value);
            DarkBishop2.x = value;
            DarkBishop2.y = 0;
            DarkBishop2.name = 'B';
            DarkBishop2.color = 'd';
            PiecePlace(DarkBishop2.x, DarkBishop2.y, DarkBishop2);

            Rook DarkRook1 = new Rook();
            DarkRook1.x = Randomizer.ChooseNumberThenRemove(ref numbers);
            DarkRook1.y = 0;
            DarkRook1.name = 'R';
            DarkRook1.color = 'd';

            Rook DarkRook2 = new Rook();
            DarkRook2.x = Randomizer.ChooseNumberThenRemove(ref numbers);
            DarkRook2.y = 0;
            DarkRook2.name = 'R';
            DarkRook2.color = 'd';

            King DarkKing = new King();
            DarkKing.x = Randomizer.ChooseNumberThenRemove(ref numbers);
            DarkKing.y = 0;
            DarkKing.name = 'K';
            DarkKing.color = 'd';

            if (DarkKing.x < DarkRook1.x && DarkKing.x < DarkRook2.x)
            {
                Piece middle = DarkRook1.x < DarkRook2.x ? ref DarkRook1 : ref DarkRook2;
                (DarkKing.x, middle.x) = (middle.x, DarkKing.x);
            }
            else if (DarkKing.x > DarkRook1.x && DarkKing.x > DarkRook2.x)
            {
                Piece middle = DarkRook1.x < DarkRook2.x ? ref DarkRook2 : ref DarkRook1;
                (DarkKing.x, middle.x) = (middle.x, DarkKing.x);
            }

            PiecePlace(DarkRook1.x, DarkRook1.y, DarkRook1);
            PiecePlace(DarkRook2.x, DarkRook2.y, DarkRook2);
            PiecePlace(DarkKing.x, DarkKing.y, DarkKing);

            Piece DarkQueen = new Queen();
            DarkQueen.x = Randomizer.ChooseNumberThenRemove(ref numbers);
            DarkQueen.y = 0;
            DarkQueen.name = 'Q';
            DarkQueen.color = 'd';
            PiecePlace(DarkQueen.x, DarkQueen.y, DarkQueen);

            Piece DarkKnight1 = new Knight();
            DarkKnight1.x = Randomizer.ChooseNumberThenRemove(ref numbers);
            DarkKnight1.y = 0;
            DarkKnight1.name = 'N';
            DarkKnight1.color = 'd';
            PiecePlace(DarkKnight1.x, DarkKnight1.y, DarkKnight1);

            Piece DarkKnight2 = new Knight();
            DarkKnight2.x = Randomizer.ChooseNumberThenRemove(ref numbers);
            DarkKnight2.y = 0;
            DarkKnight2.name = 'N';
            DarkKnight2.color = 'd';
            PiecePlace(DarkKnight2.x, DarkKnight2.y, DarkKnight2);

            for (int i = 0; i < 8; i++)
            {
                Piece DarkPawn = new Pawn()
                {
                    x = i,
                    y = 1,
                    name = 'P',
                    color = 'd'
                };
                PiecePlace(DarkPawn.x, DarkPawn.y, DarkPawn);
            }

            //Light Pieces
            Piece LightKing = new King();
            LightKing.x = DarkKing.x;
            LightKing.y = 7;
            LightKing.name = 'k';
            LightKing.color = 'l';
            PiecePlace(LightKing.x, LightKing.y, LightKing);

            Piece LightQueen = new Queen();
            LightQueen.x = DarkQueen.x;
            LightQueen.y = 7;
            LightQueen.name = 'q';
            LightQueen.color = 'l';
            PiecePlace(LightQueen.x, LightQueen.y, LightQueen);

            Piece LightKnight1 = new Knight();
            LightKnight1.x = DarkKnight1.x;
            LightKnight1.y = 7;
            LightKnight1.name = 'n';
            LightKnight1.color = 'l';
            PiecePlace(LightKnight1.x, LightKnight1.y, LightKnight1);

            Piece LightKnight2 = new Knight();
            LightKnight2.x = DarkKnight2.x;
            LightKnight2.y = 7;
            LightKnight2.name = 'n';
            LightKnight2.color = 'l';
            PiecePlace(LightKnight2.x, LightKnight2.y, LightKnight2);

            Piece LightRook1 = new Rook();
            LightRook1.x = DarkRook1.x;
            LightRook1.y = 7;
            LightRook1.name = 'r';
            LightRook1.color = 'l';
            PiecePlace(LightRook1.x, LightRook1.y, LightRook1);

            Piece LightRook2 = new Rook();
            LightRook2.x = DarkRook2.x;
            LightRook2.y = 7;
            LightRook2.name = 'r';
            LightRook2.color = 'l';
            PiecePlace(LightRook2.x, LightRook2.y, LightRook2);

            Piece LightBishop1 = new Bishop();
            LightBishop1.x = DarkBishop1.x;
            LightBishop1.y = 7;
            LightBishop1.name = 'b';
            LightBishop1.color = 'l';
            PiecePlace(LightBishop1.x, LightBishop1.y, LightBishop1);

            Piece LightBishop2 = new Bishop();
            LightBishop2.x = DarkBishop2.x;
            LightBishop2.y = 7;
            LightBishop2.name = 'b';
            LightBishop2.color = 'l';
            PiecePlace(LightBishop2.x, LightBishop2.y, LightBishop2);
            for (int i = 0; i < 8; i++)
            {
                Piece LightPawn = new Pawn()
                {
                    x = i,
                    y = 6,
                    name = 'p',
                    color = 'l'
                };
                PiecePlace(LightPawn.x, LightPawn.y, LightPawn);
            }            
        }

        public static int GetAbsValue(int num1, int num2) // A method used to get the absolute value of two numbers to make logic simplier.
        {
            int result = 0;
            if (num1 > num2)
            {
                result = num1 - num2;
            }
            else
            {
                result = num2 - num1;
            }
            return result;
        }

        static char c;

        public void AllValidMoves(Piece[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null && lightPlayerTurn == true)
                    {
                        c = board[i, j].color;
                        if (CheckColor(c) == true)
                            Console.WriteLine($"{board[i, j].name}{board[i, j].color}: {board[i, j].x}, {board[i, j].y}");
                    }
                    else if (board[i, j] != null && lightPlayerTurn == false)
                    {
                        c = board[i, j].color;

                        if (CheckColor(c) == false)
                            Console.WriteLine($"{board[i, j].name}{board[i, j].color}: {board[i, j].x}, {board[i, j].y}");
                    }
                }
            }
            Console.ReadLine();
        }

        public bool CheckColor(char c)
        {
            if (c.Equals('l'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool lightPlayerTurn = true; // If true then it is light players turn
                                            // while (gameEnd == false)
                                            //{

        public void ProcessInput(string input) //Reads the file and either place or move pieces as written.
        {
            string Origin;
            string placed;
            bool checkMate = false;
            string movePiece = ("^[a-h][1-8] [a-h][1-8]\\*?$");     //Rexex pattern that will only accept [x axis location][y axis location]
                                                                    //[location on the x axis][location on y axis]
            Match MoveMatch;

            bool captured = false;
            MoveMatch = Regex.Match(input, movePiece, RegexOptions.IgnoreCase);
            if (MoveMatch.Success)
            {
                //Previously, this part of the file read commands for placement of pieces. Since this program is supposed to be without said lines, It was removed
                captured = false;
                //Splits the line in order to gather data on the starting and ending point
                Origin = input.Split(' ')[0];
                placed = input.Split(' ')[1];
                //Checks the end of the line to see if a piece is captured
                if (placed.Substring(placed.Length - 1).Equals("*"))
                {
                    captured = true;
                }
                //If it didn't capture a piece, it simply moves the piece from point a to point b, using methods previously talked about
                if (!captured)
                {
                    int StartX = char.ToUpper(Origin.First<char>()) - 65; //This is set to 65 to make logic easier so that a is equal to 0 instead of one
                    int StartY = int.Parse(Origin.Substring(Origin.Length - 1));
                    int EndX = char.ToUpper(placed.First<char>()) - 65;
                    int EndY = int.Parse(placed.Substring(placed.Length - 1));

                    Piece p = board[StartX, 8 - StartY];
                    if (p == null)
                    {
                        string atemp = ("The space at those cordinates on the board is null");
                        PrintBoard(atemp);
                        Console.ReadLine();
                    }
                    else
                    {
                        if (lightPlayerTurn == true && p.color == 'l')
                        {
                            //lightplayer
                            PieceMove(StartX, 8 - StartY, EndX, 8 - EndY, p, input, p.color);
                        }
                        else if (lightPlayerTurn == false && p.color == 'd')
                        {
                            PieceMove(StartX, 8 - StartY, EndX, 8 - EndY, p, input, p.color);
                            //darkplayer
                        }
                        else
                        {
                            string temp = ("Invalid move: It is currently the other players turn.");
                            PrintBoard(temp);
                            Console.ReadKey();
                        }
                    }
                }
                //If a piece was captured, the parsing for the ending y axis point is moddified to be accepted as the * at the end could cause issues
                else if (captured)
                {
                    int StartX = char.ToUpper(Origin.First<char>()) - 65;
                    int StartY = int.Parse(Origin.Substring(Origin.Length - 1));
                    int EndX = char.ToUpper(placed.First<char>()) - 65;
                    int EndY = int.Parse(placed.Substring(placed.Length - 2, placed.Length - 2));
                    //game.pieceMove(StartX, 8 - StartY, EndX, 8 - EndY);
                    Piece p = board[StartX, 8 - StartY];
                    if (p == null)
                    {
                        Console.WriteLine("The space at those cordinates on the board is null");
                        Console.ReadLine();
                    }
                    else
                    {
                        if (lightPlayerTurn == true && p.color == 'l')
                        {
                            //lightplayer
                            PieceMove(StartX, 8 - StartY, EndX, 8 - EndY, p, input, p.color);
                        }
                        else if (lightPlayerTurn == false && p.color == 'd')
                        {
                            PieceMove(StartX, 8 - StartY, EndX, 8 - EndY, p, input, p.color);
                            //darkplayer
                        }
                        else
                        {
                            string temp = ("Invalid move: It is currently the other players turn.");
                            PrintBoard(temp);
                            Console.ReadKey();
                        }
                    }

                }
                else
                {
                    Console.WriteLine($"Invalid Line: {input}");
                }
            }
            if (checkMate == true)
            {
                gameEnd = true;
            }
        }

        public void PiecePlace(int x, int y, Piece piece) //x and y serving as axis points
        {
            board[x, y] = piece; //Puts the piece at the desired location
        }

        public void PieceMove(int startX, int startY, int endX, int endY, Piece piece, string Move, char Color) //Moves the Piece
        {
            lastPieceMovedColor = Color;
            //Checks if the location has a piece to move
            if (board[startX, startY] != null)
            {

                if (piece.IsValidTest(piece, endX, endY))
                {
                    if (CheckLastPlayerMovement() == 0)
                    {
                        lightPlayerTurn = true;
                    }
                    else
                    {
                        lightPlayerTurn = false;
                    }
                    board[endX, endY] = board[startX, startY]; //changes the value at the end location to what the starting location's value was
                    piece.x = endX;
                    piece.y = endY;
                    piece.TimesMoved = piece.TimesMoved + 1; // Ticks the number of times the piece has moved total in order to only allow one double move for each pawn
                    board[startX, startY] = null; //Empty the space of the starting location so the pieces don't multiply
                    PrintBoard(null);
                    //Console.ReadLine();
                }
                else
                { //prints error if an invalid move was placed.

                    string temp = ($"The move {Move.Split(' ')[0]} to {Move.Split(' ')[1]} is Invalid.");
                    PrintBoard(temp);

                    //Console.ReadLine();
                }
               ;
            }
        }

        public void PrintBoard(string message) //Prints the board
        {
            //Loop to go through the y axis
            Console.Clear();
            Console.WriteLine($"  A B C D E F G H");

            for (int y = 0; y < 8; y++)
            {
                Console.Write($"{8 - y}|");

                //a nested loop to go through the x axis
                for (int x = 0; x < 8; x++)
                {
                    if (board[x, y] == null)
                    {
                        Console.Write("-|"); //If a piece isn't at the location, write a symbol to display the empty space
                    }
                    else
                    {
                        Console.Write($"{board[x, y].name }|"); //If a piece is at the location, show said piece
                    }
                }
                Console.Write($"{8 - y}");
                Console.WriteLine();
            }
            Console.WriteLine($"  A B C D E F G H");
            Console.WriteLine("\n");

            if (message != null)
            {
                Console.WriteLine(message);
            }
        }

        public Piece[,] GetBoard()
        {
            return board;
        }


        public bool ArgCheck(string[] args) //Checks to see if argumetns have been passed through and are valid
        {
            bool valid = false;

            if (args.Length == 0) //Checks if any arguments have been passed through
            {
                Console.WriteLine("Please enter a path to a file");
            }
            else if (!File.Exists(args[0])) //checks if the file is found
            {
                Console.WriteLine("File not found");
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        //if 0 is returned then light player's turn
        //if 1 is returned then dark player's turn
        public int CheckLastPlayerMovement()
        {
            if (lastPieceMovedColor == 'd')
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

    }
}
