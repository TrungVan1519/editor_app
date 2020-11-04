using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using T1_Videos_Audios_Images.Classes;
using System.Threading;

namespace T1_Videos_Audios_Images
{
    public partial class frmImages : Form
    {
        private frmImages()
        {
            InitializeComponent();
        }

        private static frmImages images = null;

        public static frmImages Images
        {
            get
            {
                if (images == null)
                {
                    images = new frmImages();
                }
                return images;
            }
        }

        // Khoi tao doi tuong chay cac tien trinh trong may tinh
        ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            CreateNoWindow = true,
            RedirectStandardError = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            WindowStyle = ProcessWindowStyle.Hidden
        };

        MyFile myFile = new MyFile();
        MyThread myThread = new MyThread();

        public int index = -1;

        /// <summary>
        /// frmImages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmImages_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = frmMain.Main;

            txtFileName.ReadOnly = true;
        }

        private void frmImages_FormClosing(object sender, FormClosingEventArgs e)
        {
            images = null;
        }

        /// <summary>
        /// menuEdit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuChangeResolution_Click(object sender, EventArgs e)
        {
            // index == 0
            index = ((ToolStripMenuItem)sender).Owner.Items.IndexOf((ToolStripMenuItem)sender);

            cbxSpecies.Items.Clear();
            cbxSpecies.Items.Add("[Default] Width:Height");
            cbxSpecies.Items.Add("[Auto Size] Width:-1");
            cbxSpecies.Items.Add("[Auto Size] -1:Height");

            if (!string.IsNullOrEmpty(cbxSpecies.Text))
            {
                // Trong cbxSpecies cbxSpecies.Text khong phai la 1 Items nen co the kiem tra Text vs cac Items cua no
                for (int i = 0; i < cbxSpecies.Items.Count; i++)
                {
                    if (cbxSpecies.Text == cbxSpecies.Items[i].ToString())
                    {
                        cbxSpecies.SelectedIndex = i;
                        break;
                    }
                    else if (cbxSpecies.Text != cbxSpecies.Items[i].ToString() && i == cbxSpecies.Items.Count - 1)
                    {
                        cbxSpecies.Text = "";
                    }
                }

                if (!string.IsNullOrEmpty(cbxSpecies.Text))
                {
                    using (OpenFileDialog open = new OpenFileDialog() { Filter = "(PNG file)|*.png|(JPG file)|*.jpg" })
                    {
                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            if (string.IsNullOrEmpty(open.FileName))
                            {
                                MessageBox.Show("Your path is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                txtFileName.Text = open.FileName;

                                using (frmGetCoordinates getCoordinates = new frmGetCoordinates())
                                {
                                    if (getCoordinates.ShowDialog() == DialogResult.OK)
                                    {
                                        using (SaveFileDialog save = new SaveFileDialog() { Filter = "(PNG file)|*.png|(JPG file)|*.jpg" })
                                        {
                                            if (save.ShowDialog() == DialogResult.OK)
                                            {

                                                processStartInfo.FileName = "ffmpeg";

                                                // -i input.mp4 -vf scale=320:240 -sws_flags bilinear output.mp4
                                                if (!string.IsNullOrEmpty(getCoordinates.txtWidth.Text) && !string.IsNullOrEmpty(getCoordinates.txtHeight.Text))
                                                {
                                                    processStartInfo.Arguments = "-i " + open.FileName + " -vf scale=" + getCoordinates.txtWidth.Text + ":" + getCoordinates.txtHeight.Text +
                                                            " -sws_flags bilinear " + save.FileName;
                                                }

                                                // -i input.mp4 -vf scale=320:-1 -sws_flags bilinear output.mp4
                                                else if (!string.IsNullOrEmpty(getCoordinates.txtWidth.Text) && string.IsNullOrEmpty(getCoordinates.txtHeight.Text))
                                                {
                                                    if(cbxSpecies.Text == cbxSpecies.Items[1].ToString())
                                                    {
                                                        processStartInfo.Arguments = "-i " + open.FileName + " -vf scale=" + getCoordinates.txtWidth.Text +
                                                            ":-1 -sws_flags bilinear " + save.FileName;
                                                    }
                                                }

                                                // -i input.mp4 -vf scale=-1:240 -sws_flags bilinear output.mp4
                                                else
                                                {
                                                    if(cbxSpecies.Text == cbxSpecies.Items[2].ToString())
                                                    {
                                                        processStartInfo.Arguments = "-i " + open.FileName + " -vf scale=-1:" + getCoordinates.txtHeight.Text +
                                                            " -sws_flags bicubic " + save.FileName;
                                                    }
                                                }
                                                txtFileName.Text = processStartInfo.Arguments;

                                                using (Process process = new Process() { StartInfo = processStartInfo })
                                                {
                                                    if (process.Start())
                                                    {
                                                        MessageBox.Show("Excuting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                txtFileName.Text = "Select scaling videos";
            }
        }

        private void menuCrop_Click(object sender, EventArgs e)
        {
            // index == 0
            index = ((ToolStripMenuItem)sender).Owner.Items.IndexOf((ToolStripMenuItem)sender);

            cbxSpecies.Items.Clear();
            cbxSpecies.Items.Add("[Default] Width:Height");
            cbxSpecies.Items.Add("[Advanced] Width:Height:X:Y");
            cbxSpecies.Items.Add("[Autosize X] Width:Height:-1:Y");
            cbxSpecies.Items.Add("[AutoSize Y] Width:Height:X:-1");

            if (!string.IsNullOrEmpty(cbxSpecies.Text))
            {
                // Trong cbxSpecies cbxSpecies.Text khong phai la 1 Items nen co the kiem tra Text vs cac Items cua no
                for (int i = 0; i < cbxSpecies.Items.Count; i++)
                {
                    if (cbxSpecies.Text == cbxSpecies.Items[i].ToString())
                    {
                        cbxSpecies.SelectedIndex = i;
                        break;
                    }
                    else if (cbxSpecies.Text != cbxSpecies.Items[i].ToString() && i == cbxSpecies.Items.Count - 1)
                    {
                        cbxSpecies.Text = "";
                    }
                }

                if (!string.IsNullOrEmpty(cbxSpecies.Text))
                {
                    using (OpenFileDialog open = new OpenFileDialog() { Filter = "(PNG file)|*.png|(JPG file)|*.jpg" })
                    {
                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            if (string.IsNullOrEmpty(open.FileName))
                            {
                                MessageBox.Show("Your path is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                txtFileName.Text = open.FileName;

                                using (frmGetCoordinates getCoordinates = new frmGetCoordinates())
                                {
                                    if (getCoordinates.ShowDialog() == DialogResult.OK)
                                    {
                                        using (SaveFileDialog save = new SaveFileDialog() { Filter = "(PNG file)|*.png|(JPG file)|*.jpg" })
                                        {
                                            if (save.ShowDialog() == DialogResult.OK)
                                            {
                                                // -i input.mp4 -vf  "crop=w:h:x:y" output.mp4
                                                // -i input.mp4 -vf crop=w:h:x:y output.mp4
                                                //      + w: chieu dai cua anh
                                                //      + h: chieu cao cua anh
                                                //      + x: toa do truc Ox khi cat anh ---> tu trai sang phai
                                                //      + y: toa do truc Oy khi cat anh \> tu tren xuong duoi
                                                //      + Neu nhu khong goi x, y chi co so lieu w, h thoi thi anh se tu dong duoc cat o phan trung tam

                                                /// ===> Tao ra 1 video moi la output.mp4 tu video cu la input.mp4 nhung co kich thuoc thi bi crop

                                                processStartInfo.FileName = "ffmpeg";

                                                if (!string.IsNullOrEmpty(getCoordinates.txtWidth.Text) && !string.IsNullOrEmpty(getCoordinates.txtHeight.Text))
                                                {
                                                    // -i input.mp4 -vf crop=w:h out.putmp4
                                                    if (string.IsNullOrEmpty(getCoordinates.txtX.Text) && string.IsNullOrEmpty(getCoordinates.txtY.Text))
                                                    {
                                                        processStartInfo.Arguments = "-i " + open.FileName +
                                                            " -vf crop=" + getCoordinates.txtWidth.Text + ":" + getCoordinates.txtHeight.Text + " " + save.FileName;
                                                    }

                                                    // -i input.mp4 -vf crop=w:h:x:y out.putmp4
                                                    else if (!string.IsNullOrEmpty(getCoordinates.txtX.Text) && !string.IsNullOrEmpty(getCoordinates.txtY.Text))
                                                    {
                                                        processStartInfo.Arguments = "-i " + open.FileName +
                                                            " -vf crop=" + getCoordinates.txtWidth.Text + ":" + getCoordinates.txtHeight.Text +
                                                            ":" + getCoordinates.txtX.Text + ":" + getCoordinates.txtY.Text + " " + save.FileName;
                                                    }

                                                    // -i input.mp4 -vf crop=w:h:-1:y out.putmp4
                                                    else if (string.IsNullOrEmpty(getCoordinates.txtX.Text) && !string.IsNullOrEmpty(getCoordinates.txtY.Text))
                                                    {
                                                        processStartInfo.Arguments = "-i " + open.FileName +
                                                            " -vf crop=" + getCoordinates.txtWidth.Text + ":" + getCoordinates.txtHeight.Text +
                                                            ":-1:" + getCoordinates.txtY.Text + " " + save.FileName;
                                                    }

                                                    // -i input.mp4 -vf crop=w:h:x:-1 out.putmp4
                                                    else if (!string.IsNullOrEmpty(getCoordinates.txtX.Text) && string.IsNullOrEmpty(getCoordinates.txtY.Text))
                                                    {
                                                        processStartInfo.Arguments = "-i " + open.FileName +
                                                        " -vf crop=" + getCoordinates.txtWidth.Text + ":" + getCoordinates.txtHeight.Text +
                                                        ":" + getCoordinates.txtX.Text + ":-1 " + save.FileName;
                                                    }

                                                    txtFileName.Text = processStartInfo.Arguments;

                                                    using (Process process = new Process() { StartInfo = processStartInfo })
                                                    {
                                                        if (process.Start())
                                                        {
                                                            MessageBox.Show("Excuting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            process.WaitForExit();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Your width or height value is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                txtFileName.Text = "Select mode cropping videos";
            }
        }

        private void menuGetInfo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog() { Filter = "(PNG file)|*.png|(JPG file)|*.jpg|(GIF file)|*.gif" })
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // Vi viec ghi file txt luu thong tin nay khong su dung dc processStartInfo.Argument 
                    // nen phai thay the bang cach chay cmd.exe va truyen han cau lenh day du thay vi chay ffprobe.exe va su dung processStartInfo.Argument
                    using (Process process = new Process() { StartInfo = processStartInfo })
                    {
                        // Kiem tra duong dan path cua txtInfo
                        List<string> path = myFile.getPath();
                        if (path.Count > 0)
                        {
                            process.StartInfo.FileName = "cmd.exe";
                            process.Start();

                            // Giai doan 1: Ghi file txtInfo
                            // ">" la cau lenh cua cmd, nghia la ghi de len file cu: Neu file da ton tai thi ghi de len de lam mat noi dung file cu
                            if (path[0] == "1")
                            {
                                process.StandardInput.WriteLine("ffprobe -i " + open.FileName + " > " + path[1] + " 2>&1");
                            }

                            // ">>" la cau lenh cua cmd, nghia la ghi tiep file cu: Neu file chua ton tai thi se dc tao va file la trong nen ghi tiep cho no vui
                            else if (path[0] == "2")
                            {
                                process.StandardInput.WriteLine("ffprobe -i " + open.FileName + " >> " + path[1] + " 2>&1");
                            }
                            process.StandardInput.Flush();

                            // Giai doan 2: Doc file txtInfo: 
                            //          + Ta phai su dung 1 thread moi boi thread chinh dang phai chay lenh cmd
                            //          + Neu nhu thread chua xu ly xong cau lenh cua cmd ma chay doc file txtInfo luon thi se bi loi
                            myThread.returnInfo(myFile, path);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// menuConvert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPNG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog() { Filter = "(JPG file)|*.jpg|(GIF file)|*.gif" })
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = open.FileName;

                    using (SaveFileDialog save = new SaveFileDialog() { Filter = "(PNG file)|*.png" })
                    {
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            processStartInfo.FileName = "ffmpeg";
                            processStartInfo.Arguments = "-i " + open.FileName + " " + save.FileName;

                            using (Process process = new Process() { StartInfo = processStartInfo })
                            {
                                if (process.Start())
                                {
                                    MessageBox.Show("Excuting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    process.WaitForExit();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void menuJPG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog() { Filter = "(PNG file)|*.png|(GIF file)|*.gif" })
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = open.FileName;

                    using (SaveFileDialog save = new SaveFileDialog() { Filter = "(JPG file)|*.jpg" })
                    {
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            processStartInfo.FileName = "ffmpeg";
                            processStartInfo.Arguments = "-i " + open.FileName + " " + save.FileName;

                            using (Process process = new Process() { StartInfo = processStartInfo })
                            {
                                if (process.Start())
                                {
                                    MessageBox.Show("Excuting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    process.WaitForExit();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void menuGIF_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog() { Filter = "(MP4 file)|*.mp4" })
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = open.FileName;

                    using (SaveFileDialog save = new SaveFileDialog() { Filter = "(GIF file)|*.gif" })
                    {
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            processStartInfo.FileName = "ffmpeg";
                            processStartInfo.Arguments = "-i " + open.FileName + " " + save.FileName;

                            using (Process process = new Process() { StartInfo = processStartInfo })
                            {
                                if (process.Start())
                                {
                                    MessageBox.Show("Excuting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    process.WaitForExit();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void menuMP4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog() { Filter = "(GIF file)|*.gif" })
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = open.FileName;

                    using (SaveFileDialog save = new SaveFileDialog() { Filter = "(MP4 file)|*.mp4" })
                    {
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            processStartInfo.FileName = "ffmpeg";
                            processStartInfo.Arguments = "-i " + open.FileName + " " + save.FileName;

                            using (Process process = new Process() { StartInfo = processStartInfo })
                            {
                                if (process.Start())
                                {
                                    MessageBox.Show("Excuting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    process.WaitForExit();
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
