using SimpleTCP;
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

namespace ServerSide
{

    public partial class Form1 : Form
    {
        static public List<TcpClient> tcplist = new List<TcpClient>();

        public Form1()
        {
            InitializeComponent();
            initialize();
        }

        static void initialize()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
                listener.Start();
                Console.WriteLine("MultiThreadedEchoServer started...");
                while (true)
                {
                    Console.WriteLine("Waiting for incoming client connections...");
                    TcpClient client = listener.AcceptTcpClient();
                    tcplist.Add(client);
                    Console.WriteLine("Accepted new client connection...");
                    Thread t = new Thread(ProcessClientRequests);
                    t.Start(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }

            void ProcessClientRequests(object o)
            {
                TcpClient client = (TcpClient)o;
                /*StreamReader sr = new StreamReader(client.GetStream());
                string msgreceived = sr.Read();*/

                NetworkStream stream = client.GetStream();
                while (true)
                {
                    byte[] msg = new byte[1024];

                    int action_count = stream.Read(msg, 0, msg.Length);
                    string action = Encoding.ASCII.GetString(msg, 0, action_count);
                    Console.WriteLine(action);
                    broadcast(action);
                }
            }


        }

        public static void broadcast(string message)
        {
            foreach(TcpClient c in tcplist)
            {
                sendmessage(message, c);
            }
        }

        public static void sendmessage(string msg, TcpClient tcp)
        {
            byte[] message = Encoding.ASCII.GetBytes(msg);
            /*StreamWriter sw = new StreamWriter(tcp.GetStream());
            sw.Write(msg);*/
            NetworkStream ns = tcp.GetStream();
            ns.Write(message, 0, message.Length);
        }











        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Net.IPAddress ip = new System.Net.IPAddress(long.Parse(txtHost.Text));
            server.Start(ip, Convert.ToInt32(txtPort.Text));
        }

        SimpleTcpServer server;

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += e.MessageString;
                e.ReplyLine(string.Format("You: {0}", e.MessageString));
            });
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
        }
    }
}
