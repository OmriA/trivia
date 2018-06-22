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
    public partial class SignUpForm : Form
    {
        private Client client;
        public SignUpForm(Client c)
        {
            client = c;
            InitializeComponent();
        }

        private void TXT_Username_Leave(object sender, EventArgs e)
        {
            if (TXT_Username.Text == "")
            {
                TXT_Username.Text = "Enter username here";
                TXT_Username.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void TXT_Username_Enter(object sender, EventArgs e)
        {
            if (TXT_Username.Text == "Enter username here")
            {
                TXT_Username.Text = "";
                TXT_Username.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TXT_Password_Enter(object sender, EventArgs e)
        {
            if (TXT_Password.Text == "Enter password here")
            { 
                TXT_Password.UseSystemPasswordChar = true;
                TXT_Password.Text = "";
                TXT_Password.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TXT_Password_Leave(object sender, EventArgs e)
        {
            if (TXT_Password.Text == "")
            {
                TXT_Password.UseSystemPasswordChar = false;
                TXT_Password.Text = "Enter password here";
                TXT_Password.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void TXT_Email_Enter(object sender, EventArgs e)
        {
            if (TXT_Email.Text == "Enter email here")
            {
                TXT_Email.Text = "";
                TXT_Email.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TXT_Email_Leave(object sender, EventArgs e)
        {
            if (TXT_Email.Text == "")
            {
                TXT_Email.Text = "Enter email here";
                TXT_Email.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_Signup_Click(object sender, EventArgs e)
        {
            var username = TXT_Username.Text;
            var password = TXT_Password.Text;
            var email = TXT_Email.Text;

            if (username == "Enter username here")
            {
                MessageBox.Show("Please enter username.");
                return;
            }
            if (password == "Enter password here")
            {
                MessageBox.Show("Please enter password.");
                return;
            }
            if (email == "Enter email here")
            {
                MessageBox.Show("Please enter email.");
                return;
            }

            var message = Protocol.SIGN_UP_REQUEST + Protocol.GetPaddedNumber(username.Length, 2) + username + Protocol.GetPaddedNumber(password.Length, 2) + password + Protocol.GetPaddedNumber(email.Length, 2) + email;
            //message = 203##username##pass##email (where ## is two digits that contains the length of the string after it.
            client.SendMessage(message);
            var msg = client.GetMessage();
            switch (msg)
            {
                case Protocol.SIGN_UP_RESPONSE_ALREADY_EXISTS:
                    MessageBox.Show("Username already exists.");
                    break;
                case Protocol.SIGN_UP_RESPONSE_OTHER:
                    MessageBox.Show("Unknown error.");
                    break;
                case Protocol.SIGN_UP_RESPONSE_PASS_ILLEGAL:
                    MessageBox.Show("Password is illegal.");
                    break;
                case Protocol.SIGN_UP_RESPONSE_SUCCESS:
                    this.Close();
                    break;
                default:
                    MessageBox.Show($@"Unknown message recieved.
Message: {msg}");
                    break;
            }
        }
    }
}