using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T1_Videos_Audios_Images
{
    public partial class frmMain : Form
    {
        private frmMain()
        {
            InitializeComponent();
        }

        private static frmMain main = null;

        public static frmMain Main
        {
            get
            {
                if (main == null)
                {
                    main = new frmMain();
                }
                return main;
            }
        }
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            frmVideos.Videos.MdiParent = this;
            frmAudios.Audios.MdiParent = this;
            frmImages.Images.MdiParent = this;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            main = null;
        }
        
        private void btnVideos_Click(object sender, EventArgs e)
        {
            frmVideos.Videos.Show();
        }

        private void btnAudios_Click(object sender, EventArgs e)
        {
            frmAudios.Audios.Show();
        }

        private void btnImages_Click(object sender, EventArgs e)
        {
            frmImages.Images.Show();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 2.0\nFolder: Kukushka\nCreated: 06/04/2019\n" +
                "\nProblems:\n+ menuTrim - frmVideos - mode ss: Can tang FPS cho video trim thu 2" +
                "\n+ menuGetInfo - All Form: chua lay dc thong tin videos, audios, images ma moi chi viet dc file txtInfo luu thong tin." +
                " Lam vc vs class myThread vs myFile", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
