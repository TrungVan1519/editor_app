namespace T1_Videos_Audios_Images
{
    partial class frmImages
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangeResolution = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCrop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuGetInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPNG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuJPG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuGIF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMP4 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFileName = new System.Windows.Forms.ToolStripTextBox();
            this.cbxSpecies = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuConvert,
            this.cbxSpecies,
            this.txtFileName});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 27);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChangeResolution,
            this.toolStripMenuItem1,
            this.menuCrop,
            this.toolStripMenuItem5,
            this.menuGetInfo});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 23);
            this.menuEdit.Text = "Edit";
            // 
            // menuChangeResolution
            // 
            this.menuChangeResolution.Name = "menuChangeResolution";
            this.menuChangeResolution.Size = new System.Drawing.Size(174, 22);
            this.menuChangeResolution.Text = "Change Resolution";
            this.menuChangeResolution.Click += new System.EventHandler(this.menuChangeResolution_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 6);
            // 
            // menuCrop
            // 
            this.menuCrop.Name = "menuCrop";
            this.menuCrop.Size = new System.Drawing.Size(174, 22);
            this.menuCrop.Text = "Crop Images";
            this.menuCrop.Click += new System.EventHandler(this.menuCrop_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(171, 6);
            // 
            // menuGetInfo
            // 
            this.menuGetInfo.Name = "menuGetInfo";
            this.menuGetInfo.Size = new System.Drawing.Size(174, 22);
            this.menuGetInfo.Text = "Get Info";
            this.menuGetInfo.Click += new System.EventHandler(this.menuGetInfo_Click);
            // 
            // menuConvert
            // 
            this.menuConvert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPNG,
            this.toolStripMenuItem2,
            this.menuJPG,
            this.toolStripMenuItem3,
            this.menuGIF,
            this.toolStripMenuItem4,
            this.menuMP4});
            this.menuConvert.Name = "menuConvert";
            this.menuConvert.Size = new System.Drawing.Size(61, 23);
            this.menuConvert.Text = "Convert";
            // 
            // menuPNG
            // 
            this.menuPNG.Name = "menuPNG";
            this.menuPNG.Size = new System.Drawing.Size(101, 22);
            this.menuPNG.Text = ".png";
            this.menuPNG.Click += new System.EventHandler(this.menuPNG_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(98, 6);
            // 
            // menuJPG
            // 
            this.menuJPG.Name = "menuJPG";
            this.menuJPG.Size = new System.Drawing.Size(101, 22);
            this.menuJPG.Text = ".jpg";
            this.menuJPG.Click += new System.EventHandler(this.menuJPG_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(98, 6);
            // 
            // menuGIF
            // 
            this.menuGIF.Name = "menuGIF";
            this.menuGIF.Size = new System.Drawing.Size(101, 22);
            this.menuGIF.Text = ".gif";
            this.menuGIF.Click += new System.EventHandler(this.menuGIF_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(98, 6);
            // 
            // menuMP4
            // 
            this.menuMP4.Name = "menuMP4";
            this.menuMP4.Size = new System.Drawing.Size(101, 22);
            this.menuMP4.Text = ".mp4";
            this.menuMP4.Click += new System.EventHandler(this.menuMP4_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(300, 23);
            // 
            // cbxSpecies
            // 
            this.cbxSpecies.Name = "cbxSpecies";
            this.cbxSpecies.Size = new System.Drawing.Size(180, 23);
            // 
            // frmImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmImages";
            this.Text = "Images";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImages_FormClosing);
            this.Load += new System.EventHandler(this.frmImages_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuChangeResolution;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuCrop;
        private System.Windows.Forms.ToolStripMenuItem menuConvert;
        private System.Windows.Forms.ToolStripMenuItem menuPNG;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuJPG;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuGIF;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuMP4;
        private System.Windows.Forms.ToolStripTextBox txtFileName;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuGetInfo;
        public System.Windows.Forms.ToolStripComboBox cbxSpecies;
    }
}