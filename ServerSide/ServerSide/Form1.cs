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
        static public List<Client> listeclients = new List<Client>();       // Création de la liste de clients
        static public List<Channel> abschannellist = new List<Channel>();   // Création de la liste des channels
        
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
                listener.Start();                                                   //Création du listener, reste en attente de connexions
                Console.WriteLine("MultiThreadedEchoServer started...");
                abschannellist.Add(new Channel("[NITRO]GANG"));
                abschannellist.Add(new Channel("ITF 2021"));
                abschannellist.Add(new Channel("F RAIE CHAR O"));

                while (true)
                {
                    Console.WriteLine("Waiting for incoming client connections...");
                    TcpClient client = listener.AcceptTcpClient();
                    string name = receive(client);                                  //réception du nom du client qui vient de se connecter
                    listeclients.Add(new Client(name, client));                     //ajout à la liste de clients
                    Console.WriteLine("Accepted new client connection...");
                    Thread t = new Thread(ProcessClientRequests);                   //création du thread pour le nouveau client
                    t.Start(client);                                                //démarrage du thread, avec le nouveau client en paramètre
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
                    switch (cmd)                //lorsque le client réalise une action, il envoie d'abord un message 'commande' qui permet au serveur d'identifier l'action exigée
                    {
                        
                        case "connectchannel":      //lorsque le client souhaite se connecter à un channel
                             channelwanted = receive(client);       //réception du nom du channel désiré
                            string clientname = receive(client);    //réception de son nom
                            foreach (Client c in listeclients)
                            {
                                if(c.name == clientname)
                                {
                                    c.meschannels.Add(new Channel(channelwanted));      //parcourt la liste des clients, ajout du channel désiré à la liste de channels utilisés par le client
                                }
                            }
                            break;

                        case "msg":
                            channelwanted = receive(client);    //channel concerné
                            Console.WriteLine(channelwanted);
                            string content = receive(client);   //message
                            sendchannel(content, new Channel(channelwanted));   //envoi
                            foreach (Client c in listeclients)
                            {
                                foreach (Channel mychannel in c.meschannels)
                                {
                                    if (Equals(channelwanted.Trim(), mychannel._name))
                                    {
                                        DateTime timestamp = DateTime.Now;
                                        mychannel._textchannel += Environment.NewLine + timestamp.ToLongTimeString() + "\t" + content;
                                    }
                                }
                            }
                            break;


                        case "get_text":       // envoie l'historique au client qui le demande (en cas de changement de channel)

                            string chan = receive(client);
                            bool flag = false;
                            foreach (Client c in listeclients)
                            {
                                foreach (Channel oui in c.meschannels)
                                {
                                    if (oui._name == chan & flag == false)
                                    {
                                        Console.WriteLine(chan);
                                        sendmessage(oui._name, client);
                                        sendmessage(oui._textchannel, client);
                                        flag = true;
                                    }
                                }
                            }


                            break;

                        default:
                            Console.WriteLine("Action non trouvée pour : " + cmd);
                            break;
                    }




                }
            }


        }

        public static void broadcast(string message)            //envoi de la donnée à chaque client connecté
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
                    if(ch._name == c._name)                     //parcourt tous les channels, lorsque le channel concerné est trouvé, envoi du message à celui-ci
                    {
                        Console.WriteLine("sent to " + cl.name);
                        sendmessage(ch._name, cl._tcpclient);
                        sendmessage(message, cl._tcpclient);
                    }
                }
            }
        }

        public static void sendmessage(string msg, TcpClient tcp)       //envoie un message ou une commande, prend en paramètres le texte et un tcpclient 
        {
            byte[] message = Encoding.ASCII.GetBytes(msg);
            /*StreamWriter sw = new StreamWriter(tcp.GetStream());
            sw.Write(msg);*/
            NetworkStream ns = tcp.GetStream();
            ns.Write(message, 0, message.Length);
            System.Threading.Thread.Sleep(60);

        }


        public static string receive(TcpClient tcp)     //reçoit un message ou une commande, prend en paramètre un tcpclient
        {
            NetworkStream ns = tcp.GetStream();
            byte[] datarecieved = new byte[1024];
            int byte_count = ns.Read(datarecieved, 0, datarecieved.Length);
            string data = Encoding.ASCII.GetString(datarecieved, 0, byte_count);
            return data;
        }





        //--------------Tout ce qui est en dessous n'est pas utilisé, il s'agit d'ancien code que j'ai abandonné--------------


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
