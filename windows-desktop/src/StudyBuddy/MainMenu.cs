using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyBuddy
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignIn sign = new SignIn();
            FormManager.Add(sign);
            sign.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            FormManager.Add(reg);
            reg.Show();

            this.Hide();
        }
    }
}
