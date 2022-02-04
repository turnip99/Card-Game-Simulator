namespace Card_Game_Simulator
{
    partial class GetSpeed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetSpeed));
            this.lblChooseSpeed = new System.Windows.Forms.Label();
            this.btnSlow = new System.Windows.Forms.Button();
            this.btnFast = new System.Windows.Forms.Button();
            this.btnHardcore = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChooseSpeed
            // 
            this.lblChooseSpeed.AutoSize = true;
            this.lblChooseSpeed.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseSpeed.Location = new System.Drawing.Point(14, 9);
            this.lblChooseSpeed.Name = "lblChooseSpeed";
            this.lblChooseSpeed.Size = new System.Drawing.Size(186, 60);
            this.lblChooseSpeed.TabIndex = 0;
            this.lblChooseSpeed.Text = "Speed:";
            // 
            // btnSlow
            // 
            this.btnSlow.BackColor = System.Drawing.Color.Lime;
            this.btnSlow.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlow.Location = new System.Drawing.Point(12, 84);
            this.btnSlow.Name = "btnSlow";
            this.btnSlow.Size = new System.Drawing.Size(153, 39);
            this.btnSlow.TabIndex = 1;
            this.btnSlow.Text = "Slow";
            this.btnSlow.UseVisualStyleBackColor = false;
            this.btnSlow.Click += new System.EventHandler(this.btnSlow_Click);
            // 
            // btnFast
            // 
            this.btnFast.BackColor = System.Drawing.Color.DarkOrange;
            this.btnFast.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFast.Location = new System.Drawing.Point(12, 129);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(153, 39);
            this.btnFast.TabIndex = 2;
            this.btnFast.Text = "Fast";
            this.btnFast.UseVisualStyleBackColor = false;
            this.btnFast.Click += new System.EventHandler(this.btnFast_Click);
            // 
            // btnHardcore
            // 
            this.btnHardcore.BackColor = System.Drawing.Color.Red;
            this.btnHardcore.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHardcore.Location = new System.Drawing.Point(171, 129);
            this.btnHardcore.Name = "btnHardcore";
            this.btnHardcore.Size = new System.Drawing.Size(155, 39);
            this.btnHardcore.TabIndex = 3;
            this.btnHardcore.Text = "Hardcore";
            this.btnHardcore.UseVisualStyleBackColor = false;
            this.btnHardcore.Click += new System.EventHandler(this.btnHardcore_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.BackColor = System.Drawing.Color.Yellow;
            this.btnNormal.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormal.Location = new System.Drawing.Point(171, 84);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(155, 39);
            this.btnNormal.TabIndex = 4;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // GetSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(338, 180);
            this.ControlBox = false;
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnHardcore);
            this.Controls.Add(this.btnFast);
            this.Controls.Add(this.btnSlow);
            this.Controls.Add(this.lblChooseSpeed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetSpeed";
            this.Text = "Choose Your Speed!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseSpeed;
        private System.Windows.Forms.Button btnSlow;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Button btnHardcore;
        private System.Windows.Forms.Button btnNormal;
    }
}