using StudyBuddy.Managers;
using StudyBuddy.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudyBuddy.Forms
{
    public partial class Chat : Form
    {
        private readonly FormManager _formManager;
        private readonly NetworkManager _networkManager;
        private List<ChatHistory> _messages;
        private string groupName;
        private ChatGroupSession session;

        public Chat(FormManager formManager, NetworkManager networkManager, string groupName)
        {
            InitializeComponent();
            _formManager = formManager;
            _networkManager = networkManager;
            _messages = new List<ChatHistory>();
            this.groupName = groupName;
        }

        private void AddMessage(ChatHistory msg)
        {
            ChatLog.AppendText($"{msg.User.username} [{msg.SentAt.ToLocalTime().ToShortTimeString()}]: {msg.Text}\n");
        }

        private void AddMessage(string username, DateTime dateTime, string text)
        {
            ChatLog.AppendText($"{username} [{dateTime.ToShortTimeString()}]: {text}\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _networkManager.SendMessage(session.user, session.groupId, MessageBox.Text);
            MessageBox.Clear();
        }

        private void Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formManager.CloseAllForms();
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private async void Chat_Load(object sender, EventArgs e)
        {
            await _networkManager.StartHubAsync();
            session = new ChatGroupSession(_networkManager.GetUserInfo(), groupName);
            _networkManager.ConnectToGroup(session);
            _messages = await _networkManager.GetChatHubHistoryAsync(session.groupId);
            PrintChatHistory();
            _networkManager.ReceiveMessage((username, groupName, messageText, date) =>
            {
                AddMessage(username, date, messageText);
            });
        }

        private void PrintChatHistory()
        {
            _messages.ForEach(msg => AddMessage(msg));
        }
    }
}
