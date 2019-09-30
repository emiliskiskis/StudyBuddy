using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace StudyBuddy
{


    public partial class Login : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public string TextToSend;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ClientStartButton_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(UserPortField.Text));
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;

            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;
        }

        private void ServerLoginButton_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ServerAddressField.Text), int.Parse(ServerPortField.Text));

            try
            {
                client.Connect(IpEnd);

                if (client.Connected)
                {
                    ChatLogField.AppendText("Connected to server!" + "\r\n");

                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            {
                while (client.Connected)
                {
                    try
                    {
                        recieve = STR.ReadLine();
                        this.ChatLogField.Invoke(new MethodInvoker(delegate ()
                        {
                            ChatLogField.AppendText("You:" + recieve + "\r\n");
                        }));
                        recieve = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
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
                    ChatLogField.AppendText("Me:" + TextToSend + "\r\n");
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
            if (MessageField.Text != "")
            {
                TextToSend = MessageField.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            MessageField.Text = "";
        }
    }
}
