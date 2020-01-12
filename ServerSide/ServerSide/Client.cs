﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    public class Client
    {
        public string name;
        public TcpClient _tcpclient;
        public List<Channel> meschannels;
        public Client(string name, TcpClient tcpclient)
        {
            this.name = name;
            this.meschannels = new List<Channel>();
            this._tcpclient = tcpclient;

        }
        
    }
}
