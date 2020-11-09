using System;
using System.IO;

namespace PasswordsStashLite.Logic
{
    public class INIFileController : INIFile
    {

        public INIFileController() : base(Memory.inifile_datafile_path)
        {

        }

        private enum INIFileValue
        {
            MasterPassword,
            encrypt_decrypt_password,
            encrypted_string_key,
            password_hint,
            UserData,
            first_program_run,
            startAtSeePasswords
        }

        #region LOAD DATA METHOD TREE
        public void LOAD_DATA_TREE()
        {
            bool inifile_exists = DOES_INIFILE_EXIST();
            if (inifile_exists)
            {
                bool inifile_integrity_ok = IS_INIFILE_INTEGRITY_OK();
                if (inifile_integrity_ok)
                {
                    LOAD_DATA_AND_SET_ON_MEMORY();
                }
                else
                {
                    DELETE_INIFILE();
                    CREATE_INIFILE();
                    //Use default settings.
                }
            }
            else
            {
                CREATE_INIFILE();
                //Use default settings.
            }
        }

        private bool DOES_INIFILE_EXIST()
        {
            return File.Exists(Memory.inifile_datafile_path);
        }

        private bool IS_INIFILE_INTEGRITY_OK()
        {
            return true;
        }

        private void LOAD_DATA_AND_SET_ON_MEMORY()
        {
            string is_the_first_time_that_the_program_runs =
                Read(INIFileValue.UserData.ToString(),
                INIFileValue.first_program_run.ToString());

            if (is_the_first_time_that_the_program_runs == "true")
            {
                Memory.is_the_first_time_that_the_program_runs = true;
            }

            else if (is_the_first_time_that_the_program_runs == "false")
            {
                Memory.is_the_first_time_that_the_program_runs = false;
            }
            else
            {
                Memory.is_the_first_time_that_the_program_runs = false;
            }

            string start_program_at_See_Passwords =
                Read(INIFileValue.UserData.ToString(),
                INIFileValue.startAtSeePasswords.ToString());

            if (start_program_at_See_Passwords == "true")
            {
                Memory.start_program_at_see_passwords = true;
            }
            else if (start_program_at_See_Passwords == "false")
            {
                Memory.start_program_at_see_passwords = false;
            }
            else
            {
                Memory.start_program_at_see_passwords = false;
            }

            string console_message = "Data from INIFile load: OK.";
            Console.WriteLine(console_message);
        }

        public void DELETE_INIFILE()
        {
            File.Delete(Memory.inifile_datafile_path);
        }

        public void CREATE_INIFILE()
        {
            Write(INIFileValue.UserData.ToString()
               , INIFileValue.first_program_run.ToString()
               , "true");
            Write(INIFileValue.UserData.ToString(),
                INIFileValue.startAtSeePasswords.ToString(),
                "false");
            string console_message = "INIFile created. OK.";
            Console.WriteLine(console_message);
        }
        #endregion

        #region SAVE DATA METHODS
        public void SAVE_LOAD_AT_SEE_PASSWORDS(string value)
        {
            Write(INIFileValue.UserData.ToString(),
                INIFileValue.startAtSeePasswords.ToString(),
                value);
        }

        public bool LOAD_LOAD_AT_SEE_PASSWORDS()
        {
            string value = Read(INIFileValue.UserData.ToString()
                , INIFileValue.startAtSeePasswords.ToString()); ;
            if (value == "true")
            {
                return true;
            }
            else if (value == "false")
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}

