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
    public partial class GameForm : Form
    {
        private System.Windows.Forms.Timer t;
        private Client client;
        private string rName;
        private int numOfQuest;
        private int questionTime;
        private int counter;
        private int currQue = 1;
        private int corNum = 0;
        public GameForm(Client c, string msg, string roomName, int queNum, int queTime)
        {
            this.ControlBox = false;
            int i = 0;
            rName = roomName;
            questionTime = queTime;
            counter = questionTime;
            numOfQuest = queNum;
            client = c;
            InitializeComponent();
            t = new System.Windows.Forms.Timer();
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 1000; // 1 second
            t.Start();
            LBL_RoomName.Text = rName;
            LBL_QuestionOut.Text = "Question " + (i + 1) + "/" + queNum;
            LBL_Time.Text = counter.ToString();
            if (msg == "0")
            {
                MessageBox.Show("ERROR!");
                client.SendMessage(Protocol.GAME_LEAVE);
                this.Hide();
            }
            else if (Convert.ToInt32(msg.Substring(0, 3)) == 0)
            {
                MessageBox.Show("ERROR!");
                client.SendMessage(Protocol.GAME_LEAVE);
                this.Hide();
            }
            else
            {
                initForm(msg);

            }
        }

        private void BTN_Leave_Click(object sender, EventArgs e)
        {
            client.SendMessage(Protocol.GAME_LEAVE);
            t.Stop();
            this.Hide();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == -1)
            {
                client.SendMessage(Protocol.ANSWER + "5" + Protocol.GetPaddedNumber(questionTime, 1));
                BTN_AnsOne.BackColor = Color.Red;
                BTN_AnsTwo.BackColor = Color.Red;
                BTN_AnsThree.BackColor = Color.Red;
                BTN_AnsFour.BackColor = Color.Red;
                t.Stop();
                BTN_AnsOne.Enabled = false;
                BTN_AnsTwo.Enabled = false;
                BTN_AnsThree.Enabled = false;
                BTN_AnsFour.Enabled = false;
                client.GetMessage();
                var msg = client.GetMessage();
                if (currQue != numOfQuest)
                {
                    Thread.Sleep(new TimeSpan(0, 0, 0, 1));
                    currQue++;
                    initForm(msg.Substring(3));
                }
                else
                {
                    LBL_Time.Visible = false;
                    currQue++;
                    int usersnum = Convert.ToInt32(msg.Substring(3, 1));
                    string finalMsg = "", user = "";
                    int userLen = 0, score = 0;
                    msg = msg.Substring(4);
                    while (msg.Length != 0)
                    {
                        userLen = Convert.ToInt32(msg.Substring(0, 2));
                        msg = msg.Substring(2);
                        user = msg.Substring(0, userLen);
                        msg = msg.Substring(userLen);
                        score = Convert.ToInt32(msg.Substring(0, 2));
                        msg = msg.Substring(2);
                        finalMsg += user + ": " + score.ToString() + "\n";
                    }
                    MessageBox.Show(finalMsg, "Final Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            LBL_Time.Text = counter.ToString();
        }

        public void initForm(string msg)
        {
            if (numOfQuest >= currQue)
            {
                string que = "", ansone = "", anstwo = "", ansthree = "", ansfour = "";
                counter = questionTime;
                t.Start();
                LBL_QuestionOut.Text = "Question " + currQue + "/" + numOfQuest;
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
                BTN_AnsOne.BackColor = SystemColors.ButtonFace;
                BTN_AnsOne.Enabled = true;
                BTN_AnsTwo.BackColor = SystemColors.ButtonFace;
                BTN_AnsTwo.Enabled = true;
                BTN_AnsThree.BackColor = SystemColors.ButtonFace;
                BTN_AnsThree.Enabled = true;
                BTN_AnsFour.BackColor = SystemColors.ButtonFace;
                BTN_AnsFour.Enabled = true;
            }
        }

        private void BTN_AnsOne_Click(object sender, EventArgs e)
        {
            client.SendMessage(Protocol.ANSWER + "1" + Protocol.GetPaddedNumber(questionTime - counter, 1));
            t.Stop();
            BTN_AnsTwo.Enabled = false;
            BTN_AnsThree.Enabled = false;
            BTN_AnsFour.Enabled = false;
            var msg = client.GetMessage();
            if (msg.Substring(3, 1) == "1")
            {
                BTN_AnsOne.BackColor = Color.LightGreen;
                BTN_AnsOne.Enabled = false;
                corNum++;
                LBL_CorrectAnsNum.Text = corNum.ToString();
            }
            else
            {
                BTN_AnsOne.BackColor = Color.Red;
                BTN_AnsOne.Enabled = false;
            }
            msg = client.GetMessage();
            if (currQue != numOfQuest)
            {
                Thread.Sleep(new TimeSpan(0, 0, 0, 1));
                currQue++;
                initForm(msg.Substring(3));
            }
            else
            {
                LBL_Time.Visible = false;
                currQue++;
                int usersnum = Convert.ToInt32(msg.Substring(3, 1));
                string finalMsg = "", user = "";
                int userLen = 0, score = 0;
                msg = msg.Substring(4);
                while (msg.Length != 0)
                {
                    userLen = Convert.ToInt32(msg.Substring(0, 2));
                    msg = msg.Substring(2);
                    user = msg.Substring(0, userLen);
                    msg = msg.Substring(userLen);
                    score = Convert.ToInt32(msg.Substring(0, 2));
                    msg = msg.Substring(2);
                    finalMsg += user + ": " + score.ToString() + "\n";
                }
                MessageBox.Show(finalMsg, "Final Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            LBL_Time.Text = counter.ToString();
        }
        private void BTN_AnsTwo_Click(object sender, EventArgs e)
        {
            client.SendMessage(Protocol.ANSWER + "2" + Protocol.GetPaddedNumber(questionTime - counter, 1));
            t.Stop();
            BTN_AnsOne.Enabled = false;
            BTN_AnsThree.Enabled = false;
            BTN_AnsFour.Enabled = false;
            var msg = client.GetMessage();
            if (msg.Substring(3, 1) == "1")
            {
                BTN_AnsTwo.BackColor = Color.LightGreen;
                BTN_AnsTwo.Enabled = false;
                corNum++;
                LBL_CorrectAnsNum.Text = corNum.ToString();
            }
            else
            {
                BTN_AnsTwo.BackColor = Color.Red;
                BTN_AnsTwo.Enabled = false;
            }
            msg = client.GetMessage();
            if (currQue != numOfQuest)
            {
                Thread.Sleep(new TimeSpan(0, 0, 0, 1));
                currQue++;
                initForm(msg.Substring(3));
            }
            else
            {
                LBL_Time.Visible = false;
                currQue++;
                int usersnum = Convert.ToInt32(msg.Substring(3, 1));
                string finalMsg = "", user = "";
                int userLen = 0, score = 0;
                msg = msg.Substring(4);
                while (msg.Length != 0)
                {
                    userLen = Convert.ToInt32(msg.Substring(0, 2));
                    msg = msg.Substring(2);
                    user = msg.Substring(0, userLen);
                    msg = msg.Substring(userLen);
                    score = Convert.ToInt32(msg.Substring(0, 2));
                    msg = msg.Substring(2);
                    finalMsg += user + ": " + score.ToString() + "\n";
                }
                MessageBox.Show(finalMsg, "Final Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            LBL_Time.Text = counter.ToString();
        }
        private void BTN_AnsThree_Click(object sender, EventArgs e)
        {
            client.SendMessage(Protocol.ANSWER + "3" + Protocol.GetPaddedNumber(questionTime - counter, 1));
            t.Stop();
            BTN_AnsOne.Enabled = false;
            BTN_AnsTwo.Enabled = false;
            BTN_AnsFour.Enabled = false;
            var msg = client.GetMessage();
            if (msg.Substring(3, 1) == "1")
            {
                BTN_AnsThree.BackColor = Color.LightGreen;
                BTN_AnsThree.Enabled = false;
                corNum++;
                LBL_CorrectAnsNum.Text = corNum.ToString();
            }
            else
            {
                BTN_AnsThree.BackColor = Color.Red;
                BTN_AnsThree.Enabled = false;
            }
            msg = client.GetMessage();
            if (currQue != numOfQuest)
            {
                Thread.Sleep(new TimeSpan(0, 0, 0, 1));
                currQue++;
                initForm(msg.Substring(3));
            }
            else
            {
                LBL_Time.Visible = false;
                currQue++;
                int usersnum = Convert.ToInt32(msg.Substring(3, 1));
                string finalMsg = "", user = "";
                int userLen = 0, score = 0;
                msg = msg.Substring(4);
                while (msg.Length != 0)
                {
                    userLen = Convert.ToInt32(msg.Substring(0, 2));
                    msg = msg.Substring(2);
                    user = msg.Substring(0, userLen);
                    msg = msg.Substring(userLen);
                    score = Convert.ToInt32(msg.Substring(0, 2));
                    msg = msg.Substring(2);
                    finalMsg += user + ": " + score.ToString() + "\n";
                }
                MessageBox.Show(finalMsg, "Final Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            LBL_Time.Text = counter.ToString();
        }
        private void BTN_AnsFour_Click(object sender, EventArgs e)
        {
            client.SendMessage(Protocol.ANSWER + "4" + Protocol.GetPaddedNumber(questionTime - counter, 1));
            t.Stop();
            BTN_AnsOne.Enabled = false;
            BTN_AnsTwo.Enabled = false;
            BTN_AnsThree.Enabled = false;
            var msg = client.GetMessage();
            if (msg.Substring(3, 1) == "1")
            {
                BTN_AnsFour.BackColor = Color.LightGreen;
                BTN_AnsFour.Enabled = false;
                corNum++;
                LBL_CorrectAnsNum.Text = corNum.ToString();
            }
            else
            {
                BTN_AnsFour.BackColor = Color.Red;
                BTN_AnsFour.Enabled = false;
            }
            msg = client.GetMessage();
            if (currQue != numOfQuest)
            {
                Thread.Sleep(new TimeSpan(0, 0, 0, 1));
                currQue++;
                initForm(msg.Substring(3));
            }
            else
            {
                LBL_Time.Visible = false;
                currQue++;
                int usersnum = Convert.ToInt32(msg.Substring(3, 1));
                string finalMsg = "", user = "";
                int userLen = 0, score = 0;
                msg = msg.Substring(4);
                while (msg.Length != 0)
                {
                    userLen = Convert.ToInt32(msg.Substring(0, 2));
                    msg = msg.Substring(2);
                    user = msg.Substring(0, userLen);
                    msg = msg.Substring(userLen);
                    score = Convert.ToInt32(msg.Substring(0, 2));
                    msg = msg.Substring(2);
                    finalMsg += user + ": " + score.ToString() + "\n";
                }
                MessageBox.Show(finalMsg, "Final Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            LBL_Time.Text = counter.ToString();
        }

    }
}

