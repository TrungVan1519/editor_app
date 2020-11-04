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
    public partial class frmGetCoordinates : Form
    {
        public frmGetCoordinates()
        {
            InitializeComponent();
        }

        private void txtWidthVideos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Ký tự Alphabe
                char.IsSymbol(e.KeyChar) || //Ký tự đặc biệt
                char.IsWhiteSpace(e.KeyChar) || //Khoảng cách
                char.IsPunctuation(e.KeyChar)) //Dấu chấm                
            {
                e.Handled = true; //Không cho thể hiện lên TextBox
            }
        }

        private void txtHeightVideos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Ký tự Alphabe
                char.IsSymbol(e.KeyChar) || //Ký tự đặc biệt
                char.IsWhiteSpace(e.KeyChar) || //Khoảng cách
                char.IsPunctuation(e.KeyChar)) //Dấu chấm                
            {
                e.Handled = true; //Không cho thể hiện lên TextBox
            }
        }

        private void txtXVideos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Ký tự Alphabe
                char.IsSymbol(e.KeyChar) || //Ký tự đặc biệt
                char.IsWhiteSpace(e.KeyChar) || //Khoảng cách
                char.IsPunctuation(e.KeyChar)) //Dấu chấm                
            {
                e.Handled = true; //Không cho thể hiện lên TextBox
            }
        }

        private void txtYVideos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Ký tự Alphabe
                char.IsSymbol(e.KeyChar) || //Ký tự đặc biệt
                char.IsWhiteSpace(e.KeyChar) || //Khoảng cách
                char.IsPunctuation(e.KeyChar)) //Dấu chấm                
            {
                e.Handled = true; //Không cho thể hiện lên TextBox
            }
        }

        private void txtWidthVideos_Click(object sender, EventArgs e)
        {
            txtWidth.Clear();
        }

        private void txtHeightVideos_Click(object sender, EventArgs e)
        {
            txtHeight.Clear();
        }

        private void txtXVideos_Click(object sender, EventArgs e)
        {
            txtX.Clear();
        }

        private void txtYVideos_Click(object sender, EventArgs e)
        {
            txtY.Clear();
        }

        private void frmGetCoordinates_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.WindowsDefaultBounds;

            txtWidth.Clear();
            txtHeight.Clear();
            txtX.Clear();
            txtY.Clear();

            // frmVideos
            if (frmVideos.Videos.cbxSpecies.SelectedIndex != -1)
            {
                // [Default] Width:Height
                if (frmVideos.Videos.cbxSpecies.Text == frmVideos.Videos.cbxSpecies.Items[0].ToString())
                {
                    lbX.ForeColor = Color.Red;
                    lbY.ForeColor = Color.Red;

                    txtX.ReadOnly = true;
                    txtY.ReadOnly = true;
                }

                // [Advanced] Width:Height:X:Y
                else if (frmVideos.Videos.cbxSpecies.Text == frmVideos.Videos.cbxSpecies.Items[1].ToString())
                {
                    lbX.ForeColor = Color.Black;
                    lbY.ForeColor = Color.Black;

                    txtX.ReadOnly = false;
                    txtY.ReadOnly = false;
                }

                // [Autosize X] Width:Height:-1:Y
                else if (frmVideos.Videos.cbxSpecies.Text == frmVideos.Videos.cbxSpecies.Items[2].ToString())
                {
                    lbX.ForeColor = Color.Red;
                    lbY.ForeColor = Color.Black;

                    txtX.ReadOnly = true;
                    txtY.ReadOnly = false;
                }

                // [AutoSize Y] Width:Height:X:-1
                else
                {
                    lbX.ForeColor = Color.Black;
                    lbY.ForeColor = Color.Red;

                    txtX.ReadOnly = false;
                    txtY.ReadOnly = true;
                }
            }

            // frmImages
            if (frmImages.Images.index == 0)
            {
                if (frmImages.Images.cbxSpecies.SelectedIndex != -1)
                {
                    lbX.ForeColor = Color.Red;
                    lbY.ForeColor = Color.Red;

                    txtX.ReadOnly = true;
                    txtY.ReadOnly = true;

                    // [Default] Width:Height
                    if (frmImages.Images.cbxSpecies.Text == frmImages.Images.cbxSpecies.Items[0].ToString())
                    {
                        txtWidth.ReadOnly = false;
                        txtHeight.ReadOnly = false;

                        lbWidth.ForeColor = Color.Black;
                        lbHeight.ForeColor = Color.Black;
                    }

                    // [Auto Size] Width:-1
                    else if (frmImages.Images.cbxSpecies.Text == frmImages.Images.cbxSpecies.Items[1].ToString())
                    {
                        txtWidth.ReadOnly = false;
                        txtHeight.ReadOnly = true;

                        lbWidth.ForeColor = Color.Black;
                        lbHeight.ForeColor = Color.Red;
                    }

                    // [Auto Size] -1:Height
                    else
                    {
                        txtWidth.ReadOnly = true;
                        txtHeight.ReadOnly = false;

                        lbWidth.ForeColor = Color.Red;
                        lbHeight.ForeColor = Color.Black;
                    }
                }
            }
            else if (frmImages.Images.index == 2)
            {
                if (frmImages.Images.cbxSpecies.SelectedIndex != -1)
                {
                    txtWidth.ReadOnly = false;
                    txtHeight.ReadOnly = false;

                    // [Default] Width:Height
                    if (frmImages.Images.cbxSpecies.Text == frmImages.Images.cbxSpecies.Items[0].ToString())
                    {
                        lbX.ForeColor = Color.Red;
                        lbY.ForeColor = Color.Red;

                        txtX.ReadOnly = true;
                        txtY.ReadOnly = true;
                    }

                    // [Advanced] Width:Height:X:Y
                    else if (frmImages.Images.cbxSpecies.Text == frmImages.Images.cbxSpecies.Items[1].ToString())
                    {
                        lbX.ForeColor = Color.Black;
                        lbY.ForeColor = Color.Black;

                        txtX.ReadOnly = false;
                        txtY.ReadOnly = false;
                    }

                    // [Autosize X] Width:Height:-1:Y
                    else if (frmImages.Images.cbxSpecies.Text == frmImages.Images.cbxSpecies.Items[2].ToString())
                    {
                        lbX.ForeColor = Color.Red;
                        lbY.ForeColor = Color.Black;

                        txtX.ReadOnly = true;
                        txtY.ReadOnly = false;
                    }

                    // [AutoSize Y] Width:Height:X:-1
                    else
                    {
                        lbX.ForeColor = Color.Black;
                        lbY.ForeColor = Color.Red;

                        txtX.ReadOnly = false;
                        txtY.ReadOnly = true;
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
