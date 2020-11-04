using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using T1_Videos_Audios_Images.Classes;
using System.Text.RegularExpressions;

namespace T1_Videos_Audios_Images
{
    public partial class frmGetTime : Form
    {
        public frmGetTime()
        {
            InitializeComponent();
        }

        private void txtTime1_Click(object sender, EventArgs e)
        {
            txtTime1.Clear();
        }

        private void txtTime1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // frmVideos
            if (frmVideos.Videos.cbxSpecies.SelectedIndex != -1)
            {
                if (frmVideos.Videos.cbxSpecies.Text == frmVideos.Videos.cbxSpecies.Items[0].ToString())
                {
                    // Mode hh:mm:ss
                    // Cho phep nhap so va ky tu dac biet ":"
                    if (char.IsLetter(e.KeyChar) ||   //Ký tự Alphabe
                        char.IsWhiteSpace(e.KeyChar))       //Khoảng cách                 
                    {
                        e.Handled = true; //Không cho thể hiện lên TextBox
                    }
                }
                else
                {
                    // Mode ss
                    // Chi cho phep nhap so
                    if (char.IsLetter(e.KeyChar) ||    //Ký tự Alphabe
                        char.IsSymbol(e.KeyChar) ||    //Ký tự đặc biệt
                        char.IsWhiteSpace(e.KeyChar) ||    //Khoảng cách
                        char.IsPunctuation(e.KeyChar))      //Dấu chấm                
                    {
                        e.Handled = true; //Không cho thể hiện lên TextBox
                    }
                }
            }
            
            // frmAudios
            if (frmAudios.Audios.cbxSpeed.Text == "hh:mm:ss")
            {
                // Mode hh:mm:ss
                // Cho phep nhap so va ky tu dac biet ":"
                if (char.IsLetter(e.KeyChar) ||   //Ký tự Alphabe
                    char.IsWhiteSpace(e.KeyChar))       //Khoảng cách                 
                {
                    e.Handled = true; //Không cho thể hiện lên TextBox
                }
            }
        }

        private void txtTime2_Click(object sender, EventArgs e)
        {
            txtTime2.Clear();
        }

        private void txtTime2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // frmVideos
            if (frmVideos.Videos.cbxSpecies.SelectedIndex != -1)
            {
                if (frmVideos.Videos.cbxSpecies.Text == frmVideos.Videos.cbxSpecies.Items[0].ToString())
                {
                    // Mode hh:mm:ss
                    // Cho phep nhap so va ky tu dac biet ":"
                    if (char.IsLetter(e.KeyChar) ||         //Ký tự Alphabe
                        char.IsWhiteSpace(e.KeyChar))       //Khoảng cách            
                    {
                        e.Handled = true; //Không cho thể hiện lên TextBox
                    }
                }
                else
                {
                    // Mode ss
                    // Chi cho phep nhap so
                    if (char.IsLetter(e.KeyChar) ||     //Ký tự Alphabe
                        char.IsSymbol(e.KeyChar) ||     //Ký tự đặc biệt
                        char.IsWhiteSpace(e.KeyChar) ||     //Khoảng cách
                        char.IsPunctuation(e.KeyChar))      //Dấu chấm                
                    {
                        e.Handled = true; //Không cho thể hiện lên TextBox
                    }
                }
            }

            // frmAudios
            if (frmAudios.Audios.cbxSpeed.Text == "hh:mm:ss")
            {
                // Mode hh:mm:ss
                // Cho phep nhap so va ky tu dac biet ":"
                if (char.IsLetter(e.KeyChar) ||   //Ký tự Alphabe
                    char.IsWhiteSpace(e.KeyChar))       //Khoảng cách                 
                {
                    e.Handled = true; //Không cho thể hiện lên TextBox
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Vi frmGetTime.GetTime ta cho la ShowDialog() de lay gia DialogResult de biet xem users co bam OK hay khong
            DialogResult = DialogResult.OK;
        }
        
        private void frmGetTime_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.WindowsDefaultBounds;

            txtTime1.Clear();
            txtTime2.Clear();
            
            // frmVideos
            if (frmVideos.Videos.cbxSpecies.SelectedIndex != -1)
            {
                // Mode hh:mm:ss
                if (frmVideos.Videos.cbxSpecies.Text == frmVideos.Videos.cbxSpecies.Items[0].ToString())
                {
                    if (frmVideos.Videos.index == 4)
                    {
                        txtTime1.Size = new Size(120, 20);
                        txtTime1.Location = new Point(116, 27);

                        txtTime2.Size = new Size(120, 20);
                        txtTime2.Location = new Point(116, 73);

                        lbTime1.Text = "Video1's end time ";
                        lbTime2.Text = "Video2's start time ";
                        lbTime2.Visible = true;
                        txtTime2.Visible = true;

                        // Muon thay doi dc Point cua btnOK thi btnOK.Anchor khong dc phep = Right, Bottom
                        btnOK.Location = new Point(177, 116);

                        // Muon thay doi dc Size cua cac Control cung nhu Form thi phai khoi tao doi tuong moi new Size()
                        this.Size = new Size(280, 190);
                    }
                    else if (frmVideos.Videos.index == 6)
                    {
                        txtTime1.Size = new Size(110, 20);
                        txtTime1.Location = new Point(126, 67);

                        lbTime1.Text = "Each video's length";
                        lbTime2.Text = "End time";
                        lbTime2.Visible = false;
                        txtTime2.Visible = false;

                        // Muon thay doi dc Point cua btnOK thi btnOK.Anchor khong dc phep = Right, Bottom
                        btnOK.Location = new Point(177, 116 - 40);

                        // Muon thay doi dc Size cua cac Control cung nhu Form thi phai khoi tao doi tuong moi new Size()
                        btnOK.Size = new Size(75, 23);
                        this.Size = new System.Drawing.Size(280, 150);
                    }
                    else
                    {
                        txtTime1.Size = new Size(140, 20);
                        txtTime1.Location = new Point(96, 27);

                        txtTime2.Size = new Size(140, 20);
                        txtTime2.Location = new Point(96, 73);

                        lbTime1.Text = "Start time";
                        lbTime2.Text = "End time";
                        lbTime2.Visible = true;
                        txtTime2.Visible = true;

                        // Muon thay doi dc Point cua btnOK thi btnOK.Anchor khong dc phep = Right, Bottom
                        btnOK.Location = new Point(177, 116);

                        // Muon thay doi dc Size cua cac Control cung nhu Form thi phai khoi tao doi tuong moi new Size()
                        this.Size = new Size(280, 190);
                    }
                }
                // Mode ss
                else
                {
                    if (frmVideos.Videos.index == 4)
                    {
                        txtTime1.Size = new Size(100, 20);
                        txtTime1.Location = new Point(136, 67);

                        txtTime2.Size = new Size(100, 20);
                        txtTime2.Location = new Point(136, 73);

                        lbTime1.Text = "Video1's duration time ";
                        lbTime2.Text = "Video2's start time ";
                        lbTime2.Visible = false;
                        txtTime2.Visible = false;

                        // Muon thay doi dc Point cua btnOK thi btnOK.Anchor khong dc phep = Right, Bottom
                        btnOK.Location = new Point(177, 116 - 40);

                        // Muon thay doi dc Size cua cac Control cung nhu Form thi phai khoi tao doi tuong moi new Size()
                        btnOK.Size = new Size(75, 23);
                        this.Size = new System.Drawing.Size(280, 150);
                    }
                    else if (frmVideos.Videos.index == 6)
                    {
                        txtTime1.Size = new Size(110, 20);
                        txtTime1.Location = new Point(126, 67);

                        lbTime1.Text = "Each video's length";
                        lbTime2.Text = "End time";
                        lbTime2.Visible = false;
                        txtTime2.Visible = false;

                        // Muon thay doi dc Point cua btnOK thi btnOK.Anchor khong dc phep = Right, Bottom
                        btnOK.Location = new Point(177, 116 - 40);

                        // Muon thay doi dc Size cua cac Control cung nhu Form thi phai khoi tao doi tuong moi new Size()
                        btnOK.Size = new Size(75, 23);
                        this.Size = new System.Drawing.Size(280, 150);
                    }
                    else
                    {
                        txtTime1.Size = new Size(140, 20);
                        txtTime1.Location = new Point(96, 67);

                        lbTime1.Text = "Duration time";
                        lbTime2.Text = "End time";
                        lbTime2.Visible = false;
                        txtTime2.Visible = false;

                        // Muon thay doi dc Point cua btnOK thi btnOK.Anchor khong dc phep = Right, Bottom
                        btnOK.Location = new Point(177, 116 - 40);

                        // Muon thay doi dc Size cua cac Control cung nhu Form thi phai khoi tao doi tuong moi new Size()
                        btnOK.Size = new Size(75, 23);
                        this.Size = new System.Drawing.Size(280, 150);
                    }
                }
            }

            // frmAudios
            if (frmAudios.Audios.cbxSpeed.Text == "hh:mm:ss")
            {
                txtTime1.Size = new Size(140, 20);
                txtTime1.Location = new Point(96, 27);

                txtTime2.Size = new Size(140, 20);
                txtTime2.Location = new Point(96, 73);

                lbTime1.Text = "Start time";
                lbTime2.Text = "End time";
                lbTime2.Visible = true;
                txtTime2.Visible = true;

                // Muon thay doi dc Point cua btnOK thi btnOK.Anchor khong dc phep = Right, Bottom
                btnOK.Location = new Point(177, 116);

                // Muon thay doi dc Size cua cac Control cung nhu Form thi phai khoi tao doi tuong moi new Size()
                this.Size = new Size(280, 190);
            }
        }
    }
}

