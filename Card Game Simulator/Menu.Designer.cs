namespace Card_Game_Simulator
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.lblCheat = new System.Windows.Forms.Label();
            this.btnCheat4P = new System.Windows.Forms.Button();
            this.btnCheat3P = new System.Windows.Forms.Button();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.txtCurrentUser = new System.Windows.Forms.TextBox();
            this.btnDisplayUsers = new System.Windows.Forms.Button();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.btnAddUsers = new System.Windows.Forms.Button();
            this.btnHighScores = new System.Windows.Forms.Button();
            this.btnCheatRules = new System.Windows.Forms.Button();
            this.btnGuide = new System.Windows.Forms.Button();
            this.btnFLRules = new System.Windows.Forms.Button();
            this.btnFL3P = new System.Windows.Forms.Button();
            this.btnFL4P = new System.Windows.Forms.Button();
            this.lblFL = new System.Windows.Forms.Label();
            this.btnGameSettings = new System.Windows.Forms.Button();
            this.picEstonianFlag = new System.Windows.Forms.PictureBox();
            this.picUKFlag = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picEstonianFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUKFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCheat
            // 
            this.lblCheat.AutoSize = true;
            this.lblCheat.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheat.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCheat.Location = new System.Drawing.Point(320, 96);
            this.lblCheat.Name = "lblCheat";
            this.lblCheat.Size = new System.Drawing.Size(177, 60);
            this.lblCheat.TabIndex = 0;
            this.lblCheat.Text = "CHEAT";
            // 
            // btnCheat4P
            // 
            this.btnCheat4P.BackColor = System.Drawing.Color.DarkRed;
            this.btnCheat4P.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheat4P.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCheat4P.Location = new System.Drawing.Point(382, 185);
            this.btnCheat4P.Name = "btnCheat4P";
            this.btnCheat4P.Size = new System.Drawing.Size(235, 77);
            this.btnCheat4P.TabIndex = 2;
            this.btnCheat4P.Text = "4 Players";
            this.btnCheat4P.UseVisualStyleBackColor = false;
            this.btnCheat4P.Click += new System.EventHandler(this.btnCheat4P_Click);
            // 
            // btnCheat3P
            // 
            this.btnCheat3P.BackColor = System.Drawing.Color.DarkRed;
            this.btnCheat3P.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheat3P.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCheat3P.Location = new System.Drawing.Point(137, 185);
            this.btnCheat3P.Name = "btnCheat3P";
            this.btnCheat3P.Size = new System.Drawing.Size(235, 77);
            this.btnCheat3P.TabIndex = 4;
            this.btnCheat3P.Text = "3 Players";
            this.btnCheat3P.UseVisualStyleBackColor = false;
            this.btnCheat3P.Click += new System.EventHandler(this.btnCheat3P_Click);
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.Orange;
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLogIn.Location = new System.Drawing.Point(315, 12);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(214, 52);
            this.btnLogIn.TabIndex = 5;
            this.btnLogIn.Text = "Log In New User";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.ForeColor = System.Drawing.Color.Orange;
            this.lblCurrentUser.Location = new System.Drawing.Point(14, 30);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(117, 20);
            this.lblCurrentUser.TabIndex = 6;
            this.lblCurrentUser.Text = "Current User:";
            // 
            // txtCurrentUser
            // 
            this.txtCurrentUser.BackColor = System.Drawing.Color.Orange;
            this.txtCurrentUser.Enabled = false;
            this.txtCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentUser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtCurrentUser.Location = new System.Drawing.Point(134, 27);
            this.txtCurrentUser.Name = "txtCurrentUser";
            this.txtCurrentUser.ReadOnly = true;
            this.txtCurrentUser.Size = new System.Drawing.Size(161, 26);
            this.txtCurrentUser.TabIndex = 7;
            // 
            // btnDisplayUsers
            // 
            this.btnDisplayUsers.BackColor = System.Drawing.Color.Crimson;
            this.btnDisplayUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplayUsers.ForeColor = System.Drawing.Color.Cyan;
            this.btnDisplayUsers.Location = new System.Drawing.Point(584, 565);
            this.btnDisplayUsers.Name = "btnDisplayUsers";
            this.btnDisplayUsers.Size = new System.Drawing.Size(151, 52);
            this.btnDisplayUsers.TabIndex = 8;
            this.btnDisplayUsers.Text = "Display Users";
            this.btnDisplayUsers.UseVisualStyleBackColor = false;
            this.btnDisplayUsers.Click += new System.EventHandler(this.btnDisplayUsers_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdmin.ForeColor = System.Drawing.Color.Crimson;
            this.lblAdmin.Location = new System.Drawing.Point(483, 519);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(186, 31);
            this.lblAdmin.TabIndex = 9;
            this.lblAdmin.Text = "Admin Panel:";
            // 
            // btnAddUsers
            // 
            this.btnAddUsers.BackColor = System.Drawing.Color.Crimson;
            this.btnAddUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUsers.ForeColor = System.Drawing.Color.Cyan;
            this.btnAddUsers.Location = new System.Drawing.Point(414, 565);
            this.btnAddUsers.Name = "btnAddUsers";
            this.btnAddUsers.Size = new System.Drawing.Size(151, 52);
            this.btnAddUsers.TabIndex = 10;
            this.btnAddUsers.Text = "Add Users";
            this.btnAddUsers.UseVisualStyleBackColor = false;
            this.btnAddUsers.Click += new System.EventHandler(this.btnAddUsers_Click);
            // 
            // btnHighScores
            // 
            this.btnHighScores.BackColor = System.Drawing.Color.Orange;
            this.btnHighScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighScores.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnHighScores.Location = new System.Drawing.Point(535, 12);
            this.btnHighScores.Name = "btnHighScores";
            this.btnHighScores.Size = new System.Drawing.Size(214, 52);
            this.btnHighScores.TabIndex = 11;
            this.btnHighScores.Text = "View Highscores";
            this.btnHighScores.UseVisualStyleBackColor = false;
            this.btnHighScores.Click += new System.EventHandler(this.btnHighScores_Click);
            // 
            // btnCheatRules
            // 
            this.btnCheatRules.BackColor = System.Drawing.Color.DarkRed;
            this.btnCheatRules.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheatRules.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCheatRules.Location = new System.Drawing.Point(628, 185);
            this.btnCheatRules.Name = "btnCheatRules";
            this.btnCheatRules.Size = new System.Drawing.Size(121, 77);
            this.btnCheatRules.TabIndex = 13;
            this.btnCheatRules.Text = "Rules";
            this.btnCheatRules.UseVisualStyleBackColor = false;
            this.btnCheatRules.Click += new System.EventHandler(this.btnCheatRules_Click);
            // 
            // btnGuide
            // 
            this.btnGuide.BackColor = System.Drawing.Color.Orange;
            this.btnGuide.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuide.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGuide.Location = new System.Drawing.Point(30, 570);
            this.btnGuide.Name = "btnGuide";
            this.btnGuide.Size = new System.Drawing.Size(354, 52);
            this.btnGuide.TabIndex = 14;
            this.btnGuide.Text = "General Game Usage Guide";
            this.btnGuide.UseVisualStyleBackColor = false;
            this.btnGuide.Click += new System.EventHandler(this.btnGuide_Click);
            // 
            // btnFLRules
            // 
            this.btnFLRules.BackColor = System.Drawing.Color.GreenYellow;
            this.btnFLRules.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFLRules.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnFLRules.Location = new System.Drawing.Point(628, 395);
            this.btnFLRules.Name = "btnFLRules";
            this.btnFLRules.Size = new System.Drawing.Size(121, 77);
            this.btnFLRules.TabIndex = 19;
            this.btnFLRules.Text = "Rules";
            this.btnFLRules.UseVisualStyleBackColor = false;
            this.btnFLRules.Click += new System.EventHandler(this.btnFLRules_Click);
            // 
            // btnFL3P
            // 
            this.btnFL3P.BackColor = System.Drawing.Color.GreenYellow;
            this.btnFL3P.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFL3P.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnFL3P.Location = new System.Drawing.Point(137, 395);
            this.btnFL3P.Name = "btnFL3P";
            this.btnFL3P.Size = new System.Drawing.Size(235, 77);
            this.btnFL3P.TabIndex = 17;
            this.btnFL3P.Text = "3 Players";
            this.btnFL3P.UseVisualStyleBackColor = false;
            this.btnFL3P.Click += new System.EventHandler(this.btnFL3P_Click);
            // 
            // btnFL4P
            // 
            this.btnFL4P.BackColor = System.Drawing.Color.GreenYellow;
            this.btnFL4P.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFL4P.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnFL4P.Location = new System.Drawing.Point(382, 395);
            this.btnFL4P.Name = "btnFL4P";
            this.btnFL4P.Size = new System.Drawing.Size(235, 77);
            this.btnFL4P.TabIndex = 16;
            this.btnFL4P.Text = "4 Players";
            this.btnFL4P.UseVisualStyleBackColor = false;
            this.btnFL4P.Click += new System.EventHandler(this.btnFL4P_Click);
            // 
            // lblFL
            // 
            this.lblFL.AutoSize = true;
            this.lblFL.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFL.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblFL.Location = new System.Drawing.Point(268, 306);
            this.lblFL.Name = "lblFL";
            this.lblFL.Size = new System.Drawing.Size(303, 60);
            this.lblFL.TabIndex = 15;
            this.lblFL.Text = "FIVE LEAVES";
            // 
            // btnGameSettings
            // 
            this.btnGameSettings.BackColor = System.Drawing.Color.Orange;
            this.btnGameSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGameSettings.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGameSettings.Location = new System.Drawing.Point(96, 512);
            this.btnGameSettings.Name = "btnGameSettings";
            this.btnGameSettings.Size = new System.Drawing.Size(214, 52);
            this.btnGameSettings.TabIndex = 20;
            this.btnGameSettings.Text = "Game Settings";
            this.btnGameSettings.UseVisualStyleBackColor = false;
            this.btnGameSettings.Click += new System.EventHandler(this.btnGameSettings_Click);
            // 
            // picEstonianFlag
            // 
            this.picEstonianFlag.Image = global::Card_Game_Simulator.Properties.Resources.EstonianFlag;
            this.picEstonianFlag.InitialImage = null;
            this.picEstonianFlag.Location = new System.Drawing.Point(12, 400);
            this.picEstonianFlag.Name = "picEstonianFlag";
            this.picEstonianFlag.Size = new System.Drawing.Size(113, 67);
            this.picEstonianFlag.TabIndex = 18;
            this.picEstonianFlag.TabStop = false;
            // 
            // picUKFlag
            // 
            this.picUKFlag.Image = global::Card_Game_Simulator.Properties.Resources.UKFlag;
            this.picUKFlag.InitialImage = null;
            this.picUKFlag.Location = new System.Drawing.Point(12, 190);
            this.picUKFlag.Name = "picUKFlag";
            this.picUKFlag.Size = new System.Drawing.Size(113, 67);
            this.picUKFlag.TabIndex = 12;
            this.picUKFlag.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(761, 631);
            this.Controls.Add(this.btnGameSettings);
            this.Controls.Add(this.btnFLRules);
            this.Controls.Add(this.picEstonianFlag);
            this.Controls.Add(this.btnFL3P);
            this.Controls.Add(this.btnFL4P);
            this.Controls.Add(this.lblFL);
            this.Controls.Add(this.btnGuide);
            this.Controls.Add(this.btnCheatRules);
            this.Controls.Add(this.picUKFlag);
            this.Controls.Add(this.btnHighScores);
            this.Controls.Add(this.btnAddUsers);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.btnDisplayUsers);
            this.Controls.Add(this.txtCurrentUser);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.btnCheat3P);
            this.Controls.Add(this.btnCheat4P);
            this.Controls.Add(this.lblCheat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Welcome to the Card Game Simulator!";
            ((System.ComponentModel.ISupportInitialize)(this.picEstonianFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUKFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCheat;
        private System.Windows.Forms.Button btnCheat4P;
        private System.Windows.Forms.Button btnCheat3P;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.TextBox txtCurrentUser;
        private System.Windows.Forms.Button btnDisplayUsers;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Button btnAddUsers;
        private System.Windows.Forms.Button btnHighScores;
        private System.Windows.Forms.PictureBox picUKFlag;
        private System.Windows.Forms.Button btnCheatRules;
        private System.Windows.Forms.Button btnGuide;
        private System.Windows.Forms.Button btnFLRules;
        private System.Windows.Forms.PictureBox picEstonianFlag;
        private System.Windows.Forms.Button btnFL3P;
        private System.Windows.Forms.Button btnFL4P;
        private System.Windows.Forms.Label lblFL;
        private System.Windows.Forms.Button btnGameSettings;
    }
}