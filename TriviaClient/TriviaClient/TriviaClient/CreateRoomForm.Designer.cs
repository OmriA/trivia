namespace TriviaClient
{
    partial class CreateRoomForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TXT_TimeToQuestion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_NumOfQuestions = new System.Windows.Forms.TextBox();
            this.TXT_NumOfPlayers = new System.Windows.Forms.TextBox();
            this.TXT_RoomName = new System.Windows.Forms.TextBox();
            this.LBL_NumOfQuestions = new System.Windows.Forms.Label();
            this.LBL_NumOfPlayers = new System.Windows.Forms.Label();
            this.LBL_RoomName = new System.Windows.Forms.Label();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.BTN_CreateRoom = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.TXT_TimeToQuestion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TXT_NumOfQuestions);
            this.panel1.Controls.Add(this.TXT_NumOfPlayers);
            this.panel1.Controls.Add(this.TXT_RoomName);
            this.panel1.Controls.Add(this.LBL_NumOfQuestions);
            this.panel1.Controls.Add(this.LBL_NumOfPlayers);
            this.panel1.Controls.Add(this.LBL_RoomName);
            this.panel1.Location = new System.Drawing.Point(185, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 233);
            this.panel1.TabIndex = 1;
            // 
            // TXT_TimeToQuestion
            // 
            this.TXT_TimeToQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_TimeToQuestion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TXT_TimeToQuestion.Location = new System.Drawing.Point(218, 181);
            this.TXT_TimeToQuestion.Name = "TXT_TimeToQuestion";
            this.TXT_TimeToQuestion.Size = new System.Drawing.Size(274, 32);
            this.TXT_TimeToQuestion.TabIndex = 21;
            this.TXT_TimeToQuestion.Text = "Enter time to question here";
            this.TXT_TimeToQuestion.Enter += new System.EventHandler(this.TXT_TimeToQuestion_Enter);
            this.TXT_TimeToQuestion.Leave += new System.EventHandler(this.TXT_TimeToQuestion_Leave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 28);
            this.label1.TabIndex = 20;
            this.label1.Text = "Time to question:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TXT_NumOfQuestions
            // 
            this.TXT_NumOfQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_NumOfQuestions.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TXT_NumOfQuestions.Location = new System.Drawing.Point(218, 130);
            this.TXT_NumOfQuestions.Name = "TXT_NumOfQuestions";
            this.TXT_NumOfQuestions.Size = new System.Drawing.Size(274, 32);
            this.TXT_NumOfQuestions.TabIndex = 19;
            this.TXT_NumOfQuestions.Text = "Enter num of questions here";
            this.TXT_NumOfQuestions.Enter += new System.EventHandler(this.TXT_NumOfQuestions_Enter);
            this.TXT_NumOfQuestions.Leave += new System.EventHandler(this.TXT_NumOfQuestions_Leave);
            // 
            // TXT_NumOfPlayers
            // 
            this.TXT_NumOfPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_NumOfPlayers.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TXT_NumOfPlayers.Location = new System.Drawing.Point(218, 79);
            this.TXT_NumOfPlayers.Name = "TXT_NumOfPlayers";
            this.TXT_NumOfPlayers.Size = new System.Drawing.Size(274, 32);
            this.TXT_NumOfPlayers.TabIndex = 18;
            this.TXT_NumOfPlayers.Text = "Enter num of players here";
            this.TXT_NumOfPlayers.Enter += new System.EventHandler(this.TXT_NumOfPlayers_Enter);
            this.TXT_NumOfPlayers.Leave += new System.EventHandler(this.TXT_NumOfPlayers_Leave);
            // 
            // TXT_RoomName
            // 
            this.TXT_RoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_RoomName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TXT_RoomName.Location = new System.Drawing.Point(218, 28);
            this.TXT_RoomName.Name = "TXT_RoomName";
            this.TXT_RoomName.Size = new System.Drawing.Size(274, 32);
            this.TXT_RoomName.TabIndex = 17;
            this.TXT_RoomName.Text = "Enter room name here";
            this.TXT_RoomName.Enter += new System.EventHandler(this.TXT_RoomName_Enter);
            this.TXT_RoomName.Leave += new System.EventHandler(this.TXT_RoomName_Leave);
            // 
            // LBL_NumOfQuestions
            // 
            this.LBL_NumOfQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_NumOfQuestions.Location = new System.Drawing.Point(0, 131);
            this.LBL_NumOfQuestions.Name = "LBL_NumOfQuestions";
            this.LBL_NumOfQuestions.Size = new System.Drawing.Size(217, 28);
            this.LBL_NumOfQuestions.TabIndex = 16;
            this.LBL_NumOfQuestions.Text = "Number of questions:";
            this.LBL_NumOfQuestions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_NumOfPlayers
            // 
            this.LBL_NumOfPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_NumOfPlayers.Location = new System.Drawing.Point(0, 83);
            this.LBL_NumOfPlayers.Name = "LBL_NumOfPlayers";
            this.LBL_NumOfPlayers.Size = new System.Drawing.Size(194, 28);
            this.LBL_NumOfPlayers.TabIndex = 15;
            this.LBL_NumOfPlayers.Text = "Number of players:";
            this.LBL_NumOfPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_RoomName
            // 
            this.LBL_RoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_RoomName.Location = new System.Drawing.Point(0, 32);
            this.LBL_RoomName.Name = "LBL_RoomName";
            this.LBL_RoomName.Size = new System.Drawing.Size(134, 28);
            this.LBL_RoomName.TabIndex = 14;
            this.LBL_RoomName.Text = "Room name:";
            this.LBL_RoomName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_Back
            // 
            this.BTN_Back.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTN_Back.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Back.Location = new System.Drawing.Point(783, 12);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(86, 33);
            this.BTN_Back.TabIndex = 22;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // BTN_CreateRoom
            // 
            this.BTN_CreateRoom.BackColor = System.Drawing.SystemColors.WindowText;
            this.BTN_CreateRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CreateRoom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_CreateRoom.Location = new System.Drawing.Point(325, 333);
            this.BTN_CreateRoom.Name = "BTN_CreateRoom";
            this.BTN_CreateRoom.Size = new System.Drawing.Size(210, 69);
            this.BTN_CreateRoom.TabIndex = 23;
            this.BTN_CreateRoom.Text = "Create Room";
            this.BTN_CreateRoom.UseVisualStyleBackColor = false;
            this.BTN_CreateRoom.Click += new System.EventHandler(this.BTN_CreateRoom_Click);
            // 
            // CreateRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(881, 414);
            this.Controls.Add(this.BTN_CreateRoom);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.panel1);
            this.Name = "CreateRoomForm";
            this.Text = "Create Room";
            this.Load += new System.EventHandler(this.CreateRoomForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TXT_NumOfQuestions;
        private System.Windows.Forms.TextBox TXT_NumOfPlayers;
        private System.Windows.Forms.TextBox TXT_RoomName;
        private System.Windows.Forms.Label LBL_NumOfQuestions;
        private System.Windows.Forms.Label LBL_NumOfPlayers;
        private System.Windows.Forms.Label LBL_RoomName;
        private System.Windows.Forms.TextBox TXT_TimeToQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.Button BTN_CreateRoom;
    }
}