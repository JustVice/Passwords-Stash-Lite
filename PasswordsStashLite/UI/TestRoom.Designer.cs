namespace PasswordsStashLite.UI
{
    partial class TestRoom
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
            this.button_print_random_number_on_console = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox_aes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_aes_to_string = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_print_random_number_on_console
            // 
            this.button_print_random_number_on_console.Location = new System.Drawing.Point(25, 21);
            this.button_print_random_number_on_console.Name = "button_print_random_number_on_console";
            this.button_print_random_number_on_console.Size = new System.Drawing.Size(173, 23);
            this.button_print_random_number_on_console.TabIndex = 0;
            this.button_print_random_number_on_console.Text = "Print random number on console";
            this.button_print_random_number_on_console.UseVisualStyleBackColor = true;
            this.button_print_random_number_on_console.Click += new System.EventHandler(this.button_print_random_number_on_console_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(42, 74);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(516, 308);
            this.webBrowser1.TabIndex = 1;
            // 
            // textBox_aes
            // 
            this.textBox_aes.Location = new System.Drawing.Point(155, 421);
            this.textBox_aes.Name = "textBox_aes";
            this.textBox_aes.Size = new System.Drawing.Size(125, 20);
            this.textBox_aes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "AES convert to string";
            // 
            // button_aes_to_string
            // 
            this.button_aes_to_string.Location = new System.Drawing.Point(287, 417);
            this.button_aes_to_string.Name = "button_aes_to_string";
            this.button_aes_to_string.Size = new System.Drawing.Size(75, 23);
            this.button_aes_to_string.TabIndex = 4;
            this.button_aes_to_string.Text = "Convert";
            this.button_aes_to_string.UseVisualStyleBackColor = true;
            this.button_aes_to_string.Click += new System.EventHandler(this.button_aes_to_string_Click);
            // 
            // TestRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 487);
            this.Controls.Add(this.button_aes_to_string);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_aes);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button_print_random_number_on_console);
            this.Name = "TestRoom";
            this.Text = "TestRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_print_random_number_on_console;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox_aes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_aes_to_string;
    }
}