namespace PasswordsStashLite.UI
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_set_master_password = new System.Windows.Forms.Button();
            this.button_set_later = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Passwords Stash Lite";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(54, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Would you like to enable a Master Password?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(1, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(411, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "It will make your passwords to be protected with AES encryption\r\nand will make an" +
    "yone who opens the program to type it to enter.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(18, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(365, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "You can always set a Master Passwords later at settings.";
            // 
            // button_set_master_password
            // 
            this.button_set_master_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button_set_master_password.Location = new System.Drawing.Point(10, 338);
            this.button_set_master_password.Name = "button_set_master_password";
            this.button_set_master_password.Size = new System.Drawing.Size(187, 31);
            this.button_set_master_password.TabIndex = 4;
            this.button_set_master_password.Text = "Set Master Password";
            this.button_set_master_password.UseVisualStyleBackColor = true;
            this.button_set_master_password.Click += new System.EventHandler(this.button_set_master_password_Click);
            // 
            // button_set_later
            // 
            this.button_set_later.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button_set_later.Location = new System.Drawing.Point(212, 338);
            this.button_set_later.Name = "button_set_later";
            this.button_set_later.Size = new System.Drawing.Size(187, 31);
            this.button_set_later.TabIndex = 5;
            this.button_set_later.Text = "Set later";
            this.button_set_later.UseVisualStyleBackColor = true;
            this.button_set_later.Click += new System.EventHandler(this.button_set_later_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(387, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Point-and-click and get the password right to your clipboard.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PasswordsStashLite.Properties.Resources.PasswordsStashLiteIcon2;
            this.pictureBox1.Location = new System.Drawing.Point(97, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 381);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_set_later);
            this.Controls.Add(this.button_set_master_password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Welcome";
            this.Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_set_master_password;
        private System.Windows.Forms.Button button_set_later;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}