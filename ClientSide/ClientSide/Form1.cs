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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            psbox.PasswordChar = '*';
        }

        

        private void loginbut_Click(object sender, EventArgs e)
        {
            string username = namebox.Text;
            string password = psbox.Text;

            ClientList liste = new ClientList();
            liste = liste.Deserialize();

            liste.Check(username, password, Info);


        }

























        private void psbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Form register = new Signup();
            register.Show();
        }
    }
}
