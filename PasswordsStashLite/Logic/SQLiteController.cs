using PasswordsStashLite.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PasswordsStashLite.Logic
{
    public class SQLiteController : SQLite
    {
        public SQLiteController() : base(Memory.sqlite_database_path)
        {
        }

        #region LOAD DATA TREE METHODS
        public void LOAD_DATA_TREE()
        {
            bool database_exists = DOES_DATABASE_EXIST();
            if (database_exists)
            {
                bool database_integrity_ok = IS_DATABASE_INTEGRITY_OK();
                if (database_integrity_ok)
                {
                    LOAD_DATA_AND_SET_ON_MEMORY();
                }
                else
                {
                    DELETE_DATABASE_FILE();
                    CREATE_DATABASE();
                    //Use default settings.
                }
            }
            else
            {
                CREATE_DATABASE();
                //Use default settings.
            }
        }

        private bool DOES_DATABASE_EXIST()
        {
            return File.Exists(Memory.sqlite_database_path); ;
        }

        private bool IS_DATABASE_INTEGRITY_OK()
        {
            try
            {
                string query = "SELECT * FROM PASSWORD";
                string custom_console_message = "PASSWORD table checked. OK.";
                DataSet ds = Memory.sqlite.Fetch(query, custom_console_message);
                return true;
            }
            catch (Exception ex)
            {
                string console_message = "PASSWORD table checked. Corrupted. ";
                Console.WriteLine(console_message + ex);
                return false;
            }
        }

        private void LOAD_DATA_AND_SET_ON_MEMORY()
        {
            LOAD_DATA_AND_SET_ON_MEMORY_MASTER_PASSWORD();
            LOAD_DATA_AND_SET_ON_MEMORY_PASSWORDS();
        }

        private void LOAD_DATA_AND_SET_ON_MEMORY_MASTER_PASSWORD()
        {
            string query = "SELECT * FROM MASTERPASSWORD";
            string custom_console_message = "Master Password loaded from database: OK.";
            DataSet ds = Memory.sqlite.Fetch(query, custom_console_message);
            SET_CONTENT_LOADED_FROM_DATABASE_TO_MEMORY_MASTER_PASSWORD(ds);
        }

        private void SET_CONTENT_LOADED_FROM_DATABASE_TO_MEMORY_MASTER_PASSWORD(DataSet ds)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Memory.master_password.sha512_master_password = ds.Tables[0].Rows[i]["sha512_master_password"].ToString();
                Memory.master_password.password_hint = ds.Tables[0].Rows[i]["password_hint"].ToString();
            }
            string console_message = "Master Password set on memory: OK.";
            Console.WriteLine(console_message);
            Run.MASTER_PASSWORD_ACTIVATED_TOGGLE_CHECK();
        }

        private static void LOAD_DATA_AND_SET_ON_MEMORY_PASSWORDS()
        {
            string query = "SELECT * FROM PASSWORD";
            string custom_console_message = "Passwords load from database: OK.";
            DataSet ds = Memory.sqlite.Fetch(query, custom_console_message);
            SET_CONTENT_LOADED_FROM_DATABASE_TO_MEMORY_PASSWORDS(ds);
        }

        private static void SET_CONTENT_LOADED_FROM_DATABASE_TO_MEMORY_PASSWORDS(DataSet ds)
        {
            Password pass = new Password();
            Random random_number = new Random();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                pass.setService(ds.Tables[0].Rows[i]["service"].ToString());
                pass.setEmail(ds.Tables[0].Rows[i]["email"].ToString());
                pass.setUser(ds.Tables[0].Rows[i]["user"].ToString());
                pass.setPassword_content(ds.Tables[0].Rows[i]["password"].ToString());
                pass.setNotes(ds.Tables[0].Rows[i]["notes"].ToString());
                pass.setDatabaseID(int.Parse(ds.Tables[0].Rows[i]["id"].ToString()));
                pass.set_object_id(int.Parse(ds.Tables[0].Rows[i]["program_object_id"].ToString()));
                Memory.passwords_list.Add(pass);
                if (Memory.developer_mode)
                {
                    Console.WriteLine("SQLITE LOAD Password method object ID: " + pass.passwordsStashLiteObject_id);
                    Console.WriteLine("SQLITE LOAD Password method all information: " + pass);
                }
                pass = new Password();
            }
            string console_message = "Passwords set on list: OK.";
            Console.WriteLine(console_message);
        }

        public void DELETE_DATABASE_FILE()
        {
            try
            {
                File.Delete(Memory.sqlite_database_path);
            }
            catch (Exception ex)
            {
                string message = "An error has occurred.\r\n\r\n" +
                    "It seems another program has the database file open.\r\n" +
                    "Please, close this program before continue.\r\n" +
                    "If the problem persist, report this as a bug at official support.\r\n\r\n" +
                    "PasswordsStashLite official web page - JUST VICE.\r\n\r\n" +
                    "The program will close now.\r\n\r\n" +
                    "Error description:\r\n" + ex;
                Run.MESSAGEBOX(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }

        }

        public void WIPE_DATABASE_TABLES()
        {
            string query_1 = "DELETE FROM PASSWORD;";
            string query_2 = "DELETE FROM MASTERPASSWORD";

            Memory.sqlite.Query(query_1);
            Memory.sqlite.Query(query_2);
        }

        public void WIPE_PASSWORDS_TABLE()
        {
            string query_1 = "DELETE FROM PASSWORD;";
            string message = "Passwords wiped from database. OK.";
            Memory.sqlite.Query(query_1, message);
        }

        //This method creates the database file 
        //If the database exists, it only will
        //create the tables.
        public void CREATE_DATABASE()
        {
            string query = "CREATE TABLE \"PASSWORD\" " +
                "( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE" +
                ", `service` TEXT" +
                ", `email` TEXT" +
                ", `user` TEXT" +
                ", `password` TEXT" +
                ", `notes` TEXT" +
                ", `program_object_id` TEXT )";
            string query_2 = "CREATE TABLE \"MASTERPASSWORD\" " +
                "( \"id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE" +
                ", \"sha512_master_password\" TEXT" +
                ", \"password_hint\" TEXT)";
            string custom_console_message = "Database created. Table PASSWORD: OK.";
            string custom_console_message_2 = "Table MASTERPASSWORD. OK.";
            Memory.sqlite.Query(query, custom_console_message);
            Memory.sqlite.Query(query_2, custom_console_message_2);
        }

        public void SAVE_PASSWORD_ON_DATABASE(Password password)
        {
            string query = "";
            if (Memory.is_master_password_activated)
            {
                query = "INSERT INTO PASSWORD " +
                                "(service" +
                                ", email" +
                                ", user" +
                                ", password" +
                                ", notes" +
                                ", program_object_id)" +
                                "VALUES(" +
                                "'" + password.getServiceEncryptedBase64() + "'" +
                                ",'" + password.getEmailEncryptedBase64() + "'" +
                                ",'" + password.getUserEncryptedBase64() + "'" +
                                ",'" + password.getPassword_contentEncryptedBase64() + "'" +
                                ",'" + password.getNotesEncryptedBase64() + "'" +
                                ", '" + password.passwordsStashLiteObject_id + "');";
            }
            else
            {
                query = "INSERT INTO PASSWORD " +
                                "(service" +
                                ", email" +
                                ", user" +
                                ", password" +
                                ", notes" +
                                ", program_object_id)" +
                                "VALUES(" +
                                "'" + password.getServiceBase64() + "'" +
                                ",'" + password.getEmailBase64() + "'" +
                                ",'" + password.getUserBase64() + "'" +
                                ",'" + password.getPassword_contentBase64() + "'" +
                                ",'" + password.getNotesBase64() + "'" +
                                ", '" + password.passwordsStashLiteObject_id + "');";
            }
            string query_console = "Password  " + password.getService() + " added to database. OK.";
            Memory.sqlite.Query(query, query_console);
        }

        public void SAVE_ALL_PASSWORDS_ON_MEMORY_INTO_DATABASE()
        {
            foreach (Password p in Memory.passwords_list)
            {
                SAVE_PASSWORD_ON_DATABASE(p);
            }
        }

        public void SAVE_ALL_PASSWORDS_ON_MEMORY_INTO_DATABASE_BY_TEMP_LIST(List<Password> temp_list)
        {
            foreach (Password p in temp_list)
            {
                SAVE_PASSWORD_ON_DATABASE(p);
            }
            Console.WriteLine("Encrypted passwords stored on database by temporal list. OK");
        }
        #endregion
    }
}
