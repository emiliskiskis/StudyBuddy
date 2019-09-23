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
            this.IpLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.IpTextField = new System.Windows.Forms.TextBox();
            this.NameTextField = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(121, 70);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(24, 17);
            this.IpLabel.TabIndex = 0;
            this.IpLabel.Text = "IP:";
            this.IpLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(121, 120);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(49, 17);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name:";
            // 
            // IpTextField
            // 
            this.IpTextField.Location = new System.Drawing.Point(196, 67);
            this.IpTextField.Name = "IpTextField";
            this.IpTextField.Size = new System.Drawing.Size(164, 22);
            this.IpTextField.TabIndex = 2;
            // 
            // NameTextField
            // 
            this.NameTextField.Location = new System.Drawing.Point(196, 117);
            this.NameTextField.Name = "NameTextField";
            this.NameTextField.Size = new System.Drawing.Size(164, 22);
            this.NameTextField.TabIndex = 3;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(301, 201);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 4;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SumbitButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(148, 201);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 288);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.NameTextField);
            this.Controls.Add(this.IpTextField);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IpLabel);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox IpTextField;
        private System.Windows.Forms.TextBox NameTextField;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

