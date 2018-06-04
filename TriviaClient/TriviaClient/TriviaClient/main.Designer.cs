namespace TriviaClient
{
    partial class main
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
            this.BTN_BestScores = new System.Windows.Forms.Button();
            this.BTN_MyStatus = new System.Windows.Forms.Button();
            this.BTN_CreateRoom = new System.Windows.Forms.Button();
            this.BTN_JoinRoom = new System.Windows.Forms.Button();
            this.BTN_Signup = new System.Windows.Forms.Button();
            this.PNL_LAYER = new System.Windows.Forms.Panel();
            this.BTN_SignIn = new System.Windows.Forms.Button();
            this.LBL_Username = new System.Windows.Forms.Label();
            this.LBL_Password = new System.Windows.Forms.Label();
            this.TXT_Username = new System.Windows.Forms.TextBox();
            this.TXT_Password = new System.Windows.Forms.TextBox();
            this.PNL_LAYER.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_Quit
            // 
            this.BTN_Quit.Font = new System.Drawing.Font("Pretendo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Quit.Location = new System.Drawing.Point(368, 635);
            this.BTN_Quit.Name = "BTN_Quit";
            this.BTN_Quit.Size = new System.Drawing.Size(137, 43);
            this.BTN_Quit.TabIndex = 0;
            this.BTN_Quit.Text = "Quit";
            this.BTN_Quit.UseVisualStyleBackColor = true;
            this.BTN_Quit.Click += new System.EventHandler(this.BTN_Quit_Click);
            // 
            // BTN_BestScores
            // 
            this.BTN_BestScores.Font = new System.Drawing.Font("Pretendo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_BestScores.Location = new System.Drawing.Point(252, 562);
            this.BTN_BestScores.Name = "BTN_BestScores";
            this.BTN_BestScores.Size = new System.Drawing.Size(367, 43);
            this.BTN_BestScores.TabIndex = 1;
            this.BTN_BestScores.Text = "Best Scores";
            this.BTN_BestScores.UseVisualStyleBackColor = true;
            // 
            // BTN_MyStatus
            // 
            this.BTN_MyStatus.Font = new System.Drawing.Font("Pretendo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_MyStatus.Location = new System.Drawing.Point(252, 484);
            this.BTN_MyStatus.Name = "BTN_MyStatus";
            this.BTN_MyStatus.Size = new System.Drawing.Size(367, 43);
            this.BTN_MyStatus.TabIndex = 2;
            this.BTN_MyStatus.Text = "My Status";
            this.BTN_MyStatus.UseVisualStyleBackColor = true;
            // 
            // BTN_CreateRoom
            // 
            this.BTN_CreateRoom.Font = new System.Drawing.Font("Pretendo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CreateRoom.Location = new System.Drawing.Point(252, 412);
            this.BTN_CreateRoom.Name = "BTN_CreateRoom";
            this.BTN_CreateRoom.Size = new System.Drawing.Size(367, 43);
            this.BTN_CreateRoom.TabIndex = 3;
            this.BTN_CreateRoom.Text = "Create Room";
            this.BTN_CreateRoom.UseVisualStyleBackColor = true;
            // 
            // BTN_JoinRoom
            // 
            this.BTN_JoinRoom.Font = new System.Drawing.Font("Pretendo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_JoinRoom.Location = new System.Drawing.Point(252, 341);
            this.BTN_JoinRoom.Name = "BTN_JoinRoom";
            this.BTN_JoinRoom.Size = new System.Drawing.Size(367, 43);
            this.BTN_JoinRoom.TabIndex = 4;
            this.BTN_JoinRoom.Text = "Join Room";
            this.BTN_JoinRoom.UseVisualStyleBackColor = true;
            // 
            // BTN_Signup
            // 
            this.BTN_Signup.Font = new System.Drawing.Font("Pretendo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Signup.Location = new System.Drawing.Point(252, 270);
            this.BTN_Signup.Name = "BTN_Signup";
            this.BTN_Signup.Size = new System.Drawing.Size(367, 43);
            this.BTN_Signup.TabIndex = 5;
            this.BTN_Signup.Text = "Sign Up";
            this.BTN_Signup.UseVisualStyleBackColor = true;
            // 
            // PNL_LAYER
            // 
            this.PNL_LAYER.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PNL_LAYER.Controls.Add(this.TXT_Password);
            this.PNL_LAYER.Controls.Add(this.TXT_Username);
            this.PNL_LAYER.Controls.Add(this.LBL_Password);
            this.PNL_LAYER.Controls.Add(this.LBL_Username);
            this.PNL_LAYER.Controls.Add(this.BTN_SignIn);
            this.PNL_LAYER.Location = new System.Drawing.Point(138, 150);
            this.PNL_LAYER.Name = "PNL_LAYER";
            this.PNL_LAYER.Size = new System.Drawing.Size(614, 107);
            this.PNL_LAYER.TabIndex = 6;
            this.PNL_LAYER.Paint += new System.Windows.Forms.PaintEventHandler(this.PNL_LAYER_Paint);
            // 
            // BTN_SignIn
            // 
            this.BTN_SignIn.Font = new System.Drawing.Font("Pretendo", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SignIn.Location = new System.Drawing.Point(436, 21);
            this.BTN_SignIn.Name = "BTN_SignIn";
            this.BTN_SignIn.Size = new System.Drawing.Size(149, 69);
            this.BTN_SignIn.TabIndex = 7;
            this.BTN_SignIn.Text = "Sign In";
            this.BTN_SignIn.UseVisualStyleBackColor = true;
            // 
            // LBL_Username
            // 
            this.LBL_Username.AutoSize = true;
            this.LBL_Username.Font = new System.Drawing.Font("Pretendo", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Username.Location = new System.Drawing.Point(14, 21);
            this.LBL_Username.Name = "LBL_Username";
            this.LBL_Username.Size = new System.Drawing.Size(137, 25);
            this.LBL_Username.TabIndex = 8;
            this.LBL_Username.Text = "Username";
            // 
            // LBL_Password
            // 
            this.LBL_Password.AutoSize = true;
            this.LBL_Password.Font = new System.Drawing.Font("Pretendo", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Password.Location = new System.Drawing.Point(14, 65);
            this.LBL_Password.Name = "LBL_Password";
            this.LBL_Password.Size = new System.Drawing.Size(137, 25);
            this.LBL_Password.TabIndex = 9;
            this.LBL_Password.Text = "Password";
            // 
            // TXT_Username
            // 
            this.TXT_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Username.Location = new System.Drawing.Point(157, 17);
            this.TXT_Username.Name = "TXT_Username";
            this.TXT_Username.Size = new System.Drawing.Size(273, 32);
            this.TXT_Username.TabIndex = 10;
            this.TXT_Username.Text = "user";
            this.TXT_Username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TXT_Password
            // 
            this.TXT_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Password.Location = new System.Drawing.Point(157, 61);
            this.TXT_Password.Name = "TXT_Password";
            this.TXT_Password.Size = new System.Drawing.Size(273, 32);
            this.TXT_Password.TabIndex = 11;
            this.TXT_Password.Text = "Aa12";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(881, 690);
            this.Controls.Add(this.PNL_LAYER);
            this.Controls.Add(this.BTN_Signup);
            this.Controls.Add(this.BTN_JoinRoom);
            this.Controls.Add(this.BTN_CreateRoom);
            this.Controls.Add(this.BTN_MyStatus);
            this.Controls.Add(this.BTN_BestScores);
            this.Controls.Add(this.BTN_Quit);
            this.Name = "main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PNL_LAYER.ResumeLayout(false);
            this.PNL_LAYER.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Quit;
        private System.Windows.Forms.Button BTN_BestScores;
        private System.Windows.Forms.Button BTN_MyStatus;
        private System.Windows.Forms.Button BTN_CreateRoom;
        private System.Windows.Forms.Button BTN_JoinRoom;
        private System.Windows.Forms.Button BTN_Signup;
        private System.Windows.Forms.Panel PNL_LAYER;
        private System.Windows.Forms.Button BTN_SignIn;
        private System.Windows.Forms.Label LBL_Password;
        private System.Windows.Forms.Label LBL_Username;
        private System.Windows.Forms.TextBox TXT_Username;
        private System.Windows.Forms.TextBox TXT_Password;
    }
}

