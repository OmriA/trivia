using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TriviaClient
{
    public partial class Title : Form
    {
        private Client client;
        public Title(Client c)
        {
            client = c;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Quit_Click(object sender, EventArgs e)
        {
            Environment.Exit(100);
        }

        private void PNL_LAYER_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTN_SignIn_Click(object sender, EventArgs e)
        {
            string username = TXT_Username.Text;
            string password = TXT_Password.Text;
            string message = Protocol.SIGN_IN_REQUEST.ToString() + Protocol.GetPaddedNumber(username.Length,2) + username + Protocol.GetPaddedNumber(password.Length, 2) + password;
            client.SendMessage(message);
        }
    }
}
