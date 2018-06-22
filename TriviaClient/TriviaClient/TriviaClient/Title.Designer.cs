namespace TriviaClient
{
    partial class Title
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
            this.BTN_Quit = new System.Windows.Forms.Button();
            this.PNL_LAYER = new System.Windows.Forms.Panel();
            this.LBL_Welcome = new System.Windows.Forms.Label();
            this.BTN_SignOut = new System.Windows.Forms.Button();
            this.TXT_Password = new System.Windows.Forms.TextBox();
            this.BTN_Signup = new System.Windows.Forms.Button();
            this.TXT_Username = new System.Windows.Forms.TextBox();
            this.BTN_SignIn = new System.Windows.Forms.Button();
            this.BTN_JoinRoom = new System.Windows.Forms.Button();
            this.BTN_CreateRoom = new System.Windows.Forms.Button();
            this.BTN_MyStatus = new System.Windows.Forms.Button();
            this.BTN_BestScores = new System.Windows.Forms.Button();
            this.PNL_LAYER.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_Quit
            // 
            this.BTN_Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Quit.Location = new System.Drawing.Point(384, 357);
            this.BTN_Quit.Name = "BTN_Quit";
            this.BTN_Quit.Size = new System.Drawing.Size(112, 43);
            this.BTN_Quit.TabIndex = 0;
            this.BTN_Quit.Text = "Quit";
            this.BTN_Quit.UseVisualStyleBackColor = true;
            this.BTN_Quit.Click += new System.EventHandler(this.BTN_Quit_Click);
            // 
            // PNL_LAYER
            // 
            this.PNL_LAYER.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PNL_LAYER.Controls.Add(this.LBL_Welcome);
            this.PNL_LAYER.Controls.Add(this.BTN_SignOut);
            this.PNL_LAYER.Controls.Add(this.TXT_Password);
            this.PNL_LAYER.Controls.Add(this.BTN_Signup);
            this.PNL_LAYER.Controls.Add(this.TXT_Username);
            this.PNL_LAYER.Controls.Add(this.BTN_SignIn);
            this.PNL_LAYER.Location = new System.Drawing.Point(189, 47);
            this.PNL_LAYER.Name = "PNL_LAYER";
            this.PNL_LAYER.Size = new System.Drawing.Size(502, 210);
            this.PNL_LAYER.TabIndex = 6;
            this.PNL_LAYER.Paint += new System.Windows.Forms.PaintEventHandler(this.PNL_LAYER_Paint);
            // 
            // LBL_Welcome
            // 
            this.LBL_Welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Welcome.Location = new System.Drawing.Point(23, 53);
            this.LBL_Welcome.Name = "LBL_Welcome";
            this.LBL_Welcome.Size = new System.Drawing.Size(461, 49);
            this.LBL_Welcome.TabIndex = 13;
            this.LBL_Welcome.Text = "TEXT GOES HERE";
            this.LBL_Welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBL_Welcome.Visible = false;
            // 
            // BTN_SignOut
            // 
            this.BTN_SignOut.BackColor = System.Drawing.SystemColors.WindowText;
            this.BTN_SignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SignOut.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_SignOut.Location = new System.Drawing.Point(146, 122);
            this.BTN_SignOut.Name = "BTN_SignOut";
            this.BTN_SignOut.Size = new System.Drawing.Size(210, 69);
            this.BTN_SignOut.TabIndex = 12;
            this.BTN_SignOut.Text = "Sign Out";
            this.BTN_SignOut.UseVisualStyleBackColor = false;
            this.BTN_SignOut.Visible = false;
            this.BTN_SignOut.Click += new System.EventHandler(this.BTN_SignOut_Click);
            // 
            // TXT_Password
            // 
            this.TXT_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Password.Location = new System.Drawing.Point(33, 70);
            this.TXT_Password.Name = "TXT_Password";
            this.TXT_Password.Size = new System.Drawing.Size(439, 32);
            this.TXT_Password.TabIndex = 11;
            this.TXT_Password.Text = "Password";
            this.TXT_Password.UseSystemPasswordChar = true;
            // 
            // BTN_Signup
            // 
            this.BTN_Signup.BackColor = System.Drawing.SystemColors.WindowText;
            this.BTN_Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Signup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_Signup.Location = new System.Drawing.Point(262, 122);
            this.BTN_Signup.Name = "BTN_Signup";
            this.BTN_Signup.Size = new System.Drawing.Size(210, 69);
            this.BTN_Signup.TabIndex = 5;
            this.BTN_Signup.Text = "Sign Up";
            this.BTN_Signup.UseVisualStyleBackColor = false;
            this.BTN_Signup.Click += new System.EventHandler(this.BTN_Signup_Click);
            // 
            // TXT_Username
            // 
            this.TXT_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Username.Location = new System.Drawing.Point(33, 18);
            this.TXT_Username.Name = "TXT_Username";
            this.TXT_Username.Size = new System.Drawing.Size(439, 32);
            this.TXT_Username.TabIndex = 10;
            this.TXT_Username.Text = "Username";
            // 
            // BTN_SignIn
            // 
            this.BTN_SignIn.BackColor = System.Drawing.SystemColors.WindowText;
            this.BTN_SignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SignIn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_SignIn.Location = new System.Drawing.Point(33, 122);
            this.BTN_SignIn.Name = "BTN_SignIn";
            this.BTN_SignIn.Size = new System.Drawing.Size(210, 69);
            this.BTN_SignIn.TabIndex = 7;
            this.BTN_SignIn.Text = "Sign In";
            this.BTN_SignIn.UseVisualStyleBackColor = false;
            this.BTN_SignIn.Click += new System.EventHandler(this.BTN_SignIn_Click);
            // 
            // BTN_JoinRoom
            // 
            this.BTN_JoinRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_JoinRoom.Location = new System.Drawing.Point(189, 298);
            this.BTN_JoinRoom.Name = "BTN_JoinRoom";
            this.BTN_JoinRoom.Size = new System.Drawing.Size(112, 43);
            this.BTN_JoinRoom.TabIndex = 4;
            this.BTN_JoinRoom.Text = "Join Room";
            this.BTN_JoinRoom.UseVisualStyleBackColor = true;
            this.BTN_JoinRoom.Visible = false;
            // 
            // BTN_CreateRoom
            // 
            this.BTN_CreateRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CreateRoom.Location = new System.Drawing.Point(320, 298);
            this.BTN_CreateRoom.Name = "BTN_CreateRoom";
            this.BTN_CreateRoom.Size = new System.Drawing.Size(112, 43);
            this.BTN_CreateRoom.TabIndex = 3;
            this.BTN_CreateRoom.Text = "Create Room";
            this.BTN_CreateRoom.UseVisualStyleBackColor = true;
            this.BTN_CreateRoom.Visible = false;
            // 
            // BTN_MyStatus
            // 
            this.BTN_MyStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_MyStatus.Location = new System.Drawing.Point(451, 298);
            this.BTN_MyStatus.Name = "BTN_MyStatus";
            this.BTN_MyStatus.Size = new System.Drawing.Size(112, 43);
            this.BTN_MyStatus.TabIndex = 2;
            this.BTN_MyStatus.Text = "My Status";
            this.BTN_MyStatus.UseVisualStyleBackColor = true;
            this.BTN_MyStatus.Visible = false;
            this.BTN_MyStatus.Click += new System.EventHandler(this.BTN_MyStatus_Click);
            // 
            // BTN_BestScores
            // 
            this.BTN_BestScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_BestScores.Location = new System.Drawing.Point(579, 298);
            this.BTN_BestScores.Name = "BTN_BestScores";
            this.BTN_BestScores.Size = new System.Drawing.Size(112, 43);
            this.BTN_BestScores.TabIndex = 1;
            this.BTN_BestScores.Text = "Best Scores";
            this.BTN_BestScores.UseVisualStyleBackColor = true;
            this.BTN_BestScores.Visible = false;
            this.BTN_BestScores.Click += new System.EventHandler(this.BTN_BestScores_Click);
            // 
            // Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(881, 414);
            this.Controls.Add(this.PNL_LAYER);
            this.Controls.Add(this.BTN_JoinRoom);
            this.Controls.Add(this.BTN_CreateRoom);
            this.Controls.Add(this.BTN_MyStatus);
            this.Controls.Add(this.BTN_BestScores);
            this.Controls.Add(this.BTN_Quit);
            this.Name = "Title";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PNL_LAYER.ResumeLayout(false);
            this.PNL_LAYER.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Quit;
        private System.Windows.Forms.Panel PNL_LAYER;
        private System.Windows.Forms.Button BTN_SignIn;
        private System.Windows.Forms.TextBox TXT_Username;
        private System.Windows.Forms.TextBox TXT_Password;
        private System.Windows.Forms.Button BTN_JoinRoom;
        private System.Windows.Forms.Button BTN_CreateRoom;
        private System.Windows.Forms.Button BTN_MyStatus;
        private System.Windows.Forms.Button BTN_BestScores;
        private System.Windows.Forms.Button BTN_Signup;
        private System.Windows.Forms.Button BTN_SignOut;
        private System.Windows.Forms.Label LBL_Welcome;
    }
}

