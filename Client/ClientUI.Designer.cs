namespace Client
{
    partial class ClientUI
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
            this.userLabel = new System.Windows.Forms.Label();
            this.receiverLabel = new System.Windows.Forms.Label();
            this.msgLabel = new System.Windows.Forms.Label();
            this.chatLabel = new System.Windows.Forms.Label();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.userField = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.regBtn = new System.Windows.Forms.Button();
            this.receiverField = new System.Windows.Forms.TextBox();
            this.msgField = new System.Windows.Forms.TextBox();
            this.chatField = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.onlineList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.Location = new System.Drawing.Point(12, 9);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(81, 17);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "Username";
            // 
            // receiverLabel
            // 
            this.receiverLabel.AutoSize = true;
            this.receiverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiverLabel.Location = new System.Drawing.Point(12, 80);
            this.receiverLabel.Name = "receiverLabel";
            this.receiverLabel.Size = new System.Drawing.Size(72, 17);
            this.receiverLabel.TabIndex = 1;
            this.receiverLabel.Text = "Receiver";
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgLabel.Location = new System.Drawing.Point(12, 120);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(72, 17);
            this.msgLabel.TabIndex = 2;
            this.msgLabel.Text = "Message";
            // 
            // chatLabel
            // 
            this.chatLabel.AutoSize = true;
            this.chatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatLabel.Location = new System.Drawing.Point(12, 240);
            this.chatLabel.Name = "chatLabel";
            this.chatLabel.Size = new System.Drawing.Size(41, 17);
            this.chatLabel.TabIndex = 3;
            this.chatLabel.Text = "Chat";
            // 
            // onlineLabel
            // 
            this.onlineLabel.AutoSize = true;
            this.onlineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineLabel.Location = new System.Drawing.Point(600, 80);
            this.onlineLabel.Name = "onlineLabel";
            this.onlineLabel.Size = new System.Drawing.Size(55, 17);
            this.onlineLabel.TabIndex = 4;
            this.onlineLabel.Text = "Online";
            // 
            // userField
            // 
            this.userField.Location = new System.Drawing.Point(99, 6);
            this.userField.Name = "userField";
            this.userField.Size = new System.Drawing.Size(140, 22);
            this.userField.TabIndex = 5;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(245, 3);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 29);
            this.loginBtn.TabIndex = 6;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(326, 3);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(75, 29);
            this.logoutBtn.TabIndex = 7;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // regBtn
            // 
            this.regBtn.Location = new System.Drawing.Point(407, 3);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(75, 29);
            this.regBtn.TabIndex = 8;
            this.regBtn.Text = "Register";
            this.regBtn.UseVisualStyleBackColor = true;
            this.regBtn.Click += new System.EventHandler(this.regBtn_Click);
            // 
            // receiverField
            // 
            this.receiverField.Location = new System.Drawing.Point(99, 77);
            this.receiverField.Name = "receiverField";
            this.receiverField.Size = new System.Drawing.Size(140, 22);
            this.receiverField.TabIndex = 9;
            // 
            // msgField
            // 
            this.msgField.Location = new System.Drawing.Point(99, 117);
            this.msgField.Multiline = true;
            this.msgField.Name = "msgField";
            this.msgField.Size = new System.Drawing.Size(383, 44);
            this.msgField.TabIndex = 10;
            // 
            // chatField
            // 
            this.chatField.Location = new System.Drawing.Point(99, 237);
            this.chatField.Multiline = true;
            this.chatField.Name = "chatField";
            this.chatField.Size = new System.Drawing.Size(383, 88);
            this.chatField.TabIndex = 11;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(99, 167);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 29);
            this.sendBtn.TabIndex = 12;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // onlineList
            // 
            this.onlineList.FormattingEnabled = true;
            this.onlineList.ItemHeight = 16;
            this.onlineList.Location = new System.Drawing.Point(603, 117);
            this.onlineList.Name = "onlineList";
            this.onlineList.Size = new System.Drawing.Size(216, 212);
            this.onlineList.TabIndex = 13;
            // 
            // ClientUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.onlineList);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.chatField);
            this.Controls.Add(this.msgField);
            this.Controls.Add(this.receiverField);
            this.Controls.Add(this.regBtn);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.userField);
            this.Controls.Add(this.onlineLabel);
            this.Controls.Add(this.chatLabel);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.receiverLabel);
            this.Controls.Add(this.userLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ClientUI";
            this.Text = "Chat Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label receiverLabel;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.Label chatLabel;
        private System.Windows.Forms.Label onlineLabel;
        private System.Windows.Forms.TextBox userField;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button regBtn;
        private System.Windows.Forms.TextBox receiverField;
        private System.Windows.Forms.TextBox msgField;
        private System.Windows.Forms.TextBox chatField;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.ListBox onlineList;
    }
}

