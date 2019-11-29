using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
{
    [Serializable]
    public class Client
    {
        public string name;
        public string password;
        

        public Client(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
    }
}
