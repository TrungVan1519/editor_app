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

namespace T1_Videos_Audios_Images
{
    public partial class frmAudios : Form
    {
        private frmAudios()
        {
            InitializeComponent();
        }

        private static frmAudios audios = null;

        public static frmAudios Audios
        {
            get
            {
                if (audios == null)
                {
                    audios = new frmAudios();
                }
                return audios;
            }
        }

        // Xu ly tat ca nhung gi lien quan den xu ly string
        RegEx regex = new RegEx();

        // Cu ly tat ca van de lien quan den file
        MyFile myFile = new MyFile();

        // Xu ly tat ca van de lien quan den thread
        MyThread myThread = new MyThread();

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

        OpenFileDialog open = new OpenFileDialog() { Filter = "(mp3 file)|*.mp3" };

        private bool isPause = false;

        private double speed = 1.0;

        /// <summary>
        /// frmAudios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAudios_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = frmMain.Main;

            // txtFileName
            txtFileName.ReadOnly = true;
        }

        private void frmAudios_FormClosing(object sender, FormClosingEventArgs e)
        {
            audios = null;
        }

        /// <summary>
        /// toolStrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStart_Click(object sender, EventArgs e)
        {
            menuStart.PerformClick();
        }

        private void toolPause_Click(object sender, EventArgs e)
        {
            menuPause.PerformClick();
        }

        private void toolStop_Click(object sender, EventArgs e)
        {
            menuStop.PerformClick();
        }

        private void toolSkipForward_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxSpeed.Text))
            {
                speed = double.Parse(cbxSpeed.Text);
            }

            // Kiem tra xem speed co nam trong khoang 0.5 den 2 hay khong de thay doi gia tri
            speed = speed < 2 ? speed += 0.5 : speed = 2;

            // Thay doi toc do play video theo speed
            cbxSpeed.Text = speed.ToString();
            axWindowsMediaPlayer.settings.rate = speed;
            axWindowsMediaPlayer.Ctlcontrols.play();
        }

        private void toolSkipBackward_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxSpeed.Text))
            {
                speed = double.Parse(cbxSpeed.Text);
            }

            // Kiem tra xem speed co nam trong khoang 0.5 den 2 hay khong de thay doi gia tri
            speed = speed > 0.5 ? speed -= 0.5 : speed = 0.5;

            // Thay doi toc do play video theo speed
            cbxSpeed.Text = speed.ToString();
            axWindowsMediaPlayer.settings.rate = speed;
            axWindowsMediaPlayer.Ctlcontrols.play();
        }

        /// <summary>
        /// menuFile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStart_Click(object sender, EventArgs e)
        {
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = open.FileName;

                axWindowsMediaPlayer.URL = open.FileName;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
        }

        private void menuPause_Click(object sender, EventArgs e)
        {
            if (!isPause)
            {
                isPause = true;
                axWindowsMediaPlayer.Ctlcontrols.pause();
            }
            else
            {
                isPause = false;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
        }

        private void menuStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.stop();
        }

        private void menuChangeSpeed_Click(object sender, EventArgs e)
        {
            cbxSpeed.Items.Clear();
            cbxSpeed.Items.AddRange(new string[4] { "0.5", "1", "1.5", "2" });

            if (!string.IsNullOrEmpty(cbxSpeed.Text))
            {
                txtFileName.Text = open.FileName;

                // Thau doi toc do play video theo combobox
                axWindowsMediaPlayer.settings.rate = double.Parse(cbxSpeed.Text);
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
            else
            {
                txtFileName.Text = "Select speed";
            }
        }
        
        private void menuGetInfo_Click(object sender, EventArgs e)
        {
            //// Vi viec ghi file txt luu thong tin nay khong su dung dc processStartInfo.Argument 
            //// nen phai thay the bang cach chay cmd.exe va truyen han cau lenh day du thay vi chay ffprobe.exe va su dung processStartInfo.Argument
            //using (Process process = new Process() { StartInfo = processStartInfo })
            //{
            //    // Kiem tra duong dan path cua txtInfo
            //    List<string> path = myFile.getPath();
            //    if (path.Count > 0)
            //    {
            //        process.StartInfo.FileName = "cmd.exe";
            //        process.Start();

            //        // Giai doan 1: Ghi file txtInfo
            //        // ">" la cau lenh cua cmd, nghia la ghi de len file cu: Neu file da ton tai thi ghi de len de lam mat noi dung file cu
            //        if (path[0] == "1")
            //        {
            //            process.StandardInput.WriteLine("ffprobe -i " + open.FileName + " > " + path[1] + " 2>&1");
            //        }

            //        // ">>" la cau lenh cua cmd, nghia la ghi tiep file cu: Neu file chua ton tai thi se dc tao va file la trong nen ghi tiep cho no vui
            //        else if (path[0] == "2")
            //        {
            //            process.StandardInput.WriteLine("ffprobe -i " + open.FileName + " >> " + path[1] + " 2>&1");
            //        }
            //        process.StandardInput.Flush();

            //        // Giai doan 2: Doc file txtInfo: 
            //        //          + Ta phai su dung 1 thread moi boi thread chinh dang phai chay lenh cmd
            //        //          + Neu nhu thread chua xu ly xong cau lenh cua cmd ma chay doc file txtInfo luon thi se bi loi
            //        //myThread.returnInfo(myFile, path);
            //    }
            //}
            List<string> path = myFile.getPath();
            Task.Run(() =>
            {
                MyThread.ff(path, open.FileName);

                string[] data = myFile.getInfo(path[1]);
                string tmp = "";
                foreach (var item in data)
                {
                    tmp += item.Trim() + "\n";
                }
                MessageBox.Show(tmp);
            });
        }

        /// <summary>
        /// menuEdit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCut_Click(object sender, EventArgs e)
        {
            using (frmGetTime getTime = new frmGetTime())
            {
                if (getTime.ShowDialog() == DialogResult.OK)
                {
                    using (SaveFileDialog save = new SaveFileDialog() { Filter = "(mp3 file)|*.mp3" })
                    {
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            // Lay ra startTime va durationTime cho Argument cua processStartInfo
                            int startTime = 0;
                            int durationTime = 0;

                            cbxSpeed.Text = "hh:mm:ss";

                            // Mode hh:mm:ss
                            startTime = regex.getTime("0", getTime.txtTime1.Text);
                            durationTime = regex.getTime(getTime.txtTime1.Text, getTime.txtTime2.Text);

                            // -i input.mp3 -ss 00:03:00 -t 60 -c copy output.mp3
                            // -i input.mp3 -ss 3:00 -t 60 -c copy output.mp3
                            // -i input.mp3 -ss 180 -t 60 -c copy output.mp3
                            processStartInfo.FileName = "ffmpeg";
                            processStartInfo.Arguments = "-i " + open.FileName + " -ss " + startTime + " -t " + durationTime + " " + save.FileName;

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
