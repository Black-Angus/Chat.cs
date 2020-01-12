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
        static public List<Client> listeclients = new List<Client>();

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
                    string name = receive(client);
                    listeclients.Add(new Client(name, client));
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

                    int cmd_count = stream.Read(msg, 0, msg.Length);
                    string cmd = Encoding.ASCII.GetString(msg, 0, cmd_count);
                    Console.WriteLine(cmd);
                    string channelwanted;
                    switch (cmd)
                    {
                        
                        case "connectchannel":  
                             channelwanted = receive(client);
                            string clientname = receive(client);
                            foreach(Client c in listeclients)
                            {
                                if(c.name == clientname)
                                {
                                    c.meschannels.Add(new Channel(channelwanted));
                                }
                            }
                            break;

                        case "msg":
                            channelwanted = receive(client);
                            Console.WriteLine(channelwanted);
                            string content = receive(client);
                            sendchannel(content, new Channel(channelwanted));

                            break;

                        default:
                            Console.WriteLine("Action non trouvée pour : " + cmd);
                            break;
                    }




                }
            }


        }

        public static void broadcast(string message)
        {
            foreach(Client c in listeclients)
            {
                sendmessage(message, c._tcpclient);
            }
        }

        public static void sendchannel(string message, Channel ch)
        {
            foreach(Client cl in listeclients)
            {
                Console.WriteLine(cl.name);
                foreach(Channel c in cl.meschannels)
                {
                    Console.WriteLine(c._name + " "+ ch._name);
                    if(ch._name == c._name)
                    {
                        Console.WriteLine("sent to " + cl.name);
                        sendmessage(ch._name, cl._tcpclient);
                        sendmessage(message, cl._tcpclient);
                    }
                }
            }
        }

        public static void sendmessage(string msg, TcpClient tcp)
        {
            byte[] message = Encoding.ASCII.GetBytes(msg);
            /*StreamWriter sw = new StreamWriter(tcp.GetStream());
            sw.Write(msg);*/
            NetworkStream ns = tcp.GetStream();
            ns.Write(message, 0, message.Length);
            System.Threading.Thread.Sleep(60);

        }


        public static string receive(TcpClient tcp)
        {
            NetworkStream ns = tcp.GetStream();
            byte[] datarecieved = new byte[1024];
            int byte_count = ns.Read(datarecieved, 0, datarecieved.Length);
            string data = Encoding.ASCII.GetString(datarecieved, 0, byte_count);
            return data;
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
