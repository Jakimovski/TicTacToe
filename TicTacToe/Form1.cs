using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Game game;
        Score score;
        int x, y;
        private bool playing;
        private bool isPVP;
        private bool isAIFirst;

        public Color ColorX { get; set; } = Color.Black;
        public Color ColorO { get; set; } = Color.Black;
        public Color ColorBoard { get; set; } = Color.Black;
        public int Difficulty { get; set; }
        public Form1()
        {
            x = y = -1;
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Width = 600;
            this.Height = 440;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            playing = false;
            labelScore.Text = "";
            labelStatus.Text = "No game in progress.";
            //game = new Game(false, true);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Game.DrawBoard(e.Graphics);
            if (game != null || playing)
            {
                game.DrawAll(e.Graphics);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.x = e.X;
            this.y = e.Y;
            if (playing)
            {
                game.Hover(e.X, e.Y);
                Invalidate();
            }
        }

        

        private void Form1_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                game.AddPlay(x, y);
                UpdateTurnStatus();
                Invalidate();
                CheckWin();
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            FormNewGame formNewGame = new FormNewGame();
            
            if(formNewGame.ShowDialog() == DialogResult.OK)
            {
                isPVP = formNewGame.IsPVP;
                isAIFirst = formNewGame.IsAIFirst;
                Difficulty = formNewGame.Difficulty;
                game = new Game(formNewGame.IsPVP, formNewGame.IsAIFirst, formNewGame.Difficulty);
                score = new Score(formNewGame.Player1, formNewGame.Player2);
                labelScore.Text = score.ToString();
                groupBoxScore.Visible = true;
                playing = true;
                UpdateTurnStatus();
                Invalidate();
            }
        }
        private void UpdateTurnStatus()
        {
            string status = "";
            if (playing)
            {
                if (isPVP)
                {
                    if (game.XTurn)
                    {
                        status = string.Format("{0}'s turn", score.GetXInCurrentGame());
                    }
                    else
                    {
                        status = string.Format("{0}'s turn", score.GetOInCurrentGame());
                    }
                }
                else
                {
                    status = "Player's turn";
                }
            }
            labelStatus.Text = status;
        }

        private void UpdateColors()
        {
            Game.ColorX = ColorX;
            Game.ColorO = ColorO;
            Game.ColorBoard = ColorBoard;
            if(game != null)
            {
                game.UpdatePlaysColors();
            }
        }

        private void buttonCustomize_Click(object sender, EventArgs e)
        {
            FormCustomizeBoard formCustomizeBoard = new FormCustomizeBoard(ColorX, ColorO, ColorBoard);

            if(formCustomizeBoard.ShowDialog() == DialogResult.OK)
            {
                ColorX = formCustomizeBoard.ColorX;
                ColorO = formCustomizeBoard.ColorO;
                ColorBoard = formCustomizeBoard.ColorBoard;

                UpdateColors();
                Invalidate();
            }
        }

        private void CheckWin()
        {
            
            if (game.Over)
            {
                string message = "";
                playing = false;
                if (game.Winner.Equals('X'))
                {
                    message = string.Format("{0} wins!", score.GetXInCurrentGame());
                    score.AddWinner('X');
                }
                else if (game.Winner.Equals('O'))
                {
                    message = string.Format("{0} wins!", score.GetOInCurrentGame());
                    score.AddWinner('O');
                }
                else
                {
                    message = "Draw!";
                    score.AddWinner('T');
                }
                labelScore.Text = score.ToString();
                UpdateTurnStatus();
                DialogResult result = MessageBox.Show("Rematch?", message, MessageBoxButtons.YesNo);
                
                if(result == DialogResult.Yes)
                {
                    
                    isAIFirst = !isAIFirst;
                    game = new Game(isPVP, isAIFirst, Difficulty);
                    playing = true;
                    UpdateTurnStatus();
                }
                else
                {
                    game = null;
                    string status = "";
                    if(score.PointsP1 > score.PointsP2)
                    {
                        status = string.Format("Game over. {0} wins!", score.Player1);
                    }
                    else if(score.PointsP1 < score.PointsP2)
                    {
                        status = string.Format("Game over. {0} wins!", score.Player2);
                    }
                    else
                    {
                        status = string.Format("Game over. No winner.");
                    }
                    labelStatus.Text = status;
                }

                Invalidate();
            }
        }

        
    }
}
