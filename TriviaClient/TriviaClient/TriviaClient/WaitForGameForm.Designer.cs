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
            this.LBL_ConnectedTo = new System.Windows.Forms.Label();
            this.LBL_ = new System.Windows.Forms.Label();
            this.PNL_LAYER.SuspendLayout();
            this.SuspendLayout();
            // 
            // PNL_LAYER
            // 
            this.PNL_LAYER.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PNL_LAYER.Controls.Add(this.LBL_);
            this.PNL_LAYER.Controls.Add(this.LBL_ConnectedTo);
            this.PNL_LAYER.Location = new System.Drawing.Point(12, 59);
            this.PNL_LAYER.Name = "PNL_LAYER";
            this.PNL_LAYER.Size = new System.Drawing.Size(857, 265);
            this.PNL_LAYER.TabIndex = 7;
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
            // LBL_
            // 
            this.LBL_.AutoSize = true;
            this.LBL_.Location = new System.Drawing.Point(34, 63);
            this.LBL_.Name = "LBL_";
            this.LBL_.Size = new System.Drawing.Size(35, 13);
            this.LBL_.TabIndex = 1;
            this.LBL_.Text = "label1";
            // 
            // WaitForGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(881, 414);
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
        private System.Windows.Forms.Label LBL_;
    }
}