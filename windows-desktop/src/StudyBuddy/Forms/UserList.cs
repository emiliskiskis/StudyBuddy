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
using StudyBuddy.Models;

namespace StudyBuddy.Forms
{
    public partial class UserList : Form
    {
        private readonly FormManager _formManager;
        private readonly NetworkManager _networkManager;
        private List<PublicUser> users;

        public UserList(FormManager formManager, NetworkManager networkManager)
        {
            InitializeComponent();
            _formManager = formManager;
            _networkManager = networkManager;
        }

        private void UserList_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formManager.CloseAllForms();
        }

        private async void UserList_Load(object sender, EventArgs e)
        {
            users = await _networkManager.GetAllUsersAsync();
            foreach (PublicUser x in users) listBox1.Items.Add(x.username+" ("+x.firstName+" "+x.lastName+")");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            PublicUser user = users.ElementAt(listBox1.SelectedIndex);
            string groupName = await _networkManager.GetGroupNameAsync(_networkManager.GetUserInfo().username, user.username);
            _formManager.OpenChat(this, groupName);
        }
    }
}
