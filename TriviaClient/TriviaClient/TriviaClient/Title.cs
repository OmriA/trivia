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

        private void BTN_SignIn_Click(object sender, EventArgs e)
        {
            if (TXT_Username.Text == "")
            {
                TXT_Username.Text = " ";
            }
            if (TXT_Password.Text == "")
            {
                TXT_Password.Text = " ";
            }
            var username = TXT_Username.Text;
            var password = TXT_Password.Text;
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
            var message = Protocol.SIGN_IN_REQUEST.ToString() + Protocol.GetPaddedNumber(username.Length,2) + username + Protocol.GetPaddedNumber(password.Length, 2) + password;
            client.SendMessage(message);

            var msg = client.GetMessage();
            msg = msg.Substring(0, 4);
            if (msg == Protocol.SIGN_IN_RESPONSE_SUCCESS)
            {
                TXT_Username.Visible = false;
                TXT_Password.Visible = false;
                BTN_SignIn.Visible = false;
                BTN_Signup.Visible = false;
                BTN_SignOut.Visible = true;
                BTN_JoinRoom.Visible = true;
                BTN_CreateRoom.Visible = true;
                BTN_MyStatus.Visible = true;
                BTN_BestScores.Visible = true;
                LBL_Welcome.Text = $"Welcome {username}";
                LBL_Welcome.Visible = true;
            }
            else if (msg == Protocol.SIGN_IN_RESPONSE_WRONG_DETAILS)
            {
                MessageBox.Show("Wrong details!");
            }
            else if (msg == Protocol.SIGN_IN_RESPONSE_ALREADY_CONNECTED)
            {
                MessageBox.Show("User already connected!");
            }
            else
            {
                MessageBox.Show($"Unknown message recieved from server.\nMessage:{msg}.");
            }
        }

        private void BTN_SignOut_Click(object sender, EventArgs e)
        {
            client.SendMessage(Protocol.SIGN_OUT_REQUEST.ToString());
            TXT_Username.Visible = true;
            TXT_Password.Visible = true;
            BTN_SignIn.Visible = true;
            BTN_Signup.Visible = true;
            BTN_SignOut.Visible = false;
            BTN_JoinRoom.Visible = false;
            BTN_CreateRoom.Visible = false;
            BTN_MyStatus.Visible = false;
            BTN_BestScores.Visible = false;
            LBL_Welcome.Visible = false;
            TXT_Username.Text = "Username";
            TXT_Password.Text = "Password";
        }

        private void BTN_BestScores_Click(object sender, EventArgs e)
        {
            var username = TXT_Username.Text;
            client.SendMessage(Protocol.BEST_SCORES_REQUEST);
            var msg = client.GetMessage();

            var firstNum = Convert.ToInt32(msg.Substring(3, 2));
            var firstUser = msg.Substring(5, firstNum);
            var firstScore = Convert.ToInt32(msg.Substring(5 + firstNum, 6));
            var secNum = Convert.ToInt32(msg.Substring(5 + firstNum + 6, 2));
            var secUser = msg.Substring(5 + firstNum + 6 + 2, secNum);
            var secScore = Convert.ToInt32(msg.Substring(5 + firstNum + 12, 6));
            var thirdNum = Convert.ToInt32(msg.Substring(5 + firstNum + 18, 2));
            var thirdUser = msg.Substring(5 + firstNum + 18 + 2, thirdNum);
            var thirdScore = Convert.ToInt32(msg.Substring(5 + firstNum + 24, 6));
            MessageBox.Show($"1. {firstUser} - {firstScore} \n2. {secUser} - {secScore}\n3. {thirdUser} - {thirdScore}", "Best Scores:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BTN_MyStatus_Click(object sender, EventArgs e)
        {
            var username = TXT_Username.Text;
            client.SendMessage(Protocol.PERSONAL_STATUS_REQUEST);
            var msg = client.GetMessage();
            var numberOfGames = Convert.ToInt32(msg.Substring(3, 4));
            var numOfRightAns = Convert.ToInt32(msg.Substring(7, 6));
            var numOfWrongAns = Convert.ToInt32(msg.Substring(13, 6));
            var avgTimeForAns = Convert.ToDouble(msg.Substring(19, 4)) / 100.0;
            
            MessageBox.Show($"You played {numberOfGames} games\n{numOfRightAns} of your answers were right\n{numOfWrongAns} of your answers were wrong\nAverage time for each answer: {avgTimeForAns}", $"{username}'s Personal Status:", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BTN_Signup_Click(object sender, EventArgs e)
        {
            var signUp = new SignUpForm(client);
            this.Hide();
            signUp.ShowDialog();
            this.Show();
        }

        private void BTN_CreateRoom_Click(object sender, EventArgs e)
        {
            var createRoom = new CreateRoomForm(client);
            this.Hide();
            createRoom.ShowDialog();
            this.Show();
        }
    }
}
