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
    public partial class GameForm : Form
    {
        private Timer t;
        private Client client;
        private string uname;
        private string rName;
        private int numOfQuest;
        private int questionTime;
        private int counter;
        public GameForm(Client c, string username, string roomName, int queNum, int queTime)
        {
            int i = 0, corAns = 0, wrongAns = 0;
            uname = username;
            rName = roomName;
            questionTime = queTime;
            counter = questionTime;
            numOfQuest = queNum;
            client = c;
            InitializeComponent();
            LBL_RoomName.Text = rName;
            LBL_QuestionOut.Text = "Question " + (i + 1) + "/" + queNum;
            LBL_Time.Text = counter.ToString();
            var msg = client.GetMessage();
            if (msg == Protocol.GAME_FAIL)
            {
                MessageBox.Show("ERROR!");
                client.SendMessage(Protocol.GAME_LEAVE);
                this.Hide();
            }
            else if (Convert.ToInt32(msg.Substring(3,3)) == 0)
            {
                MessageBox.Show("ERROR!");
                client.SendMessage(Protocol.GAME_LEAVE);
                this.Hide();
            }
            else
            {
                string que = "", ansone = "", anstwo = "", ansthree = "", ansfour = "";
                for (i = 0; i < 1; i++)
                {
                    counter = questionTime;
                    LBL_QuestionOut.Text = "Question " + (i + 1) + "/" + queNum;
                    msg = msg.Substring(3);
                    int queLen = 0, oneLen = 0, twoLen = 0, threeLen = 0, fourLen = 0;
                    queLen = Convert.ToInt32(msg.Substring(0, 3));
                    msg = msg.Substring(3);
                    que = msg.Substring(0, queLen);
                    LBL_Question.Text = que;
                    msg = msg.Substring(queLen);
                    oneLen = Convert.ToInt32(msg.Substring(0, 3));
                    msg = msg.Substring(3);
                    ansone = msg.Substring(0, oneLen);
                    BTN_AnsOne.Text = ansone;
                    msg = msg.Substring(oneLen);
                    twoLen = Convert.ToInt32(msg.Substring(0, 3));
                    msg = msg.Substring(3);
                    anstwo = msg.Substring(0, twoLen);
                    BTN_AnsTwo.Text = anstwo;
                    msg = msg.Substring(twoLen);
                    threeLen = Convert.ToInt32(msg.Substring(0, 3));
                    msg = msg.Substring(3);
                    ansthree = msg.Substring(0, threeLen);
                    BTN_AnsThree.Text = ansthree;
                    msg = msg.Substring(threeLen);
                    fourLen = Convert.ToInt32(msg.Substring(0, 3));
                    msg = msg.Substring(3);
                    ansfour = msg.Substring(0, fourLen);
                    BTN_AnsFour.Text = ansfour;
                    msg = msg.Substring(fourLen);

                    
                }
            }
        }

        private void BTN_Leave_Click(object sender, EventArgs e)
        {
            client.SendMessage(Protocol.GAME_LEAVE);
            this.Hide();
        }
    }
}
