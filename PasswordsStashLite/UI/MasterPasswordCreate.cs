using System;
using System.Windows.Forms;
using PasswordsStashLite.Logic;

namespace PasswordsStashLite.UI
{
    public partial class MasterPasswordCreate : UserControl
    {
        public MasterPasswordCreate()
        {
            InitializeComponent();
        }

        #region CREATE MASTER PASSWORD
        private void button_save_master_password_Click(object sender, EventArgs e)
        {
            CREATE_MASTER_PASSWORD_TREE();
        }

        private void CREATE_MASTER_PASSWORD_TREE()
        {
            bool password_fields_correctly_set = ARE_PASSWORD_FIELDS_CORRECTLY_SET_TREE();
            if (password_fields_correctly_set)
            {
                Object.MasterPassword new_mp = BUILD_MASTER_PASSWORD_OBJECT();
                if (IS_THERE_A_MASTER_PASSWORD_HINT_TYPED())
                {
                    new_mp.password_hint = this.textBox_password_hint.Text;
                    Console.WriteLine("Password hint: " + new_mp.password_hint);
                }
                SAVE_MASTER_PASSWORD_SETTINGS(new_mp);
                bool there_are_passwords_stored = ARE_THERE_PASSWORDS_STORED();
                if (there_are_passwords_stored)
                {
                    Run.PASSWORDS_ON_DATABASE_GET_ENCRYPTED();
                }
                else
                {
                    //do nothing..
                }
                UI_CHANGES_AFTER_SAVE_MASTER_PASSWORD();
            }
        }

        private void UI_CHANGES_AFTER_SAVE_MASTER_PASSWORD()
        {
            Run.MESSAGEBOX("Master Password set", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Memory.master_password_form.OPEN_HOME();
        }

        private bool ARE_THERE_PASSWORDS_STORED()
        {
            return Run.ARE_THERE_PASSWORDS_STORED();
        }

        private void SAVE_MASTER_PASSWORD_SETTINGS(Object.MasterPassword new_mp)
        {
            Run.SAVE_MASTER_PASSWORD_SETTINGS_INSIDE_MEMORY(new_mp);
            Run.SAVE_MASTER_PASSWORD_SETTINGS_INSIDE_DATABASE(new_mp);
            Memory.is_master_password_activated = true;
        }

        private bool IS_THERE_A_MASTER_PASSWORD_HINT_TYPED()
        {
            return !string.IsNullOrWhiteSpace(this.textBox_password_hint.Text);
        }

        private Object.MasterPassword BUILD_MASTER_PASSWORD_OBJECT()
        {
            Object.MasterPassword temp_mp = new Object.MasterPassword();

            string password_typed = this.textBox_password_1.Text;
            temp_mp.legible_master_password = password_typed;
            temp_mp.sha512_master_password = Sha512.string_to_sha512(password_typed);

            return temp_mp;
        }

        #region PASSWORDS FIELDS CHECKER METHODS
        private bool ARE_PASSWORD_FIELDS_CORRECTLY_SET_TREE()
        {
            if (IS_THEHRE_A_PASSWORD_TYPED_ON_FIELD_1() &&
                IS_THEHRE_A_PASSWORD_TYPED_ON_FIELD_2() &&
                ARE_PASSWORD_FIELD_1_AND_2_WITH_THE_SAME_STRING_TYPED())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool ARE_PASSWORD_FIELD_1_AND_2_WITH_THE_SAME_STRING_TYPED()
        {
            string password_1 = this.textBox_password_1.Text;
            string password_2 = this.textBox_password_2.Text;
            if (password_1 == password_2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Master Password typed on fields are not the same.");
                Run.MESSAGEBOX("The passwords typed on field 1 and 2 are not the same"
                    , "Not same passwords typed"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool IS_THEHRE_A_PASSWORD_TYPED_ON_FIELD_2()
        {
            string password_field_2 = this.textBox_password_2.Text;
            if (!string.IsNullOrEmpty(password_field_2))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Master Password Field 2 empty.");
                return false;
            }
        }

        private bool IS_THEHRE_A_PASSWORD_TYPED_ON_FIELD_1()
        {
            string password_field_1 = this.textBox_password_1.Text;
            if (!string.IsNullOrEmpty(password_field_1))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Master Password field 1 empty.");
                return false;
            }
        }
        #endregion

        #endregion
    }
}