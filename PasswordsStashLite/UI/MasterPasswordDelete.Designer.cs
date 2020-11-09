namespace PasswordsStashLite.UI
{
    partial class MasterPasswordDelete
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_delete_master_password = new System.Windows.Forms.Button();
            this.button_show_hint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Master Password:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBox1.Location = new System.Drawing.Point(210, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(271, 29);
            this.textBox1.TabIndex = 1;
            // 
            // button_delete_master_password
            // 
            this.button_delete_master_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button_delete_master_password.Location = new System.Drawing.Point(9, 41);
            this.button_delete_master_password.Name = "button_delete_master_password";
            this.button_delete_master_password.Size = new System.Drawing.Size(472, 26);
            this.button_delete_master_password.TabIndex = 2;
            this.button_delete_master_password.Text = "Delete master password";
            this.button_delete_master_password.UseVisualStyleBackColor = true;
            this.button_delete_master_password.Click += new System.EventHandler(this.button_delete_master_password_Click);
            // 
            // button_show_hint
            // 
            this.button_show_hint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button_show_hint.Location = new System.Drawing.Point(9, 71);
            this.button_show_hint.Name = "button_show_hint";
            this.button_show_hint.Size = new System.Drawing.Size(472, 26);
            this.button_show_hint.TabIndex = 4;
            this.button_show_hint.Text = "Show hint";
            this.button_show_hint.UseVisualStyleBackColor = true;
            this.button_show_hint.Click += new System.EventHandler(this.button_show_hint_Click);
            // 
            // MasterPasswordDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_show_hint);
            this.Controls.Add(this.button_delete_master_password);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "MasterPasswordDelete";
            this.Size = new System.Drawing.Size(485, 102);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_delete_master_password;
        private System.Windows.Forms.Button button_show_hint;
    }
}
