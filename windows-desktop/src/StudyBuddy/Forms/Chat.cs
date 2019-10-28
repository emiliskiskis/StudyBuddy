using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StudyBuddy.Models;
using StudyBuddy.Managers;

namespace StudyBuddy.Forms
{
    public partial class Chat : Form
    {
        private readonly NetworkManager _networkManager;
        private List<string> messages;
        private ChatGroupSession session;

        public Chat(NetworkManager networkManager)
        {
            InitializeComponent();
            _networkManager = networkManager;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _networkManager.SendMessage(session.user, session.groupId, MessageBox.Text);
            MessageBox.Clear();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Loading chat...");
            _networkManager.StartHub();
            Console.WriteLine("Hub started");
            session = new ChatGroupSession(_networkManager.GetUserInfo(), "TestGroup");
            Console.WriteLine("session set");
            _networkManager.ConnectToGroup(session);
            Console.WriteLine("Connected to Group");
        }
    }
}
