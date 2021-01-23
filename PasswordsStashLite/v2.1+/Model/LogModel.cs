using System;

namespace PasswordsStashLite.v2._1_.Model
{
    public class LogModel
    {
        public int LogId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public LogModel() { }

        public LogModel(string title, string type, string description)
        {
            DateTime localDate = DateTime.Now; // Generates the date to store.
            Title = title;
            Type = type;
            Description = description;
            Date = localDate.ToString();
        }

        public override string ToString()
        {
            string str = string.Format(@"{0}. {1}. {2} {3}.", Date, Title, Description, Type);
            return str;
        }

        public static string[] LogTitles =
        {
                "Navigation" // 0
                , "Warning" // 1
                , "Critic" // 2
                , "Query" // 3
        };

        public static string[] LogTypes = {
                "Login" // 0
                , "App opened" // 1
                , "PS created" // 2
                , "See Passwords" // 3
                , "PS deleted" // 4
                , "PS edited" // 5
                , "PS copied" // 6
                , "Settings opened" // 7
                , "MPsswd created" // 8
                , "MPsswd deleted" // 9
                , "Easter Egg" // 10
                , "About" // 11
                , "About act" // 12
                , "Error" // 13
                , "Login failed" // 14
                , "Hint request" // 15
                , "Navigating" // 16
                , "MPsswd query" // 17
                };
    }
}
