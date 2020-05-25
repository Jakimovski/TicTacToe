namespace TicTacToe
{
    partial class FormCustomizeBoard
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
            this.panelX = new System.Windows.Forms.Panel();
            this.panelO = new System.Windows.Forms.Panel();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelX
            // 
            this.panelX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelX.Location = new System.Drawing.Point(196, 50);
            this.panelX.Name = "panelX";
            this.panelX.Size = new System.Drawing.Size(40, 40);
            this.panelX.TabIndex = 1;
            this.panelX.Click += new System.EventHandler(this.panelX_Click);
            this.panelX.MouseEnter += new System.EventHandler(this.panelX_MouseEnter);
            this.panelX.MouseLeave += new System.EventHandler(this.panelX_MouseLeave);
            // 
            // panelO
            // 
            this.panelO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelO.Location = new System.Drawing.Point(196, 111);
            this.panelO.Name = "panelO";
            this.panelO.Size = new System.Drawing.Size(40, 40);
            this.panelO.TabIndex = 3;
            this.panelO.Click += new System.EventHandler(this.panelO_Click);
            this.panelO.MouseEnter += new System.EventHandler(this.panelO_MouseEnter);
            this.panelO.MouseLeave += new System.EventHandler(this.panelO_MouseLeave);
            // 
            // panelBoard
            // 
            this.panelBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBoard.Location = new System.Drawing.Point(196, 171);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(40, 40);
            this.panelBoard.TabIndex = 5;
            this.panelBoard.Click += new System.EventHandler(this.panelBoard_Click);
            this.panelBoard.MouseEnter += new System.EventHandler(this.panelBoard_MouseEnter);
            this.panelBoard.MouseLeave += new System.EventHandler(this.panelBoard_MouseLeave);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(49, 272);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(103, 36);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save Changes";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(166, 272);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 36);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "X Color:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "O Color:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Board Color:";
            // 
            // FormCustomizeBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 343);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.panelBoard);
            this.Controls.Add(this.panelO);
            this.Controls.Add(this.panelX);
            this.Name = "FormCustomizeBoard";
            this.Text = "Customize Board";
            this.Load += new System.EventHandler(this.FormCustomizeBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelX;
        private System.Windows.Forms.Panel panelO;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}