using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyBuddy.Managers;

namespace StudyBuddy.Forms
{
    public partial class MainMenu : Form
    {
        private readonly FormManager _formManager;
        private readonly NetworkManager _networkManager;

        public MainMenu(FormManager formManager, NetworkManager networkManager)
        {
            InitializeComponent();
            _formManager = formManager;
            _networkManager = networkManager;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _formManager.Add(FormManager.FormType.signin);

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _formManager.Add(FormManager.FormType.register);

            this.Hide();
        }
    }
}
