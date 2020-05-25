using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Score
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public double PointsP1 { get; set; }
        public double PointsP2 { get; set; }
        public List<char> Winners { get; set; }

        public Score(string player1, string player2)
        {
            Player1 = player1;
            Player2 = player2;
            PointsP1 = 0;
            PointsP2 = 0;
            Winners = new List<char>();
        }

        public void AddWinner(char winner)
        {
            Winners.Add(winner);
            CalculateScore();
        }
        public string GetXInCurrentGame()
        {
            if(Winners.Count % 2 == 0)
            {
                return Player1;
            }
            else
            {
                return Player2;
            }
        }
        public string GetOInCurrentGame()
        {
            if (Winners.Count % 2 != 0)
            {
                return Player1;
            }
            else
            {
                return Player2;
            }
        }
        private void CalculateScore()
        {
            double p1 = 0, p2 = 0;
            for(int i=0; i<Winners.Count; i++)
            {
                if (Winners[i].Equals('X'))
                {
                    if (i % 2 == 0)
                    {
                        p1 += 1;
                    }
                    else
                    {
                        p2 += 1;
                    }
                }
                else if (Winners[i].Equals('O'))
                {
                    if (i % 2 == 0)
                    {
                        p2 += 1;
                    }
                    else
                    {
                        p1 += 1;
                    }
                }
                else
                {
                    p1 += 0.5;
                    p2 += 0.5;
                }
            }
            PointsP1 = p1;
            PointsP2 = p2;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}\n{2}: {3}", Player1, Math.Round(PointsP1, 1).ToString(), Player2, Math.Round(PointsP2, 1).ToString());
        }

    }
}
