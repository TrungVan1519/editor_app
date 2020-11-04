using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.RegularExpressions;

namespace T1_Videos_Audios_Images.Classes
{
    class MyFile
    {
        /// <summary>
        /// Lay ra duong dan de ghi ra 1 file txt txtInfo luu thong tin cua videos, audios, images
        /// Viec ghi file nay se dc thuc hien bang ffprobe ben menuGetInfo cua frmVideos, frmAudios, frmImages
        /// </summary>
        public Func<List<string>> getPath = () =>
        {
            // Luu duong dan va 1 option de danh dau 2 TH
            List<string> list = new List<string>();

            //// Cach 1: Nhanh hon vi chi can kiem tra file
            //// Neu duong dan da ton tai thi luu duong dan va danh dau = 1
            //if (File.Exists(@"C:\Users\Public\Kukushka\txtInfo.txt"))
            //{
            //    list.Add("1");
            //    list.Add(@"C:\Users\Public\Kukushka\txtInfo.txt");
            //}

            //// Neu duong dan chua ton tai thi phai tao ra duong dan va danh dau = 2
            //else
            //{
            //    // Truoc khi tao File phai tao Directory truoc
            //    Directory.CreateDirectory(@"C:\Users\Public\Kukushka\");
            //    File.Create(@"C:\Users\Public\Kukushka\txtInfo.txt");

            //    list.Add("2");
            //    list.Add(@"C:\Users\Public\Kukushka\txtInfo.txt");
            //}

            // cach 2: Tuong minh hon vi phan biet kiem tra Directory va File
            if (Directory.Exists(@"C:\Users\Public\Kukushka\"))
            {
                // Doi vs class File phai ghi ca DirectoryPath lan FileName thi moi chay dung, thieu bat ky cai j deu sai ca
                if (File.Exists(@"C:\Users\Public\Kukushka\txtInfo.txt"))
                {
                    list.Add("1");
                    list.Add(@"C:\Users\Public\Kukushka\txtInfo.txt");
                }
                else
                {
                    File.Create(@"C:\Users\Public\Kukushka\txtInfo.txt");
                    list.Add("1");
                    list.Add(@"C:\Users\Public\Kukushka\txtInfo.txt");
                }
            }
            else
            {
                // Truoc khi tao File phai tao Directory truoc
                Directory.CreateDirectory(@"C:\Users\Public\Kukushka\");
                File.Create(@"C:\Users\Public\Kukushka\txtInfo.txt");

                list.Add("2");
                list.Add(@"C:\Users\Public\Kukushka\txtInfo.txt");
            }

            return list;
        };

        /// <summary>
        /// Doc file txt txtInfo da luu va lay ra 1 so dong text can thiet
        /// </summary>
        public Func<string, string[]> getInfo = (pathTXTInfo) =>
        {
            // Dung de luu info videos or audios or images
            string[] arrStringInfo = null;

            // Lay ra dong text co chu "Duaration" trong file txtInfo
            Regex getLine = new Regex(@"Duration");

            // Tao doi tuong doc file txtInfo
            StreamReader reader = new StreamReader(pathTXTInfo);
            string line = reader.ReadLine();

            while (line != null)
            {
                // Neu gap chu "Duration" trong file thi dung luon va xu ly dong text do
                if (getLine.IsMatch(line))
                {
                    break;
                }

                // Khong gap thi cu doc tiep
                else
                {
                    line = reader.ReadLine();
                }
            }

            if (getLine.IsMatch(line))
            {
                // Lay thong tin
                Regex getInfo = new Regex(@"\,");
                arrStringInfo = getInfo.Split(line);
            }

            return arrStringInfo;
        };
    }
}
