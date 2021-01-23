namespace PasswordsStashLite.UI
{
    partial class Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
            this.button_back = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox_filter = new System.Windows.Forms.ComboBox();
            this.button_LogDictionary = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_info = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(12, 452);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(125, 23);
            this.button_back.TabIndex = 0;
            this.button_back.Text = "Back to settings";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(816, 436);
            this.listBox1.TabIndex = 1;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // comboBox_filter
            // 
            this.comboBox_filter.FormattingEnabled = true;
            this.comboBox_filter.Items.AddRange(new object[] {
            "All",
            "Title",
            "Type",
            "Description",
            "Date latest",
            "Date older"});
            this.comboBox_filter.Location = new System.Drawing.Point(539, 455);
            this.comboBox_filter.Name = "comboBox_filter";
            this.comboBox_filter.Size = new System.Drawing.Size(121, 21);
            this.comboBox_filter.TabIndex = 3;
            this.comboBox_filter.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // button_LogDictionary
            // 
            this.button_LogDictionary.Location = new System.Drawing.Point(666, 455);
            this.button_LogDictionary.Name = "button_LogDictionary";
            this.button_LogDictionary.Size = new System.Drawing.Size(163, 23);
            this.button_LogDictionary.TabIndex = 4;
            this.button_LogDictionary.Text = "Open log reference dictionary";
            this.button_LogDictionary.UseVisualStyleBackColor = true;
            this.button_LogDictionary.Click += new System.EventHandler(this.button_LogDictionary_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filder";
            // 
            // button_info
            // 
            this.button_info.Location = new System.Drawing.Point(143, 453);
            this.button_info.Name = "button_info";
            this.button_info.Size = new System.Drawing.Size(56, 23);
            this.button_info.TabIndex = 6;
            this.button_info.Text = "Info";
            this.button_info.UseVisualStyleBackColor = true;
            this.button_info.Click += new System.EventHandler(this.button_info_Click);
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 483);
            this.Controls.Add(this.button_info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_LogDictionary);
            this.Controls.Add(this.comboBox_filter);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_back);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Log";
            this.Text = "Log";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox_filter;
        private System.Windows.Forms.Button button_LogDictionary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_info;
    }
}