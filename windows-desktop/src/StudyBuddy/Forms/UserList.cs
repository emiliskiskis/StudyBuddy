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
    public partial class UserList : Form
    {
        private readonly FormManager _formManager;

        public UserList(FormManager formManager)
        {
            InitializeComponent();
            _formManager = formManager;
        }

        private void UserList_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formManager.CloseAllForms();
        }

        private void UserList_Load(object sender, EventArgs e)
        {
        }
    }
}
