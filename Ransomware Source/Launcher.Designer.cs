namespace Launcher_Ransomware
{
    partial class Launcher
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
            this.TxtEncryptionKey = new System.Windows.Forms.TextBox();
            this.BtnDecrypt = new System.Windows.Forms.Button();
            this.LblText = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtEncryptionKey
            // 
            this.TxtEncryptionKey.Location = new System.Drawing.Point(12, 67);
            this.TxtEncryptionKey.Name = "TxtEncryptionKey";
            this.TxtEncryptionKey.Size = new System.Drawing.Size(530, 20);
            this.TxtEncryptionKey.TabIndex = 0;
            this.TxtEncryptionKey.Text = "E824C3D6650DD7C9B958F344CE7098620B7E22093A2C0966DECBBDB5AF590FC6";
            // 
            // BtnDecrypt
            // 
            this.BtnDecrypt.Location = new System.Drawing.Point(455, 126);
            this.BtnDecrypt.Name = "BtnDecrypt";
            this.BtnDecrypt.Size = new System.Drawing.Size(87, 23);
            this.BtnDecrypt.TabIndex = 1;
            this.BtnDecrypt.Text = "Decrypt Files";
            this.BtnDecrypt.UseVisualStyleBackColor = true;
            this.BtnDecrypt.Click += new System.EventHandler(this.BtnDecrypt_Click);
            // 
            // LblText
            // 
            this.LblText.AutoSize = true;
            this.LblText.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblText.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblText.Location = new System.Drawing.Point(12, 128);
            this.LblText.Name = "LblText";
            this.LblText.Size = new System.Drawing.Size(330, 19);
            this.LblText.TabIndex = 2;
            this.LblText.Text = "Do not close this if you do not want your files get delete :)";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(116, 9);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(320, 28);
            this.LblTitle.TabIndex = 3;
            this.LblTitle.Text = "It is okay if you see something unusual";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 161);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.LblText);
            this.Controls.Add(this.BtnDecrypt);
            this.Controls.Add(this.TxtEncryptionKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(570, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(570, 200);
            this.Name = "Launcher";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Netalker Ransomware";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Launcher_FormClosing);
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtEncryptionKey;
        private System.Windows.Forms.Button BtnDecrypt;
        private System.Windows.Forms.Label LblText;
        private System.Windows.Forms.Label LblTitle;
    }
}

