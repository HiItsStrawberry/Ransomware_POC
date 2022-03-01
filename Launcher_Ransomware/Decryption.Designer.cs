namespace Launcher_Ransomware
{
    partial class Decryption
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
            this.BtnFinish = new System.Windows.Forms.Button();
            this.LblRemain = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.LblProgress = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.LblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnFinish
            // 
            this.BtnFinish.Location = new System.Drawing.Point(467, 206);
            this.BtnFinish.Name = "BtnFinish";
            this.BtnFinish.Size = new System.Drawing.Size(75, 23);
            this.BtnFinish.TabIndex = 21;
            this.BtnFinish.Text = "Finish";
            this.BtnFinish.UseVisualStyleBackColor = true;
            this.BtnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // LblRemain
            // 
            this.LblRemain.AutoSize = true;
            this.LblRemain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRemain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblRemain.Location = new System.Drawing.Point(14, 42);
            this.LblRemain.Name = "LblRemain";
            this.LblRemain.Size = new System.Drawing.Size(107, 16);
            this.LblRemain.TabIndex = 20;
            this.LblRemain.Text = "Total Decrypted:";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblName.Location = new System.Drawing.Point(14, 74);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(50, 16);
            this.LblName.TabIndex = 19;
            this.LblName.Text = "Name: ";
            // 
            // LblProgress
            // 
            this.LblProgress.AutoSize = true;
            this.LblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProgress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblProgress.Location = new System.Drawing.Point(14, 106);
            this.LblProgress.Name = "LblProgress";
            this.LblProgress.Size = new System.Drawing.Size(85, 16);
            this.LblProgress.TabIndex = 16;
            this.LblProgress.Text = "0% complete";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 125);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(530, 43);
            this.ProgressBar.TabIndex = 18;
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblInfo.Location = new System.Drawing.Point(14, 10);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(212, 16);
            this.LblInfo.TabIndex = 17;
            this.LblInfo.Text = "Decrypting file from target machine";
            // 
            // Decryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 241);
            this.Controls.Add(this.BtnFinish);
            this.Controls.Add(this.LblRemain);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.LblProgress);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.LblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(570, 280);
            this.MinimumSize = new System.Drawing.Size(570, 280);
            this.Name = "Decryption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Netwalker Decryption";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Decryption_FormClosing);
            this.Load += new System.EventHandler(this.Decryption_LoadAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnFinish;
        private System.Windows.Forms.Label LblRemain;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblProgress;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label LblInfo;
    }
}