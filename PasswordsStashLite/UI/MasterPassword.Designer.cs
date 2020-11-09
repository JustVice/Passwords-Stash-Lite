namespace PasswordsStashLite.UI
{
    partial class MasterPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterPassword));
            this.label1 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.masterPasswordDelete1 = new PasswordsStashLite.UI.MasterPasswordDelete();
            this.masterPasswordCreate1 = new PasswordsStashLite.UI.MasterPasswordCreate();
            this.__________________________________________________ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Master Password";
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.button_cancel.Location = new System.Drawing.Point(18, 195);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(72, 29);
            this.button_cancel.TabIndex = 10;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // masterPasswordDelete1
            // 
            this.masterPasswordDelete1.Location = new System.Drawing.Point(18, 65);
            this.masterPasswordDelete1.Name = "masterPasswordDelete1";
            this.masterPasswordDelete1.Size = new System.Drawing.Size(484, 100);
            this.masterPasswordDelete1.TabIndex = 12;
            // 
            // masterPasswordCreate1
            // 
            this.masterPasswordCreate1.Location = new System.Drawing.Point(18, 48);
            this.masterPasswordCreate1.Name = "masterPasswordCreate1";
            this.masterPasswordCreate1.Size = new System.Drawing.Size(495, 141);
            this.masterPasswordCreate1.TabIndex = 11;
            // 
            // __________________________________________________
            // 
            this.__________________________________________________.AutoSize = true;
            this.__________________________________________________.Location = new System.Drawing.Point(15, 36);
            this.__________________________________________________.Name = "__________________________________________________";
            this.__________________________________________________.Size = new System.Drawing.Size(505, 13);
            this.__________________________________________________.TabIndex = 13;
            this.__________________________________________________.Text = "_________________________________________________________________________________" +
    "__";
            // 
            // MasterPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 227);
            this.Controls.Add(this.__________________________________________________);
            this.Controls.Add(this.masterPasswordDelete1);
            this.Controls.Add(this.masterPasswordCreate1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MasterPassword";
            this.Text = "MasterPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_cancel;
        private MasterPasswordCreate masterPasswordCreate1;
        private MasterPasswordDelete masterPasswordDelete1;
        private System.Windows.Forms.Label __________________________________________________;
    }
}