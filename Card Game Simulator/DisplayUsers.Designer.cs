namespace Card_Game_Simulator
{
    partial class DisplayUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayUsers));
            this.dgdUsers = new System.Windows.Forms.DataGridView();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tblUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cardGameDatabaseDataSet = new Card_Game_Simulator.CardGameDatabaseDataSet();
            this.tblUserTableAdapter = new Card_Game_Simulator.CardGameDatabaseDataSetTableAdapters.tblUserTableAdapter();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbxAdmin = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgdUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardGameDatabaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgdUsers
            // 
            this.dgdUsers.AllowUserToAddRows = false;
            this.dgdUsers.AllowUserToDeleteRows = false;
            this.dgdUsers.AllowUserToResizeColumns = false;
            this.dgdUsers.AllowUserToResizeRows = false;
            this.dgdUsers.AutoGenerateColumns = false;
            this.dgdUsers.BackgroundColor = System.Drawing.Color.Orange;
            this.dgdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usernameDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.adminDataGridViewCheckBoxColumn});
            this.dgdUsers.DataSource = this.tblUserBindingSource;
            this.dgdUsers.GridColor = System.Drawing.Color.Orange;
            this.dgdUsers.Location = new System.Drawing.Point(10, 12);
            this.dgdUsers.Name = "dgdUsers";
            this.dgdUsers.ReadOnly = true;
            this.dgdUsers.RowHeadersVisible = false;
            this.dgdUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdUsers.Size = new System.Drawing.Size(305, 437);
            this.dgdUsers.TabIndex = 0;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // adminDataGridViewCheckBoxColumn
            // 
            this.adminDataGridViewCheckBoxColumn.DataPropertyName = "Admin";
            this.adminDataGridViewCheckBoxColumn.HeaderText = "Admin";
            this.adminDataGridViewCheckBoxColumn.Name = "adminDataGridViewCheckBoxColumn";
            this.adminDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // tblUserBindingSource
            // 
            this.tblUserBindingSource.DataMember = "tblUser";
            this.tblUserBindingSource.DataSource = this.cardGameDatabaseDataSet;
            // 
            // cardGameDatabaseDataSet
            // 
            this.cardGameDatabaseDataSet.DataSetName = "CardGameDatabaseDataSet";
            this.cardGameDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblUserTableAdapter
            // 
            this.tblUserTableAdapter.ClearBeforeFill = true;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(51, 461);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(72, 13);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "Admin Status:";
            // 
            // cbxAdmin
            // 
            this.cbxAdmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAdmin.FormattingEnabled = true;
            this.cbxAdmin.Location = new System.Drawing.Point(130, 458);
            this.cbxAdmin.Name = "cbxAdmin";
            this.cbxAdmin.Size = new System.Drawing.Size(121, 21);
            this.cbxAdmin.TabIndex = 2;
            this.cbxAdmin.SelectionChangeCommitted += new System.EventHandler(this.Filter);
            // 
            // DisplayUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(325, 491);
            this.Controls.Add(this.cbxAdmin);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.dgdUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DisplayUsers";
            this.Text = "Users!";
            this.Load += new System.EventHandler(this.DisplayUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardGameDatabaseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgdUsers;
        private CardGameDatabaseDataSet cardGameDatabaseDataSet;
        private System.Windows.Forms.BindingSource tblUserBindingSource;
        private CardGameDatabaseDataSetTableAdapters.tblUserTableAdapter tblUserTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn adminDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cbxAdmin;
    }
}