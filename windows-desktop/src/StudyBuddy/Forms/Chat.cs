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
        private List<ChatHistory> _messages;
        private ChatGroupSession session;
        private string groupName;

        public Chat(NetworkManager networkManager, string groupName)
        {
            InitializeComponent();
            _networkManager = networkManager;
            _messages = new List<ChatHistory>();
            this.groupName = groupName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _networkManager.SendMessage(session.user, session.groupId, MessageBox.Text);
            MessageBox.Clear();
        }

        private async void Chat_Load(object sender, EventArgs e)
        {
            await _networkManager.StartHubAsync();
            session = new ChatGroupSession(_networkManager.GetUserInfo(), groupName);
            _networkManager.ConnectToGroup(session);
            _messages = await _networkManager.GetChatHubHistoryAsync(session.groupId);
            PrintChatHistory(session.groupId);
            _networkManager.ReceiveMessage((username, groupName, messageText) =>
            {
                ChatLog.AppendText($"{username} [{groupName}] : {messageText}\n");
            });
        }

        private void PrintChatHistory(string groupName)
        {
            foreach (var msg in _messages)
            {
                ChatLog.AppendText($"{msg.User.username} [{groupName}] : {msg.Text}\n");
            }
        }
    }
}
