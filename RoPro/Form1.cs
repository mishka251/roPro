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
    struct imageAndText
    {
        public Image<Rgb, byte> image;
        public string text;
    }
    public partial class Form1 : Form
    {
        DirectoryInfo project;
        public Form1()
        {
            InitializeComponent();
            project = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;

            LoadSamples();
        }
       List< imageAndText> znaki;
        void LoadSamples()
        {
            DirectoryInfo imagesDir = project.GetDirectories().Where(
                (DirectoryInfo dir) => dir.Name == "ро").First();

            var files = imagesDir.GetFiles();
            znaki = new List<imageAndText>();
            Dictionary<int, string> texts = new Dictionary<int, string>();
            foreach (var file in files)
            {
                string name = ((string)file.Name.Clone()).Replace(file.Extension, "");
                int i;
                if (!int.TryParse(file.Name.Split('.')[0], out i))
                    continue;
                if (file.Extension == ".txt")
                {
                    StreamReader sr = file.OpenText();
                    var txt = sr.ReadToEnd();
                    texts.Add(i, txt);
                }              
            }


            foreach (var file in files)
            {
                string name = ((string)file.Name.Clone()).Replace(file.Extension, "");
                int i;
                if (!int.TryParse(file.Name.Split('.')[0], out i))
                    continue;
                if (file.Extension != ".txt")
                {
               
                    try
                    {
                        znaki.Add(new imageAndText()
                        {
                            image =  new Image<Rgb, byte>(file.FullName),
                            text = texts[i]
                        });
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message + " in file " + file.Name);
                    }
                }
            }
        }
        Image<Rgb, byte> image;
        private void button2_Click(object sender, EventArgs e)
        {

            if (image == null)
            {
                MessageBox.Show("Нет картинки");
            }
            try
            {

                int min_i = -1;
                MyDetector md = new MyDetector();
                double min_dist = 10;
                for (int i = 1; i < znaki.Count; i++)
                {
                    var dist = md.dist2(image, znaki[i].image);
                    if (dist < min_dist)
                    {
                        min_i = i;
                        min_dist = dist;
                    }
                }




                if (min_i == -1)
                {
                    richTextBox1.Text = "Не найдено";
                    pbDetected.Image = pbDetected.ErrorImage;
                }
                else
                {
                    richTextBox1.Text = znaki[min_i].text;
                    pbDetected.Image = znaki[min_i].image.Bitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                image = new Image<Rgb, byte>(ofd.FileName);
                pbSource.Image = image.Bitmap;
                pbDetected.Image = pbDetected.ErrorImage;
                richTextBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
