using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TriviaClient
{
    public partial class WaitForGameForm : Form
    {
        private Client client;
        private bool listen = true;
        private string userName;
        private string roomName;
        private int qstNum;
        private int qstTime;

        public WaitForGameForm(Client c, bool admin, string roomName, int maxNumPlayers, int numOfQst, int timeToQst, string uname)
        {
            client = c;
            userName = uname;
            this.roomName = roomName;
            qstNum = numOfQst;
            qstTime = timeToQst;

            InitializeComponent();
            LBL_ConnectedTo.Text += roomName;
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

            var listenThread = new Thread(listenToServer);
            listenThread.Start();
        }

        private void listenToServer()
        {
            string msgCode;
            while (listen)
            {
                var msg = client.GetMessage();
                msgCode = msg.Substring(0, 3);
                msg = msg.Substring(3);
                if (msgCode == Protocol.USERS_IN_ROOM_RESPONSE)
                {
                    BeginInvoke((MethodInvoker)(() => LST_Users.Items.Clear()));
                    var numOfUsers = Convert.ToInt32(msg.Substring(0, 1));
                    msg = msg.Substring(1);
                    for (int i = 0; i < numOfUsers; i++)
                    {
                        var nameLen = Convert.ToInt32(msg.Substring(0, 2));
                        var name = msg.Substring(2, nameLen);
                        msg = msg.Substring(2 + nameLen);
                        Invoke((MethodInvoker)(() => LST_Users.Items.Add(name)));
                    }
                }
                else
                {
                    listen = false;
                    if (msgCode == Protocol.GAME_START)
                    {
                        var gameForm = new GameForm(client, userName, roomName, qstNum, qstTime);
                        gameForm.ShowDialog();
                    }
                    Invoke((MethodInvoker)(() => this.Close()));
                }
            }
        }
    }
}
