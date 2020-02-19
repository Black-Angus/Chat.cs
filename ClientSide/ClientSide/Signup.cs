using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Createbut_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            ClientList cl = new ClientList();
            cl = cl.Deserialize();
            if(username != null && password!=null)  cl.listeclients.Add(new Client(username, password));
            cl.Serialize(cl);
            this.Dispose();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
