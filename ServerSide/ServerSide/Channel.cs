using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    public class Channel
    {
        public string _name;
        public string _textchannel;
        public Channel(string name)
        {
            this._name = name;
            this._textchannel = "Bienvenue dans le salon " + _name + Environment.NewLine;
        }
    }
}
