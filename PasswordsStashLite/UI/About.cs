using PasswordsStashLite.Logic;
using System;
using System.Windows.Forms;

namespace PasswordsStashLite.UI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            SETTINGS();
            this.Text = "PSLite " + Memory.version;
        }

        private void SETTINGS()
        {
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pictureBox1.Image = Properties.Resources.vice_logo;
        }

        private void button_back_to_settings_Click(object sender, EventArgs e)
        {
            this.Hide();
            var next_form = new MoreAndSettings();
            next_form.Closed += (s, args) => this.Close();
            next_form.Show();
        }

        private void label_pslite_web_page_Click(object sender, EventArgs e)
        {
            Run.OPEN_LINK_ON_BROWSER("http://split-vice/technology/CSharp/passwords-stash-lite/");
        }

        private void label_pslite_github_Click(object sender, EventArgs e)
        {
            Run.OPEN_LINK_ON_BROWSER("https://github.com/SplitVice/Passwords-Stash-Lite");
        }

        private void label_vice_links_Click(object sender, EventArgs e)
        {
            Run.OPEN_LINK_ON_BROWSER("http://split-vice.com");
        }
    }
}
