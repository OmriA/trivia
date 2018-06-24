namespace TriviaClient
{
    partial class WaitForGameForm
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
            this.PNL_LAYER = new System.Windows.Forms.Panel();
            this.LBL_MaxPlayers = new System.Windows.Forms.Label();
            this.LBL_ConnectedTo = new System.Windows.Forms.Label();
            this.LBL_QuestionsNum = new System.Windows.Forms.Label();
            this.LBL_QuestionTime = new System.Windows.Forms.Label();
            this.LBL_Participants = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BTN_CloseRoom = new System.Windows.Forms.Button();
            this.BTN_StartGame = new System.Windows.Forms.Button();
            this.BTN_LeaveRoom = new System.Windows.Forms.Button();
            this.PNL_LAYER.SuspendLayout();
            this.SuspendLayout();
            // 
            // PNL_LAYER
            // 
            this.PNL_LAYER.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PNL_LAYER.Controls.Add(this.listBox1);
            this.PNL_LAYER.Controls.Add(this.LBL_Participants);
            this.PNL_LAYER.Controls.Add(this.LBL_QuestionTime);
            this.PNL_LAYER.Controls.Add(this.LBL_QuestionsNum);
            this.PNL_LAYER.Controls.Add(this.LBL_MaxPlayers);
            this.PNL_LAYER.Controls.Add(this.LBL_ConnectedTo);
            this.PNL_LAYER.Location = new System.Drawing.Point(12, 59);
            this.PNL_LAYER.Name = "PNL_LAYER";
            this.PNL_LAYER.Size = new System.Drawing.Size(857, 265);
            this.PNL_LAYER.TabIndex = 7;
            // 
            // LBL_MaxPlayers
            // 
            this.LBL_MaxPlayers.AutoSize = true;
            this.LBL_MaxPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_MaxPlayers.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBL_MaxPlayers.Location = new System.Drawing.Point(50, 58);
            this.LBL_MaxPlayers.Name = "LBL_MaxPlayers";
            this.LBL_MaxPlayers.Size = new System.Drawing.Size(192, 24);
            this.LBL_MaxPlayers.TabIndex = 1;
            this.LBL_MaxPlayers.Text = "max number players: ";
            // 
            // LBL_ConnectedTo
            // 
            this.LBL_ConnectedTo.AutoSize = true;
            this.LBL_ConnectedTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_ConnectedTo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LBL_ConnectedTo.Location = new System.Drawing.Point(305, 23);
            this.LBL_ConnectedTo.Name = "LBL_ConnectedTo";
            this.LBL_ConnectedTo.Size = new System.Drawing.Size(278, 25);
            this.LBL_ConnectedTo.TabIndex = 0;
            this.LBL_ConnectedTo.Text = "You are connected to room ";
            // 
            // LBL_QuestionsNum
            // 
            this.LBL_QuestionsNum.AutoSize = true;
            this.LBL_QuestionsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_QuestionsNum.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBL_QuestionsNum.Location = new System.Drawing.Point(306, 58);
            this.LBL_QuestionsNum.Name = "LBL_QuestionsNum";
            this.LBL_QuestionsNum.Size = new System.Drawing.Size(187, 24);
            this.LBL_QuestionsNum.TabIndex = 2;
            this.LBL_QuestionsNum.Text = "number of questions:";
            // 
            // LBL_QuestionTime
            // 
            this.LBL_QuestionTime.AutoSize = true;
            this.LBL_QuestionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_QuestionTime.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBL_QuestionTime.Location = new System.Drawing.Point(584, 58);
            this.LBL_QuestionTime.Name = "LBL_QuestionTime";
            this.LBL_QuestionTime.Size = new System.Drawing.Size(160, 24);
            this.LBL_QuestionTime.TabIndex = 3;
            this.LBL_QuestionTime.Text = "time per question:";
            // 
            // LBL_Participants
            // 
            this.LBL_Participants.AutoSize = true;
            this.LBL_Participants.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_Participants.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LBL_Participants.Location = new System.Drawing.Point(305, 120);
            this.LBL_Participants.Name = "LBL_Participants";
            this.LBL_Participants.Size = new System.Drawing.Size(243, 25);
            this.LBL_Participants.TabIndex = 4;
            this.LBL_Participants.Text = "Current participants are:";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(267, 149);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(316, 104);
            this.listBox1.TabIndex = 5;
            // 
            // BTN_CloseRoom
            // 
            this.BTN_CloseRoom.BackColor = System.Drawing.SystemColors.WindowText;
            this.BTN_CloseRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CloseRoom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_CloseRoom.Location = new System.Drawing.Point(144, 333);
            this.BTN_CloseRoom.Name = "BTN_CloseRoom";
            this.BTN_CloseRoom.Size = new System.Drawing.Size(210, 69);
            this.BTN_CloseRoom.TabIndex = 8;
            this.BTN_CloseRoom.Text = "Close Room";
            this.BTN_CloseRoom.UseVisualStyleBackColor = false;
            // 
            // BTN_StartGame
            // 
            this.BTN_StartGame.BackColor = System.Drawing.SystemColors.WindowText;
            this.BTN_StartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_StartGame.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_StartGame.Location = new System.Drawing.Point(502, 333);
            this.BTN_StartGame.Name = "BTN_StartGame";
            this.BTN_StartGame.Size = new System.Drawing.Size(210, 69);
            this.BTN_StartGame.TabIndex = 9;
            this.BTN_StartGame.Text = "Start Game";
            this.BTN_StartGame.UseVisualStyleBackColor = false;
            // 
            // BTN_LeaveRoom
            // 
            this.BTN_LeaveRoom.BackColor = System.Drawing.SystemColors.WindowText;
            this.BTN_LeaveRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_LeaveRoom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_LeaveRoom.Location = new System.Drawing.Point(322, 333);
            this.BTN_LeaveRoom.Name = "BTN_LeaveRoom";
            this.BTN_LeaveRoom.Size = new System.Drawing.Size(210, 69);
            this.BTN_LeaveRoom.TabIndex = 10;
            this.BTN_LeaveRoom.Text = "Leave Room";
            this.BTN_LeaveRoom.UseVisualStyleBackColor = false;
            // 
            // WaitForGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(881, 414);
            this.Controls.Add(this.BTN_LeaveRoom);
            this.Controls.Add(this.BTN_StartGame);
            this.Controls.Add(this.BTN_CloseRoom);
            this.Controls.Add(this.PNL_LAYER);
            this.Name = "WaitForGameForm";
            this.Text = "Wait For Game";
            this.PNL_LAYER.ResumeLayout(false);
            this.PNL_LAYER.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNL_LAYER;
        private System.Windows.Forms.Label LBL_ConnectedTo;
        private System.Windows.Forms.Label LBL_MaxPlayers;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label LBL_Participants;
        private System.Windows.Forms.Label LBL_QuestionTime;
        private System.Windows.Forms.Label LBL_QuestionsNum;
        private System.Windows.Forms.Button BTN_CloseRoom;
        private System.Windows.Forms.Button BTN_StartGame;
        private System.Windows.Forms.Button BTN_LeaveRoom;
    }
}