using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using PasswordsStashLite.Logic;

namespace PasswordsStashLite.UI
{
    public partial class TestRoom : Form
    {
        public TestRoom()
        {
            InitializeComponent();
            //Interac
            this.Text = Memory.program_title_bar;
        }

        private void button_print_random_number_on_console_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(random.Next(1, 34857875));
            }
        }

        private void button_aes_to_string_Click(object sender, EventArgs e)
        {
            string input = textBox_aes.Text;
            Run.MESSAGEBOX(AES.Decrypt(input, Memory.master_password.legible_master_password), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
