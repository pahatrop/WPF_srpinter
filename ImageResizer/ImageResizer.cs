using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace image_resizer
{
    public class ImageResizer
    {
        public ImageResizer(string source, string target)
        {
            var img = new Bitmap(Image.FromFile(source));
            int x1 = 10;
            int x2 = 50;
            int y1 = 10;
            int y2 = 50;
            int width = x2 - x1 + 1;
            int height = y2 - y1 + 1;
            var result = new Bitmap(width, height);
            for (int i = x1; i <= x2; i++)
                for (int j = y1; j <= y2; j++)
                    result.SetPixel(i - x1, j - y1, img.GetPixel(i, j));
            result.Save(target);
        }
    }
}
