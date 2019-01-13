using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
namespace RoPro
{
    class MyDetector
    {

        // Compare two images by getting the L2 error (square-root of sum of squared error).
        public double dist4(Mat A, Mat B)
        {
            if (A.Rows > 0 && A.Rows == B.Rows && A.Cols > 0 && A.Cols == B.Cols)
            {
                double errorL2 = CvInvoke.Norm(A, B, NormType.L2);
                // Calculate the L2 relative error between images.
                // Convert to a reasonable scale, since L2 error is summed across all pixels of the image.
                double similarity = errorL2 / (double)(A.Rows * A.Cols);
                return similarity;
            }
            else
            {
                //Images have a different size
                return 100000000.0;  // Return a bad value
            }
        }
        /// <summary>
        /// Размер картинки для сравнения
        /// </summary>
        const int size = 50;
        /// <summary>
        /// Предобработка картинки
        /// 1)преобразуем в серый
        /// 2)обрезаем белое вокруг
        /// 3)приводим к размеру size x size
        /// </summary>
        /// <param name="img">исходная картинка</param>
        /// <returns>Обрезанная серая картинка</returns>
        public Image<Gray, byte> predObr(Image<Rgb, byte> img)
        {
            var gray1 = img.Mat.ToImage<Gray, byte>();

            int minx = 0, miny = 0, maxx = gray1.Width, maxy = gray1.Height;

            for (int i = 0; i < gray1.Width; i++)
            {
                bool stop = false;
                for (int j = 0; j < gray1.Height; j++)
                    if (gray1[j, i].Intensity < 200)
                    {

                        stop = true;
                        break;
                    }
                if (stop)
                {
                    minx = i;
                    break;
                }
            }

            for (int i = 0; i < gray1.Height; i++)
            {
                bool stop = false;
                for (int j = 0; j < gray1.Width; j++)
                    if (gray1[i, j].Intensity < 200)
                    {

                        stop = true;
                        break;
                    }
                if (stop)
                {
                    miny = i;
                    break;
                }
            }

            for (int i =  gray1.Height-1; i>=0; i--)
            {
                bool stop = false;
                for (int j = 0; j < gray1.Width; j++)
                    if (gray1[i, j].Intensity < 200)
                    {

                        stop = true;
                        break;
                    }
                if (stop)
                {
                    maxy = i;
                    break;
                }
            }

            for (int i =  gray1.Width-1; i>=0; i--)
            {
                bool stop = false;
                for (int j = 0; j < gray1.Height; j++)
                    if (gray1[j, i].Intensity < 200)
                    {

                        stop = true;
                        break;
                    }
                if (stop)
                {
                    maxx = i;
                    break;
                }
            }

            gray1.ROI = new System.Drawing.Rectangle(minx, miny, maxx - minx, maxy - miny);

            return gray1.Resize(size, size, Inter.Linear);

        }

        /// <summary>
        /// Простая предобработка(не используется)
        /// Перегоняем изображение в серое и меняем размер до 50х50
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public Image<Gray, byte> predObr2(Image<Rgb, byte> img)
        {
            var gray1 = img.Mat.ToImage<Gray, byte>();        
            return gray1.Resize(size, size, Inter.Linear);
        }
        /// <summary>
        /// расстояние(вариант1) не используется
        /// </summary>
        /// <param name="A">картинка 1</param>
        /// <param name="B">картинка 2</param>
        /// <returns></returns>
        public double dist1(Image<Rgb, byte> A, Image<Rgb, byte> B)
        {
            double d = 0;

            var resize1 = predObr2(A);
            var resize2 = predObr2(B);

            //ImgForm if1 = new ImgForm(resize1, "1");
            //if1.Show();

            //ImgForm if2 = new ImgForm(resize2, "2");
            //if2.Show();

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    d += Math.Abs(resize1[i, j].Intensity - resize2[i, j].Intensity);

            return d;
        }
        /// <summary>
        /// Расстояние 2
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public double dist2(Image<Rgb, byte> A, Image<Rgb, byte> B)
        {
            double d = 0;

            var resize1 = predObr(A);
            var resize2 = predObr(B);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    d += Math.Abs(resize1[i, j].Intensity - resize2[i, j].Intensity);

            return d/(size*size*255);
        }
    }

}