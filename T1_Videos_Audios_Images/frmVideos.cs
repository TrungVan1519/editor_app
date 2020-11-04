using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using T1_Videos_Audios_Images.Classes;
using System.Threading;

namespace T1_Videos_Audios_Images
{
    public partial class frmVideos : Form
    {
        private frmVideos()
        {
            InitializeComponent();
        }

        static private frmVideos videos = null;

        static public frmVideos Videos
        {
            get
            {
                if (videos == null)
                {
                    videos = new frmVideos();
                }
                return videos;
            }
            private set { videos = value; }
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

        OpenFileDialog open = new OpenFileDialog() { Filter = "(mp4 file)|*.mp4" };
        SaveFileDialog save = new SaveFileDialog() { Filter = "(mp4 file)|*.mp4" };

        // Lay ra index cac menuItem (lay ra index cua menuCut va index cua menuTrim) de dc dung chung method btnOk trong frmGetTime
        public int index = -1;

        // Dung de lam flag kiem tra xem video co dang pause hay dang chay
        bool isPause = false;

        // Dung de lay rate cho axWindowsMediaPlayer
        double speed = 1.0;

        /// <summary>
        /// frmVideos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmVideos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = frmMain.Main;
            
            // txtFileName
            txtFileName.ReadOnly = true;
        }
        
        private void frmVideos_FormClosing(object sender, FormClosingEventArgs e)
        {
            videos = null;
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
            if (!string.IsNullOrEmpty(cbxSpecies.Text))
            {
                speed = double.Parse(cbxSpecies.Text);
            }

            // Kiem tra xem speed co nam trong khoang 0.5 den 2 hay khong de thay doi gia tri
            speed = speed < 2 ? speed += 0.5 : speed = 2;

            // Thay doi toc do play video theo speed
            cbxSpecies.Text = speed.ToString();
            axWindowsMediaPlayer.settings.rate = speed;
            axWindowsMediaPlayer.Ctlcontrols.play();
        }

        private void toolSkipBackward_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxSpecies.Text))
            {
                speed = double.Parse(cbxSpecies.Text);
            }

            // Kiem tra xem speed co nam trong khoang 0.5 den 2 hay khong de thay doi gia tri
            speed = speed > 0.5 ? speed -= 0.5 : speed = 0.5;

            // Thay doi toc do play video theo speed
            cbxSpecies.Text = speed.ToString();
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
            cbxSpecies.Items.Clear();
            cbxSpecies.Items.AddRange(new string[4] { "0.5", "1", "1.5", "2" });

            if (!string.IsNullOrEmpty(cbxSpecies.Text))
            {
                txtFileName.Text = open.FileName;

                // Thau doi toc do play video theo combobox
                axWindowsMediaPlayer.settings.rate = double.Parse(cbxSpecies.Text);
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
            else
            {
                txtFileName.Text = "Select speed";
            }
        }
        
        private void menuGetInfo_Click(object sender, EventArgs e)
        {
            List<string> path = myFile.getPath();
            ////Vi viec ghi file txt luu thong tin nay khong su dung dc processStartInfo.Argument
            ////nen phai thay the bang cach chay cmd.exe va truyen han cau lenh day du thay vi chay ffprobe.exe va su dung processStartInfo.Argument
            //using (Process process = new Process() { StartInfo = processStartInfo })
            //{
            //    // Kiem tra duong dan path cua txtInfo
            //    //List<string> path = myFile.getPath();
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
            //        txtFileName.Text = process.StandardOutput.ReadToEnd();
            //        //process.WaitForExit();
            //    }
            //}

            ////Giai doan 2: Doc file txtInfo:
            ////+Ta phai su dung 1 thread moi boi thread chinh dang phai chay lenh cmd
            ////          +Neu nhu thread chua xu ly xong cau lenh cua cmd ma chay doc file txtInfo luon thi se bi loi
            //myThread.returnInfo(myFile, path);
            /*
            object obj = new Tuple<MyFile, List<string>, string>(myFile, path, open.FileName);
            System.Threading.Thread thread = new System.Threading.Thread(run);
            thread.Start(obj);

            string[] data = myFile.getInfo(path[1]);
            string tmp = "";
            foreach (var item in data)
            {
                tmp += item.Trim() + "\n";
            }
            MessageBox.Show(tmp);
            */
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
        private void run(object box)
        {
           // Tuple<MyFile, List<string>, string> unbox = box as Tuple<MyFile, List<string>, string>;

           // myThread.ff(unbox.Item2, unbox.Item3);
          //  myThread.returnInfo(unbox.Item1, unbox.Item2);
        }

        /// <summary>
        /// menuEdit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuChangeResolution_Click(object sender, EventArgs e)
        {
            try
            {
                cbxSpecies.Items.Clear();
                cbxSpecies.Items.Add("1920 x 1080 (1080p)");
                cbxSpecies.Items.Add("1280 x 720 (720p)");
                cbxSpecies.Items.Add("640 x 480");
                cbxSpecies.Items.Add("640 x 360");

                if (string.IsNullOrEmpty(open.FileName))
                {
                    MessageBox.Show("Your path is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Trong cbxSpecies thi cbxSpecies.Text khong phai la 1 Items nen co the kiem tra Text vs cac Items cua no
                    for (int i = 0; i < cbxSpecies.Items.Count; i++)
                    {
                        if (cbxSpecies.Text == cbxSpecies.Items[i].ToString())
                        {
                            break;
                        }
                        else if (cbxSpecies.Text != cbxSpecies.Items[i].ToString() && i == cbxSpecies.Items.Count - 1)
                        {
                            cbxSpecies.Text = "";
                        }
                    }

                    if (!string.IsNullOrEmpty(cbxSpecies.Text))
                    {
                        txtFileName.Text = open.FileName;

                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            // Lay ra tu cbxResolution do phan giai cho video: WidthXHeight
                            string[] arrString = regex.getResolution(cbxSpecies.Text);

                            // -i input.mp4 -s 1280x720 -c:a copy output.mp4
                            // -i input.mp4 -vf scale=320:240 -sws_flags bilinear output.mp4

                            /// ===> Tao ra 1 video moi la output.mp4 tu video cu la input.mp4 nhung co do phan giai bi scale la 320:240
                            ///      va option -sws_flags cho phep lua chon thuat toan bilinear de scale video (neu khong chon thuat toan thi mac dinh su dung thuat toan bicubic)

                            // -i input.mp4 -vf "scale=320:240:force_original_aspect_ratio=decrease,pad=320:240:(ow-iw)/2:(oh-ih)/2" output.mp4

                            /// ===> Tao ra 1 video moi la output.mp4 tu video cu la input.mp4 nhung video moi co nhung dac diem sau:
                            ///         + Da bi scale thanh 320:240
                            ///         + video moi putput.mp4 se tu dong giam kich thuoc neu can thiet de phu hop vs khung hinh 320:240
                            ///         + Nhung khoang trong khi video output.mp4 giam kich thuoc se dc filter pad tu dong dien mau den vao

                            /// ====> Ket hop 2 TH tren ta se co 1 cau lenh day du hon nhu sau:
                            /// -i input.mp4 -vf "scale=320:240:force_original_aspect_ratio=decrease,pad=320:240:(ow-iw)/2:(oh-ih)/2" -sws_flags bilinear output.mp4
                            processStartInfo.FileName = "ffmpeg";
                            processStartInfo.Arguments = "-i " + open.FileName + " -s " + arrString[0] + arrString[1] + arrString[2] + " -c:a copy " + save.FileName;

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
                    else
                    {
                        txtFileName.Text = "Select resolution changing mode";
                    }
                }
            }
            catch (MyException myEx)
            {
                MessageBox.Show(myEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuCut_Click(object sender, EventArgs e)
        {
            try
            {
                // index == 2
                index = ((ToolStripMenuItem)sender).Owner.Items.IndexOf((ToolStripMenuItem)sender);

                cbxSpecies.Items.Clear();
                cbxSpecies.Items.Add("hh:mm:ss");
                cbxSpecies.Items.Add("ss");

                if (string.IsNullOrEmpty(open.FileName))
                {
                    MessageBox.Show("Your path is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Trong cbxSpecies cbxSpecies.Text khong phai la 1 Items nen co the kiem tra Text vs cac Items cua no
                    for (int i = 0; i < cbxSpecies.Items.Count; i++)
                    {
                        if (cbxSpecies.Text == cbxSpecies.Items[i].ToString())
                        {
                            break;
                        }
                        else if (cbxSpecies.Text != cbxSpecies.Items[i].ToString() && i == cbxSpecies.Items.Count - 1)
                        {
                            cbxSpecies.Text = "";
                        }
                    }

                    if (!string.IsNullOrEmpty(cbxSpecies.Text))
                    {
                        txtFileName.Text = open.FileName;

                        using (frmGetTime getTime = new frmGetTime())
                        {
                            // Do ta su dung 1 Form khac de tra ve gia tri durationTime nen phai de phong TH users khong an OK ma an huy
                            if (getTime.ShowDialog() == DialogResult.OK)
                            {
                                if (save.ShowDialog() == DialogResult.OK)
                                {
                                    // Lay ra startTime va durationTime cho Argument cua processStartInfo
                                    int startTime = 0;
                                    int durationTime = 0;

                                    // Mode hh:mm:ss
                                    if (cbxSpecies.Text == cbxSpecies.Items[0].ToString())
                                    {
                                        startTime = regex.getTime("0", getTime.txtTime1.Text);
                                        durationTime = regex.getTime(getTime.txtTime1.Text, getTime.txtTime2.Text);
                                    }
                                    // Mode ss
                                    else
                                    {
                                        startTime = 0;
                                        durationTime = int.Parse(getTime.txtTime1.Text);
                                    }

                                    // Cach 1:
                                    // -i input.mp4 -ss 00:00:03 -t 00:01:18 -async 1 output.mp4
                                    // -i input.mp4 -ss 00:00:03 -t 1:18 -async 1 output.mp4
                                    // -i input.mp4 -ss 00:00:03 -t 78 -async 1 output.mp4
                                    // --> 3 cau lenh tren deu giong nhau het

                                    // Cach 2:
                                    // -i movie.mp4 -ss 00:00:03 -t 00:00:08 -async 1 -strict -2 cut.mp4

                                    // cach 3: It dung hon
                                    // -i input.mp4 -t 50 output.mp4

                                    /// ===> Tao ra 1 video moi output.mp4 tu video cu input.mp4 nhung co timeStart tu 00:00:03 va keo dai trong durationTime = 78 giay
                                    processStartInfo.FileName = "ffmpeg";
                                    processStartInfo.Arguments = "-i " + open.FileName + " -ss " + startTime + " -t " + durationTime + " -async 1 " + save.FileName;
                                    // -i C:\Users\Admin\Desktop\abc.mp4 -ss 60 -t 60 -async 1 C:\Users\Admin\Desktop\testCutVideosHHMMSS.mp4
                                    // -i C:\Users\Admin\Desktop\abc.mp4 -ss 0 -t 40 -async 1 C:\Users\Admin\Desktop\testCutVideosSS.mp4

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
                    else
                    {
                        txtFileName.Text = "Select videos cutting mode";
                    }
                }
            }
            catch (MyException myEx)
            {
                MessageBox.Show(myEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuTrim_Click(object sender, EventArgs e)
        {
            try
            {
                // index == 4
                index = ((ToolStripMenuItem)sender).Owner.Items.IndexOf((ToolStripMenuItem)sender);

                cbxSpecies.Items.Clear();
                cbxSpecies.Items.Add("hh:mm:ss");
                cbxSpecies.Items.Add("ss");

                if (string.IsNullOrEmpty(open.FileName))
                {
                    MessageBox.Show("Your path is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Trong cbxSpecies cbxSpecies.Text khong phai la 1 Items nen co the kiem tra Text vs cac Items cua no
                    for (int i = 0; i < cbxSpecies.Items.Count; i++)
                    {
                        if (cbxSpecies.Text == cbxSpecies.Items[i].ToString())
                        {
                            break;
                        }
                        else if (cbxSpecies.Text != cbxSpecies.Items[i].ToString() && i == cbxSpecies.Items.Count - 1)
                        {
                            cbxSpecies.Text = "";
                        }
                    }

                    if (!string.IsNullOrEmpty(cbxSpecies.Text))
                    {
                        txtFileName.Text = open.FileName;

                        using (frmGetTime getTime = new frmGetTime())
                        {
                            if (getTime.ShowDialog() == DialogResult.OK)
                            {
                                if (save.ShowDialog() == DialogResult.OK)
                                {
                                    // Lay ra FileName cua SaveFileDialog va them so sau ten de dat ten 2 file moi
                                    List<string> listResult = regex.getFileName(save.FileName);

                                    // Lay ra startTime va durationTime cho Argument cua processStartInfo
                                    int durationTime = regex.getTime("0", getTime.txtTime1.Text);
                                    int startTime = 0;

                                    // Mode hh:mm:ss
                                    if (cbxSpecies.Text == cbxSpecies.Items[0].ToString())
                                    {
                                        startTime = regex.getTime("0", getTime.txtTime2.Text);
                                    }
                                    // Mode ss
                                    else
                                    {
                                        startTime = int.Parse(getTime.txtTime1.Text);
                                    }

                                    // -i input.mp4 -t 60 -c copy part1.mp4 -ss 00:01:30 -codec copy part2.mp4

                                    /// ===> Tao ra 2 video moi la part1.mp4 va part2.mp4 tu video cu la input.mp4, trong do:
                                    ///         video part1.mp4 se luon luon bat dau tu 00:00:00 va keo dai trong 60 giay
                                    ///         video part2.mp4 se luon luon bat dau tu 00:01:30 va keo dai den het video cu input.mp4
                                    processStartInfo.FileName = "ffmpeg";
                                    processStartInfo.Arguments = "-i " + open.FileName + " -t " + durationTime + " -c copy " + listResult[0] + " -ss " + startTime + " -codec copy " + listResult[1];

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
                    else
                    {
                        txtFileName.Text = "Select videos trimming mode";
                    }
                }
            }
            catch (MyException myEx)
            {
                MessageBox.Show(myEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuSplit_Click(object sender, EventArgs e)
        {
            try
            {
                // index == 6
                index = ((ToolStripMenuItem)sender).Owner.Items.IndexOf((ToolStripMenuItem)sender);

                cbxSpecies.Items.Clear();
                cbxSpecies.Items.Add("hh:mm:ss");
                cbxSpecies.Items.Add("ss");

                if (string.IsNullOrEmpty(open.FileName))
                {
                    MessageBox.Show("Your path is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Trong cbxSpecies cbxSpecies.Text khong phai la 1 Items nen co the kiem tra Text vs cac Items cua no
                    for (int i = 0; i < cbxSpecies.Items.Count; i++)
                    {
                        if (cbxSpecies.Text == cbxSpecies.Items[i].ToString())
                        {
                            break;
                        }
                        else if (cbxSpecies.Text != cbxSpecies.Items[i].ToString() && i == cbxSpecies.Items.Count - 1)
                        {
                            cbxSpecies.Text = "";
                        }
                    }

                    if (!string.IsNullOrEmpty(cbxSpecies.Text))
                    {
                        txtFileName.Text = open.FileName;

                        using (frmGetTime getTime = new frmGetTime())
                        {
                            if (getTime.ShowDialog() == DialogResult.OK)
                            {
                                //// Cach 1: Su dung FolderBrownser
                                //using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
                                //{
                                //    if (folderBrowser.ShowDialog() == DialogResult.OK)
                                //    {
                                //        int durationTime = 0;

                                //        if (cbxSpecies.Text == cbxSpecies.Items[0].ToString())
                                //        {
                                //            durationTime = regex.getTime("0", getTime.txtTime1.Text);
                                //        }
                                //        else
                                //        {
                                //            durationTime = int.Parse(getTime.txtTime1.Text);
                                //        }

                                //        // -i input.mp4 -c copy -f segment -segment_time 40 -reset_timestamps 1 %d.mp4
                                //        processStartInfo.FileName = "ffmpeg";
                                //        processStartInfo.Arguments = "-i " + open.FileName + " -c copy -f segment -segment_time " + durationTime + " -reset_timestamps 1 " + folderBrowser.SelectedPath + "\\0%d.mp4";

                                //        txtFileName.Text = processStartInfo.Arguments;

                                //        using (Process process = new Process() { StartInfo = processStartInfo })
                                //        {
                                //            if (process.Start())
                                //            {
                                //                MessageBox.Show("Excuting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //            }
                                //            process.Close();
                                //        }
                                //    }
                                //}

                                // Cach 2: Su dung SaveFileDialog
                                if (save.ShowDialog() == DialogResult.OK)
                                {
                                    string path = regex.getSplitFileName(save.FileName, "mp4");

                                    int durationTime = 0;
                                    if (cbxSpecies.Text == cbxSpecies.Items[0].ToString())
                                    {
                                        durationTime = regex.getTime("0", getTime.txtTime1.Text);
                                    }
                                    else
                                    {
                                        durationTime = int.Parse(getTime.txtTime1.Text);
                                    }

                                    // -i input.mp4 - c copy - f segment - segment_time 40 - reset_timestamps 1 %d.mp4

                                    /// ===> Tao ra N video la %d.mp4 tu video cu la input.mp4, trong do:
                                    ///         So luong N phu thuoc vao do dai goc cua video cu input.mp4 va do dai moi video moi va do dai moi video moi la 40 giay
                                    ///         %d co tac lam cho N video sau khi luu se co ten tu dong tang dan o vi tri %d la 1, 2, 3, ... N => cau lenh moi chay dc
                                    /*Neu tao ra N video ma ta chi luu 1, 2 video < N thi tat ca video se tu dong khong luu nua*/
                                    processStartInfo.FileName = "ffmpeg";
                                    processStartInfo.Arguments = "-i " + open.FileName + " -c copy -f segment -segment_time " + durationTime + " -reset_timestamps 1 " + path;

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
                    else
                    {
                        txtFileName.Text = "Select videos splitting mode";
                    }
                }
            }
            catch (MyException myEx)
            {
                MessageBox.Show(myEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuCrop_Click(object sender, EventArgs e)
        {
            try
            {
                // index == 8
                index = ((ToolStripMenuItem)sender).Owner.Items.IndexOf((ToolStripMenuItem)sender);

                cbxSpecies.Items.Clear();
                cbxSpecies.Items.Add("[Default] Width:Height");
                cbxSpecies.Items.Add("[Advanced] Width:Height:X:Y");
                cbxSpecies.Items.Add("[Autosize X] Width:Height:-1:Y");
                cbxSpecies.Items.Add("[AutoSize Y] Width:Height:X:-1");

                if (string.IsNullOrEmpty(open.FileName))
                {
                    MessageBox.Show("Your path is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Trong cbxSpecies cbxSpecies.Text khong phai la 1 Items nen co the kiem tra Text vs cac Items cua no
                    for (int i = 0; i < cbxSpecies.Items.Count; i++)
                    {
                        if (cbxSpecies.Text == cbxSpecies.Items[i].ToString())
                        {
                            break;
                        }
                        else if (cbxSpecies.Text != cbxSpecies.Items[i].ToString() && i == cbxSpecies.Items.Count - 1)
                        {
                            cbxSpecies.Text = "";
                        }
                    }

                    if (!string.IsNullOrEmpty(cbxSpecies.Text))
                    {
                        txtFileName.Text = open.FileName;

                        using (frmGetCoordinates getCoordinates = new frmGetCoordinates())
                        {
                            if (getCoordinates.ShowDialog() == DialogResult.OK)
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
                    else
                    {
                        txtFileName.Text = "Select videos cropping mode";
                    }
                }
            }
            catch (MyException myEx)
            {
                MessageBox.Show(myEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Scale videos thuc chat la thay doi resolution cua video va da dc code o ham menuChangeResolution roi
        //private void menuScale_Click(object sender, EventArgs e)
        //{
        //    // index == 10
        //    index = ((ToolStripMenuItem)sender).Owner.Items.IndexOf((ToolStripMenuItem)sender);

        //    cbxSpecies.Items.Clear();
        //    cbxSpecies.Items.Add("[Default] Width:Height");
        //    cbxSpecies.Items.Add("[Advanced] Width:-n");
        //    cbxSpecies.Items.Add("[Advanced] -n:Height");
        //    cbxSpecies.Items.Add("[Auto Size] Width:-1");
        //    cbxSpecies.Items.Add("[Auto Size] -1:Height");

        //    if (string.IsNullOrEmpty(open.FileName))
        //    {
        //        MessageBox.Show("Your path is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    else
        //    {
        //        // Trong cbxSpecies cbxSpecies.Text khong phai la 1 Items nen co the kiem tra Text vs cac Items cua no
        //        for (int i = 0; i < cbxSpecies.Items.Count; i++)
        //        {
        //            if (cbxSpecies.Text == cbxSpecies.Items[i].ToString())
        //            {
        //                break;
        //            }
        //            else if (cbxSpecies.Text != cbxSpecies.Items[i].ToString() && i == cbxSpecies.Items.Count - 1)
        //            {
        //                cbxSpecies.Text = "";
        //            }
        //        }

        //        if (!string.IsNullOrEmpty(cbxSpecies.Text))
        //        {
        //            txtFileName.Text = open.FileName;

        //            using (frmGetWidthHeight getWidthHeight = new frmGetWidthHeight())
        //            {
        //                if (getWidthHeight.ShowDialog() == DialogResult.OK)
        //                {
        //                    if (save.ShowDialog() == DialogResult.OK)
        //                    {

        //                        processStartInfo.FileName = "ffmpeg";

        //                        // -i input.mp4 -vf scale=320:240 -sws_flags bilinear output.mp4
        //                        if (!string.IsNullOrEmpty(getWidthHeight.txtWidth.Text) && !string.IsNullOrEmpty(getWidthHeight.txtHeight.Text))
        //                        {
        //                            processStartInfo.Arguments = "-i " + open.FileName + " -vf scale=" + getWidthHeight.txtWidth.Text + ":" + getWidthHeight.txtHeight.Text +
        //                                    " -sws_flags " + getWidthHeight.cbxAlgorithms.Text + " " + save.FileName;
        //                        }

        //                        // -i input.mp4 -vf scale=320:-n -sws_flags bilinear output.mp4 || -i input.mp4 -vf scale=320:-1 -sws_flags bilinear output.mp4
        //                        else if (!string.IsNullOrEmpty(getWidthHeight.txtWidth.Text) && string.IsNullOrEmpty(getWidthHeight.txtHeight.Text))
        //                        {
        //                            // -i input.mp4 -vf scale=320:-n -sws_flags bilinear output.mp4
        //                            if (cbxSpecies.Text == cbxSpecies.Items[1].ToString())
        //                            {
        //                                processStartInfo.Arguments = "-i " + open.FileName + " -vf scale=" + getWidthHeight.txtWidth.Text + 
        //                                    ":-n -sws_flags " + getWidthHeight.cbxAlgorithms.Text + " " + save.FileName;
        //                            }

        //                            // -i input.mp4 -vf scale=320:-1 -sws_flags bilinear output.mp4
        //                            else
        //                            {
        //                                processStartInfo.Arguments = "-i " + open.FileName + " -vf scale=" + getWidthHeight.txtWidth.Text + 
        //                                    ":-1 -sws_flags " + getWidthHeight.cbxAlgorithms.Text + " " + save.FileName;
        //                            }
        //                        }

        //                        // -i input.mp4 -vf scale=-n:240 -sws_flags bilinear output.mp4 || -i input.mp4 -vf scale=-1:240 -sws_flags bilinear output.mp4
        //                        else
        //                        {
        //                            // -i input.mp4 -vf scale=-n:240 -sws_flags bilinear output.mp4
        //                            if (cbxSpecies.Text == cbxSpecies.Items[2].ToString())
        //                            {
        //                                processStartInfo.Arguments = "-i " + open.FileName + " -vf scale=-n:" + getWidthHeight.txtHeight.Text +
        //                                    " -sws_flags " + getWidthHeight.cbxAlgorithms.Text + " " + save.FileName;
        //                            }

        //                            // -i input.mp4 - vf scale = -1:240 - sws_flags bilinear output.mp4
        //                            else
        //                            {
        //                                processStartInfo.Arguments = "-i " + open.FileName + " -vf scale=-1:" + getWidthHeight.txtHeight.Text +
        //                                    " -sws_flags " + getWidthHeight.cbxAlgorithms.Text + " " + save.FileName;
        //                            }
        //                        }
        //                        txtFileName.Text = processStartInfo.Arguments;

        //                        using (Process process = new Process() { StartInfo = processStartInfo })
        //                        {
        //                            if (process.Start())
        //                            {
        //                                MessageBox.Show("Excuting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            txtFileName.Text = "Select algorithm to scale videos";
        //        }
        //    }
        //}

        /// <summary>
        /// menuConvert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuToAudios_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveAudio = new SaveFileDialog() { Filter = "(mp3 file)|*.mp3" })
            {
                if (saveAudio.ShowDialog() == DialogResult.OK)
                {
                    // -i input.mp4 output.mp3
                    processStartInfo.FileName = "ffmpeg";
                    processStartInfo.Arguments = "-i " + open.FileName + " " + saveAudio.FileName;

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

        private void menuToPNG_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog savePNG = new SaveFileDialog() { Filter = "(png file)|*.png" })
            {
                if (savePNG.ShowDialog() == DialogResult.OK)
                {
                    string fileName = regex.getSplitFileName(savePNG.FileName, "png");

                    // -i input.mp4 output%d.png
                    processStartInfo.FileName = "ffmpeg";
                    processStartInfo.Arguments = "-i " + open.FileName + " " + fileName;

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

        private void menuToJPG_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveJPG = new SaveFileDialog() { Filter = "(jpg file)|*.jpg" })
            {
                if (saveJPG.ShowDialog() == DialogResult.OK)
                {
                    string fileName = regex.getSplitFileName(saveJPG.FileName, "jpg");

                    // -i input.mp4 output%d.jpg
                    processStartInfo.FileName = "ffmpeg";
                    processStartInfo.Arguments = "-i " + open.FileName + " " + fileName;

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

        private void menuToGIF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveJPG = new SaveFileDialog() { Filter = "(gif file)|*.gif" })
            {
                if (saveJPG.ShowDialog() == DialogResult.OK)
                {
                    // -i input.mp4 output.gif
                    processStartInfo.FileName = "ffmpeg";
                    processStartInfo.Arguments = "-i " + open.FileName + " " + saveJPG.FileName;

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
