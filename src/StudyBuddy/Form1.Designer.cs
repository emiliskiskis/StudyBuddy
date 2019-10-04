namespace StudyBuddy
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ChatLogField = new System.Windows.Forms.TextBox();
            this.MessageField = new System.Windows.Forms.TextBox();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.ClientSetup = new System.Windows.Forms.GroupBox();
            this.UserPortLabel = new System.Windows.Forms.Label();
            this.UserPortField = new System.Windows.Forms.TextBox();
            this.UserAddressLabel = new System.Windows.Forms.Label();
            this.UserAddressField = new System.Windows.Forms.TextBox();
            this.ClientStartButton = new System.Windows.Forms.Button();
            this.ServerSetup = new System.Windows.Forms.GroupBox();
            this.ServerPortLabel = new System.Windows.Forms.Label();
            this.ServerLoginButton = new System.Windows.Forms.Button();
            this.ServerPortField = new System.Windows.Forms.TextBox();
            this.ServerAddressField = new System.Windows.Forms.TextBox();
            this.ServerAddressLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ClientSetup.SuspendLayout();
            this.ServerSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ChatLogField
            // 
            this.ChatLogField.Location = new System.Drawing.Point(309, 24);
            this.ChatLogField.Multiline = true;
            this.ChatLogField.Name = "ChatLogField";
            this.ChatLogField.Size = new System.Drawing.Size(426, 251);
            this.ChatLogField.TabIndex = 6;
            // 
            // MessageField
            // 
            this.MessageField.Location = new System.Drawing.Point(309, 281);
            this.MessageField.Name = "MessageField";
            this.MessageField.Size = new System.Drawing.Size(426, 20);
            this.MessageField.TabIndex = 7;
            this.MessageField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageField_KeyDown);
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.Location = new System.Drawing.Point(309, 317);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(426, 23);
            this.SendMessageButton.TabIndex = 8;
            this.SendMessageButton.Text = "Send";
            this.SendMessageButton.UseVisualStyleBackColor = true;
            this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker2_DoWork);
            // 
            // ClientSetup
            // 
            this.ClientSetup.Controls.Add(this.UserPortLabel);
            this.ClientSetup.Controls.Add(this.UserPortField);
            this.ClientSetup.Controls.Add(this.UserAddressLabel);
            this.ClientSetup.Controls.Add(this.UserAddressField);
            this.ClientSetup.Controls.Add(this.ClientStartButton);
            this.ClientSetup.Location = new System.Drawing.Point(15, 24);
            this.ClientSetup.Name = "ClientSetup";
            this.ClientSetup.Size = new System.Drawing.Size(275, 140);
            this.ClientSetup.TabIndex = 12;
            this.ClientSetup.TabStop = false;
            this.ClientSetup.Text = "User Settings";
            // 
            // UserPortLabel
            // 
            this.UserPortLabel.AutoSize = true;
            this.UserPortLabel.Location = new System.Drawing.Point(6, 78);
            this.UserPortLabel.Name = "UserPortLabel";
            this.UserPortLabel.Size = new System.Drawing.Size(29, 13);
            this.UserPortLabel.TabIndex = 4;
            this.UserPortLabel.Text = "Port:";
            // 
            // UserPortField
            // 
            this.UserPortField.Location = new System.Drawing.Point(41, 75);
            this.UserPortField.Name = "UserPortField";
            this.UserPortField.Size = new System.Drawing.Size(100, 20);
            this.UserPortField.TabIndex = 3;
            this.UserPortField.Validating += new System.ComponentModel.CancelEventHandler(this.UserPortField_Validating);
            // 
            // UserAddressLabel
            // 
            this.UserAddressLabel.AutoSize = true;
            this.UserAddressLabel.Location = new System.Drawing.Point(6, 25);
            this.UserAddressLabel.Name = "UserAddressLabel";
            this.UserAddressLabel.Size = new System.Drawing.Size(73, 13);
            this.UserAddressLabel.TabIndex = 2;
            this.UserAddressLabel.Text = "User Address:";
            // 
            // UserAddressField
            // 
            this.UserAddressField.Location = new System.Drawing.Point(6, 41);
            this.UserAddressField.Name = "UserAddressField";
            this.UserAddressField.Size = new System.Drawing.Size(262, 20);
            this.UserAddressField.TabIndex = 1;
            this.UserAddressField.Validating += new System.ComponentModel.CancelEventHandler(this.UserAddressField_Validating);
            // 
            // ClientStartButton
            // 
            this.ClientStartButton.Location = new System.Drawing.Point(6, 111);
            this.ClientStartButton.Name = "ClientStartButton";
            this.ClientStartButton.Size = new System.Drawing.Size(262, 23);
            this.ClientStartButton.TabIndex = 0;
            this.ClientStartButton.Text = "Start";
            this.ClientStartButton.UseVisualStyleBackColor = true;
            this.ClientStartButton.Click += new System.EventHandler(this.ClientStartButton_Click);
            // 
            // ServerSetup
            // 
            this.ServerSetup.Controls.Add(this.ServerPortLabel);
            this.ServerSetup.Controls.Add(this.ServerLoginButton);
            this.ServerSetup.Controls.Add(this.ServerPortField);
            this.ServerSetup.Controls.Add(this.ServerAddressField);
            this.ServerSetup.Controls.Add(this.ServerAddressLabel);
            this.ServerSetup.Location = new System.Drawing.Point(13, 183);
            this.ServerSetup.Name = "ServerSetup";
            this.ServerSetup.Size = new System.Drawing.Size(277, 157);
            this.ServerSetup.TabIndex = 13;
            this.ServerSetup.TabStop = false;
            this.ServerSetup.Text = "Server Settings";
            // 
            // ServerPortLabel
            // 
            this.ServerPortLabel.AutoSize = true;
            this.ServerPortLabel.Location = new System.Drawing.Point(8, 81);
            this.ServerPortLabel.Name = "ServerPortLabel";
            this.ServerPortLabel.Size = new System.Drawing.Size(29, 13);
            this.ServerPortLabel.TabIndex = 9;
            this.ServerPortLabel.Text = "Port:";
            // 
            // ServerLoginButton
            // 
            this.ServerLoginButton.Location = new System.Drawing.Point(8, 114);
            this.ServerLoginButton.Name = "ServerLoginButton";
            this.ServerLoginButton.Size = new System.Drawing.Size(262, 23);
            this.ServerLoginButton.TabIndex = 5;
            this.ServerLoginButton.Text = "Login";
            this.ServerLoginButton.UseVisualStyleBackColor = true;
            this.ServerLoginButton.Click += new System.EventHandler(this.ServerLoginButton_Click);
            // 
            // ServerPortField
            // 
            this.ServerPortField.Location = new System.Drawing.Point(43, 78);
            this.ServerPortField.Name = "ServerPortField";
            this.ServerPortField.Size = new System.Drawing.Size(100, 20);
            this.ServerPortField.TabIndex = 8;
            this.ServerPortField.Validating += new System.ComponentModel.CancelEventHandler(this.ServerPortField_Validating);
            // 
            // ServerAddressField
            // 
            this.ServerAddressField.Location = new System.Drawing.Point(8, 44);
            this.ServerAddressField.Name = "ServerAddressField";
            this.ServerAddressField.Size = new System.Drawing.Size(262, 20);
            this.ServerAddressField.TabIndex = 6;
            this.ServerAddressField.Validating += new System.ComponentModel.CancelEventHandler(this.ServerAddressField_Validating);
            // 
            // ServerAddressLabel
            // 
            this.ServerAddressLabel.AutoSize = true;
            this.ServerAddressLabel.Location = new System.Drawing.Point(8, 28);
            this.ServerAddressLabel.Name = "ServerAddressLabel";
            this.ServerAddressLabel.Size = new System.Drawing.Size(82, 13);
            this.ServerAddressLabel.TabIndex = 7;
            this.ServerAddressLabel.Text = "Server Address:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(759, 353);
            this.Controls.Add(this.ServerSetup);
            this.Controls.Add(this.ClientSetup);
            this.Controls.Add(this.SendMessageButton);
            this.Controls.Add(this.MessageField);
            this.Controls.Add(this.ChatLogField);
            this.Name = "Login";
            this.Text = "Study Buddy";
            this.ClientSetup.ResumeLayout(false);
            this.ClientSetup.PerformLayout();
            this.ServerSetup.ResumeLayout(false);
            this.ServerSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ChatLogField;
        private System.Windows.Forms.TextBox MessageField;
        private System.Windows.Forms.Button SendMessageButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox ClientSetup;
        private System.Windows.Forms.Label UserPortLabel;
        private System.Windows.Forms.TextBox UserPortField;
        private System.Windows.Forms.Label UserAddressLabel;
        private System.Windows.Forms.TextBox UserAddressField;
        private System.Windows.Forms.Button ClientStartButton;
        private System.Windows.Forms.GroupBox ServerSetup;
        private System.Windows.Forms.Label ServerPortLabel;
        private System.Windows.Forms.Button ServerLoginButton;
        private System.Windows.Forms.TextBox ServerPortField;
        private System.Windows.Forms.TextBox ServerAddressField;
        private System.Windows.Forms.Label ServerAddressLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

