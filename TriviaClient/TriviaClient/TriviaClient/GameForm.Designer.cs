namespace TriviaClient
{
    partial class GameForm
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
            this.LBL_CorrectAnsNum = new System.Windows.Forms.Label();
            this.LBL_CorrectAns = new System.Windows.Forms.Label();
            this.LBL_Time = new System.Windows.Forms.Label();
            this.Pic_Watch = new System.Windows.Forms.PictureBox();
            this.BTN_AnsTwo = new System.Windows.Forms.Button();
            this.BTN_AnsThree = new System.Windows.Forms.Button();
            this.BTN_AnsFour = new System.Windows.Forms.Button();
            this.BTN_AnsOne = new System.Windows.Forms.Button();
            this.LBL_RoomName = new System.Windows.Forms.Label();
            this.BTN_Leave = new System.Windows.Forms.Button();
            this.LBL_QuestionOut = new System.Windows.Forms.Label();
            this.LBL_Question = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Watch)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.LBL_CorrectAnsNum);
            this.panel1.Controls.Add(this.LBL_CorrectAns);
            this.panel1.Controls.Add(this.LBL_Time);
            this.panel1.Controls.Add(this.Pic_Watch);
            this.panel1.Controls.Add(this.BTN_AnsTwo);
            this.panel1.Controls.Add(this.BTN_AnsThree);
            this.panel1.Controls.Add(this.BTN_AnsFour);
            this.panel1.Controls.Add(this.BTN_AnsOne);
            this.panel1.Location = new System.Drawing.Point(102, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 298);
            this.panel1.TabIndex = 1;
            // 
            // LBL_CorrectAnsNum
            // 
            this.LBL_CorrectAnsNum.AutoSize = true;
            this.LBL_CorrectAnsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CorrectAnsNum.Location = new System.Drawing.Point(576, 242);
            this.LBL_CorrectAnsNum.Name = "LBL_CorrectAnsNum";
            this.LBL_CorrectAnsNum.Size = new System.Drawing.Size(20, 24);
            this.LBL_CorrectAnsNum.TabIndex = 10;
            this.LBL_CorrectAnsNum.Text = "0";
            // 
            // LBL_CorrectAns
            // 
            this.LBL_CorrectAns.AutoSize = true;
            this.LBL_CorrectAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CorrectAns.Location = new System.Drawing.Point(513, 203);
            this.LBL_CorrectAns.Name = "LBL_CorrectAns";
            this.LBL_CorrectAns.Size = new System.Drawing.Size(154, 24);
            this.LBL_CorrectAns.TabIndex = 8;
            this.LBL_CorrectAns.Text = "Correct Answers:";
            // 
            // LBL_Time
            // 
            this.LBL_Time.AutoSize = true;
            this.LBL_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Time.Location = new System.Drawing.Point(558, 71);
            this.LBL_Time.Name = "LBL_Time";
            this.LBL_Time.Size = new System.Drawing.Size(28, 42);
            this.LBL_Time.TabIndex = 8;
            this.LBL_Time.Text = "t";
            // 
            // Pic_Watch
            // 
            this.Pic_Watch.BackgroundImage = global::TriviaClient.Properties.Resources.watch;
            this.Pic_Watch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pic_Watch.Location = new System.Drawing.Point(517, 14);
            this.Pic_Watch.Name = "Pic_Watch";
            this.Pic_Watch.Size = new System.Drawing.Size(142, 148);
            this.Pic_Watch.TabIndex = 9;
            this.Pic_Watch.TabStop = false;
            // 
            // BTN_AnsTwo
            // 
            this.BTN_AnsTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_AnsTwo.Location = new System.Drawing.Point(31, 94);
            this.BTN_AnsTwo.Name = "BTN_AnsTwo";
            this.BTN_AnsTwo.Size = new System.Drawing.Size(480, 48);
            this.BTN_AnsTwo.TabIndex = 8;
            this.BTN_AnsTwo.Text = "Ans2 goes here";
            this.BTN_AnsTwo.UseVisualStyleBackColor = true;
            this.BTN_AnsTwo.Click += new System.EventHandler(this.BTN_AnsTwo_Click);
            // 
            // BTN_AnsThree
            // 
            this.BTN_AnsThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_AnsThree.Location = new System.Drawing.Point(31, 163);
            this.BTN_AnsThree.Name = "BTN_AnsThree";
            this.BTN_AnsThree.Size = new System.Drawing.Size(480, 48);
            this.BTN_AnsThree.TabIndex = 7;
            this.BTN_AnsThree.Text = "Ans3 goes here";
            this.BTN_AnsThree.UseVisualStyleBackColor = true;
            this.BTN_AnsThree.Click += new System.EventHandler(this.BTN_AnsThree_Click);
            // 
            // BTN_AnsFour
            // 
            this.BTN_AnsFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_AnsFour.Location = new System.Drawing.Point(31, 230);
            this.BTN_AnsFour.Name = "BTN_AnsFour";
            this.BTN_AnsFour.Size = new System.Drawing.Size(480, 48);
            this.BTN_AnsFour.TabIndex = 6;
            this.BTN_AnsFour.Text = "Ans4 goes here";
            this.BTN_AnsFour.UseVisualStyleBackColor = true;
            this.BTN_AnsFour.Click += new System.EventHandler(this.BTN_AnsFour_Click);
            // 
            // BTN_AnsOne
            // 
            this.BTN_AnsOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_AnsOne.Location = new System.Drawing.Point(31, 24);
            this.BTN_AnsOne.Name = "BTN_AnsOne";
            this.BTN_AnsOne.Size = new System.Drawing.Size(480, 48);
            this.BTN_AnsOne.TabIndex = 5;
            this.BTN_AnsOne.Text = "Ans1 goes here";
            this.BTN_AnsOne.UseVisualStyleBackColor = true;
            this.BTN_AnsOne.Click += new System.EventHandler(this.BTN_AnsOne_Click);
            // 
            // LBL_RoomName
            // 
            this.LBL_RoomName.AutoSize = true;
            this.LBL_RoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_RoomName.Location = new System.Drawing.Point(12, 9);
            this.LBL_RoomName.Name = "LBL_RoomName";
            this.LBL_RoomName.Size = new System.Drawing.Size(214, 24);
            this.LBL_RoomName.TabIndex = 4;
            this.LBL_RoomName.Text = "Room Name Goes Here";
            // 
            // BTN_Leave
            // 
            this.BTN_Leave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTN_Leave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Leave.Location = new System.Drawing.Point(783, 12);
            this.BTN_Leave.Name = "BTN_Leave";
            this.BTN_Leave.Size = new System.Drawing.Size(86, 33);
            this.BTN_Leave.TabIndex = 5;
            this.BTN_Leave.Text = "Leave Game";
            this.BTN_Leave.UseVisualStyleBackColor = true;
            this.BTN_Leave.Click += new System.EventHandler(this.BTN_Leave_Click);
            // 
            // LBL_QuestionOut
            // 
            this.LBL_QuestionOut.AutoSize = true;
            this.LBL_QuestionOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_QuestionOut.Location = new System.Drawing.Point(28, 68);
            this.LBL_QuestionOut.Name = "LBL_QuestionOut";
            this.LBL_QuestionOut.Size = new System.Drawing.Size(144, 24);
            this.LBL_QuestionOut.TabIndex = 6;
            this.LBL_QuestionOut.Text = "question i/num: ";
            // 
            // LBL_Question
            // 
            this.LBL_Question.AutoSize = true;
            this.LBL_Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Question.Location = new System.Drawing.Point(285, 68);
            this.LBL_Question.Name = "LBL_Question";
            this.LBL_Question.Size = new System.Drawing.Size(183, 24);
            this.LBL_Question.TabIndex = 7;
            this.LBL_Question.Text = "Question Goes Here";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(881, 414);
            this.Controls.Add(this.LBL_Question);
            this.Controls.Add(this.LBL_QuestionOut);
            this.Controls.Add(this.BTN_Leave);
            this.Controls.Add(this.LBL_RoomName);
            this.Controls.Add(this.panel1);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Watch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBL_RoomName;
        private System.Windows.Forms.Button BTN_Leave;
        private System.Windows.Forms.Label LBL_QuestionOut;
        private System.Windows.Forms.Label LBL_Question;
        private System.Windows.Forms.Button BTN_AnsFour;
        private System.Windows.Forms.Button BTN_AnsOne;
        private System.Windows.Forms.Button BTN_AnsThree;
        private System.Windows.Forms.Button BTN_AnsTwo;
        private System.Windows.Forms.PictureBox Pic_Watch;
        private System.Windows.Forms.Label LBL_Time;
        private System.Windows.Forms.Label LBL_CorrectAnsNum;
        private System.Windows.Forms.Label LBL_CorrectAns;
    }
}