using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        /// <summary>
        /// Colors used for drawing
        /// </summary>
        public static Color ColorBoard { get; set; } = Color.Black;
        public static Color ColorX { get; set; } = Color.Black;
        public static Color ColorO { get; set; } = Color.Black;
        /// <summary>
        /// Current game board
        /// </summary>
        public char[,] Board { get; set; }
        /// <summary>
        /// Is X's turn
        /// </summary>
        public bool XTurn { get; set; }
        /// <summary>
        /// Stores objects from PlayX and PlayO classes (used for drawing)
        /// </summary>
        public List<IPlay> Plays { get; set; }
        /// <summary>
        /// Winner of the game
        /// Possible values: 'X', 'O' and 'T' for tie
        /// </summary>
        public char Winner { get; set; }
        /// <summary>
        /// Is the game mode player vs player
        /// </summary>
        public bool PVP { get; set; }
        /// <summary>
        /// Is AI playing as X
        /// </summary>
        public bool AIFirstMove { get; set; }
        /// <summary>
        /// Is the game over
        /// </summary>
        public bool Over { get; set; }
        /// <summary>
        /// Stores an object (PlayX or PlayO)
        /// Used for drawing on a hovered square (if it's available)
        /// </summary>
        public IPlay Hovered { get; set; }
        /// <summary>
        /// Difficulty of the game
        /// 1 - Easy, 2 - Medium, 3 - Hard
        /// </summary>
        public int Difficullty { get; set; }
        
        private char player1 = 'X';
        private char player2 = 'O';
        /// <summary>
        /// scores used in Minimax (assuming AI is playing as O, if AI is playing as X scoreX=10, scoreO=-10)
        /// </summary>
        private float scoreX = -10;
        private float scoreO = 10;
        private float scoreTie = 0;
        /// <summary>
        /// used in Minimax to generate random depth (for medium difficulty only)
        /// </summary>
        private static Random random = new Random();

        public Game(bool Pvp, bool AiFirstMove, int difficulty)
        {
            Board = new char[3, 3];
            XTurn = true;
            Plays = new List<IPlay>();
            Over = false;
            PVP = Pvp;
            AIFirstMove = AiFirstMove;
            Hovered = null;
            Difficullty = difficulty;
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    Board[i, j] = ' ';
                }
            }
            if (!PVP)
            {
                if (AIFirstMove)
                {
                    player2 = 'X';
                    player1 = 'O';
                    scoreX = 10;
                    scoreO = -10;
                    if(Difficullty < 2)
                    {
                        RandomMove();
                    }
                    else
                    {
                        AIMove();
                    }
                }
            }
        }
        
        public static void DrawBoard(Graphics g)
        {
            Pen pen = new Pen(ColorBoard, 4);

            g.DrawLine(pen, 20, 20, 380, 20);
            g.DrawLine(pen, 20, 140, 380, 140);
            g.DrawLine(pen, 20, 260, 380, 260);
            g.DrawLine(pen, 20, 380, 380, 380);

            g.DrawLine(pen, 20, 18, 20, 382);
            g.DrawLine(pen, 140, 20, 140, 380);
            g.DrawLine(pen, 260, 20, 260, 380);
            g.DrawLine(pen, 380, 18, 380, 382);

            pen.Dispose();
        }
        public void AddPlay(int x, int y)
        {
            Point point = GetDrawingPoint(x,y);
            if(point != Point.Empty)//Clicked on board (valid click)
            {
                int[] coordinates = GetBoardCoordinates(x, y);
                if (!Over)//Game is not over
                {
                    if (Board[coordinates[0], coordinates[1]].Equals(' '))//Clicked spot is empty
                    {
                        if (XTurn)
                        {
                            Plays.Add(new PlayX(point, coordinates[0], coordinates[1], ColorX));
                        }
                        else
                        {
                            
                            Plays.Add(new PlayO(point, coordinates[0], coordinates[1], ColorO));
                            
                            
                        }

                        AddToBoard(coordinates[0], coordinates[1]);
                        WinCheck();
                        if (!PVP && !Over)
                        {
                            if (Difficullty < 2)
                            {
                                RandomMove();
                            }
                            else
                            {
                                AIMove();
                            }

                        }
                        WinCheck();
                        if (!Over)
                        {
                            XTurn = !XTurn;
                        }
                    }
                }
            }
        }
        public void AddToBoard(int i, int j)
        {
            if (XTurn)
            {
                Board[i, j] = 'X';
            }
            else
            {
                Board[i, j] = 'O';
            }
        }

        public void Hover(int x, int y)
        {
            if (IsHoveringBoard(x, y) && !GetDrawingPoint(x,y).Equals(Point.Empty))
            {
                int[] boardCoordinates = GetBoardCoordinates(x, y);
                if (Hovered != null)
                {

                    int hoverI = Hovered.GetCoordinates()[0];
                    int hoverJ = Hovered.GetCoordinates()[1];
                    if (boardCoordinates[0] != hoverI || boardCoordinates[1] != hoverJ)
                    {
                        Hovered = null;
                    }
                }


                if (Hovered == null && Board[boardCoordinates[0], boardCoordinates[1]].Equals(' '))
                {
                    Point point = GetDrawingPoint(x, y);
                    if (XTurn)
                    {
                        Hovered = new PlayX(point, boardCoordinates[0], boardCoordinates[1], Color.LightGray);
                    }
                    else
                    {
                        Hovered = new PlayO(point, boardCoordinates[0], boardCoordinates[1], Color.LightGray);
                    }

                }
            }
            else
            {
                Hovered = null;
            }
        }
        public Point GetDrawingPoint(int x, int y)
        {
            //returns the drawing point based on the click coordinates
            if (x > 20 && y > 20 && x < 380 && y < 380)
            {
                if (x > 20 && y > 20 && x < 140 && y < 140)
                {
                    return new Point(80, 80);
                }
                else if (x > 140 && y > 20 && x < 260 && y < 140)
                {
                    return new Point(200, 80);
                }
                else if (x > 260 && y > 20 && x < 380 && y < 140)
                {
                    return new Point(320, 80);
                }
                else if (x > 20 && y > 140 && x < 140 && y < 260)
                {
                    return new Point(80, 200);
                }
                else if (x > 140 && y > 140 && x < 260 && y < 260)
                {
                    return new Point(200, 200);
                }
                else if (x > 260 && y > 140 && x < 380 && y < 260)
                {
                    return new Point(320, 200);
                }
                else if (x > 20 && y > 260 && x < 140 && y < 380)
                {
                    return new Point(80, 320);
                }
                else if (x > 140 && y > 260 && x < 260 && y < 380)
                {
                    return new Point(200, 320);
                }
                else if (x > 260 && y > 260 && x < 380 && y < 380)
                {
                    return new Point(320, 320);
                }
            }
            return Point.Empty;
        }
        private bool WinCheck()
        {
            for(int i=0; i<3; i++)
            {
                if(!Board[0,i].Equals(' '))
                {
                    if(Board[0,i].Equals(Board[1,i]) && Board[0, i].Equals(Board[2, i]))
                    {
                        Winner = Board[0, i];
                        Over = true;
                        return true;
                    }
                }
                if(!Board[i,0].Equals(' '))
                {
                    if (Board[i, 0].Equals(Board[i, 1]) && Board[i, 0].Equals(Board[i, 2]))
                    {
                        Winner = Board[i, 0];
                        Over = true;
                        return true;
                    }
                }
            }
            if(!Board[0,0].Equals(' '))
            {
                if(Board[0,0].Equals(Board[1,1]) && Board[0, 0].Equals(Board[2, 2]))
                {
                    Winner = Board[0, 0];
                    Over = true;
                    return true;
                }
            }
            if (!Board[0, 2].Equals(' '))
            {
                if (Board[0, 2].Equals(Board[1, 1]) && Board[0, 2].Equals(Board[2, 0]))
                {
                    Winner = Board[0, 2];
                    Over = true;
                    return true;
                }
            }
            if (Plays.Count == 9)
            {
                Winner = 'T';
                Over = true;
                for(int i=0; i < 3; i++)
                {
                    for(int j=0; j < 3; j++)
                    {
                        if(Board[i,j].Equals(' '))
                        {
                            Over = false;
                            Winner = ' ';
                        }
                    }
                }
            }
            return false;
        }
        private char GetResult()
        {
            for (int i = 0; i < 3; i++)
            {
                if (!Board[0, i].Equals(' '))
                {
                    if (Board[0, i].Equals(Board[1, i]) && Board[0, i].Equals(Board[2, i]))
                    {
                        
                        return Board[0, i];
                    }
                }
                if (!Board[i, 0].Equals(' '))
                {
                    if (Board[i, 0].Equals(Board[i, 1]) && Board[i, 0].Equals(Board[i, 2]))
                    {
                        return Board[i, 0];
                    }
                }
            }
            if (!Board[0, 0].Equals(' '))
            {
                if (Board[0, 0].Equals(Board[1, 1]) && Board[0, 0].Equals(Board[2, 2]))
                {
                    return Board[0, 0];
                }
            }
            if (!Board[0, 2].Equals(' '))
            {
                if (Board[0, 2].Equals(Board[1, 1]) && Board[0, 2].Equals(Board[2, 0]))
                {
                    return Board[0, 2];
                }
            }
            char result = 'T';
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j].Equals(' '))
                    {
                        result = '/';
                    }
                }
            }
            return result;
        }
        public bool IsHoveringBoard(int x, int y)
        {
            if(x > 20 && y > 20 && x < 380 && y < 380)
            {
                return true;
            }
            return false;
        }
        public int[] GetBoardCoordinates(int x, int y)
        {
            //returns the board coordinates based on the click coordinates
            int[] coordinates = new int[2];
            if (x > 20 && y > 20 && x < 380 && y < 380)
            {
                if (x > 20 && y > 20 && x < 140 && y < 140)
                {
                    coordinates[0] = 0;
                    coordinates[1] = 0;
                }
                else if (x > 140 && y > 20 && x < 260 && y < 140)
                {
                    coordinates[0] = 0;
                    coordinates[1] = 1;
                }
                else if (x > 260 && y > 20 && x < 380 && y < 140)
                {
                    coordinates[0] = 0;
                    coordinates[1] = 2;
                }
                else if (x > 20 && y > 140 && x < 140 && y < 260)
                {
                    coordinates[0] = 1;
                    coordinates[1] = 0;
                }
                else if (x > 140 && y > 140 && x < 260 && y < 260)
                {
                    coordinates[0] = 1;
                    coordinates[1] = 1;
                }
                else if (x > 260 && y > 140 && x < 380 && y < 260)
                {
                    coordinates[0] = 1;
                    coordinates[1] = 2;
                }
                else if (x > 20 && y > 260 && x < 140 && y < 380)
                {
                    coordinates[0] = 2;
                    coordinates[1] = 0;
                }
                else if (x > 140 && y > 260 && x < 260 && y < 380)
                {
                    coordinates[0] = 2;
                    coordinates[1] = 1;
                }
                else if (x > 260 && y > 260 && x < 380 && y < 380)
                {
                    coordinates[0] = 2;
                    coordinates[1] = 2;
                }
            }
            return coordinates;
        }
        public int[] GetDrawingCoordinates(int i, int j)
        {
            //returns drawing coordinates based on the coordinates on the board
            int[] coordinates = new int[2];

            if (i == 0)
            {
                if (j == 0)
                {
                    coordinates[0] = 80;
                    coordinates[1] = 80;
                }
                else if (j == 1)
                {
                    coordinates[0] = 200;
                    coordinates[1] = 80;
                }
                else
                {
                    coordinates[0] = 320;
                    coordinates[1] = 80;
                }
            }
            else if (i == 1)
            {
                if (j == 0)
                {
                    coordinates[0] = 80;
                    coordinates[1] = 200;
                }
                else if (j == 1)
                {
                    coordinates[0] = 200;
                    coordinates[1] = 200;
                }
                else
                {
                    coordinates[0] = 320;
                    coordinates[1] = 200;
                }
            }
            else
            {
                if (j == 0)
                {
                    coordinates[0] = 80;
                    coordinates[1] = 320;
                }
                else if (j == 1)
                {
                    coordinates[0] = 200;
                    coordinates[1] = 320;
                }
                else
                {
                    coordinates[0] = 320;
                    coordinates[1] = 320;
                }
            }
            return coordinates;
        }

        public void RandomMove()
        {
            int i = 0, j = 0;
            while (true)
            {
                i = random.Next(3);
                j = random.Next(3);
                if(Board[i,j].Equals(' '))
                {
                    Board[i, j] = player2;
                    break;
                }
            }
            int[] drawingCoordinates = GetDrawingCoordinates(i, j);
            Point point = new Point(drawingCoordinates[0], drawingCoordinates[1]);
            if (player2.Equals('X'))
            {
                Plays.Add(new PlayX(point, i, j, ColorX));
            }
            else
            {
                Plays.Add(new PlayO(point, i, j, ColorO));
            }
            XTurn = !XTurn;
        }
        public void AIMove()
        {
            float bestScore = float.NegativeInfinity;
            int moveI = -1, moveJ = -1;
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    if (Board[i,j].Equals(' '))
                    {
                        
                        Board[i, j] = player2;
                        float score = Minimax(Board, 0, false, float.NegativeInfinity, float.PositiveInfinity);

                        Board[i,j] = ' ';
                        if(score > bestScore)
                        {
                            bestScore = score;
                            moveI = i;
                            moveJ = j;
                        }
                    }
                }
            }
            int[] drawingCoordinates = GetDrawingCoordinates(moveI, moveJ);
            Point point = new Point(drawingCoordinates[0], drawingCoordinates[1]);

            Board[moveI, moveJ] = player2;
            
            if (player2.Equals('X'))
            {
                Plays.Add(new PlayX(point, moveI, moveJ, ColorX));
            }
            else
            {
                Plays.Add(new PlayO(point, moveI, moveJ, ColorO));
            }
            XTurn = !XTurn;
        }
        
        public float Minimax(char[,] board, int depth, bool isMaximizing, float alpha, float beta)
        {
            char result = GetResult();

            if (!result.Equals('/'))
            {
                if (result.Equals('X'))
                {
                    return scoreX;
                }else if (result.Equals('O'))
                {
                    return scoreO;
                }
                else
                {
                    return scoreTie;
                }
            }

            if (isMaximizing)
            {
                float bestScore = float.NegativeInfinity;

                for(int i=0; i<3; i++)
                {
                    for(int j=0; j<3; j++)
                    {
                        if (Board[i, j].Equals(' '))
                        {
                            Board[i, j] = player2;
                            float score = Minimax(Board, depth + 1, false, alpha, beta);
                            Board[i, j] = ' ';
                            bestScore = Math.Max(score, bestScore);
                            alpha = Math.Max(alpha, bestScore);
                            if(Difficullty == 2 && depth == random.Next(1,5))//Medium difficulty
                            {
                                return bestScore;
                            }
                            if(beta <= alpha)
                            {
                                break;
                            }
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                float bestScore = float.PositiveInfinity;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Board[i, j].Equals(' '))
                        {
                            Board[i, j] = player1;
                            float score = Minimax(Board, depth + 1, true, alpha, beta);
                            Board[i, j] = ' ';
                            bestScore = Math.Min(score, bestScore);
                            beta = Math.Min(beta, bestScore);
                            if (this.Difficullty == 2 && depth == random.Next(1,5))//Medium difficulty
                            {
                                return bestScore;
                                
                            }
                            if (beta <= alpha)
                            {
                                break;
                            }
                        }
                    }
                }
                return bestScore;
            }


        }
        
        public void DrawAll(Graphics g)
        {
            if (Hovered != null)
            {
                Hovered.Draw(g);
            }
            foreach (IPlay play in Plays)
            {
                play.Draw(g);
            }
            
        }
        public void UpdatePlaysColors()
        {
            foreach(IPlay play in Plays)
            {
                if (Board[play.GetCoordinates()[0], play.GetCoordinates()[1]].Equals('X'))
                {
                    play.Color = ColorX;
                }
                else
                {
                    play.Color = ColorO;
                }
            }
        }
    }
}
