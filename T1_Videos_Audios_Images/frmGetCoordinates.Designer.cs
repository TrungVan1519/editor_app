namespace T1_Videos_Audios_Images
{
    partial class frmGetCoordinates
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
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lbY = new System.Windows.Forms.Label();
            this.lbX = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtY
            // 
            this.txtY.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtY.Location = new System.Drawing.Point(91, 147);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(60, 20);
            this.txtY.TabIndex = 32;
            this.txtY.Click += new System.EventHandler(this.txtYVideos_Click);
            this.txtY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYVideos_KeyPress);
            // 
            // txtX
            // 
            this.txtX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtX.Location = new System.Drawing.Point(91, 106);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(60, 20);
            this.txtX.TabIndex = 31;
            this.txtX.Click += new System.EventHandler(this.txtXVideos_Click);
            this.txtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXVideos_KeyPress);
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Location = new System.Drawing.Point(91, 65);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(140, 20);
            this.txtHeight.TabIndex = 30;
            this.txtHeight.Click += new System.EventHandler(this.txtHeightVideos_Click);
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeightVideos_KeyPress);
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.Location = new System.Drawing.Point(91, 24);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(140, 20);
            this.txtWidth.TabIndex = 29;
            this.txtWidth.Click += new System.EventHandler(this.txtWidthVideos_Click);
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWidthVideos_KeyPress);
            // 
            // lbY
            // 
            this.lbY.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbY.AutoSize = true;
            this.lbY.Location = new System.Drawing.Point(27, 150);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(14, 13);
            this.lbY.TabIndex = 28;
            this.lbY.Text = "Y";
            // 
            // lbX
            // 
            this.lbX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(27, 109);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(14, 13);
            this.lbX.TabIndex = 27;
            this.lbX.Text = "X";
            // 
            // lbHeight
            // 
            this.lbHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(27, 68);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(38, 13);
            this.lbHeight.TabIndex = 26;
            this.lbHeight.Text = "Height";
            // 
            // lbWidth
            // 
            this.lbWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(27, 27);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(35, 13);
            this.lbWidth.TabIndex = 25;
            this.lbWidth.Text = "Width";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(177, 176);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmGetCoordinates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 211);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lbY);
            this.Controls.Add(this.lbX);
            this.Controls.Add(this.lbHeight);
            this.Controls.Add(this.lbWidth);
            this.Name = "frmGetCoordinates";
            this.Text = "Get coordinates";
            this.Load += new System.EventHandler(this.frmGetCoordinates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox txtY;
        public System.Windows.Forms.TextBox txtX;
        public System.Windows.Forms.TextBox txtHeight;
        public System.Windows.Forms.TextBox txtWidth;
    }
}