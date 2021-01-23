using PasswordsStashLite.Logic;
using System;
using System.Windows.Forms;

namespace PasswordsStashLite.UI
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            SETTINGS();
            this.Text = Memory.program_title_bar;
        }

        #region SETTINGS
        private void SETTINGS()
        {
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }
        #endregion

        private void button_set_master_password_Click(object sender, EventArgs e)
        {
            this.Hide();
            Memory.master_password_form = new MasterPassword(0, 0);
            Memory.master_password_form.Closed += (s, args) => this.Close();
            Memory.master_password_form.Show();
            Run.RegisterLog(0, 7, "Master Password Set opened from Welcome window.");
        }

        private void button_set_later_Click(object sender, EventArgs e)
        {
            this.Hide();
            var next_form = new Home();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
            Run.RegisterLog(0, 16, "Home window opened from Welcome window.");
        }
    }
}
