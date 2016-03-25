namespace TicTacToeApplication
{
    partial class StartWindow
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
            this.pbCross = new System.Windows.Forms.PictureBox();
            this.pbCircle = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.lblUsers = new System.Windows.Forms.Label();
            this.chbUser = new System.Windows.Forms.CheckBox();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.chbMachine = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCircle)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCross
            // 
            this.pbCross.BackgroundImage = global::TicTacToeApplication.Properties.Resources.cross;
            this.pbCross.Location = new System.Drawing.Point(26, 108);
            this.pbCross.Name = "pbCross";
            this.pbCross.Size = new System.Drawing.Size(100, 100);
            this.pbCross.TabIndex = 0;
            this.pbCross.TabStop = false;
            this.pbCross.Click += new System.EventHandler(this.pbCross_Click);
            // 
            // pbCircle
            // 
            this.pbCircle.BackgroundImage = global::TicTacToeApplication.Properties.Resources.circle;
            this.pbCircle.Location = new System.Drawing.Point(153, 108);
            this.pbCircle.Name = "pbCircle";
            this.pbCircle.Size = new System.Drawing.Size(100, 100);
            this.pbCircle.TabIndex = 1;
            this.pbCircle.TabStop = false;
            this.pbCircle.Click += new System.EventHandler(this.pbCircle_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.btnStart.Location = new System.Drawing.Point(26, 219);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(146, 31);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Jogar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Location = new System.Drawing.Point(178, 219);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 31);
            this.btnEnd.TabIndex = 3;
            this.btnEnd.Text = "Sair";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblUsers.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.lblUsers.ForeColor = System.Drawing.Color.White;
            this.lblUsers.Location = new System.Drawing.Point(23, 9);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(246, 16);
            this.lblUsers.TabIndex = 4;
            this.lblUsers.Text = "Jogador que ira comecar a partida:";
            // 
            // chbUser
            // 
            this.chbUser.AutoSize = true;
            this.chbUser.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUser.ForeColor = System.Drawing.Color.Black;
            this.chbUser.Location = new System.Drawing.Point(26, 39);
            this.chbUser.Name = "chbUser";
            this.chbUser.Size = new System.Drawing.Size(77, 19);
            this.chbUser.TabIndex = 6;
            this.chbUser.Text = "Usuario";
            this.chbUser.UseVisualStyleBackColor = true;
            this.chbUser.CheckedChanged += new System.EventHandler(this.chbUser_CheckedChanged);
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblSymbol.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.lblSymbol.ForeColor = System.Drawing.Color.White;
            this.lblSymbol.Location = new System.Drawing.Point(23, 76);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(248, 16);
            this.lblSymbol.TabIndex = 8;
            this.lblSymbol.Text = "Escolha o simbolo que voce deseja:";
            // 
            // chbMachine
            // 
            this.chbMachine.AutoSize = true;
            this.chbMachine.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMachine.ForeColor = System.Drawing.Color.Black;
            this.chbMachine.Location = new System.Drawing.Point(109, 39);
            this.chbMachine.Name = "chbMachine";
            this.chbMachine.Size = new System.Drawing.Size(107, 19);
            this.chbMachine.TabIndex = 9;
            this.chbMachine.Text = "Computador";
            this.chbMachine.UseVisualStyleBackColor = true;
            this.chbMachine.CheckedChanged += new System.EventHandler(this.chbMachine_CheckedChanged);
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.chbMachine);
            this.Controls.Add(this.lblSymbol);
            this.Controls.Add(this.chbUser);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbCircle);
            this.Controls.Add(this.pbCross);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCircle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCross;
        private System.Windows.Forms.PictureBox pbCircle;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.CheckBox chbUser;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.CheckBox chbMachine;
    }
}