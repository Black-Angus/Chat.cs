namespace ClientSide
{
    partial class window
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
            this.messagesent = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.conversation = new System.Windows.Forms.RichTextBox();
            this.nomclient = new System.Windows.Forms.Label();
            this.ChannelList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // messagesent
            // 
            this.messagesent.Location = new System.Drawing.Point(70, 255);
            this.messagesent.Name = "messagesent";
            this.messagesent.Size = new System.Drawing.Size(544, 20);
            this.messagesent.TabIndex = 0;
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(70, 281);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 1;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // conversation
            // 
            this.conversation.Location = new System.Drawing.Point(70, 70);
            this.conversation.Name = "conversation";
            this.conversation.Size = new System.Drawing.Size(544, 179);
            this.conversation.TabIndex = 2;
            this.conversation.Text = "";
            // 
            // nomclient
            // 
            this.nomclient.AutoSize = true;
            this.nomclient.Location = new System.Drawing.Point(67, 54);
            this.nomclient.Name = "nomclient";
            this.nomclient.Size = new System.Drawing.Size(0, 13);
            this.nomclient.TabIndex = 3;
            // 
            // ChannelList
            // 
            this.ChannelList.FormattingEnabled = true;
            this.ChannelList.Location = new System.Drawing.Point(620, 70);
            this.ChannelList.Name = "ChannelList";
            this.ChannelList.Size = new System.Drawing.Size(103, 173);
            this.ChannelList.TabIndex = 4;
            this.ChannelList.SelectedIndexChanged += new System.EventHandler(this.ChannelList_SelectedIndexChanged);
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChannelList);
            this.Controls.Add(this.nomclient);
            this.Controls.Add(this.conversation);
            this.Controls.Add(this.send);
            this.Controls.Add(this.messagesent);
            this.Name = "window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messagesent;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.RichTextBox conversation;
        private System.Windows.Forms.Label nomclient;
        private System.Windows.Forms.ListBox ChannelList;
    }
}