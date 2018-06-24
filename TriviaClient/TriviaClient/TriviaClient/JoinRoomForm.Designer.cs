namespace TriviaClient
{
    partial class JoinRoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTN_Back = new System.Windows.Forms.Button();
            this.LBL_RoomList = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CMB_Rooms = new System.Windows.Forms.ComboBox();
            this.BTN_Join = new System.Windows.Forms.Button();
            this.BTN_Refresh = new System.Windows.Forms.Button();
            this.LBL_FlavorText = new System.Windows.Forms.Label();
            this.LBL_Players = new System.Windows.Forms.Label();
            this.LST_Players = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_Back
            // 
            this.BTN_Back.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTN_Back.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Back.Location = new System.Drawing.Point(783, 12);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(86, 33);
            this.BTN_Back.TabIndex = 2;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // LBL_RoomList
            // 
            this.LBL_RoomList.AutoSize = true;
            this.LBL_RoomList.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_RoomList.Location = new System.Drawing.Point(353, 46);
            this.LBL_RoomList.Name = "LBL_RoomList";
            this.LBL_RoomList.Size = new System.Drawing.Size(195, 42);
            this.LBL_RoomList.TabIndex = 3;
            this.LBL_RoomList.Text = "Room List:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.LST_Players);
            this.panel1.Controls.Add(this.LBL_Players);
            this.panel1.Controls.Add(this.LBL_FlavorText);
            this.panel1.Controls.Add(this.BTN_Join);
            this.panel1.Controls.Add(this.BTN_Refresh);
            this.panel1.Controls.Add(this.CMB_Rooms);
            this.panel1.Location = new System.Drawing.Point(196, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 280);
            this.panel1.TabIndex = 4;
            // 
            // CMB_Rooms
            // 
            this.CMB_Rooms.AllowDrop = true;
            this.CMB_Rooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_Rooms.FormattingEnabled = true;
            this.CMB_Rooms.Location = new System.Drawing.Point(143, 19);
            this.CMB_Rooms.Name = "CMB_Rooms";
            this.CMB_Rooms.Size = new System.Drawing.Size(219, 21);
            this.CMB_Rooms.TabIndex = 0;
            this.CMB_Rooms.SelectedIndexChanged += new System.EventHandler(this.CMB_Rooms_SelectedIndexChanged);
            // 
            // BTN_Join
            // 
            this.BTN_Join.BackColor = System.Drawing.SystemColors.WindowText;
            this.BTN_Join.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Join.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_Join.Location = new System.Drawing.Point(269, 208);
            this.BTN_Join.Name = "BTN_Join";
            this.BTN_Join.Size = new System.Drawing.Size(210, 69);
            this.BTN_Join.TabIndex = 8;
            this.BTN_Join.Text = "Join";
            this.BTN_Join.UseVisualStyleBackColor = false;
            this.BTN_Join.Visible = false;
            this.BTN_Join.Click += new System.EventHandler(this.BTN_Join_Click);
            // 
            // BTN_Refresh
            // 
            this.BTN_Refresh.BackColor = System.Drawing.SystemColors.WindowText;
            this.BTN_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Refresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_Refresh.Location = new System.Drawing.Point(20, 208);
            this.BTN_Refresh.Name = "BTN_Refresh";
            this.BTN_Refresh.Size = new System.Drawing.Size(210, 69);
            this.BTN_Refresh.TabIndex = 9;
            this.BTN_Refresh.Text = "Refresh";
            this.BTN_Refresh.UseVisualStyleBackColor = false;
            this.BTN_Refresh.Click += new System.EventHandler(this.BTN_Refresh_Click);
            // 
            // LBL_FlavorText
            // 
            this.LBL_FlavorText.AutoSize = true;
            this.LBL_FlavorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_FlavorText.ForeColor = System.Drawing.Color.Red;
            this.LBL_FlavorText.Location = new System.Drawing.Point(156, 43);
            this.LBL_FlavorText.Name = "LBL_FlavorText";
            this.LBL_FlavorText.Size = new System.Drawing.Size(196, 25);
            this.LBL_FlavorText.TabIndex = 10;
            this.LBL_FlavorText.Text = "No available rooms";
            // 
            // LBL_Players
            // 
            this.LBL_Players.AutoSize = true;
            this.LBL_Players.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Players.Location = new System.Drawing.Point(170, 68);
            this.LBL_Players.Name = "LBL_Players";
            this.LBL_Players.Size = new System.Drawing.Size(153, 42);
            this.LBL_Players.TabIndex = 5;
            this.LBL_Players.Text = "Players:";
            // 
            // LST_Players
            // 
            this.LST_Players.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LST_Players.FormattingEnabled = true;
            this.LST_Players.ItemHeight = 24;
            this.LST_Players.Location = new System.Drawing.Point(110, 113);
            this.LST_Players.Name = "LST_Players";
            this.LST_Players.Size = new System.Drawing.Size(276, 76);
            this.LST_Players.TabIndex = 11;
            // 
            // JoinRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(881, 414);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LBL_RoomList);
            this.Controls.Add(this.BTN_Back);
            this.Name = "JoinRoomForm";
            this.Text = "JoinRoomForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.Label LBL_RoomList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CMB_Rooms;
        private System.Windows.Forms.Button BTN_Join;
        private System.Windows.Forms.Button BTN_Refresh;
        private System.Windows.Forms.Label LBL_FlavorText;
        private System.Windows.Forms.Label LBL_Players;
        private System.Windows.Forms.ListBox LST_Players;
    }
}