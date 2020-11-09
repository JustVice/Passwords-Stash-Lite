using PasswordsStashLite.Logic;
using System;
using System.Windows.Forms;

namespace PasswordsStashLite.UI
{
    public partial class MasterPassword : Form
    {
        //panel_option
        //0=create master password
        //1=delete master password

        //master_password_opened_from
        //0=When user clicks cancel, the form Home will be displayed.
        //1=When user clicks cancel, the form MoreAndSettings will be displayed.
        private int panel_option;

        private int master_password_opened_from;

        public MasterPassword(int panel_option, int master_password_opened_from)
        {
            InitializeComponent();
            this.panel_option = panel_option;
            this.master_password_opened_from = master_password_opened_from;
            SETTINGS();
            this.Text = Memory.program_title_bar;
        }

        #region SETTINGS
        private void SETTINGS()
        {
            this.CenterToScreen();
            this.MaximizeBox = false;
            PANEL_TO_SHOW();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }
        private void PANEL_TO_SHOW()
        {
            switch (panel_option)
            {
                case 0:
                    this.masterPasswordCreate1.Show();
                    this.masterPasswordDelete1.Hide();
                    break;
                case 1:
                    this.masterPasswordDelete1.Show();
                    this.masterPasswordCreate1.Hide();
                    break;
            }
        }
        #endregion

        #region OPEN FORM METHODS
        private void button_cancel_Click(object sender, EventArgs e)
        {
            if(this.master_password_opened_from == 0)
            {
                this.Hide();
                var next_form = new Home();
                next_form.Closed += (s, args) => this.Close();
                next_form.Show();
            }
            else
            {
                this.Hide();
                var next_form = new MoreAndSettings();
                next_form.Closed += (s, args) => this.Close();
                next_form.Show();
            }
        }
        public void OPEN_HOME()
        {
            this.Hide();
            var next_form = new Home();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }
        #endregion
    }
}
