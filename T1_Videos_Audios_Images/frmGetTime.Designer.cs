namespace T1_Videos_Audios_Images
{
    partial class frmGetTime
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
            this.txtTime1 = new System.Windows.Forms.TextBox();
            this.lbTime1 = new System.Windows.Forms.Label();
            this.txtTime2 = new System.Windows.Forms.TextBox();
            this.lbTime2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTime1
            // 
            this.txtTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime1.Location = new System.Drawing.Point(96, 27);
            this.txtTime1.Name = "txtTime1";
            this.txtTime1.Size = new System.Drawing.Size(140, 20);
            this.txtTime1.TabIndex = 0;
            this.txtTime1.Click += new System.EventHandler(this.txtTime1_Click);
            this.txtTime1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime1_KeyPress);
            // 
            // lbTime1
            // 
            this.lbTime1.AutoSize = true;
            this.lbTime1.Location = new System.Drawing.Point(18, 30);
            this.lbTime1.Name = "lbTime1";
            this.lbTime1.Size = new System.Drawing.Size(55, 13);
            this.lbTime1.TabIndex = 1;
            this.lbTime1.Text = "Start Time";
            // 
            // txtTime2
            // 
            this.txtTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime2.Location = new System.Drawing.Point(96, 73);
            this.txtTime2.Name = "txtTime2";
            this.txtTime2.Size = new System.Drawing.Size(140, 20);
            this.txtTime2.TabIndex = 1;
            this.txtTime2.Click += new System.EventHandler(this.txtTime2_Click);
            this.txtTime2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime2_KeyPress);
            // 
            // lbTime2
            // 
            this.lbTime2.AutoSize = true;
            this.lbTime2.Location = new System.Drawing.Point(18, 76);
            this.lbTime2.Name = "lbTime2";
            this.lbTime2.Size = new System.Drawing.Size(52, 13);
            this.lbTime2.TabIndex = 1;
            this.lbTime2.Text = "End Time";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(177, 116);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmGetTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 151);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbTime2);
            this.Controls.Add(this.lbTime1);
            this.Controls.Add(this.txtTime2);
            this.Controls.Add(this.txtTime1);
            this.Name = "frmGetTime";
            this.Text = "Get time";
            this.Load += new System.EventHandler(this.frmGetTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox txtTime1;
        public System.Windows.Forms.TextBox txtTime2;
        public System.Windows.Forms.Label lbTime1;
        public System.Windows.Forms.Label lbTime2;
    }
}