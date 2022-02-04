namespace Card_Game_Simulator
{
    partial class Highscores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Highscores));
            this.dgdHighScores = new System.Windows.Forms.DataGridView();
            this.scoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gameIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblScoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cardGameDatabaseDataSet = new Card_Game_Simulator.CardGameDatabaseDataSet();
            this.cbxGame = new System.Windows.Forms.ComboBox();
            this.lblGame = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.cbxUser = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.tblScoreTableAdapter = new Card_Game_Simulator.CardGameDatabaseDataSetTableAdapters.tblScoreTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgdHighScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblScoreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardGameDatabaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgdHighScores
            // 
            this.dgdHighScores.AllowUserToAddRows = false;
            this.dgdHighScores.AllowUserToDeleteRows = false;
            this.dgdHighScores.AllowUserToResizeColumns = false;
            this.dgdHighScores.AllowUserToResizeRows = false;
            this.dgdHighScores.AutoGenerateColumns = false;
            this.dgdHighScores.BackgroundColor = System.Drawing.Color.Orange;
            this.dgdHighScores.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgdHighScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdHighScores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scoreDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.gameIDDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn});
            this.dgdHighScores.DataSource = this.tblScoreBindingSource;
            this.dgdHighScores.Location = new System.Drawing.Point(33, 12);
            this.dgdHighScores.Name = "dgdHighScores";
            this.dgdHighScores.ReadOnly = true;
            this.dgdHighScores.RowHeadersVisible = false;
            this.dgdHighScores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgdHighScores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdHighScores.Size = new System.Drawing.Size(504, 522);
            this.dgdHighScores.TabIndex = 0;
            // 
            // scoreDataGridViewTextBoxColumn
            // 
            this.scoreDataGridViewTextBoxColumn.DataPropertyName = "Score";
            this.scoreDataGridViewTextBoxColumn.HeaderText = "Score";
            this.scoreDataGridViewTextBoxColumn.Name = "scoreDataGridViewTextBoxColumn";
            this.scoreDataGridViewTextBoxColumn.ReadOnly = true;
            this.scoreDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "User";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gameIDDataGridViewTextBoxColumn
            // 
            this.gameIDDataGridViewTextBoxColumn.DataPropertyName = "GameID";
            this.gameIDDataGridViewTextBoxColumn.HeaderText = "Game";
            this.gameIDDataGridViewTextBoxColumn.Name = "gameIDDataGridViewTextBoxColumn";
            this.gameIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Position";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            this.positionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tblScoreBindingSource
            // 
            this.tblScoreBindingSource.DataMember = "tblScore";
            this.tblScoreBindingSource.DataSource = this.cardGameDatabaseDataSet;
            // 
            // cardGameDatabaseDataSet
            // 
            this.cardGameDatabaseDataSet.DataSetName = "CardGameDatabaseDataSet";
            this.cardGameDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbxGame
            // 
            this.cbxGame.DisplayMember = "GameID";
            this.cbxGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGame.FormattingEnabled = true;
            this.cbxGame.Location = new System.Drawing.Point(409, 552);
            this.cbxGame.Name = "cbxGame";
            this.cbxGame.Size = new System.Drawing.Size(150, 21);
            this.cbxGame.TabIndex = 1;
            this.cbxGame.ValueMember = "GameID";
            this.cbxGame.SelectionChangeCommitted += new System.EventHandler(this.Filter);
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.Location = new System.Drawing.Point(333, 555);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(72, 13);
            this.lblGame.TabIndex = 2;
            this.lblGame.Text = "Sort by game:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(99, 555);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(66, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Sort by user:";
            // 
            // cbxUser
            // 
            this.cbxUser.DisplayMember = "UserID";
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(170, 552);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(152, 21);
            this.cbxUser.TabIndex = 3;
            this.cbxUser.ValueMember = "UserID";
            this.cbxUser.SelectionChangeCommitted += new System.EventHandler(this.Filter);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(13, 550);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tblScoreTableAdapter
            // 
            this.tblScoreTableAdapter.ClearBeforeFill = true;
            // 
            // Highscores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(569, 585);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.cbxUser);
            this.Controls.Add(this.lblGame);
            this.Controls.Add(this.cbxGame);
            this.Controls.Add(this.dgdHighScores);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Highscores";
            this.Text = "Highscores!";
            this.Load += new System.EventHandler(this.Highscores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdHighScores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblScoreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardGameDatabaseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgdHighScores;
        private System.Windows.Forms.ComboBox cbxGame;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cbxUser;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn scoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gameIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private CardGameDatabaseDataSet cardGameDatabaseDataSet;
        private System.Windows.Forms.BindingSource tblScoreBindingSource;
        private CardGameDatabaseDataSetTableAdapters.tblScoreTableAdapter tblScoreTableAdapter;
    }
}