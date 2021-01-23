using PasswordsStashLite.Logic;
using System;
using System.Windows.Forms;

namespace PasswordsStashLite.UI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            SETTINGS();
            this.Text = "PSLite " + Memory.version;
        }

        #region SETTINGS
        private void SETTINGS()
        {
            this.CenterToScreen();
            this.MaximizeBox = false;
            PROGRAM_STARTED_AT_LEAST_ONE_TIME_SAVE_USER_DATA();
            BUTTON_SEE_PASSWORDS_HABILITATED_IF_THERE_ARE_PASSWORDS();
            //this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }
        private void BUTTON_SEE_PASSWORDS_HABILITATED_IF_THERE_ARE_PASSWORDS()
        {
            this.button_see_password.Enabled = Run.ARE_THERE_PASSWORDS_STORED();
        }
        #endregion

        private void PROGRAM_STARTED_AT_LEAST_ONE_TIME_SAVE_USER_DATA()
        {
            if (Memory.is_the_first_time_that_the_program_runs)
            {
                Memory.inifile.Write("UserData", "first_program_run", "false");
            }
        }

        private void button_create_new_password_Click(object sender, EventArgs e)
        {
            Run.RegisterLog(0, 16, "Create new password window opened.");
            this.Hide();
            var next_form = new CreatePassword();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }

        private void button_see_password_Click(object sender, EventArgs e)
        {
            Run.RegisterLog(2, 3, "User entered See Passwords window from home window.");
            this.Hide();
            var next_form = new SeePasswords();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }

        private void button_more_Click(object sender, EventArgs e)
        {
            Run.RegisterLog(0, 7, "User entered Settings window from home Window.");
            this.Hide();
            var next_form = new MoreAndSettings();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }

        private void Home_ResizeEnd(object sender, EventArgs e)
        {
            Run.RegisterLog(0, 10, "Hey! how did that get there?");
        }
    }
}
