using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
{
    [Serializable]
    public class Channel
    {
        public string _name;

        public Channel(string name)
        {
            this._name = name;
        }
    }
}
