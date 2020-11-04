using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using T1_Videos_Audios_Images.Classes;
using System.Diagnostics;

namespace T1_Videos_Audios_Images.Classes
{
    class MyThread
    {
        public void returnInfo(MyFile myFile, List<string> path)
        {
            // Do trong multy thread ta chi co the truyen duy nhat 1 doi so cho ham chay thread khac va doi so do phai co kieu object
            // Vi vay ma ta phai boxing tat ca du lieu muon truyen di ve thanh 1 box kieu object
            // Sau khi ta truyen box do di roi thi muon su dung thi ta tiep tuc unboxing cac box object ma ta da truyen va su dung bihn thuong

            // Boxing
            object boxingObj = new Tuple<MyFile, List<string>>(myFile, path);
            
            Thread newThread = new Thread(getInfo);
            // Huy thread khi chay xong thread
            newThread.IsBackground = true;
            newThread.Start(boxingObj);
            newThread.Abort();
        }

        private void getInfo(object box)
        {
            // Unboxing: Ep kieu object cua box ve lai dung kieu du lieu cu truoc khi truyen de su dung
            Tuple<MyFile, List<string>> unboxingObj = box as Tuple<MyFile, List<string>>;
            
            // Doc file txtInfo bang doi tuong myFile da dc unboxing va lay ra thong tin
            string[] data = unboxingObj.Item1.getInfo(unboxingObj.Item2[1]);

            // Hien thi thong tin
            string tmp = "";
            foreach (var item in data)
            {
                tmp += item.Trim() + "\n";
            }
            MessageBox.Show(tmp);
        }

        public static void ff(List<string> path, string openFileName)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                RedirectStandardError = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            using (Process process = new Process() { StartInfo = processStartInfo })
            {
                // Kiem tra duong dan path cua txtInfo
                //List<string> path = myFile.getPath();
                if (path.Count > 0)
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.Start();

                    // Giai doan 1: Ghi file txtInfo
                    // ">" la cau lenh cua cmd, nghia la ghi de len file cu: Neu file da ton tai thi ghi de len de lam mat noi dung file cu
                    if (path[0] == "1")
                    {
                        process.StandardInput.WriteLine("ffprobe -i \"" + openFileName+ "\" > \"" + path[1] + "\" 2>&1");
                    }

                    // ">>" la cau lenh cua cmd, nghia la ghi tiep file cu: Neu file chua ton tai thi se dc tao va file la trong nen ghi tiep cho no vui
                    else if (path[0] == "2")
                    {
                        process.StandardInput.WriteLine("ffprobe -i \"" + openFileName + "\" >> \"" + path[1] + "\" 2>&1");
                    }
                    process.StandardInput.Flush();
                }
                process.WaitForExit();
            }
        }
    }
}
