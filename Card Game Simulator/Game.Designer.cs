namespace Card_Game_Simulator
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            PicPlayer = new System.Windows.Forms.PictureBox[3];
            this.PicPlayer[0] = new System.Windows.Forms.PictureBox();
            this.PicPlayer[1] = new System.Windows.Forms.PictureBox();
            this.PicPlayer[2] = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.PicDeck = new System.Windows.Forms.PictureBox();
            this.LblStatus = new System.Windows.Forms.Label();
            this.PicDiscard = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.TxtScore = new System.Windows.Forms.TextBox();
            LblValue = new System.Windows.Forms.Label[4];
            LblValue[0] = new System.Windows.Forms.Label();
            LblValue[1] = new System.Windows.Forms.Label();
            LblValue[2] = new System.Windows.Forms.Label();
            LblValue[3] = new System.Windows.Forms.Label();
            this.BtnCallCheat = new System.Windows.Forms.Button();
            this.LblLastPlayed = new System.Windows.Forms.Label();
            this.BtnRules = new System.Windows.Forms.Button();
            this.BtnGuide = new System.Windows.Forms.Button();
            this.BtnHint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlayer[1])).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlayer[2])).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlayer[0])).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDiscard)).BeginInit();
            this.SuspendLayout();
            // 
            // PicP3
            // 
            this.PicPlayer[1].InitialImage = null;
            this.PicPlayer[1].Location = new System.Drawing.Point(420, 59);
            this.PicPlayer[1].Name = "PicP3";
            this.PicPlayer[1].Size = new System.Drawing.Size(141, 182);
            this.PicPlayer[1].TabIndex = 0;
            this.PicPlayer[1].TabStop = false;
            // 
            // PicP4
            // 
            this.PicPlayer[2].Location = new System.Drawing.Point(782, 220);
            this.PicPlayer[2].Name = "PicP4";
            this.PicPlayer[2].Size = new System.Drawing.Size(166, 360);
            this.PicPlayer[2].TabIndex = 1;
            this.PicPlayer[2].TabStop = false;
            // 
            // PicP2
            // 
            this.PicPlayer[0].Location = new System.Drawing.Point(25, 220);
            this.PicPlayer[0].Name = "PicP2";
            this.PicPlayer[0].Size = new System.Drawing.Size(166, 360);
            this.PicPlayer[0].TabIndex = 2;
            this.PicPlayer[0].TabStop = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblUser.Location = new System.Drawing.Point(12, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(85, 16);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Current User:";
            // 
            // TxtUser
            // 
            this.TxtUser.BackColor = System.Drawing.Color.Orange;
            this.TxtUser.Enabled = false;
            this.TxtUser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.TxtUser.Location = new System.Drawing.Point(103, 11);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.ReadOnly = true;
            this.TxtUser.Size = new System.Drawing.Size(112, 20);
            this.TxtUser.TabIndex = 4;
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            // 
            // PicDeck
            // 
            this.PicDeck.BackColor = System.Drawing.Color.Transparent;
            this.PicDeck.Location = new System.Drawing.Point(339, 315);
            this.PicDeck.Name = "PicDeck";
            this.PicDeck.Size = new System.Drawing.Size(60, 88);
            this.PicDeck.TabIndex = 5;
            this.PicDeck.TabStop = false;
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.BackColor = System.Drawing.Color.Transparent;
            this.LblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblStatus.Location = new System.Drawing.Point(274, 5);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(0, 31);
            this.LblStatus.TabIndex = 6;
            // 
            // PicDiscard
            // 
            this.PicDiscard.BackColor = System.Drawing.Color.Transparent;
            this.PicDiscard.Location = new System.Drawing.Point(448, 315);
            this.PicDiscard.Name = "PicDiscard";
            this.PicDiscard.Size = new System.Drawing.Size(60, 88);
            this.PicDiscard.TabIndex = 8;
            this.PicDiscard.TabStop = false;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Navy;
            this.lblScore.Location = new System.Drawing.Point(768, 13);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(55, 20);
            this.lblScore.TabIndex = 9;
            this.lblScore.Text = "Score:";
            // 
            // TxtScore
            // 
            this.TxtScore.BackColor = System.Drawing.Color.Orange;
            this.TxtScore.Enabled = false;
            this.TxtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtScore.Location = new System.Drawing.Point(829, 10);
            this.TxtScore.Name = "TxtScore";
            this.TxtScore.ReadOnly = true;
            this.TxtScore.Size = new System.Drawing.Size(112, 26);
            this.TxtScore.TabIndex = 10;
            // 
            // LblP3Value
            // 
            this.LblValue[2].AutoSize = true;
            this.LblValue[2].BackColor = System.Drawing.Color.Transparent;
            this.LblValue[2].Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValue[2].Location = new System.Drawing.Point(467, 244);
            this.LblValue[2].Name = "LblP3Value";
            this.LblValue[2].Size = new System.Drawing.Size(26, 29);
            this.LblValue[2].TabIndex = 11;
            this.LblValue[2].Text = "3";
            // 
            // LblP2Value
            // 
            this.LblValue[1].AutoSize = true;
            this.LblValue[1].BackColor = System.Drawing.Color.Transparent;
            this.LblValue[1].Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValue[1].Location = new System.Drawing.Point(208, 347);
            this.LblValue[1].Name = "LblP2Value";
            this.LblValue[1].Size = new System.Drawing.Size(26, 29);
            this.LblValue[1].TabIndex = 12;
            this.LblValue[1].Text = "2";
            // 
            // LblP4Value
            // 
            this.LblValue[3].AutoSize = true;
            this.LblValue[3].BackColor = System.Drawing.Color.Transparent;
            this.LblValue[3].Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValue[3].Location = new System.Drawing.Point(718, 347);
            this.LblValue[3].Name = "LblP4Value";
            this.LblValue[3].Size = new System.Drawing.Size(26, 29);
            this.LblValue[3].TabIndex = 13;
            this.LblValue[3].Text = "4";
            // 
            // LblP1Value
            // 
            this.LblValue[0].AutoSize = true;
            this.LblValue[0].BackColor = System.Drawing.Color.Transparent;
            this.LblValue[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValue[0].Location = new System.Drawing.Point(467, 452);
            this.LblValue[0].Name = "LblP1Value";
            this.LblValue[0].Size = new System.Drawing.Size(26, 29);
            this.LblValue[0].TabIndex = 14;
            this.LblValue[0].Text = "1";
            // 
            // BtnCallCheat
            // 
            this.BtnCallCheat.BackColor = System.Drawing.SystemColors.MenuText;
            this.BtnCallCheat.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCallCheat.ForeColor = System.Drawing.Color.Chocolate;
            this.BtnCallCheat.Location = new System.Drawing.Point(762, 753);
            this.BtnCallCheat.Name = "BtnCallCheat";
            this.BtnCallCheat.Size = new System.Drawing.Size(210, 129);
            this.BtnCallCheat.TabIndex = 15;
            this.BtnCallCheat.Text = "CHEAT!";
            this.BtnCallCheat.UseVisualStyleBackColor = false;
            this.BtnCallCheat.Click += new System.EventHandler(this.btnCallCheat_Click);
            // 
            // LblLastPlayed
            // 
            this.LblLastPlayed.AutoSize = true;
            this.LblLastPlayed.BackColor = System.Drawing.Color.Transparent;
            this.LblLastPlayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLastPlayed.ForeColor = System.Drawing.Color.Lime;
            this.LblLastPlayed.Location = new System.Drawing.Point(545, 328);
            this.LblLastPlayed.Name = "LblLastPlayed";
            this.LblLastPlayed.Size = new System.Drawing.Size(18, 20);
            this.LblLastPlayed.TabIndex = 16;
            this.LblLastPlayed.Text = "0";
            // 
            // BtnRules
            // 
            this.BtnRules.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnRules.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRules.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnRules.Location = new System.Drawing.Point(15, 842);
            this.BtnRules.Name = "BtnRules";
            this.BtnRules.Size = new System.Drawing.Size(100, 40);
            this.BtnRules.TabIndex = 17;
            this.BtnRules.Text = "Game Rules";
            this.BtnRules.UseVisualStyleBackColor = false;
            this.BtnRules.Visible = false;
            this.BtnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // BtnGuide
            // 
            this.BtnGuide.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnGuide.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuide.Location = new System.Drawing.Point(15, 803);
            this.BtnGuide.Name = "BtnGuide";
            this.BtnGuide.Size = new System.Drawing.Size(100, 40);
            this.BtnGuide.TabIndex = 18;
            this.BtnGuide.Text = "General Usage Guide";
            this.BtnGuide.UseVisualStyleBackColor = false;
            this.BtnGuide.Visible = false;
            this.BtnGuide.Click += new System.EventHandler(this.btnGuide_Click);
            // 
            // BtnHint
            // 
            this.BtnHint.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnHint.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHint.Location = new System.Drawing.Point(15, 764);
            this.BtnHint.Name = "BtnHint";
            this.BtnHint.Size = new System.Drawing.Size(100, 40);
            this.BtnHint.TabIndex = 19;
            this.BtnHint.Text = "      Hint!        (-5 points)";
            this.BtnHint.UseVisualStyleBackColor = false;
            this.BtnHint.Visible = false;
            this.BtnHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Card_Game_Simulator.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(984, 911);
            this.Controls.Add(this.BtnHint);
            this.Controls.Add(this.BtnGuide);
            this.Controls.Add(this.BtnRules);
            this.Controls.Add(this.LblLastPlayed);
            this.Controls.Add(this.BtnCallCheat);
            this.Controls.Add(LblValue[0]);
            this.Controls.Add(LblValue[1]);
            this.Controls.Add(LblValue[2]);
            this.Controls.Add(LblValue[3]);
            this.Controls.Add(PicPlayer[0]);
            this.Controls.Add(PicPlayer[1]);
            this.Controls.Add(PicPlayer[2]);
            this.Controls.Add(this.TxtScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.PicDiscard);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.PicDeck);
            this.Controls.Add(this.TxtUser);
            this.Controls.Add(this.lblUser);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(300, 10);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Game On!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.PicDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDiscard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PicPlayer[0])).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PicPlayer[1])).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PicPlayer[2])).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblScore;
        public System.Windows.Forms.TextBox TxtUser;
        public System.Windows.Forms.TextBox TxtScore;
        public System.Windows.Forms.Label LblLastPlayed;
        public System.Windows.Forms.Timer timerMain;
        public System.Windows.Forms.PictureBox PicDiscard;
        public System.Windows.Forms.Label LblStatus;
        public System.Windows.Forms.PictureBox PicDeck;
        public System.Windows.Forms.Label[] LblValue;
        public System.Windows.Forms.PictureBox[] PicPlayer;
        public System.Windows.Forms.Button BtnCallCheat;
        public System.Windows.Forms.Button BtnRules;
        public System.Windows.Forms.Button BtnGuide;
        public System.Windows.Forms.Button BtnHint;
    }
}