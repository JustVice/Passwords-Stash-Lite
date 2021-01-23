using PasswordsStashLite.Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordsStashLite.UI
{
    public partial class MasterPasswordWall : Form
    {
        public MasterPasswordWall()
        {
            InitializeComponent();
            SETTINGS();
            this.Text = Memory.program_title_bar;
        }

        #region SETTINGS
        private void SETTINGS()
        {
            // To set focus on the password textbox.
            this.ActiveControl = this.textBox_password;
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.textBox_password.PasswordChar = '*';
            IS_THERE_A_HINT();
            checkBox_start_at_see_passwords_check();
            password_hint_button();
        }

        private void password_hint_button()
        {
            password_hint_button_toggle_enable(!string.IsNullOrWhiteSpace(Memory.master_password.password_hint));
        }

        private void password_hint_button_toggle_enable(bool status)
        {
            this.button_show_hint.Enabled = status;
        }

        private void checkBox_start_at_see_passwords_check()
        {
            if (Memory.start_program_at_see_passwords)
            {
                this.checkBox_start_at_see_passwords.Checked = true;
            }
            else
            {
                this.checkBox_start_at_see_passwords.Checked = false;
            }
        }

        private void IS_THERE_A_HINT()
        {
            //true: clickeable button. False: button not clickeable.
        }
        #endregion

        #region CHECK PASSWORD
        private void button_verify_password_Click(object sender, EventArgs e)
        {
            VERIFY_PASWORD_ACTION_PERFORMED();
        }

        private void VERIFY_PASSWORD_TREE(string password)
        {
            if (IS_THERE_SOMETHING_TYPED_INSIDE_THE_TEXTBOX(password))
            {
                if (IS_PASSWORD_CORRECT(password))
                {
                    Run.RegisterLog(2, 0, "User has entered a correct Master Password and entered the software.");
                    PASSWORD_IS_CORRECT();
                }
                else
                {
                    PASSWORD_IS_INCORRECT();
                    Run.RegisterLog(2, 14, "User has entered a wrong Master Password");
                }
            }
        }

        private void PASSWORD_IS_CORRECT()
        {
            Run.DECODE_ALL_PASSWORDS_ON_MEMORY();
            Run.DECRYPT_ALL_PASSWORDS_ON_MEMORY();
            Console.WriteLine("Password is correct. OK!");
            //opens Home.
            if (this.checkBox_start_at_see_passwords.Checked)
            {
                Run.RegisterLog(2, 3, "User entered See Passwords window from home window.");
                this.Hide();
                var next_form = new SeePasswords();
                next_form.Closed += (s, args) => this.Close();
                next_form.Show();
            }
            else // opens see passwords form.
            {
                Run.RegisterLog(2, 3, "User entered See Passwords window from home Master Password welcome form.");
                this.Hide();
                var next_form = new Home();
                next_form.Closed += (s, args) => this.Close();
                next_form.Show();
            }
        }

        private void PASSWORD_IS_INCORRECT()
        {
            this.textBox_password.ForeColor = Color.Red;
        }

        private bool IS_THERE_SOMETHING_TYPED_INSIDE_THE_TEXTBOX(string password)
        {
            if (!string.IsNullOrEmpty(password))
                return true;
            else
                Console.WriteLine("No password written down.");
            //do nothing..
            return false;
        }

        private bool IS_PASSWORD_CORRECT(string password)
        {
            return CHECK_PASSWORD_IF_CORRECT(password);
        }

        private bool CHECK_PASSWORD_IF_CORRECT(string password)
        {
            string sha512_password = Sha512.string_to_sha512(password);
            if (sha512_password == Memory.master_password.sha512_master_password)
            {
                Memory.master_password.legible_master_password = password;
                return true;
            }
            else
                return false;
        }

        private void VERIFY_PASWORD_ACTION_PERFORMED()
        {
            string password = this.textBox_password.Text;
            Console.WriteLine("Password typed: " + password);
            VERIFY_PASSWORD_TREE(password);
        }
        #endregion

        private void button_delete_all_data_Click(object sender, EventArgs e)
        {
            Run r = new Run();
            r.DELETE_ALL_DATA_METHOD_TREE();
        }

        private void button_show_hint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Memory.master_password.password_hint))
            {
                Run.RegisterLog(2, 15, "User has asked for the Master Password hint.");
                Run.MESSAGEBOX("Passwords hint:\r\n" +
                    Memory.master_password.password_hint, "Password hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox_start_at_see_passwords_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_start_at_see_passwords.Checked)
            {
                Memory.inifile.SAVE_LOAD_AT_SEE_PASSWORDS("true");
                Memory.start_program_at_see_passwords = true;
                Console.WriteLine("Start program at See Passwords TRUE.");
            }
            else
            {
                Memory.inifile.SAVE_LOAD_AT_SEE_PASSWORDS("false");
                Memory.start_program_at_see_passwords = false;
                Console.WriteLine("Start program at See Passwords FALSE.");
            }
        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VERIFY_PASWORD_ACTION_PERFORMED();
            }
        }

    }
}
