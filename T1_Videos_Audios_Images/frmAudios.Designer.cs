namespace T1_Videos_Audios_Images
{
    partial class frmAudios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAudios));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPause = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuChangeSpeed = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxSpeed = new System.Windows.Forms.ToolStripComboBox();
            this.txtFileName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolIncreaseSpeed = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDecreaseSpeed = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuGetInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.axWindowsMediaPlayer);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(800, 398);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(800, 450);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(800, 429);
            this.axWindowsMediaPlayer.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.cbxSpeed,
            this.txtFileName});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 27);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStart,
            this.toolStripSeparator3,
            this.menuPause,
            this.toolStripSeparator1,
            this.menuStop,
            this.toolStripSeparator2,
            this.menuChangeSpeed,
            this.toolStripMenuItem1,
            this.menuGetInfo});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 23);
            this.menuFile.Text = "File";
            // 
            // menuStart
            // 
            this.menuStart.Name = "menuStart";
            this.menuStart.Size = new System.Drawing.Size(180, 22);
            this.menuStart.Text = "Start";
            this.menuStart.Click += new System.EventHandler(this.menuStart_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // menuPause
            // 
            this.menuPause.Name = "menuPause";
            this.menuPause.Size = new System.Drawing.Size(180, 22);
            this.menuPause.Text = "Pause";
            this.menuPause.Click += new System.EventHandler(this.menuPause_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuStop
            // 
            this.menuStop.Name = "menuStop";
            this.menuStop.Size = new System.Drawing.Size(180, 22);
            this.menuStop.Text = "Stop";
            this.menuStop.Click += new System.EventHandler(this.menuStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // menuChangeSpeed
            // 
            this.menuChangeSpeed.Name = "menuChangeSpeed";
            this.menuChangeSpeed.Size = new System.Drawing.Size(180, 22);
            this.menuChangeSpeed.Text = "Change Speed";
            this.menuChangeSpeed.Click += new System.EventHandler(this.menuChangeSpeed_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCut});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 23);
            this.menuEdit.Text = "Edit";
            // 
            // menuCut
            // 
            this.menuCut.Name = "menuCut";
            this.menuCut.Size = new System.Drawing.Size(133, 22);
            this.menuCut.Text = "Cut Audios";
            this.menuCut.Click += new System.EventHandler(this.menuCut_Click);
            // 
            // cbxSpeed
            // 
            this.cbxSpeed.Name = "cbxSpeed";
            this.cbxSpeed.Size = new System.Drawing.Size(121, 23);
            // 
            // txtFileName
            // 
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(300, 23);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStart,
            this.toolStripSeparator4,
            this.toolPause,
            this.toolStripSeparator5,
            this.toolStop,
            this.toolStripSeparator6,
            this.toolStripSeparator7,
            this.toolIncreaseSpeed,
            this.toolStripSeparator8,
            this.toolDecreaseSpeed});
            this.toolStrip.Location = new System.Drawing.Point(3, 27);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(157, 25);
            this.toolStrip.TabIndex = 1;
            // 
            // toolStart
            // 
            this.toolStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStart.Image")));
            this.toolStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStart.Name = "toolStart";
            this.toolStart.Size = new System.Drawing.Size(23, 22);
            this.toolStart.Text = "Start";
            this.toolStart.Click += new System.EventHandler(this.toolStart_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPause
            // 
            this.toolPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPause.Image = ((System.Drawing.Image)(resources.GetObject("toolPause.Image")));
            this.toolPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPause.Name = "toolPause";
            this.toolPause.Size = new System.Drawing.Size(23, 22);
            this.toolPause.Text = "Pause";
            this.toolPause.Click += new System.EventHandler(this.toolPause_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStop
            // 
            this.toolStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStop.Image")));
            this.toolStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStop.Name = "toolStop";
            this.toolStop.Size = new System.Drawing.Size(23, 22);
            this.toolStop.Text = "Stop";
            this.toolStop.Click += new System.EventHandler(this.toolStop_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolIncreaseSpeed
            // 
            this.toolIncreaseSpeed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolIncreaseSpeed.Image = ((System.Drawing.Image)(resources.GetObject("toolIncreaseSpeed.Image")));
            this.toolIncreaseSpeed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolIncreaseSpeed.Name = "toolIncreaseSpeed";
            this.toolIncreaseSpeed.Size = new System.Drawing.Size(23, 22);
            this.toolIncreaseSpeed.Text = "Increase Speed";
            this.toolIncreaseSpeed.Click += new System.EventHandler(this.toolSkipForward_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolDecreaseSpeed
            // 
            this.toolDecreaseSpeed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDecreaseSpeed.Image = ((System.Drawing.Image)(resources.GetObject("toolDecreaseSpeed.Image")));
            this.toolDecreaseSpeed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDecreaseSpeed.Name = "toolDecreaseSpeed";
            this.toolDecreaseSpeed.Size = new System.Drawing.Size(23, 22);
            this.toolDecreaseSpeed.Text = "Decrease Speed";
            this.toolDecreaseSpeed.Click += new System.EventHandler(this.toolSkipBackward_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuGetInfo
            // 
            this.menuGetInfo.Name = "menuGetInfo";
            this.menuGetInfo.Size = new System.Drawing.Size(180, 22);
            this.menuGetInfo.Text = "Get Info";
            this.menuGetInfo.Click += new System.EventHandler(this.menuGetInfo_Click);
            // 
            // frmAudios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripContainer);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmAudios";
            this.Text = "Audios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAudios_FormClosing);
            this.Load += new System.EventHandler(this.frmAudios_Load);
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem menuStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuChangeSpeed;
        private System.Windows.Forms.ToolStripMenuItem menuCut;
        private System.Windows.Forms.ToolStripButton toolStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolIncreaseSpeed;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolDecreaseSpeed;
        private System.Windows.Forms.ToolStripTextBox txtFileName;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        public System.Windows.Forms.ToolStripComboBox cbxSpeed;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuGetInfo;
    }
}