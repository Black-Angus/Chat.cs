using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
{
    [Serializable]

    public class Channels
    {
        public List<Channel> _channels;
        public Channels()
        {
            _channels = new List<Channel>();
        }


        //------------Serialization and Deserialazation------------//

        public void Serialize(Channels channels)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream mystream = new FileStream("ChannelList.bin", FileMode.Create, FileAccess.Write);
            formatter.Serialize(mystream, channels);
            mystream.Close();
        }

        public Channels Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream mystream = new FileStream("ChannelList.bin", FileMode.Open, FileAccess.Read);
            Channels channels = new Channels();
            channels = (Channels)formatter.Deserialize(mystream);
            mystream.Close();
            return channels;
        }
    }
}
