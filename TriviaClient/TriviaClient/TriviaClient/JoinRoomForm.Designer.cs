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
            // 
            // JoinRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(881, 414);
            this.Controls.Add(this.BTN_Back);
            this.Name = "JoinRoomForm";
            this.Text = "JoinRoomForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Back;
    }
}