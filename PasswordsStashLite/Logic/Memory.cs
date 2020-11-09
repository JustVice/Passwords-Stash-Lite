using PasswordsStashLite.Object;
using System.Collections.Generic;

namespace PasswordsStashLite.Logic
{
    public class Memory
    {
        //Paths
        public static string sqlite_database_name = "psldata.db";
        public static string sqlite_database_path = 
            Run.GET_PROGRAM_PATH() + "\\" + sqlite_database_name;
        public static string inifile_datafile_name = "userdata.ini";
        public static string inifile_datafile_path =
            Run.GET_PROGRAM_PATH() + "\\" + inifile_datafile_name;

        //Titles
        public static string program_name = "Passwords Stash Lite";
        public static string version = "2.0.3";
        public static string program_title_bar = program_name + " " + version;
        

        //Booleans
        public static bool is_master_password_activated = false;
        public static bool is_base64_activated = true;
        public static bool is_the_first_time_that_the_program_runs = true;
        public static bool start_program_at_see_passwords = false;
        public static bool developer_mode = false;
        public static bool hide_about = false;

        //Objects
        public static SQLiteController  sqlite = new SQLiteController();
        public static List<Password> passwords_list = new List<Password>();
        public static MasterPassword master_password = new MasterPassword();
        public static INIFileController inifile = new INIFileController();
        public static UI.MasterPassword master_password_form;

        //Enums
        public enum initial_panel
        {
            Home = 0,
            SeePasswords = 1,
            about = 3,
            moreAndSettings = 4,
            CreatePassword = 5,
            MasterPasswordWall = 6,
            welcome = 7,
            MasterPasswordCreate = 8,
            MasterPasswordDelete = 9
        }

        //Program initialization string
        public static string initiate_program_at = initial_panel.Home.ToString();

    }
}
