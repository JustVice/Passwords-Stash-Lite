using PasswordsStashLite.Logic;
using System;
using System.Windows.Forms;

namespace PasswordsStashLite.UI
{
    public partial class MoreAndSettings : Form
    {
        public MoreAndSettings()
        {
            InitializeComponent();
            SETTINGS();
            this.Text = "Passwords Stash Lite " + Memory.version;
        }

        #region SETTINGS
        private void SETTINGS()
        {
            this.CenterToScreen();
            this.MaximizeBox = false;
            button_about.Enabled = !Memory.hide_about;
            //this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }
        #endregion

        #region BUTTONS
        private void button_master_password_Click(object sender, System.EventArgs e)
        {
            if (Memory.is_master_password_activated)
            {
                Run.RegisterLog(2, 17, "User has entered the DELETE Master Password window.");
                this.Hide();
                Memory.master_password_form = new MasterPassword(1, 1);
                Memory.master_password_form.Closed += (s, args) => this.Close();
                Memory.master_password_form.Show();
            }
            else
            {
                Run.RegisterLog(2, 17, "User has entered the CREATE Master Password window.");
                this.Hide();
                Memory.master_password_form = new MasterPassword(0, 1);
                Memory.master_password_form.Closed += (s, args) => this.Close();
                Memory.master_password_form.Show();
            }
            
        }
        
        private void button_about_Click(object sender, System.EventArgs e)
        {
            Run.RegisterLog(0, 11, "User has entered About window. Thats me!");
            this.Hide();
            var next_form = new About();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }
        #endregion

        #region DELETE ALL DATA
        private void button_delete_all_data_Click(object sender, System.EventArgs e)
        {
            Run.RegisterLog(2, 16, "User has pressed Delete all data button!");
            Run r = new Run();
            r.DELETE_ALL_DATA_METHOD_TREE();
        }
        #endregion

        private void button_back_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            var next_form = new Home();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }

        private void label_whats_this_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Opening Easter Egg 2...");
            string url = "https://dl.dropboxusercontent.com/s/905d2fgfbn3cady/room-pslite.png?dl=0";
            Run.RegisterLog(0, 10, "That's my room when I made this program.");
            Run.OPEN_LINK_ON_BROWSER(url);
        }

        private void button_logs_Click(object sender, EventArgs e)
        {
            Run.RegisterLog(0, 16, "User has entered Logs Window.");
            this.Hide();
            var next_form = new Log();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }
    }
}
