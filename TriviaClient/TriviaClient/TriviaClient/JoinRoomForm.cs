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
    public partial class JoinRoomForm : Form
    {
        private Client client;
        private string uname;
        private string roomId;

        public JoinRoomForm(Client c, string username)
        {
            uname = username;
            client = c;
            InitializeComponent();
            CMB_Rooms.Items.Clear();
            client.SendMessage(Protocol.AVAILABLE_ROOMS_REQUEST);
            var msg = client.GetMessage();
            var roomNum = Convert.ToInt32(msg.Substring(3, 4));
            if (roomNum != 0)
            {
                BTN_Join.Visible = true;
                LBL_FlavorText.Text = "";
            }
            var roomStr = msg.Substring(7);
            while (roomStr.Length != 0)
            {
                roomId = (roomStr.Substring(0, 4));
                roomStr = roomStr.Substring(4);
                var roomNameLength = Convert.ToInt32(roomStr.Substring(0, 2));
                var roomName = roomStr.Substring(2, roomNameLength);
                roomStr = roomStr.Substring(2 + roomNameLength);
                CMB_Rooms.Items.Add(roomName);
            }
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_Refresh_Click(object sender, EventArgs e)
        {
            CMB_Rooms.Items.Clear();
            LST_Players.Items.Clear();
            client.SendMessage(Protocol.AVAILABLE_ROOMS_REQUEST);
            var msg = client.GetMessage();
            var roomNum = Convert.ToInt32(msg.Substring(3, 4));
            if (roomNum != 0)
            {
                BTN_Join.Visible = true;
                LBL_FlavorText.Text = "";
            }
            else
            {
                LBL_FlavorText.Text = "No available rooms";
                BTN_Join.Visible = false;
                LST_Players.Items.Clear();
                return;
            }
            var roomStr = msg.Substring(7);
            while (roomStr.Length != 0)
            {
                roomId = roomStr.Substring(0, 4);
                roomStr = roomStr.Substring(4);
                var roomNameLength = Convert.ToInt32(roomStr.Substring(0, 2));
                var roomName = roomStr.Substring(2, roomNameLength);
                roomStr = roomStr.Substring(2 + roomNameLength);
                CMB_Rooms.Items.Add(roomName);
            }
        }

        private void CMB_Rooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMB_Rooms.ItemHeight != 0)
            {
                var room = CMB_Rooms.Text;
                roomId = room.Substring(0, 4);
                client.SendMessage(Protocol.USERS_IN_ROOM_REQUEST + roomId);
                var msg = client.GetMessage();
                if (msg == "1080")
                {
                    return;
                }
                else
                {
                    msg = msg.Substring(3);
                    var numUsers = msg.Substring(0, 1);
                    msg = msg.Substring(1);
                    while (msg.Length != 0)
                    {
                        var nameLen = Convert.ToInt32(msg.Substring(0, 2));
                        msg = msg.Substring(2);
                        var name = msg.Substring(0, nameLen);
                        msg = msg.Substring(nameLen);
                        LST_Players.Items.Add(name);

                    }
                }
            }
            else
            {
                return;
            }
        }

        private void BTN_Join_Click(object sender, EventArgs e)
        {
            var room = CMB_Rooms.Text;
            roomId = room.Substring(0, 4);
            client.SendMessage(Protocol.ROOM_JOIN_REQUEST + roomId);
            var msg = client.GetMessage();
            if (msg == "1101")
            {
                LBL_FlavorText.Text = "Room is full";
                return;
            }
            else if (msg == "1102")
            {
                LBL_FlavorText.Text = "Room doesn't exist or other reason";
                return;
            }
            else
            {
                msg = msg.Substring(4);
                var questionNumber = Convert.ToInt32(msg.Substring(0, 2));
                msg = msg.Substring(2);
                var questionTime = Convert.ToInt32(msg.Substring(0, 2));
                var waitForGame = new WaitForGameForm(client, false, CMB_Rooms.Text, LST_Players.ItemHeight, questionNumber, questionTime, uname);
                this.Hide();
                waitForGame.ShowDialog();
                this.Show();
            }
        }
    }
}
