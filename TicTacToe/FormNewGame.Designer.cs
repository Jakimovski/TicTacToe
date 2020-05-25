namespace TicTacToe
{
    partial class FormNewGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonPlayer = new System.Windows.Forms.RadioButton();
            this.radioButtonComputer = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxSelectSide = new System.Windows.Forms.GroupBox();
            this.radioButtonPlayO = new System.Windows.Forms.RadioButton();
            this.radioButtonPlayX = new System.Windows.Forms.RadioButton();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxNames = new System.Windows.Forms.GroupBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxSelectSide.SuspendLayout();
            this.groupBoxNames.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonPlayer
            // 
            this.radioButtonPlayer.AutoSize = true;
            this.radioButtonPlayer.Location = new System.Drawing.Point(30, 37);
            this.radioButtonPlayer.Name = "radioButtonPlayer";
            this.radioButtonPlayer.Size = new System.Drawing.Size(100, 17);
            this.radioButtonPlayer.TabIndex = 1;
            this.radioButtonPlayer.TabStop = true;
            this.radioButtonPlayer.Text = "Player vs Player";
            this.radioButtonPlayer.UseVisualStyleBackColor = true;
            this.radioButtonPlayer.CheckedChanged += new System.EventHandler(this.radioButtonPlayer_CheckedChanged);
            // 
            // radioButtonComputer
            // 
            this.radioButtonComputer.AutoSize = true;
            this.radioButtonComputer.Location = new System.Drawing.Point(232, 37);
            this.radioButtonComputer.Name = "radioButtonComputer";
            this.radioButtonComputer.Size = new System.Drawing.Size(116, 17);
            this.radioButtonComputer.TabIndex = 2;
            this.radioButtonComputer.TabStop = true;
            this.radioButtonComputer.Text = "Player vs Computer";
            this.radioButtonComputer.UseVisualStyleBackColor = true;
            this.radioButtonComputer.CheckedChanged += new System.EventHandler(this.radioButtonComputer_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonComputer);
            this.groupBox1.Controls.Add(this.radioButtonPlayer);
            this.groupBox1.Location = new System.Drawing.Point(43, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 88);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Mode";
            // 
            // groupBoxSelectSide
            // 
            this.groupBoxSelectSide.Controls.Add(this.radioButtonPlayO);
            this.groupBoxSelectSide.Controls.Add(this.radioButtonPlayX);
            this.groupBoxSelectSide.Location = new System.Drawing.Point(250, 162);
            this.groupBoxSelectSide.Name = "groupBoxSelectSide";
            this.groupBoxSelectSide.Size = new System.Drawing.Size(202, 104);
            this.groupBoxSelectSide.TabIndex = 4;
            this.groupBoxSelectSide.TabStop = false;
            this.groupBoxSelectSide.Text = "Select Side";
            // 
            // radioButtonPlayO
            // 
            this.radioButtonPlayO.AutoSize = true;
            this.radioButtonPlayO.Location = new System.Drawing.Point(30, 64);
            this.radioButtonPlayO.Name = "radioButtonPlayO";
            this.radioButtonPlayO.Size = new System.Drawing.Size(70, 17);
            this.radioButtonPlayO.TabIndex = 1;
            this.radioButtonPlayO.TabStop = true;
            this.radioButtonPlayO.Text = "Play as O";
            this.radioButtonPlayO.UseVisualStyleBackColor = true;
            this.radioButtonPlayO.CheckedChanged += new System.EventHandler(this.radioButtonPlayO_CheckedChanged);
            // 
            // radioButtonPlayX
            // 
            this.radioButtonPlayX.AutoSize = true;
            this.radioButtonPlayX.Location = new System.Drawing.Point(30, 38);
            this.radioButtonPlayX.Name = "radioButtonPlayX";
            this.radioButtonPlayX.Size = new System.Drawing.Size(69, 17);
            this.radioButtonPlayX.TabIndex = 0;
            this.radioButtonPlayX.TabStop = true;
            this.radioButtonPlayX.Text = "Play as X";
            this.radioButtonPlayX.UseVisualStyleBackColor = true;
            this.radioButtonPlayX.CheckedChanged += new System.EventHandler(this.radioButtonPlayX_CheckedChanged);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartGame.Location = new System.Drawing.Point(73, 310);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(145, 48);
            this.buttonStartGame.TabIndex = 5;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(281, 310);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(145, 48);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxNames
            // 
            this.groupBoxNames.Controls.Add(this.label2);
            this.groupBoxNames.Controls.Add(this.label1);
            this.groupBoxNames.Controls.Add(this.textBoxPlayer2);
            this.groupBoxNames.Controls.Add(this.textBoxPlayer1);
            this.groupBoxNames.Location = new System.Drawing.Point(43, 162);
            this.groupBoxNames.Name = "groupBoxNames";
            this.groupBoxNames.Size = new System.Drawing.Size(202, 104);
            this.groupBoxNames.TabIndex = 5;
            this.groupBoxNames.TabStop = false;
            this.groupBoxNames.Text = "Player Names";
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(76, 37);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayer1.TabIndex = 0;
            this.textBoxPlayer1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPlayer1_KeyPress);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Location = new System.Drawing.Point(76, 63);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayer2.TabIndex = 1;
            this.textBoxPlayer2.TextChanged += new System.EventHandler(this.textBoxPlayer2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player 2:";
            // 
            // FormNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 380);
            this.Controls.Add(this.groupBoxNames);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.groupBoxSelectSide);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormNewGame";
            this.Text = "Start new game";
            this.Load += new System.EventHandler(this.FormNewGame_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxSelectSide.ResumeLayout(false);
            this.groupBoxSelectSide.PerformLayout();
            this.groupBoxNames.ResumeLayout(false);
            this.groupBoxNames.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButtonPlayer;
        private System.Windows.Forms.RadioButton radioButtonComputer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxSelectSide;
        private System.Windows.Forms.RadioButton radioButtonPlayO;
        private System.Windows.Forms.RadioButton radioButtonPlayX;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxNames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1;
    }
}