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
    public partial class CreateRoomForm : Form
    {
        private Client client;
        private string uname;
        public CreateRoomForm(Client c, string username)
        {
            this.ControlBox = false;
            uname = username;
            client = c;
            InitializeComponent();
        }

        private void CreateRoomForm_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_CreateRoom_Click(object sender, EventArgs e)
        {
            var roomName = TXT_RoomName.Text;
            if (roomName == "Enter room name here")
            {
                MessageBox.Show("Please enter room name.");
                return;
            }
            int numOfPlayers;
            if (TXT_NumOfPlayers.Text == "" || !Int32.TryParse(TXT_NumOfPlayers.Text, out numOfPlayers))
            {
                MessageBox.Show("Please enter number in number of players.");
                return;
            }
            if (numOfPlayers < 1 || numOfPlayers > 9)
            {
                MessageBox.Show("Please enter number between 1 to 9 in number of players.");
                return;
            }
            int numOfQuestions;
            if (TXT_NumOfQuestions.Text == "" || !Int32.TryParse(TXT_NumOfQuestions.Text, out numOfQuestions))
            {
                MessageBox.Show("Please enter number in number of questions.");
                return;
            }
            if (numOfQuestions < 1 || numOfQuestions > 99)
            {
                MessageBox.Show("Please enter number between 1 to 99 in number of questions.");
                return;
            }
            int timeToQuestion;
            if (TXT_TimeToQuestion.Text == "" || !Int32.TryParse(TXT_TimeToQuestion.Text, out timeToQuestion))
            {
                MessageBox.Show("Please enter number in time to question.");
                return;
            }
            if (timeToQuestion < 1 || timeToQuestion > 99)
            {
                MessageBox.Show("Please enter number between 1 to 99 in time to question.");
                return;
            }
            if (numOfPlayers >= 1 && numOfPlayers <= 9)
            {
                //message = "213##roomName playersNumber questionsNumber questionTimeInSec".
                var message = Protocol.ROOM_CREATE_REQUEST + Protocol.GetPaddedNumber(roomName.Length, 2) + roomName + Protocol.GetPaddedNumber(numOfPlayers, 1) + Protocol.GetPaddedNumber(numOfQuestions, 2) + Protocol.GetPaddedNumber(timeToQuestion, 2);
                client.SendMessage(message);
                var msg = client.GetMessage();
                switch (msg)
                {
                    case Protocol.ROOM_CREATE_RESPONSE_SUCCESS:
                        this.Hide();
                        var waitForGame = new WaitForGameForm(client, true, roomName, numOfPlayers, numOfQuestions, timeToQuestion, uname);
                        waitForGame.ShowDialog();
                        if (waitForGame.gameStart)
                        {
                            var gameForm = new GameForm(client, waitForGame.msg, roomName, waitForGame.qstNum, waitForGame.qstTime);
                            gameForm.ShowDialog();
                        }
                        this.Close();
                        break;
                    case Protocol.ROOM_CREATE_RESPONSE_TOO_MANY_QUESTIONS:
                        MessageBox.Show("Not enough questions in the database.");
                        break;
                    case Protocol.ROOM_CREATE_RESPONSE_FAIL:
                        MessageBox.Show("Create room failed.");
                        break;
                    default:
                        MessageBox.Show($@"Unknown message recieved.
Message: {msg}");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Num of players must be between 1 and 9.");
            }
        }

        private void TXT_RoomName_Enter(object sender, EventArgs e)
        {
            if (TXT_RoomName.Text == "Enter room name here")
            {
                TXT_RoomName.Text = "";
                TXT_RoomName.ForeColor = Color.Black;
            }
        }

        private void TXT_RoomName_Leave(object sender, EventArgs e)
        {
            if (TXT_RoomName.Text == "")
            {
                TXT_RoomName.Text = "Enter room name here";
                TXT_RoomName.ForeColor = Color.Gray;
            }
        }

        private void TXT_NumOfPlayers_Enter(object sender, EventArgs e)
        {
            if (TXT_NumOfPlayers.Text == "Enter num of players here")
            {
                TXT_NumOfPlayers.Text = "";
                TXT_NumOfPlayers.ForeColor = Color.Black;
            }
        }

        private void TXT_NumOfPlayers_Leave(object sender, EventArgs e)
        {
            if (TXT_NumOfPlayers.Text == "")
            {
                TXT_NumOfPlayers.Text = "Enter num of players here";
                TXT_NumOfPlayers.ForeColor = Color.Gray;
            }
        }

        private void TXT_NumOfQuestions_Enter(object sender, EventArgs e)
        {
            if (TXT_NumOfQuestions.Text == "Enter num of questions here")
            {
                TXT_NumOfQuestions.Text = "";
                TXT_NumOfQuestions.ForeColor = Color.Black;
            }
        }

        private void TXT_NumOfQuestions_Leave(object sender, EventArgs e)
        {
            if (TXT_NumOfQuestions.Text == "")
            {
                TXT_NumOfQuestions.Text = "Enter num of questions here";
                TXT_NumOfQuestions.ForeColor = Color.Gray;
            }
        }

        private void TXT_TimeToQuestion_Enter(object sender, EventArgs e)
        {
            if (TXT_TimeToQuestion.Text == "Enter time to question here")
            {
                TXT_TimeToQuestion.Text = "";
                TXT_TimeToQuestion.ForeColor = Color.Black;
            }
        }

        private void TXT_TimeToQuestion_Leave(object sender, EventArgs e)
        {
            if (TXT_TimeToQuestion.Text == "")
            {
                TXT_TimeToQuestion.Text = "Enter time to question here";
                TXT_TimeToQuestion.ForeColor = Color.Gray;
            }
        }
    }
}
