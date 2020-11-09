namespace PasswordsStashLite.UI
{
    partial class SeePasswords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeePasswords));
            this.listBox_passwords = new System.Windows.Forms.ListBox();
            this.button_edit_selected_password = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_copy_password = new System.Windows.Forms.Button();
            this.button_copy_user = new System.Windows.Forms.Button();
            this.button_copy_email = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_delete_password = new System.Windows.Forms.Button();
            this.button_home_menu = new System.Windows.Forms.Button();
            this.button_copy_notes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox_passwords
            // 
            this.listBox_passwords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.listBox_passwords.FormattingEnabled = true;
            this.listBox_passwords.ItemHeight = 20;
            this.listBox_passwords.Location = new System.Drawing.Point(12, 12);
            this.listBox_passwords.Name = "listBox_passwords";
            this.listBox_passwords.Size = new System.Drawing.Size(535, 344);
            this.listBox_passwords.TabIndex = 0;
            this.listBox_passwords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_passwords_MouseClick);
            this.listBox_passwords.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_passwords_MouseDoubleClick);
            // 
            // button_edit_selected_password
            // 
            this.button_edit_selected_password.Location = new System.Drawing.Point(351, 378);
            this.button_edit_selected_password.Name = "button_edit_selected_password";
            this.button_edit_selected_password.Size = new System.Drawing.Size(75, 49);
            this.button_edit_selected_password.TabIndex = 1;
            this.button_edit_selected_password.Text = "Edit selected password";
            this.button_edit_selected_password.UseVisualStyleBackColor = true;
            this.button_edit_selected_password.Click += new System.EventHandler(this.button_edit_selected_password_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Copy to clipboard";
            // 
            // button_copy_password
            // 
            this.button_copy_password.Location = new System.Drawing.Point(112, 380);
            this.button_copy_password.Name = "button_copy_password";
            this.button_copy_password.Size = new System.Drawing.Size(75, 23);
            this.button_copy_password.TabIndex = 4;
            this.button_copy_password.Text = "Password";
            this.button_copy_password.UseVisualStyleBackColor = true;
            this.button_copy_password.Click += new System.EventHandler(this.button_copy_password_Click);
            // 
            // button_copy_user
            // 
            this.button_copy_user.Location = new System.Drawing.Point(112, 406);
            this.button_copy_user.Name = "button_copy_user";
            this.button_copy_user.Size = new System.Drawing.Size(75, 23);
            this.button_copy_user.TabIndex = 5;
            this.button_copy_user.Text = "User";
            this.button_copy_user.UseVisualStyleBackColor = true;
            this.button_copy_user.Click += new System.EventHandler(this.button_copy_user_Click);
            // 
            // button_copy_email
            // 
            this.button_copy_email.Location = new System.Drawing.Point(193, 380);
            this.button_copy_email.Name = "button_copy_email";
            this.button_copy_email.Size = new System.Drawing.Size(75, 23);
            this.button_copy_email.TabIndex = 6;
            this.button_copy_email.Text = "Email";
            this.button_copy_email.UseVisualStyleBackColor = true;
            this.button_copy_email.Click += new System.EventHandler(this.button_copy_email_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "More";
            // 
            // button_delete_password
            // 
            this.button_delete_password.Location = new System.Drawing.Point(432, 378);
            this.button_delete_password.Name = "button_delete_password";
            this.button_delete_password.Size = new System.Drawing.Size(75, 49);
            this.button_delete_password.TabIndex = 9;
            this.button_delete_password.Text = "Delete selected password";
            this.button_delete_password.UseVisualStyleBackColor = true;
            this.button_delete_password.Click += new System.EventHandler(this.button_delete_password_Click);
            // 
            // button_home_menu
            // 
            this.button_home_menu.Location = new System.Drawing.Point(12, 391);
            this.button_home_menu.Name = "button_home_menu";
            this.button_home_menu.Size = new System.Drawing.Size(75, 23);
            this.button_home_menu.TabIndex = 10;
            this.button_home_menu.Text = "Home menu";
            this.button_home_menu.UseVisualStyleBackColor = true;
            this.button_home_menu.Click += new System.EventHandler(this.button_home_menu_Click);
            // 
            // button_copy_notes
            // 
            this.button_copy_notes.Location = new System.Drawing.Point(193, 406);
            this.button_copy_notes.Name = "button_copy_notes";
            this.button_copy_notes.Size = new System.Drawing.Size(75, 23);
            this.button_copy_notes.TabIndex = 11;
            this.button_copy_notes.Text = "Notes";
            this.button_copy_notes.UseVisualStyleBackColor = true;
            this.button_copy_notes.Click += new System.EventHandler(this.button_notes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Double click to copy password directly.";
            // 
            // SeePasswords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 442);
            this.Controls.Add(this.listBox_passwords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_copy_notes);
            this.Controls.Add(this.button_home_menu);
            this.Controls.Add(this.button_delete_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_copy_email);
            this.Controls.Add(this.button_copy_user);
            this.Controls.Add(this.button_copy_password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_edit_selected_password);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeePasswords";
            this.Text = "SeePasswords";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_passwords;
        private System.Windows.Forms.Button button_edit_selected_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_copy_password;
        private System.Windows.Forms.Button button_copy_user;
        private System.Windows.Forms.Button button_copy_email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_delete_password;
        private System.Windows.Forms.Button button_home_menu;
        private System.Windows.Forms.Button button_copy_notes;
        private System.Windows.Forms.Label label3;
    }
}