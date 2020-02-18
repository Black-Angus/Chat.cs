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
            this.conversation = new System.Windows.Forms.RichTextBox();
            this.nomclient = new System.Windows.Forms.Label();
            this.ChannelList = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.send = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // messagesent
            // 
            this.messagesent.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.messagesent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messagesent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagesent.Location = new System.Drawing.Point(12, 386);
            this.messagesent.Name = "messagesent";
            this.messagesent.Size = new System.Drawing.Size(544, 15);
            this.messagesent.TabIndex = 0;
            this.messagesent.TextChanged += new System.EventHandler(this.messagesent_TextChanged);
            // 
            // conversation
            // 
            this.conversation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.conversation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.conversation.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conversation.Location = new System.Drawing.Point(12, 12);
            this.conversation.Name = "conversation";
            this.conversation.Size = new System.Drawing.Size(544, 368);
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
            this.ChannelList.BackColor = System.Drawing.SystemColors.Window;
            this.ChannelList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChannelList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChannelList.FormattingEnabled = true;
            this.ChannelList.ItemHeight = 16;
            this.ChannelList.Location = new System.Drawing.Point(562, 12);
            this.ChannelList.Name = "ChannelList";
            this.ChannelList.Size = new System.Drawing.Size(103, 368);
            this.ChannelList.TabIndex = 4;
            this.ChannelList.SelectedIndexChanged += new System.EventHandler(this.ChannelList_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::ClientSide.Properties.Resources.Logo_Efrei_Paris_Cube_aplat_plein_noir;
            this.pictureBox1.Location = new System.Drawing.Point(671, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.SystemColors.Window;
            this.send.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send.ForeColor = System.Drawing.SystemColors.WindowText;
            this.send.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.send.Location = new System.Drawing.Point(13, 407);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(54, 26);
            this.send.TabIndex = 1;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ChannelList);
            this.Controls.Add(this.nomclient);
            this.Controls.Add(this.conversation);
            this.Controls.Add(this.send);
            this.Controls.Add(this.messagesent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "window";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messagesent;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.RichTextBox conversation;
        private System.Windows.Forms.Label nomclient;
        private System.Windows.Forms.ListBox ChannelList;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}