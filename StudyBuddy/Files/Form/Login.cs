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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SumbitButton_Click(object sender, EventArgs e)
        {
            String ip = IpTextField.Text;
            String name = NameTextField.Text;

            this.Hide();
            Chat chatForm = new Chat();
            chatForm.Show();
        }
    }
}
