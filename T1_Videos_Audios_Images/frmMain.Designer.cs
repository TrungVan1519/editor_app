namespace T1_Videos_Audios_Images
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVideos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAudios = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImages = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVideos,
            this.toolStripSeparator2,
            this.btnAudios,
            this.toolStripSeparator3,
            this.btnImages,
            this.toolStripSeparator4,
            this.btnInfo});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(429, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // btnInfo
            // 
            this.btnInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(23, 22);
            this.btnInfo.Text = "Info";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnVideos
            // 
            this.btnVideos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVideos.Image = ((System.Drawing.Image)(resources.GetObject("btnVideos.Image")));
            this.btnVideos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVideos.Name = "btnVideos";
            this.btnVideos.Size = new System.Drawing.Size(23, 22);
            this.btnVideos.Text = "Videos";
            this.btnVideos.Click += new System.EventHandler(this.btnVideos_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAudios
            // 
            this.btnAudios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAudios.Image = ((System.Drawing.Image)(resources.GetObject("btnAudios.Image")));
            this.btnAudios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAudios.Name = "btnAudios";
            this.btnAudios.Size = new System.Drawing.Size(23, 22);
            this.btnAudios.Text = "Audios";
            this.btnAudios.Click += new System.EventHandler(this.btnAudios_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnImages
            // 
            this.btnImages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImages.Image = ((System.Drawing.Image)(resources.GetObject("btnImages.Image")));
            this.btnImages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImages.Name = "btnImages";
            this.btnImages.Size = new System.Drawing.Size(23, 22);
            this.btnImages.Text = "Images";
            this.btnImages.Click += new System.EventHandler(this.btnImages_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 259);
            this.Controls.Add(this.toolStrip);
            this.Name = "frmMain";
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnVideos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAudios;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnImages;
    }
}