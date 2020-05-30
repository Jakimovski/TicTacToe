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
    public partial class FormNewGame : Form
    {
        
        public Game Game { get; set; }
        public bool IsPVP { get; set; }
        public bool IsAIFirst { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public int Difficulty { get; set; }
        public FormNewGame()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
        }

        private void FormNewGame_Load(object sender, EventArgs e)
        {
            buttonStartGame.Enabled = false;
            groupBoxSelectSide.Enabled = false;
        }
        private int GetDifficulty()
        {
            if (radioButtonEasy.Checked)
            {
                return 1;
            }
            if (radioButtonMedium.Checked)
            {
                return 2;
            }
            return 3;
        }
        private void radioButtonComputer_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonComputer.Checked)
            {
                groupBoxNames.Enabled = false;
                groupBoxSelectSide.Enabled = true;
                if (radioButtonPlayX.Checked || radioButtonPlayO.Checked)
                {
                    groupBoxDifficulty.Enabled = true;
                    if(radioButtonEasy.Checked || radioButtonMedium.Checked || radioButtonHard.Checked)
                    {
                        buttonStartGame.Enabled = true;
                    }
                }
                else
                {
                    buttonStartGame.Enabled = false;
                }

            }
            else
            {
                groupBoxSelectSide.Enabled = false;
                buttonStartGame.Enabled = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            if (radioButtonPlayer.Checked)
            {
                IsPVP = true;
                IsAIFirst = false;
                Player1 = textBoxPlayer1.Text;
                Player2 = textBoxPlayer2.Text;
            }
            else if (radioButtonComputer.Checked && radioButtonPlayX.Checked)
            {
                IsPVP = false;
                IsAIFirst = false;
                Player1 = "Player";
                Player2 = "Computer";
                Difficulty = GetDifficulty();
            }
            else if(radioButtonComputer.Checked && radioButtonPlayO.Checked)
            {
                IsPVP = false;
                IsAIFirst = true;
                Player1 = "Computer";
                Player2 = "Player";
                Difficulty = GetDifficulty();
            }
            DialogResult = DialogResult.OK;
        }

        private void radioButtonPlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPlayer.Checked)
            {
                groupBoxNames.Enabled = true;
                groupBoxSelectSide.Enabled = false;
                groupBoxDifficulty.Enabled = false;
                if(textBoxPlayer1.Text != null && textBoxPlayer1.Text != "" && textBoxPlayer2.Text != null && textBoxPlayer2.Text != "")
                {
                    buttonStartGame.Enabled = true;
                }
            }
            else
            {
                buttonStartGame.Enabled = false;
                groupBoxNames.Enabled = false;
                groupBoxSelectSide.Enabled = true;
            }
        }

        private void radioButtonPlayX_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDifficulty.Enabled = true;
            
            
        }

        private void radioButtonPlayO_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDifficulty.Enabled = true;
            
            
        }

        private void textBoxPlayer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxPlayer1.Text.Length > 0 && textBoxPlayer2.Text.Length > 0)
            {
                buttonStartGame.Enabled = true;
            }
            else
            {
                buttonStartGame.Enabled = false;
            }
        }

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPlayer1.Text.Length > 0 && textBoxPlayer2.Text.Length > 0)
            {
                buttonStartGame.Enabled = true;
            }
            else
            {
                buttonStartGame.Enabled = false;
            }
        }

        private void radioButtonEasy_CheckedChanged(object sender, EventArgs e)
        {
            buttonStartGame.Enabled = true;
        }

        private void radioButtonMedium_CheckedChanged(object sender, EventArgs e)
        {
            buttonStartGame.Enabled = true;
        }

        private void radioButtonHard_CheckedChanged(object sender, EventArgs e)
        {
            buttonStartGame.Enabled = true;
        }
    }
}
