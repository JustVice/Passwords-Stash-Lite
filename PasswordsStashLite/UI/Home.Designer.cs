namespace PasswordsStashLite.UI
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.label1 = new System.Windows.Forms.Label();
            this.button_create_new_password = new System.Windows.Forms.Button();
            this.button_see_password = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_more = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Passwords Stash Lite";
            // 
            // button_create_new_password
            // 
            this.button_create_new_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_create_new_password.Location = new System.Drawing.Point(28, 41);
            this.button_create_new_password.Name = "button_create_new_password";
            this.button_create_new_password.Size = new System.Drawing.Size(204, 37);
            this.button_create_new_password.TabIndex = 1;
            this.button_create_new_password.Text = "Create new password";
            this.button_create_new_password.UseVisualStyleBackColor = true;
            this.button_create_new_password.Click += new System.EventHandler(this.button_create_new_password_Click);
            // 
            // button_see_password
            // 
            this.button_see_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_see_password.Location = new System.Drawing.Point(59, 87);
            this.button_see_password.Name = "button_see_password";
            this.button_see_password.Size = new System.Drawing.Size(144, 37);
            this.button_see_password.TabIndex = 2;
            this.button_see_password.Text = "See passwords";
            this.button_see_password.UseVisualStyleBackColor = true;
            this.button_see_password.Click += new System.EventHandler(this.button_see_password_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "______________________________________";
            // 
            // button_more
            // 
            this.button_more.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.button_more.Location = new System.Drawing.Point(62, 143);
            this.button_more.Name = "button_more";
            this.button_more.Size = new System.Drawing.Size(143, 23);
            this.button_more.TabIndex = 5;
            this.button_more.Text = "More/Settings";
            this.button_more.UseVisualStyleBackColor = true;
            this.button_more.Click += new System.EventHandler(this.button_more_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PasswordsStashLite.Properties.Resources.PasswordsStashLiteInki;
            this.pictureBox1.Location = new System.Drawing.Point(270, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(577, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 172);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_more);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_see_password);
            this.Controls.Add(this.button_create_new_password);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.Text = "P.S Lite";
            this.ResizeEnd += new System.EventHandler(this.Home_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_create_new_password;
        private System.Windows.Forms.Button button_see_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_more;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}