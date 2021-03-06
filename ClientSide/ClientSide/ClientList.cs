﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    [Serializable]
    class ClientList
    {
        public List<Client> listeclients;

        public ClientList() {

            this.listeclients = new List<Client>();
            //listeclients.Add(new Client("admin", "admin"));
        }



        //------------Serialization and Deserialazation------------//

        public void Serialize(ClientList list)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream mystream = new FileStream("ClientList.bin", FileMode.Create, FileAccess.Write);
            formatter.Serialize(mystream, list);
            mystream.Close();
        }

        public ClientList Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream mystream = new FileStream("ClientList.bin", FileMode.Open, FileAccess.Read);
            ClientList list = new ClientList();
            list = (ClientList)formatter.Deserialize(mystream);
            mystream.Close();
            return list;
        }



        //------------Login and Password Check------------//


            //renvoie un client si le client existe en base de données, null sinon

        public Client Check(string username, string password, Label label)
        {
            Client zero = null;
            foreach (Client client in listeclients)
            {
                if (client.password == password & client.name == username)
                {
                    label.Text = "Authentificated Successfuly";
                    zero = client;
                    break;
                }
                
                else
                {
                    label.Text = "Authentification Failed";
                }

            }
            
            return zero;
        }

    }
}
