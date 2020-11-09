using PasswordsStashLite.Logic;
using PasswordsStashLite.Object;
using System;
using System.Windows.Forms;

namespace PasswordsStashLite.UI
{
    public partial class SeePasswords : Form
    {
        public SeePasswords()
        {
            InitializeComponent();
            SETTINGS();
        }

        #region SETTINGS
        private void SETTINGS()
        {
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LOAD_PASSWORDS_ON_LIST();
            this.Text = Memory.program_title_bar;
        }
        private void LOAD_PASSWORDS_ON_LIST()
        {
            this.listBox_passwords.Items.Clear();
            if (Run.ARE_THERE_PASSWORDS_STORED())
            {
                foreach (Password p in Memory.passwords_list)
                {
                    Console.WriteLine(p);
                    this.listBox_passwords.Items.Add(p);
                }
                Console.WriteLine("Passwords added to list (See passwords Window). OK.");
            }
            else
            {
                Console.WriteLine("No passwords stored!!!\r\n" +
                    "This window shouldn't be open.\r\n" +
                    "Are you a hacker!? ovo");
            }
        }
        #endregion

        #region RETURN HOME
        private void button_home_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            var next_form = new Home();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }
        #endregion

        #region COPY TO CLIPBOARD METHODS
        private void button_copy_password_Click(object sender, EventArgs e)
        {
            Password temp_password = return_selected_password_on_list();
            if (temp_password != null)
            {
                COPY_TO_CLIPBOARD_METHOD_TREE(temp_password, "password");
            }
        }
        private void button_copy_user_Click(object sender, EventArgs e)
        {
            Password temp_password = return_selected_password_on_list();
            if (temp_password != null)
            {
                COPY_TO_CLIPBOARD_METHOD_TREE(temp_password, "user");
            }
        }
        private void button_copy_email_Click(object sender, EventArgs e)
        {
            Password temp_password = return_selected_password_on_list();
            if (temp_password != null)
            {
                COPY_TO_CLIPBOARD_METHOD_TREE(temp_password, "email");
            }
        }
        private void button_notes_Click(object sender, EventArgs e)
        {
            Password temp_password = return_selected_password_on_list();
            if (temp_password != null)
            {
                COPY_TO_CLIPBOARD_METHOD_TREE(temp_password, "notes");
            }
        }
        private void COPY_TO_CLIPBOARD_METHOD_TREE(Password temp_password, string element_to_copy)
        {
            switch (element_to_copy)
            {
                case "user":
                    string user_content = temp_password.getUser();
                    if (!string.IsNullOrEmpty(user_content))
                    {
                        COPY_ELEMENT_TO_CLIPBOARD(temp_password.getUser());
                        CHANGE_COPY_BUTTONS_TEXT("Password", "Copied!", "Email", "Notes");
                    }
                    break;
                case "email":
                    string email_content = temp_password.getEmail();
                    if (!string.IsNullOrEmpty(email_content))
                    {
                        COPY_ELEMENT_TO_CLIPBOARD(temp_password.getEmail());
                        CHANGE_COPY_BUTTONS_TEXT("Password", "User", "Copied!", "Notes");
                    }
                    break;
                case "password":
                    COPY_ELEMENT_TO_CLIPBOARD(temp_password.getPassword_content());
                    CHANGE_COPY_BUTTONS_TEXT("Copied!", "User", "Email", "Notes");
                    break;
                case "notes":
                    string notes_content = temp_password.getNotes();
                    if (!string.IsNullOrEmpty(notes_content))
                    {
                        COPY_ELEMENT_TO_CLIPBOARD(temp_password.getNotes());
                        CHANGE_COPY_BUTTONS_TEXT("Password", "User", "Email", "Copied!");
                    }
                    break;
                default:
                    break;
            }
        }
        private void COPY_ELEMENT_TO_CLIPBOARD(string element_to_paste_on_clipboard)
        {
            Run.COPY_TO_CLIPBOARD(element_to_paste_on_clipboard);
        }
        private Password return_selected_password_on_list()
        {
            Password selected_password = this.listBox_passwords.SelectedItem as Password;
            return selected_password;
        }
        #endregion

        #region DELETE PASSWORD
        private void button_delete_password_Click(object sender, EventArgs e)
        {
            delete_password_method_tree();
        }

        private void delete_password_method_tree()
        {
            Password selected_password_to_delete = this.listBox_passwords.SelectedItem as Password;
            if (selected_password_to_delete != null)
            {
                bool user_sure_about_deleting_password = is_the_user_sure_about_deleting_password(selected_password_to_delete);
                if (user_sure_about_deleting_password)
                {
                    delete_password_from_database(selected_password_to_delete);
                    delete_password_from_memory(selected_password_to_delete);
                    after_delete_ui_changes();
                }
                else
                {
                    //do nothing
                }
            }
        }

        private void after_delete_ui_changes()
        {
            LOAD_PASSWORDS_ON_LIST();
        }

        private void delete_password_from_memory(Password selected_password_to_delete)
        {
            for (int i = 0; i < Memory.passwords_list.Count; i++)
            {
                if (selected_password_to_delete.passwordsStashLiteObject_id ==
                    Memory.passwords_list[i].passwordsStashLiteObject_id)
                {
                    Memory.passwords_list.RemoveAt(i);
                    Console.WriteLine("Password "
                        + selected_password_to_delete.getService()
                        + " deleted from memory. OK.");
                    break;
                }
            }
        }

        private void delete_password_from_database(Password selected_password_to_delete)
        {
            int password_to_delete_database_id = selected_password_to_delete.passwordsStashLiteObject_id;
            string database_query =
                "DELETE FROM PASSWORD WHERE program_object_id =" + password_to_delete_database_id + ";";
            string query_console_message =
                "Password " +
                selected_password_to_delete.getService() +
                " deleted from database. OK";
            Memory.sqlite.Query(database_query, query_console_message);
        }

        private bool is_the_user_sure_about_deleting_password(Password selected_password_to_delete)
        {
            var message_content = "Are you sure you want to delete\r\n" +
                "" + selected_password_to_delete.getService() + "\r\n" +
                "password? This action cannot be undone.";
            var option = MessageBox.Show(message_content, "Delete password"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option.ToString() == "Yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region EDIT PASSWORD
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button_edit_selected_password_Click(object sender, EventArgs e)
        {
            Password selected_password_to_edit = this.listBox_passwords.SelectedItem as Password;
            if (selected_password_to_edit != null)
            {
                Console.WriteLine("Editing: " + selected_password_to_edit.ToString());
                //Console.WriteLine("Database id: " + selected_password_to_edit.getDatabaseID());
                //Console.WriteLine("Object id: " + selected_password_to_edit.passwordsStashLiteObject_id);
                edit_password_tree(selected_password_to_edit);
            }
        }
        private void edit_password_tree(Password selected_password_to_edit)
        {
            this.Hide();
            var next_form = new EditPassword(selected_password_to_edit);
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }
        #endregion

        private void CHANGE_COPY_BUTTONS_TEXT(string password, string user, string email, string notes)
        {
            this.button_copy_password.Text = password;
            this.button_copy_user.Text = user;
            this.button_copy_email.Text = email;
            this.button_copy_notes.Text = notes;
        }

        private void listBox_passwords_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Password temp_password = return_selected_password_on_list();
            if (temp_password != null)
            {
                COPY_ELEMENT_TO_CLIPBOARD(temp_password.getPassword_content());
                CHANGE_COPY_BUTTONS_TEXT("Copied!", "User", "Email", "Notes");
            }
        }

        private void listBox_passwords_MouseClick(object sender, MouseEventArgs e)
        {
            CHANGE_COPY_BUTTONS_TEXT("Password", "User", "Email", "Notes");
            Password temp_password = return_selected_password_on_list();
            ENABLE_OR_DISABLE_COPY_BUTTONS_DEPENDING_ON_PASSWORD_CONTENT(temp_password);
        }

        private void ENABLE_OR_DISABLE_COPY_BUTTONS_DEPENDING_ON_PASSWORD_CONTENT(Password temp_password)
        {
            string email = temp_password.getEmail();
            string user = temp_password.getUser();
            string notes = temp_password.getNotes();
            button_copy_email.Enabled = !string.IsNullOrEmpty(email);
            button_copy_user.Enabled = !string.IsNullOrEmpty(user);
            button_copy_notes.Enabled = !string.IsNullOrEmpty(notes);
        }
    }
}