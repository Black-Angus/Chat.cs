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

            try
            {
                tcpclient.Connect(IPAddress.Parse("127.0.0.1"), 5000);
                this.tcp = tcpclient;
                sendmessage("Salut");
                Thread thread = new Thread(o => wait((TcpClient)o));

                //I start my thread
                thread.Start(tcpclient);
            }

            catch(SocketException)
            {
                nomclient.Text = "Connexion impossible au serveur";
            }
        }
        private void send_Click(object sender, EventArgs e)
        {
            sendmessage(messagesent.Text);
        }

        public void sendmessage(string msg)
        {
            byte[] message = Encoding.ASCII.GetBytes(msg);
            /*StreamWriter sw = new StreamWriter(tcp.GetStream());
            sw.Write(msg);*/
            NetworkStream ns = tcp.GetStream();
            ns.Write(message, 0, message.Length);
        }

         void wait(TcpClient client)
        {
            NetworkStream ns = tcp.GetStream();
            byte[] datarecieved = new byte[1024];
            int byte_count;
            while ((byte_count = ns.Read(datarecieved, 0, datarecieved.Length)) > 0)
            {
                string data = Encoding.ASCII.GetString(datarecieved, 0, byte_count);
                AppendText(data, false);
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

    }
}
