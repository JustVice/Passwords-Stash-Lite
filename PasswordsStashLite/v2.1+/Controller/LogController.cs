using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using PasswordsStashLite.v2._1_.Model;
using PasswordsStashLite.Logic;

namespace PasswordsStashLite.v2._1_.Controller
{
    public class LogController
    {
        private SQLiteConnection sqlite_conn;
        private string sqlite_database_path;

        public LogController(string SQLite_database_path)
        {
            if (SQLite_database_path_contains_dot_db(SQLite_database_path))
            {
                this.sqlite_database_path = SQLite_database_path;
            }
            else
            {
                this.sqlite_database_path = SQLite_database_path + ".db";
            }
            this.sqlite_conn = new SQLiteConnection(
                "Data Source= " + this.sqlite_database_path + "; " +
                "Version = 3; " +
                "New = True; " +
                "Compress = True; ");
        }

        #region CRUD

        public void InsertLog(LogModel logModel)
        {
            SQLiteCommand sqlite_cmd;
            string query =
                string.Format(
                "INSERT INTO Log(Title, Type, Description, Date) " +
                "VALUES('{0}','{1}','{2}','{3}')"
                , logModel.Title, logModel.Type, logModel.Description, logModel.Date);
            try
            {
                this.sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = query;
                sqlite_cmd.ExecuteNonQuery();
                Console.WriteLine("Log saved.");
            }
            catch (Exception ex)
            {
                Console.Write("Error performing Query!\n\r" + ex);
                this.sqlite_conn.Close();
                CreateLogTable();
            }
            finally
            {
                this.sqlite_conn.Close();
            }
        }

        public List<LogModel> ReadLogs()
        {
            SQLiteCommand sql_cmd;
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            string query = "SELECT * FROM Log";
            try
            {
                this.sqlite_conn.Open();
                sql_cmd = this.sqlite_conn.CreateCommand();
                DB = new SQLiteDataAdapter(query, this.sqlite_conn);
                DS.Reset();
                DB.Fill(DS);
                Console.WriteLine("Fetch query completed.");
            }
            catch (Exception ex)
            {
                this.sqlite_conn.Close();
                Console.WriteLine("Read data failed! \n\r" + ex);
            }
            finally
            {
                this.sqlite_conn.Close();
            }
            List<LogModel> lista_LogModel = new List<LogModel>();
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                lista_LogModel.Add(new LogModel
                {
                    LogId = Int32.Parse(DS.Tables[0].Rows[i]["LogId"].ToString()),
                    Title = DS.Tables[0].Rows[i]["Title"].ToString(),
                    Type = DS.Tables[0].Rows[i]["Type"].ToString(),
                    Description = DS.Tables[0].Rows[i]["Description"].ToString(),
                    Date = DS.Tables[0].Rows[i]["Date"].ToString()
                });
            }
            return lista_LogModel;
        }

        public void DeleteLog(int LogId)
        {
            SQLiteCommand sqlite_cmd;
            string query = 
                string.Format("DELETE FROM Log WHERE LogId = {0}", LogId);
            try
            {
                this.sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = query;
                sqlite_cmd.ExecuteNonQuery();
                Console.WriteLine("Query successful. Log " + LogId + " deleted.");
            }
            catch (Exception ex)
            {
                Console.Write("Error performing Query!\n\r" + ex);
                this.sqlite_conn.Close();
            }
            finally
            {
                this.sqlite_conn.Close();
            }
        }

        /// <summary>
        /// Creates the log table if it does not exist in the current
        /// database file. Then tries again the query.
        /// </summary>
        /// <param name="logModel"></param>
        private void CreateLogTable()
        {
            string query = @"CREATE TABLE `Log`(
                `LogId` INTEGER NOT NULL UNIQUE,
                `Title` TEXT,
	            `Type`  TEXT,
	            `Description`   TEXT,
	            `Date`  TEXT,
	            PRIMARY KEY(`LogId` AUTOINCREMENT)
                );";
            string custom_console_message = "Warning: Log table does not exist. It has been created now.";
            Memory.sqlite.Query(query, custom_console_message);
        }

        #endregion

        private bool SQLite_database_path_contains_dot_db(string SQLite_database_path)
        {
            return SQLite_database_path.Contains(".db");
        }
    }
}
