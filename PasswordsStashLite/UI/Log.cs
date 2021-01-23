using PasswordsStashLite.Logic;
using PasswordsStashLite.v2._1_.Controller;
using PasswordsStashLite.v2._1_.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PasswordsStashLite.UI
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
            SETTINGS();
            this.Text = "Passwords Stash Lite " + Memory.version;
            LoadLogs();
            PopulateComboboxFilter();
        }

        private void LoadLogs()
        {
            this.listBox1.Items.Clear();
            LogController logController = new LogController(Memory.sqlite_database_path);
            List<LogModel> LogModel_list = logController.ReadLogs();
            LogModel_list.Reverse();
            foreach (var item in LogModel_list)
            {
                this.listBox1.Items.Add(item);
            }
        }

        private void PopulateComboboxFilter()
        {
            comboBox_filter.Items.Clear();
            comboBox_filter.Items.Add("All");
            foreach (var item in LogModel.LogTitles)
            {
                comboBox_filter.Items.Add("Title: " + item);
            }

            foreach (var item in LogModel.LogTypes)
            {
                comboBox_filter.Items.Add("Type: " + item);
            }
        }

        #region SETTINGS
        private void SETTINGS()
        {
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Text = Memory.program_title_bar;
        }
        #endregion

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var next_form = new MoreAndSettings();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string SelectedValue = comboBox_filter.SelectedItem.ToString();
            if (SelectedValue.Equals("All"))
            {
                LoadLogs();
            }
            else
            {
                string option = ExtractSelectedOption(SelectedValue);
                LogController logController = new LogController(Memory.sqlite_database_path);
                List<LogModel> LogModel_list = logController.ReadLogs();
                LogModel_list.Reverse();
                this.listBox1.Items.Clear();
                if (SelectedValue.Contains("Title"))
                {
                    foreach (var item in LogModel_list)
                    {
                        if (item.Title.Equals(option))
                        {
                            this.listBox1.Items.Add(item);
                        }
                    }
                }
                else // Type
                {
                    foreach (var item in LogModel_list)
                    {
                        if (item.Type.Equals(option))
                        {
                            this.listBox1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private string ExtractSelectedOption(string input)
        {
            StringBuilder sb = new StringBuilder(input);
            if (sb.ToString().Contains("Title: "))
            {
                sb.Replace("Title: ", "");
            }

            if (sb.ToString().Contains("Type: "))
            {
                sb.Replace("Type: ", "");
            }
            return sb.ToString();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LogModel temp_log = return_selected_log_on_list();
            if (temp_log != null)
            {
                string message =
                    "Log details. Date: " + temp_log.Date + "\r\n\r\n" +
                    "Log title or severity: " + temp_log.Title + "\r\n" +
                    "Log type: " + temp_log.Type + "\r\n\r\n" +
                    "Log description: \r\n" +
                    temp_log.Description
                    ;
                Run.MESSAGEBOX(message, "Log details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private LogModel return_selected_log_on_list()
        {
            LogModel SelectedLogModel = this.listBox1.SelectedItem as LogModel;
            return SelectedLogModel;
        }

        private void button_LogDictionary_Click(object sender, EventArgs e)
        {
            Run.OPEN_LINK_ON_BROWSER("https://github.com/JustVice/Passwords-Stash-Lite/wiki/Log-variable-dictionary");
        }

        private void button_info_Click(object sender, EventArgs e)
        {
            string message =
                "This is a log of what operator of this Passwords Stash Lite instance has done through the application.\r\n\r\n" +
                "Double click any log instance to see it more clearly.\r\n" +
                "Click on Open log reference dictionary button to open Log wiki and to understand about its title and type instances.\r\n\r\n" +
                "Logs are meant to protect the owner of the application instance. If you want to delete logs, you can by deleting all application data.\r\n" +
                "Logs are only stored natively on the local Passwords Stash Lite instance.";
            Run.MESSAGEBOX(message, "Log info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
