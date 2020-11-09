namespace PasswordsStashLite.UI
{
    partial class MasterPasswordWall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterPasswordWall));
            this.label1 = new System.Windows.Forms.Label();
            this.button_verify_password = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_show_hint = new System.Windows.Forms.Button();
            this.button_delete_all_data = new System.Windows.Forms.Button();
            this.checkBox_start_at_see_passwords = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(11, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please, type the master password to continue";
            // 
            // button_verify_password
            // 
            this.button_verify_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button_verify_password.Location = new System.Drawing.Point(39, 100);
            this.button_verify_password.Name = "button_verify_password";
            this.button_verify_password.Size = new System.Drawing.Size(300, 28);
            this.button_verify_password.TabIndex = 1;
            this.button_verify_password.Text = "Verify";
            this.button_verify_password.UseVisualStyleBackColor = true;
            this.button_verify_password.Click += new System.EventHandler(this.button_verify_password_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(36, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Passwords Stash Lite";
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.textBox_password.Location = new System.Drawing.Point(39, 68);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(300, 26);
            this.textBox_password.TabIndex = 4;
            this.textBox_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_password_KeyDown);
            // 
            // button_show_hint
            // 
            this.button_show_hint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button_show_hint.Location = new System.Drawing.Point(39, 134);
            this.button_show_hint.Name = "button_show_hint";
            this.button_show_hint.Size = new System.Drawing.Size(300, 28);
            this.button_show_hint.TabIndex = 5;
            this.button_show_hint.Text = "Show hint";
            this.button_show_hint.UseVisualStyleBackColor = true;
            this.button_show_hint.Click += new System.EventHandler(this.button_show_hint_Click);
            // 
            // button_delete_all_data
            // 
            this.button_delete_all_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button_delete_all_data.Location = new System.Drawing.Point(39, 168);
            this.button_delete_all_data.Name = "button_delete_all_data";
            this.button_delete_all_data.Size = new System.Drawing.Size(300, 28);
            this.button_delete_all_data.TabIndex = 6;
            this.button_delete_all_data.Text = "Delete all data (master password forgotten)";
            this.button_delete_all_data.UseVisualStyleBackColor = true;
            this.button_delete_all_data.Click += new System.EventHandler(this.button_delete_all_data_Click);
            // 
            // checkBox_start_at_see_passwords
            // 
            this.checkBox_start_at_see_passwords.AutoSize = true;
            this.checkBox_start_at_see_passwords.Location = new System.Drawing.Point(42, 203);
            this.checkBox_start_at_see_passwords.Name = "checkBox_start_at_see_passwords";
            this.checkBox_start_at_see_passwords.Size = new System.Drawing.Size(136, 17);
            this.checkBox_start_at_see_passwords.TabIndex = 7;
            this.checkBox_start_at_see_passwords.Text = "Start at See Passwords";
            this.checkBox_start_at_see_passwords.UseVisualStyleBackColor = true;
            this.checkBox_start_at_see_passwords.CheckedChanged += new System.EventHandler(this.checkBox_start_at_see_passwords_CheckedChanged);
            // 
            // MasterPasswordWall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 228);
            this.Controls.Add(this.checkBox_start_at_see_passwords);
            this.Controls.Add(this.button_delete_all_data);
            this.Controls.Add(this.button_show_hint);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_verify_password);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MasterPasswordWall";
            this.Text = "MasterPasswordWall";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_verify_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_show_hint;
        private System.Windows.Forms.Button button_delete_all_data;
        private System.Windows.Forms.CheckBox checkBox_start_at_see_passwords;
    }
}