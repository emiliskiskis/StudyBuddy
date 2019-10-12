using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;

namespace StudyBuddy
{
    public partial class Login : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public string TextToSend;
        private readonly Regex portRegex = new Regex("^[0-9][1-9]{1,4}$");

        public Login()
        {
            InitializeComponent();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    UserAddressField.Text = address.ToString();
                }
            }
        }

        private void ClientStartButton_Click(object sender, EventArgs e)
        {
            ValidateClientFields();
            if (!HasErrors(new List<TextBox>() {
                UserAddressField,
                UserPortField
            }))
            {
                TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(UserPortField.Text));
                ClientStartButton.Enabled = false;
                ClientStartButton.Text = "Waiting for client...";

                new Thread(new ThreadStart(() =>
                {
                    listener.Start();
                    client = listener.AcceptTcpClient();
                    STR = new StreamReader(client.GetStream());
                    STW = new StreamWriter(client.GetStream())
                    {
                        AutoFlush = true
                    };

                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;
                })).Start();
            }
        }

        private void ServerLoginButton_Click(object sender, EventArgs e)
        {
            ValidateServerFields();
            if (!HasErrors(new List<TextBox>()
            {
                ServerAddressField,
                ServerPortField
            }))
            {
                client = new TcpClient();
                IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ServerAddressField.Text), int.Parse(ServerPortField.Text));
                try
                {
                    client.Connect(IpEnd);

                    if (client.Connected)
                    {
                        ChatLogField.AppendText("Connected to server!\r\n");

                        STW = new StreamWriter(client.GetStream())
                        {
                            AutoFlush = true
                        };
                        STR = new StreamReader(client.GetStream());
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                    this.ChatLogField.Invoke(new MethodInvoker(delegate
                   {
                       ChatLogField.AppendText("Them: " + receive + "\r\n");
                   }));
                    receive = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(TextToSend);
                this.ChatLogField.Invoke(new MethodInvoker(delegate ()
                {
                    ChatLogField.AppendText("Me: " + TextToSend + "\r\n");
                }));
            }
            else
            {
                MessageBox.Show("Sending failed");
            }
            backgroundWorker2.CancelAsync();
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            SendMessage(MessageField);
        }

        private void MessageField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage(MessageField);
            }
        }

        private void UserAddressField_Validating(object sender, CancelEventArgs e)
        {
            ValidateAddressField(UserAddressField);
        }

        private void UserPortField_Validating(object sender, CancelEventArgs e)
        {
            ValidatePortField(UserPortField);
        }

        private void ServerAddressField_Validating(object sender, CancelEventArgs e)
        {
            ValidateAddressField(ServerAddressField);
        }

        private void ServerPortField_Validating(object sender, CancelEventArgs e)
        {
            ValidatePortField(ServerPortField);
        }

        private bool HasErrors(List<TextBox> textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (errorProvider.GetError(textBox).Length > 0) return true;
            }
            return false;
        }

        private void SendMessage(TextBox textBox)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                TextToSend = MessageField.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            textBox.Text = "";
        }

        private void ValidateClientFields()
        {
            ValidateFields(UserAddressField, UserPortField);
        }

        private void ValidateServerFields()
        {
            ValidateFields(ServerAddressField, ServerPortField);
        }

        private void ValidateFields(TextBox addressField, TextBox portField)
        {
            ValidateAddressField(addressField);
            ValidatePortField(portField);
        }

        private void ValidateAddressField(TextBox addressField)
        {
            if (!IPAddress.TryParse(addressField.Text, out _))
            {
                errorProvider.SetError(addressField, "Invalid IP");
            }
            else
            {
                errorProvider.SetError(addressField, "");
            }
        }

        private void ValidatePortField(TextBox portField)
        {
            if (!portRegex.IsMatch(portField.Text))
            {
                errorProvider.SetError(portField, "Invalid port");
            }
            else
            {
                errorProvider.SetError(portField, "");
            }
        }

        private void ServerPortField_TextChanged(object sender, EventArgs e)
        {
        }
    }
}