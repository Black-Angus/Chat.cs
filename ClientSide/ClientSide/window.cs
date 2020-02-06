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
            listechannels._channels.Add(new Channel("Lounge"));             //ajout de 3 channels, disponibles pour tous les clients
            foreach (Channel c in listechannels._channels)
            {
                ChannelList.Items.Add(c._name);     //affichage des channels dans une listbox
            }
                try
            {
                tcpclient.Connect(IPAddress.Parse("127.0.0.1"), 5000);
                this.tcp = tcpclient;
                sendmessage(connected.name);            // envoie le nom du client au serveur pour qu'il soit ajouté à la liste des clients côté serveur
                connectchannels();                      // informe tous les channels qu'un nouveau client est connecté
                sendmessage("User has joined conversation");
                Thread thread = new Thread(o => wait((TcpClient)o));        // lambda expression = méthode anonyme

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
            sendmessage("msg");                                 //lors de l'envoi d'un message, le client envoie la commande msg, le nom du channel puis le contenu
            sendmessage(ChannelList.SelectedItem.ToString());
            sendmessage(messagesent.Text);

        }

        public void sendmessage(string msg)         //methode d'envoi de message
        {
            byte[] message = Encoding.ASCII.GetBytes(msg);
            NetworkStream ns = tcp.GetStream();
            ns.Write(message, 0, message.Length);
            System.Threading.Thread.Sleep(60);      //temporisation pour laisser le temps au serveur de traiter les instructions
        }

         void wait(TcpClient client)
        {
            NetworkStream ns = tcp.GetStream();
            byte[] datarecieved = new byte[1024];
            int byte_count;
          
            while ((byte_count = ns.Read(datarecieved, 0, datarecieved.Length)) > 0)        //tant qu'il y a des choses à lire
            {
                string data = Encoding.ASCII.GetString(datarecieved, 0, byte_count);        //data attend un nom de channel à qui envoyer le message

                
                if(data == currentchannel) {                                                //envoie le message au channel concerné
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
                this.Invoke(            //modifier un élément de la fenetre nécessite d'accéder à un thread
                    new MethodInvoker(  //cela revient à accéder à un thread à partir d'un thread, d'où la nécessité d'un invoke
                    delegate () { AppendText(what); }));
            }
            else
            {
                DateTime timestamp = DateTime.Now;
                conversation.AppendText(timestamp.ToLongTimeString() + "\t" + what + Environment.NewLine);  //affiche l'heure, tabulation puis le message
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChannelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentchannel = ChannelList.SelectedItem.ToString();
            conversation.Clear();   // efface le texte lors d'un changement de channel
        }

        public static string receive(TcpClient tcp) //réception de données, prend en paramètre un tcpclient
        {
            NetworkStream ns = tcp.GetStream();
            byte[] datarecieved = new byte[1024];
            int byte_count = ns.Read(datarecieved, 0, datarecieved.Length);
            string data = Encoding.ASCII.GetString(datarecieved, 0, byte_count);
            return data;
        }


        private void clickconnet_Click(object sender, EventArgs e)      // envoie la commande pour se connecter au channel, ainsi que le nom du channel et le nom du client
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

        public void connectchannels()       // informe tous les channels qu'un nouveau client est connecté
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
