using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace WPF_sprinter
{
    public class ImageResizer
    {
        public ImageResizer(string source, string target)
        {
            Image image = new Bitmap(Image.FromFile(source));

            float ImgWidth = image.Width;
            float ImgHeight = image.Height;
            float width;
            float height;
            float x = 0;
            float y = 0;

            int Size = 400;
            double Prop;

            if(ImgHeight >= ImgWidth)
            {
                Prop = ImgWidth / Size;
                width = Size;
                height = ImgHeight/(float)Prop;
            }
            else
            {
                Prop = ImgHeight / Size;
                height = Size;
                x  = ((ImgWidth / 2) - (ImgHeight / 2)) / (float)Prop - Size;
                x = x + Size / 4;
                width = ImgWidth / (float)Prop;
            }

            Image result = new Bitmap(Size, Size);
            using (var g = Graphics.FromImage(result))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, x, y, width, height);
                g.Dispose();
            }
            result.Save(target);
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }
    }
}
