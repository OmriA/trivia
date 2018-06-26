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
    public partial class WaitForGameForm : Form
    {
        private Client client;
        private string uname;
        private string rName;
        private int numOfQuest;
        private int questionTime;
        public WaitForGameForm(Client c, bool admin, string roomName, int maxNumPlayers, int numOfQst, int timeToQst, string username)
        {
            uname = username;
            client = c;
            InitializeComponent();
            rName = roomName;
            numOfQuest = numOfQst;
            questionTime = timeToQst;
            LBL_MaxPlayers.Text += maxNumPlayers.ToString();
            LBL_QuestionsNum.Text += numOfQst.ToString();
            LBL_QuestionTime.Text += timeToQst.ToString();
            if (!admin) 
            {
                LBL_MaxPlayers.Visible = false;
                BTN_CloseRoom.Visible = false;
                BTN_StartGame.Visible = false;
            }
            else
            {
                BTN_LeaveRoom.Visible = false;
            }
        }

        private void BTN_StartGame_Click(object sender, EventArgs e)
        {
            client.SendMessage(Protocol.GAME_START);
            var game = new GameForm(client, uname, rName, numOfQuest, questionTime);
            this.Hide();
            game.ShowDialog();
        }
    }
}
