using PasswordsStashLite.Object;
using PasswordsStashLite.UI;
using PasswordsStashLite.v2._1_.Controller;
using PasswordsStashLite.v2._1_.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PasswordsStashLite.Logic
{
    public class Run
    {
        public void RUN_PROGRAM()
        {
            try
            {
                LOAD_DATA_FROM_INIFILE();
                LOAD_DATA_FROM_DATABASE();
                AFTER_LOAD_METHOD_TREE();
            }
            catch (Exception e)
            {
                string message = "There has been a problem with Passwords Stash Lite.\r\n" +
                    "The program will close now. If the problem persist, take a screenshot\r\n" +
                    "of the following error report and report it to the creator at https://justvice.github.io/h/send-message/" + "\r\n" +
                    "\r\n" +
                    "Error report:\r\n\r\n" +
                    e;
                Run.MESSAGEBOX(message, "An error has occured.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region NORMAL RUN METHODS
        private void AFTER_LOAD_METHOD_TREE()
        {
            NORMAL_RUN_TREE();
        }

        private void NORMAL_RUN_TREE()
        {
            if (FIRST_TIME_THE_PROGRAM_OPENS() && !Memory.is_master_password_activated)
            {
                Console.WriteLine("First time opening program.");
                string first_time_the_program_opens_string_option = Memory.initial_panel.welcome.ToString();
                OPEN_SELECTOR(first_time_the_program_opens_string_option);
                RegisterLog(0, 1, "User has opened the app for the first time.");
            }
            else
            {
                MASTER_PASSWORD_WALL_TREE();
            }
        }

        private bool FIRST_TIME_THE_PROGRAM_OPENS()
        {
            return Memory.is_the_first_time_that_the_program_runs;
        }

        private void MASTER_PASSWORD_WALL_TREE()
        {
            if (Memory.is_master_password_activated)
            {
                RegisterLog(0, 1, "User has opened the application and Master Password form was shown.");
                string console_message =
                    "Master password activated. Opening Master Password Wall.";
                Console.WriteLine(console_message);
                string master_password_wall_string_option = Memory.initial_panel.MasterPasswordWall.ToString();
                OPEN_SELECTOR(master_password_wall_string_option);
            }
            else
            {
                RegisterLog(0, 1, "User has opened the application and home window was shown.");
                DECODE_ALL_PASSWORDS_ON_MEMORY();
                string console_message =
                    "Master password disabled. Opening home.";
                Console.WriteLine(console_message);
                OPEN_SELECTOR(Memory.initiate_program_at);
            }
        }

        private void LOAD_DATA_FROM_DATABASE()
        {
            Memory.sqlite.LOAD_DATA_TREE();
        }

        private void LOAD_DATA_FROM_INIFILE()
        {
            Memory.inifile.LOAD_DATA_TREE();
        }
        #endregion

        #region FORM OPEN METHODS
        public void OPEN_SELECTOR(string initial_panel)
        {
            switch (initial_panel)
            {
                case "Home":
                    OPEN_HOME_FORM();
                    break;
                case "SeePasswords":
                    OPEN_SEE_PASSWORDS();
                    break;
                case "MasterPasswordCreate":
                    OPEN_MASTER_PASSWORD_CREATE();
                    break;
                case "MasterPasswordDelete":
                    OPEN_MASTER_PASSWORD_DELETE();
                    break;
                case "about":
                    OPEN_ABOUT();
                    break;
                case "moreAndSettings":
                    OPEN_MORE_AND_SETTINGS();
                    break;
                case "CreatePassword":
                    OPEN_CREATE_PASSWORD();
                    break;
                case "MasterPasswordWall":
                    OPEN_MASTER_PASSWORD_WALL();
                    break;
                case "welcome":
                    OPEN_WELCOME();
                    break;
                default:
                    Console.WriteLine("Open selector error! No critical error.");
                    OPEN_HOME_FORM();
                    break;
            }
        }
        public static void OPEN_HOME_FORM()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
        public static void OPEN_WELCOME()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Welcome());
        }
        public static void OPEN_MASTER_PASSWORD_WALL()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MasterPasswordWall());
        }
        public static void OPEN_CREATE_PASSWORD()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreatePassword());
        }
        public static void OPEN_MORE_AND_SETTINGS()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MoreAndSettings());
        }
        public static void OPEN_MASTER_PASSWORD_CREATE()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.MasterPassword(0, 0));
        }
        public static void OPEN_MASTER_PASSWORD_DELETE()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.MasterPassword(1, 0));
        }
        public static void OPEN_ABOUT()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new About());
        }
        public static void OPEN_SEE_PASSWORDS()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SeePasswords());
        }
        private void OPEN_TEST_ROOM()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestRoom());
        }
        #endregion

        #region MASTER PASSWORD STATIC METHODS
        public static void SAVE_MASTER_PASSWORD_SETTINGS_INSIDE_DATABASE(Object.MasterPassword new_mp)
        {
            string query_delete_old_registry = "DELETE FROM MASTERPASSWORD;";
            string console_delete_message = "MASTER PASSWORD old registry deleted. OK.";
            Memory.sqlite.Query(query_delete_old_registry, console_delete_message);

            string query_insert_new_settings = "INSERT INTO MASTERPASSWORD " +
                "(sha512_master_password" +
                ", password_hint)" +
                "VALUES ('" + new_mp.sha512_master_password + "'" +
                ", '" + new_mp.password_hint + "');";
            Console.WriteLine("sha512 content: -----------------" + new_mp.sha512_master_password);
            string console_new_regitry = "Master password new registry inserted. OK.";
            Memory.sqlite.Query(query_insert_new_settings, console_new_regitry);
        }
        public static void SAVE_MASTER_PASSWORD_SETTINGS_INSIDE_MEMORY(Object.MasterPassword new_mp)
        {
            Memory.master_password.legible_master_password = new_mp.legible_master_password;
            Memory.master_password.sha512_master_password = new_mp.sha512_master_password;
            Memory.master_password.password_hint = new_mp.password_hint;
        }
        public static void MASTER_PASSWORD_ACTIVATED_TOGGLE_CHECK()
        {
            Console.WriteLine("Master password encrypted_string_key content: '"
                + Memory.master_password.sha512_master_password + "'");
            if (!string.IsNullOrEmpty(Memory.master_password.sha512_master_password))
            {
                Console.WriteLine("Master password set. Master password activated: OK.");
                Memory.is_master_password_activated = true;
            }
            else
            {
                Console.WriteLine("Master password set. Master password not activated: OK.");
                Memory.is_master_password_activated = false;
            }
        }

        #region NEW MASTER PASSWORD CREATED AND THERE ARE PASSWORDS STORED METHODS
        public static void PASSWORDS_ON_DATABASE_GET_ENCRYPTED()
        {
            Memory.sqlite.WIPE_PASSWORDS_TABLE();
            Memory.sqlite.SAVE_ALL_PASSWORDS_ON_MEMORY_INTO_DATABASE();
        }

        private static List<Password> ENCRYPT_ALL_PASSWORDS_ON_MEMORY_AND_RETURN_THEM_IN_A_TEMP_LIST()
        {
            List<Password> temp_list = new List<Password>();
            for (int i = 0; i < Memory.passwords_list.Count; i++)
            {
                Password temp_password = Memory.passwords_list[i];

                string encrypted_service = temp_password.getServiceEncryptedBase64();
                string encrypted_email = temp_password.getEmailEncryptedBase64();
                string encrypted_user = temp_password.getUserEncryptedBase64();
                string encrypted_password = temp_password.getPassword_contentEncryptedBase64();
                string encrypted_notes = temp_password.getNotesEncryptedBase64();

                temp_password.setService(encrypted_service);
                temp_password.setEmail(encrypted_email);
                temp_password.setUser(encrypted_user);
                temp_password.setPassword_content(encrypted_password);
                temp_password.setNotes(encrypted_notes);
                temp_list.Add(temp_password);
            }
            Console.WriteLine("Temporal encrypted passwords list created. OK.");
            return temp_list;
        }

        private void ENCRYPT_ALL_PASSWORDS_ON_MEMORY()
        {
            List<Password> temp_list = new List<Password>();
            for (int i = 0; i < Memory.passwords_list.Count; i++)
            {
                Password temp_password = Memory.passwords_list[i];
                string encrypted_service = AES.Encrypt(temp_password.getService(), Memory.master_password.legible_master_password);
                string encrypted_email = AES.Encrypt(temp_password.getEmail(), Memory.master_password.legible_master_password);
                string encrypted_user = AES.Encrypt(temp_password.getUser(), Memory.master_password.legible_master_password);
                string encrypted_password = AES.Encrypt(temp_password.getPassword_content(), Memory.master_password.legible_master_password);
                string encrypted_notes = AES.Encrypt(temp_password.getNotes(), Memory.master_password.legible_master_password);

                temp_password.setService(encrypted_service);
                temp_password.setEmail(encrypted_email);
                temp_password.setUser(encrypted_user);
                temp_password.setPassword_content(encrypted_password);
                temp_password.setNotes(encrypted_notes);
                temp_list.Add(temp_password);
            }
            Memory.passwords_list = temp_list;
            Console.WriteLine("Passwords on memory encrypted. OK.");
        }

        public static void PASSWORDS_ON_DATABASE_GET_DECRYPTED()
        {
            Memory.sqlite.WIPE_PASSWORDS_TABLE();
            Memory.sqlite.SAVE_ALL_PASSWORDS_ON_MEMORY_INTO_DATABASE();
        }

        public static void DECODE_ALL_PASSWORDS_ON_MEMORY()
        {
            List<Password> temp_list = new List<Password>();
            for (int i = 0; i < Memory.passwords_list.Count; i++)
            {
                Password temp_password = Memory.passwords_list[i];
                string decored_service = Base64.Base64Decode(temp_password.getService());
                string decored_email = Base64.Base64Decode(temp_password.getEmail());
                string decored_user = Base64.Base64Decode(temp_password.getUser());
                string decored_password = Base64.Base64Decode(temp_password.getPassword_content());
                string decored_notes = Base64.Base64Decode(temp_password.getNotes());

                temp_password.setService(decored_service);
                temp_password.setEmail(decored_email);
                temp_password.setUser(decored_user);
                temp_password.setPassword_content(decored_password);
                temp_password.setNotes(decored_notes);
                temp_list.Add(temp_password);
            }
            Memory.passwords_list = temp_list;
            Console.WriteLine("Passwords on memory decrypted. OK.");
            Run.PRINT_MEMORY_PASSWORD_ON_CONSOLE();
        }

        public static void DECRYPT_ALL_PASSWORDS_ON_MEMORY()
        {
            List<Password> temp_list = new List<Password>();
            for (int i = 0; i < Memory.passwords_list.Count; i++)
            {
                Password temp_password = Memory.passwords_list[i];
                string decrypted_service = AES.Decrypt(temp_password.getService(), Memory.master_password.legible_master_password);
                string decrypted_email = AES.Decrypt(temp_password.getEmail(), Memory.master_password.legible_master_password);
                string decrypted_user = AES.Decrypt(temp_password.getUser(), Memory.master_password.legible_master_password);
                string decrypted_password = AES.Decrypt(temp_password.getPassword_content(), Memory.master_password.legible_master_password);
                string decrypted_notes = AES.Decrypt(temp_password.getNotes(), Memory.master_password.legible_master_password);

                temp_password.setService(decrypted_service);
                temp_password.setEmail(decrypted_email);
                temp_password.setUser(decrypted_user);
                temp_password.setPassword_content(decrypted_password);
                temp_password.setNotes(decrypted_notes);
                temp_list.Add(temp_password);
            }
            Memory.passwords_list = temp_list;
            Console.WriteLine("Passwords on memory decrypted. OK.");
            Run.PRINT_MEMORY_PASSWORD_ON_CONSOLE();
        }
        #endregion

        #endregion

        #region SMALL LOGIC DETAILS
        public static string GET_PROGRAM_PATH()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        internal static bool ARE_THERE_PASSWORDS_STORED()
        {
            return Memory.passwords_list.Count > 0;
        }

        public static void MESSAGEBOX(string message_content,
            string title,
            MessageBoxButtons mbButtons,
            MessageBoxIcon mbIcon)
        {
            MessageBox.Show(message_content, title, mbButtons, mbIcon);
        }

        public static void COPY_TO_CLIPBOARD(string to_clipboard)
        {
            Clipboard.SetText(to_clipboard);
        }

        public static void OPEN_LINK_ON_BROWSER(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("OPEN BROWSER WITH URL ERROR.\r\n" + ex);
            }
        }

        /// <summary>
        /// Inserts a new log into the database.
        /// </summary>
        /// <param name="title">Title index from LogModel.LogTitles[]</param>
        /// <param name="type">Type index from LogModel.LogTypes[]</param>
        /// <param name="description">Description of the log.</param>
        public static async void RegisterLog(int title
            , int type
            , string description)
        {
            string title_str = LogModel.LogTitles[title];
            string type_str = LogModel.LogTypes[type];

            LogModel logModel = new LogModel(title_str, type_str, description);
            LogController logController = new LogController(Memory.sqlite_database_path);
            logController.InsertLog(logModel);
        }
        #endregion

        public static void PRINT_MEMORY_PASSWORD_ON_CONSOLE()
        {
            if (Memory.developer_mode)
            {
                foreach (Password p in Memory.passwords_list)
                {
                    Console.WriteLine(p);
                }
            }
        }

        #region DELETE ALL DATA
        public void DELETE_ALL_DATA_METHOD_TREE()
        {
            bool user_sure_about_deleting_all_data = is_user_sure_about_deleteting_all_data();
            if (user_sure_about_deleting_all_data)
            {
                delete_all_data_from_database();
                delete_all_data_from_ini_file();
                delete_all_data_from_memory();
                ui_changes_after_deleting_all_data();
            }
        }

        private bool is_user_sure_about_deleteting_all_data()
        {
            string message = "Are you sure you want to delete all data?\r\n" +
                "This includes:\r\n\r\n" +
                "- All passwords stored.\r\n" +
                "- Master Password config.\r\n\r\n" +
                "This action cannot be undone.\r\n\r\n" +
                "Press Yes to confirm.";
            DialogResult dr = MessageBox.Show(message, "Delete all data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Console.WriteLine("Delete all data");
                return true;
            }
            else return false;
        }

        private void ui_changes_after_deleting_all_data()
        {
            Console.WriteLine("...");
            Console.WriteLine("All data deleted. Success. OK.");
            string message = "All data was deleted!\r\n" +
                               "Program will close now.";
            Run.MESSAGEBOX(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Environment.Exit(1);
        }

        private void delete_all_data_from_memory()
        {
            Memory.passwords_list = new List<Password>();
            Console.WriteLine("Passwords on memory deteled. OK.");
            Memory.master_password = new Object.MasterPassword();
            Console.WriteLine("Master password information on memory deteled. OK.");
        }

        private void delete_all_data_from_ini_file()
        {
            Memory.inifile.DELETE_INIFILE();
            Console.WriteLine("Ini file deteled. OK.");
            Memory.inifile.CREATE_INIFILE();
            Console.WriteLine("new ini file created. OK.");
        }

        private void delete_all_data_from_database()
        {
            Memory.sqlite.WIPE_DATABASE_TABLES();
            Console.WriteLine("Database deleted... OK.");
            Memory.sqlite.CREATE_DATABASE();
            Console.WriteLine("New database created... OK.");
        }
        #endregion
    }
}
