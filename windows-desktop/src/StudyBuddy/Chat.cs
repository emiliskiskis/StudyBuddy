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
    public partial class Chat : Form
    {
        ChatGroupSession session;

        List<string> messages;

        public Chat()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetworkManager.SendMessage(session.user, session.groupId, MessageBox.Text);
            MessageBox.Clear();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Loading chat...");
            NetworkManager.StartHub();
            Console.WriteLine("Hub started");
            session = new ChatGroupSession(NetworkManager.GetUserInformation(), "TestGroup");
            Console.WriteLine("session set");
            NetworkManager.ConnectToGroup(session);
            Console.WriteLine("Connected to Group");
        }
    }
}
