using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{

    public partial class window : Form
    {
        TcpClient tcp;
        Client connected;
        Channels listechannels;
        string currentchannel;
        public window()
        {
            InitializeComponent();
            
        }

        
        public window(Client client)
        {
            InitializeComponent();
            this.connected = client;
            nomclient.Text = connected.name;
            TcpClient tcpclient = new TcpClient();
            listechannels = new Channels();
            listechannels._channels.Add(new Channel("General"));
            listechannels._channels.Add(new Channel("Cafe des Sports"));
            listechannels._channels.Add(new Channel("Lounge"));
            foreach (Channel c in listechannels._channels)
            {
                ChannelList.Items.Add(c._name);
            }
                try
            {
                tcpclient.Connect(IPAddress.Parse("127.0.0.1"), 5000);
                this.tcp = tcpclient;
                sendmessage(connected.name);
                connectchannels();
                sendmessage("User has joined conversation");
                Thread thread = new Thread(o => wait((TcpClient)o));

                //I start my thread
                thread.Start(tcpclient);
            }

            catch(SocketException)
            {
                nomclient.Text = "Unable to establish connection with server";
            }
        }
        private void send_Click(object sender, EventArgs e)
        {
            sendmessage("msg");
            sendmessage(ChannelList.SelectedItem.ToString());
            sendmessage(messagesent.Text);

        }

        public void sendmessage(string msg)
        {
            byte[] message = Encoding.ASCII.GetBytes(msg);
            NetworkStream ns = tcp.GetStream();
            ns.Write(message, 0, message.Length);
            System.Threading.Thread.Sleep(60);
        }

         void wait(TcpClient client)
        {
            NetworkStream ns = tcp.GetStream();
            byte[] datarecieved = new byte[1024];
            int byte_count;
          
            while ((byte_count = ns.Read(datarecieved, 0, datarecieved.Length)) > 0)
            {
                string data = Encoding.ASCII.GetString(datarecieved, 0, byte_count);

                
                if(data == currentchannel) {
                    string msg = receive(client);
                    AppendText(msg, false);

                }


            }
        }

        public void AppendText(string what, bool debug = false)
        {
            if (debug)
                return;
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new MethodInvoker(
                    delegate () { AppendText(what); }));
            }
            else
            {
                DateTime timestamp = DateTime.Now;
                conversation.AppendText(timestamp.ToLongTimeString() + "\t" + what + Environment.NewLine);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChannelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentchannel = ChannelList.SelectedItem.ToString();
            conversation.Clear();
        }

        public static string receive(TcpClient tcp)
        {
            NetworkStream ns = tcp.GetStream();
            byte[] datarecieved = new byte[1024];
            int byte_count = ns.Read(datarecieved, 0, datarecieved.Length);
            string data = Encoding.ASCII.GetString(datarecieved, 0, byte_count);
            return data;
        }


        private void clickconnet_Click(object sender, EventArgs e)
        {

            try
            {
                sendmessage("connectchannel");
                string item = ChannelList.GetItemText(ChannelList.SelectedItem);
                sendmessage(item);
                sendmessage(connected.name);
            }
            catch
            {

            }
        }

        public void connectchannels()
        {
            foreach(Channel c in listechannels._channels)
            {
                sendmessage("connectchannel");
                string item = c._name;
                sendmessage(item);
                sendmessage(connected.name);
            }
        }
    }
}
