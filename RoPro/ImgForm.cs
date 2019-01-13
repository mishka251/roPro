using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using Emgu.CV.XFeatures2D;
using System.IO;

namespace RoPro
{
    public partial class ImgForm : Form
    {
        public ImgForm(Image<Rgb, byte> img, string text = "")
        {
            InitializeComponent();
            Text = text;
            pictureBox1.Image = img.Bitmap;
        }

        public ImgForm(Image<Gray, byte> img, string text = "")
        {
            InitializeComponent();
            Text = text;
            pictureBox1.Image = img.Bitmap;
        }
    }
}
