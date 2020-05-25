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
        public static Color ColorBoard { get; set; } = Color.Black;
        public static Color ColorX { get; set; } = Color.Black;
        public static Color ColorO { get; set; } = Color.Black;
        public char[,] Board { get; set; }
        public bool XTurn { get; set; }
        public List<IPlay> Plays { get; set; }
        public char Winner { get; set; }
        public char player1 = 'X';
        public char player2 = 'O';
        public bool PVP { get; set; }
        public bool AIFirstMove { get; set; }
        public bool Over { get; set; }

        private float scoreX = -10;
        private float scoreO = 10;
        private float scoreTie = 0;

        public IPlay Hovered { get; set; }

        public Game(bool Pvp, bool AiFirstMove)
        {
            Board = new char[3, 3];
            XTurn = true;
            Plays = new List<IPlay>();
            Over = false;
            PVP = Pvp;
            AIFirstMove = AiFirstMove;
            
            for(int i=0; i<3; i++)
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
                    BestMove();
                }
            }
            Hovered = null;
        }
        public string BoardToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sb.Append(Board[i, j] + " ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
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
                            BestMove();
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
        public bool WinCheck()
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
        public char GetResult()
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

        
        public void BestMove()
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
                        float score = Minimax(Board, 0, false);

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
        
        public float Minimax(char[,] board, int depth, bool isMaximizing)
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
                            float score = Minimax(Board, depth + 1, false);
                            Board[i, j] = ' ';
                            bestScore = Math.Max(score, bestScore);
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
                            float score = Minimax(Board, depth + 1, true);
                            Board[i, j] = ' ';
                            bestScore = Math.Min(score, bestScore);
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
