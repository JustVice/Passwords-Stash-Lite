using PasswordsStashLite.Logic;
using PasswordsStashLite.Object;
using System;
using System.Windows.Forms;

namespace PasswordsStashLite.UI
{
    public partial class EditPassword : Form
    {
        private Password password_to_edit_classGlobalVariable;

        public EditPassword(Password password_to_edit)
        {
            this.password_to_edit_classGlobalVariable = password_to_edit;
            InitializeComponent();
            SETTINGS();
            this.Text = Memory.program_title_bar;
        }

        #region SETTINGS
        private void SETTINGS()
        {
            this.CenterToScreen();
            this.MaximizeBox = false;
            load_password_to_edit_on_fields(this.password_to_edit_classGlobalVariable);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }
        private void load_password_to_edit_on_fields(Password p)
        {
            this.textBox_service.Text = p.getService();
            this.textBox_email.Text = p.getEmail();
            this.textBox_user.Text = p.getUser();
            this.textBox_notes.Text = p.getNotes();
            this.textBox_password.Text = p.getPassword_content();
        }
        #endregion

        #region KEY DOWN EDIT
        private void textBox_service_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EDIT_PASSWORD_METHOD_TREE();
            }
        }

        private void textBox_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EDIT_PASSWORD_METHOD_TREE();
            }
        }

        private void textBox_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EDIT_PASSWORD_METHOD_TREE();
            }
        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EDIT_PASSWORD_METHOD_TREE();
            }
        }

        private void textBox_notes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EDIT_PASSWORD_METHOD_TREE();
            }
        }
        #endregion

        #region LOGIC METHODS
        private void button_save_edit_changes_Click(object sender, EventArgs e)
        {
            EDIT_PASSWORD_METHOD_TREE();
        }

        private void EDIT_PASSWORD_METHOD_TREE()
        {
            if (are_neccesary_fields_filled())
            {
                Password password_edited = build_edited_password();
                save_changes_on_memory(password_edited);
                save_changes_on_database(password_edited);
                ui_changes_after_save_changes();
            }
        }

        private Password build_edited_password()
        {
            Password edited_password = new Password();
            edited_password.setService(this.textBox_service.Text);
            edited_password.setEmail(this.textBox_email.Text);
            edited_password.setUser(this.textBox_user.Text);
            edited_password.setPassword_content(this.textBox_password.Text);
            edited_password.setNotes(this.textBox_notes.Text);
            edited_password.passwordsStashLiteObject_id = this.password_to_edit_classGlobalVariable.passwordsStashLiteObject_id;
            edited_password.setDatabaseID(this.password_to_edit_classGlobalVariable.getDatabaseID());
            return edited_password;
        }

        private void ui_changes_after_save_changes()
        {
            Run.MESSAGEBOX("Password successfully edited.", "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Hide();
            var next_form = new SeePasswords();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }

        private void save_changes_on_memory(Password password_to_edit_method_scope)
        {
            int password_object_id = password_to_edit_method_scope.passwordsStashLiteObject_id;
            for (int i = 0; i < Memory.passwords_list.Count; i++)
            {
                if (Memory.passwords_list[i].passwordsStashLiteObject_id == password_object_id)
                {
                    Memory.passwords_list[i] = password_to_edit_method_scope;
                    Console.WriteLine("Password edited on memory. OK.");
                    break;
                }
            }
        }

        private void save_changes_on_database(Password password_edited)
        {
            int password_id = password_edited.passwordsStashLiteObject_id;
            string query = "";
            if (Memory.is_master_password_activated)
            {
                query = "UPDATE PASSWORD SET " +
                "service = '" + password_edited.getServiceEncryptedBase64() + "'" +
                ", email = '" + password_edited.getEmailEncryptedBase64() + "'" +
                ", user = '" + password_edited.getUserEncryptedBase64() + "'" +
                ", password = '" + password_edited.getPassword_contentEncryptedBase64() + "'" +
                ", notes = '" + password_edited.getNotesEncryptedBase64() + "'" +
                " WHERE " +
                "program_object_id = '" + password_id + "'";
            }
            else
            {
                query = "UPDATE PASSWORD SET " +
                "service = '" + password_edited.getServiceBase64() + "'" +
                ", email = '" + password_edited.getEmailBase64() + "'" +
                ", user = '" + password_edited.getUserBase64() + "'" +
                ", password = '" + password_edited.getPassword_contentBase64() + "'" +
                ", notes = '" + password_edited.getNotesBase64() + "'" +
                " WHERE " +
                "program_object_id = '" + password_id + "'";
            }
            string console_query_message = "Password edited. OK.";
            Memory.sqlite.Query(query,console_query_message);
        }

        private bool are_neccesary_fields_filled()
        {
            if (!string.IsNullOrEmpty(this.textBox_service.Text)
                && !string.IsNullOrEmpty(this.textBox_password.Text))
            {
                if (!string.IsNullOrEmpty(this.textBox_email.Text) ||
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
                        "Service.\r\n" +
                        "Either Email or User.\r\n" +
                        "Password.", "Required info missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("Missing info to create a new password.");
                    break;
            }
        }
        #endregion

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var next_form = new SeePasswords();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }
    }
}
