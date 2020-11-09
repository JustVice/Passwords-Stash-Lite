using System;
using System.Windows.Forms;
using PasswordsStashLite.Logic;

namespace PasswordsStashLite.UI
{
    public partial class MasterPasswordDelete : UserControl
    {
        public MasterPasswordDelete()
        {
            InitializeComponent();
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

        private void button_delete_master_password_Click(object sender, EventArgs e)
        {
            string typed_password = this.textBox1.Text;
            if (typed_password == Memory.master_password.legible_master_password)
            {
                Memory.is_master_password_activated = false;
                Run.PASSWORDS_ON_DATABASE_GET_DECRYPTED();
                delete_master_password_on_memory();
                delete_master_password_on_database();
                ui_setting_after_deleting_master_password();
                OPEN_SETTINGS_AND_MORE_WINDOW();
            }
            else
            { 
                Run.MESSAGEBOX("Wrong Master Password password.",
                    "Wrong password",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void OPEN_SETTINGS_AND_MORE_WINDOW()
        {
            Memory.master_password_form.OPEN_HOME();
        }

        private void delete_master_password_on_database()
        {
            string query = "DELETE FROM MASTERPASSWORD";
            string message = "Master Password record deleted from database. OK.";
            Memory.sqlite.Query(query, message);
        }

        private void delete_master_password_on_memory()
        {
            Memory.master_password = new Object.MasterPassword();
            Console.WriteLine("Master Password record deleted from memory. OK.");
        }

        private void ui_setting_after_deleting_master_password()
        {
            string message = "Master Password deleted!\r\n\r\n" +
                "Note: Passwords stored also missed the encryption.";
            Run.MESSAGEBOX(message, "Master Password deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_show_hint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Memory.master_password.password_hint))
            {
                Run.MESSAGEBOX("Passwords hint:\r\n" +
                    Memory.master_password.password_hint, "Password hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
