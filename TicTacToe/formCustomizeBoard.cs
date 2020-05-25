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
    public partial class FormCustomizeBoard : Form
    {
        public Color ColorX { get; set; }
        public Color ColorO { get; set; }
        public Color ColorBoard { get; set; }
        public FormCustomizeBoard(Color colorX, Color colorO, Color colorBoard)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ColorX = colorX;
            ColorO = colorO;
            ColorBoard = colorBoard;

            InitializeComponent();
        }


        private void buttonColorX_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorX = colorDialog.Color;
                panelX.BackColor = ColorX;
            }
        }

        private void buttonColorO_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorO = colorDialog.Color;
                panelO.BackColor = ColorO;
            }
        }

        private void buttonColorBoard_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorBoard = colorDialog.Color;
                panelBoard.BackColor = ColorBoard;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FormCustomizeBoard_Load(object sender, EventArgs e)
        {

            panelX.BackColor = ColorX;
            panelO.BackColor = ColorO;
            panelBoard.BackColor = ColorBoard;
        }

        private void panelX_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorX = colorDialog.Color;
                panelX.BackColor = ColorX;
            }
        }

        private void panelO_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorO = colorDialog.Color;
                panelO.BackColor = ColorO;
            }
        }

        private void panelBoard_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorBoard = colorDialog.Color;
                panelBoard.BackColor = ColorBoard;
            }
        }

        private void panelX_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void panelX_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panelO_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panelO_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void panelBoard_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panelBoard_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}
