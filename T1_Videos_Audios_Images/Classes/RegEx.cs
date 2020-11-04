using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using T1_Videos_Audios_Images.Classes;

namespace T1_Videos_Audios_Images.Classes
{
    class RegEx
    {
        /// <summary>
        /// Lay ra tu cbxResolution do phan giai cho videos: WidthXHeight
        /// Su dung trong menuChangeResolution
        /// </summary>
        public Func<string, string[]> getResolution = (resolution) =>
        {
            Regex getResolution = new Regex(@"\s+");
            string[] arrStringResult = getResolution.Split(resolution);
            return arrStringResult;
        };

        /// <summary>
        /// Lay ra durationTime de cat (cut) videos
        /// Su dung trong menuCut va menuTrim
        /// </summary>
        public Func<string, string, int> getTime = (startTime, endTime) =>
        {
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                int start = 0;
                int end = 0;
                int durationTime = 0;

                // Vs cac char binh thuong thi phai su dung them "\" vi "\" co tac dung bo di tinh dac biet cua char 
                // => chuong trinh se hieu chi la char binh thuong
                // VD o day la muon lay char ':' va char ':' nay la char binh thuong nen ta phai viet @"\:"
                Regex getTime = new Regex(@"\:");
                MatchCollection check2DotsStartTime = getTime.Matches(startTime);
                MatchCollection check2DotsEndTime = getTime.Matches(endTime);

                // Vs cac char dac biet thi duoc su dung "\" hay khong con tuy thuoc vao bang Regex
                // VD muon lay ra char ky tu thi phai viet @"\w+" nhung cung co the viet la @"[a-zA-Z0-9]+"
                Regex checkError = new Regex(@"[a-zA-Z]+|\s+");

                // Kiem tra xem string truyen vao co nhieu hon 2 dau ":" 
                // hoac co cac char dac biet hay khong (chi cho phep co <= 2 char dac biet ":" thoi)
                if (check2DotsStartTime.Count > 2 || check2DotsEndTime.Count > 2 || checkError.IsMatch(startTime) || checkError.IsMatch(endTime))
                {
                    throw new MyException("Your value is invalid");
                }
                else
                {
                    // Tach bo cac char ":" de lay so tinh time
                    string[] arrStringGetStartTime = getTime.Split(startTime);
                    string[] arrStringGetEndTime = getTime.Split(endTime);

                    // Tinh startTime
                    if (check2DotsStartTime.Count == 2)
                    {
                        start = int.Parse(arrStringGetStartTime[0]) * 3600 + int.Parse(arrStringGetStartTime[1]) * 60 + int.Parse(arrStringGetStartTime[2]);
                    }
                    else if (check2DotsStartTime.Count == 1)
                    {
                        start = int.Parse(arrStringGetStartTime[0]) * 60 + int.Parse(arrStringGetStartTime[1]);
                    }
                    else
                    {
                        start = int.Parse(arrStringGetStartTime[0]);
                    }

                    // Tinh endTime
                    if (check2DotsEndTime.Count == 2)
                    {
                        end = int.Parse(arrStringGetEndTime[0]) * 3600 + int.Parse(arrStringGetEndTime[1]) * 60 + int.Parse(arrStringGetEndTime[2]);
                    }
                    else if (check2DotsEndTime.Count == 1)
                    {
                        end = int.Parse(arrStringGetEndTime[0]) * 60 + int.Parse(arrStringGetEndTime[1]);
                    }
                    else
                    {
                        end = int.Parse(arrStringGetEndTime[0]);
                    }

                    // Phong truong hop user nhap nham thu tu startTime vs endTime
                    if (end > start)
                    {
                        durationTime = end - start;
                    }
                    else
                    {
                        durationTime = start - end;
                    }
                    return durationTime;
                }
            }
            else
            {
                throw new MyException("Your time is empty");
            }
        };

        /// <summary>
        /// Lay ra FileName cua SaveFileDialog ben frmVideos de doi thanh FileName1, FileName2
        /// Su dung trong menuTrim
        /// </summary>
        public Func<string, List<string>> getFileName = (saveFileName) =>
        {
            string varStringPath1 = "";
            string varStringPath2 = "";
            List<string> listResult = new List<string>();

            Regex getFileName = new Regex(@"\\");
            string[] arrStringPathAndFileName = getFileName.Split(saveFileName);

            Regex getName = new Regex(@"\.");
            string[] arrStringName = getName.Split(arrStringPathAndFileName[arrStringPathAndFileName.Length - 1]);

            for (int i = 0; i < arrStringPathAndFileName.Length; i++)
            {
                if (i == arrStringPathAndFileName.Length - 1)
                {
                    varStringPath1 += arrStringName[0] + "1.mp4";
                    varStringPath2 += arrStringName[0] + "2.mp4";
                }
                else
                {
                    varStringPath1 += arrStringPathAndFileName[i] + "\\";
                    varStringPath2 += arrStringPathAndFileName[i] + "\\";
                }
            }
            listResult.Add(varStringPath1);
            listResult.Add(varStringPath2);

            return listResult;
        };

        /// <summary>
        /// Chuc nang tuong tu nhu ham getFileName() o tren nhung su dung thuat toan de hon thay 1.mp4, 2.mp4 thanh %d.mp4
        /// Ham nay hay hon ham getFileName() nhung doi vs TH menuTrim thi bat buoc phai su dung ham getFileName()
        /// Con cac TH khac dien hinh nhu TH menuSplitVideo() thi su dung ham nay co loi ich hon rat nhieu 
        /// Su dung trong menuSplit
        /// </summary>
        public Func<string, string, string> getSplitFileName = (saveFileName, typeExtension) =>
        {
            string stringResult = "";

            Regex getFileName = new Regex(@"\\");
            string[] arrStringPathAndFileName = getFileName.Split(saveFileName);

            Regex getName = new Regex(@"\.");
            string[] arrStringName = getName.Split(arrStringPathAndFileName[arrStringPathAndFileName.Length - 1]);

            for (int i = 0; i < arrStringPathAndFileName.Length; i++)
            {
                if (i == arrStringPathAndFileName.Length - 1)
                {
                    // output%d.mp4 || output%d.png || output%d.jpg || output%d.gif
                    stringResult += arrStringName[0] + "%d." + typeExtension;
                }
                else
                {
                    stringResult += arrStringPathAndFileName[i] + "\\";
                }
            }

            return stringResult;
        };
    }
}
