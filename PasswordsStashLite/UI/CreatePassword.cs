using PasswordsStashLite.Logic;
using PasswordsStashLite.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsStashLite.UI
{
    public partial class CreatePassword : Form
    {
        public CreatePassword()
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
            FILL_SPACES_DEV_MODE();
        }

        private void FILL_SPACES_DEV_MODE()
        {
            if (Memory.developer_mode)
            {
                textBox_service.Text = "service";
                textBox_mail.Text = "email";
                textBox_user.Text = "user";
                textBox_password.Text = "password";
                textBox_notes.Text = "notes";
            }
        }
        #endregion

        #region KEY DOWN METHODS
        private void textBox_service_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CREATE_PASSWORD_TREE();
            }
        }

        private void textBox_mail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CREATE_PASSWORD_TREE();
            }
        }

        private void textBox_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CREATE_PASSWORD_TREE();
            }
        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CREATE_PASSWORD_TREE();
            }
        }

        private void textBox_notes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CREATE_PASSWORD_TREE();
            }
        }
        #endregion

        #region CREATE NEW PASSWORD
        private void button_create_new_password_Click_1(object sender, EventArgs e)
        {
            CREATE_PASSWORD_TREE();
        }

        private void CREATE_PASSWORD_TREE()
        {
            bool all_required_fields_filled = ARE_REQUIRED_FIELDS_FILLED();
            if (all_required_fields_filled)
            {
                Password new_pass = BUILD_PASSWORD_OBJECT();
                SAVE_PASSWORD_TREE(new_pass);
                UI_CHANGES_AFTER_SAVING_PASSWORD(new_pass);
                Run.RegisterLog(3, 2, "User has created a new password: " + new_pass.getService() + ".");
            }
        }

        private void SAVE_PASSWORD_TREE(Password pass)
        {
            SAVE_PASSWORD_ON_MEMORY(pass);
            Memory.sqlite.SAVE_PASSWORD_ON_DATABASE(pass);
        }

        private Password BUILD_PASSWORD_OBJECT()
        {
            string service = this.textBox_service.Text.ToUpper();
            string email = this.textBox_mail.Text;
            string user = this.textBox_user.Text;
            string password = this.textBox_password.Text;
            string notes = this.textBox_notes.Text;
            ///build object
            Password temp_password = new Password();
            temp_password.setEmail(email);
            temp_password.setUser(user);
            temp_password.setService(service);
            temp_password.setPassword_content(password);
            temp_password.setNotes(notes);
            return temp_password;
        }

        private void UI_CHANGES_AFTER_SAVING_PASSWORD(Password new_pass)
        {
            Run.MESSAGEBOX("Password " + new_pass.getService() + " saved.", "Password saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CLEAN_FIELDS();
            this.button_cancel.Text = "Back";
        }

        private void CLEAN_FIELDS()
        {
            this.textBox_service.Text = "";
            this.textBox_mail.Text = "";
            this.textBox_notes.Text = "";
            this.textBox_password.Text = "";
            this.textBox_user.Text = "";
        }

        private void SAVE_PASSWORD_ON_MEMORY(Password password)
        {
            Memory.passwords_list.Add(password);
        }

        private bool ARE_REQUIRED_FIELDS_FILLED()
        {
            if (!string.IsNullOrEmpty(this.textBox_service.Text)
                && !string.IsNullOrEmpty(this.textBox_password.Text))
            {
                if (!string.IsNullOrEmpty(this.textBox_mail.Text) ||
                    !string.IsNullOrEmpty(this.textBox_user.Text))
                {
                    FIELDS_ERROR_MESSAGE(0);
                    return true;
                }
                else
                {
                    FIELDS_ERROR_MESSAGE(1);
                    return false;
                }

            }
            else
            {
                FIELDS_ERROR_MESSAGE(1);
                return false;
            }
        }

        private void FIELDS_ERROR_MESSAGE(int option)
        {
            switch (option)
            {
                //All good.
                case 0:
                    Console.WriteLine("Required info. OK.");
                    break;
                //Info missing
                case 1:
                    Run.MESSAGEBOX("Required info missing!\r\nRequired info:\r\n\r\n" +
                        "- Service.\r\n" +
                        "- Either Email or User.\r\n" +
                        "- Password.", "Required info missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("Missing info to create a new password.");
                    break;
            }
        }
        #endregion

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var next_form = new Home();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }
    }
}
