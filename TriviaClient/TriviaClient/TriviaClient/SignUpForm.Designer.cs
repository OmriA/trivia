namespace TriviaClient
{
    partial class SignUpForm
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
            this.TXT_Email = new System.Windows.Forms.TextBox();
            this.TXT_Password = new System.Windows.Forms.TextBox();
            this.TXT_Username = new System.Windows.Forms.TextBox();
            this.LBL_Email = new System.Windows.Forms.Label();
            this.LBL_Password = new System.Windows.Forms.Label();
            this.LBL_Username = new System.Windows.Forms.Label();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.BTN_Signup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.TXT_Email);
            this.panel1.Controls.Add(this.TXT_Password);
            this.panel1.Controls.Add(this.TXT_Username);
            this.panel1.Controls.Add(this.LBL_Email);
            this.panel1.Controls.Add(this.LBL_Password);
            this.panel1.Controls.Add(this.LBL_Username);
            this.panel1.Location = new System.Drawing.Point(189, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 210);
            this.panel1.TabIndex = 0;
            // 
            // TXT_Email
            // 
            this.TXT_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Email.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TXT_Email.Location = new System.Drawing.Point(158, 140);
            this.TXT_Email.Name = "TXT_Email";
            this.TXT_Email.Size = new System.Drawing.Size(316, 32);
            this.TXT_Email.TabIndex = 19;
            this.TXT_Email.Text = "Enter email here";
            this.TXT_Email.Enter += new System.EventHandler(this.TXT_Email_Enter);
            this.TXT_Email.Leave += new System.EventHandler(this.TXT_Email_Leave);
            // 
            // TXT_Password
            // 
            this.TXT_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Password.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TXT_Password.Location = new System.Drawing.Point(158, 86);
            this.TXT_Password.Name = "TXT_Password";
            this.TXT_Password.Size = new System.Drawing.Size(316, 32);
            this.TXT_Password.TabIndex = 18;
            this.TXT_Password.Text = "Enter password here";
            this.TXT_Password.Enter += new System.EventHandler(this.TXT_Password_Enter);
            this.TXT_Password.Leave += new System.EventHandler(this.TXT_Password_Leave);
            // 
            // TXT_Username
            // 
            this.TXT_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Username.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TXT_Username.Location = new System.Drawing.Point(158, 31);
            this.TXT_Username.Name = "TXT_Username";
            this.TXT_Username.Size = new System.Drawing.Size(316, 32);
            this.TXT_Username.TabIndex = 17;
            this.TXT_Username.Text = "Enter username here";
            this.TXT_Username.Enter += new System.EventHandler(this.TXT_Username_Enter);
            this.TXT_Username.Leave += new System.EventHandler(this.TXT_Username_Leave);
            // 
            // LBL_Email
            // 
            this.LBL_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Email.Location = new System.Drawing.Point(30, 144);
            this.LBL_Email.Name = "LBL_Email";
            this.LBL_Email.Size = new System.Drawing.Size(73, 28);
            this.LBL_Email.TabIndex = 16;
            this.LBL_Email.Text = "Email:";
            this.LBL_Email.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Password
            // 
            this.LBL_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Password.Location = new System.Drawing.Point(30, 87);
            this.LBL_Password.Name = "LBL_Password";
            this.LBL_Password.Size = new System.Drawing.Size(116, 28);
            this.LBL_Password.TabIndex = 15;
            this.LBL_Password.Text = "Password:";
            this.LBL_Password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Username
            // 
            this.LBL_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Username.Location = new System.Drawing.Point(30, 31);
            this.LBL_Username.Name = "LBL_Username";
            this.LBL_Username.Size = new System.Drawing.Size(122, 28);
            this.LBL_Username.TabIndex = 14;
            this.LBL_Username.Text = "Username:";
            this.LBL_Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_Back
            // 
            this.BTN_Back.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTN_Back.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Back.Location = new System.Drawing.Point(783, 12);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(86, 33);
            this.BTN_Back.TabIndex = 1;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // BTN_Signup
            // 
            this.BTN_Signup.BackColor = System.Drawing.SystemColors.WindowText;
            this.BTN_Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Signup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_Signup.Location = new System.Drawing.Point(340, 300);
            this.BTN_Signup.Name = "BTN_Signup";
            this.BTN_Signup.Size = new System.Drawing.Size(210, 69);
            this.BTN_Signup.TabIndex = 6;
            this.BTN_Signup.Text = "Sign Up";
            this.BTN_Signup.UseVisualStyleBackColor = false;
            this.BTN_Signup.Click += new System.EventHandler(this.BTN_Signup_Click);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(881, 414);
            this.Controls.Add(this.BTN_Signup);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.panel1);
            this.Name = "SignUpForm";
            this.Text = "SignUpForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.Button BTN_Signup;
        private System.Windows.Forms.Label LBL_Username;
        private System.Windows.Forms.Label LBL_Password;
        private System.Windows.Forms.Label LBL_Email;
        private System.Windows.Forms.TextBox TXT_Email;
        private System.Windows.Forms.TextBox TXT_Password;
        private System.Windows.Forms.TextBox TXT_Username;
    }
}