using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace parallel_tpl
{
  class Program
  {
    static void Main(string[] args)
    {
      Directory.CreateDirectory("output");
      Bitmap source = new Bitmap("input/car.jpeg");
      new Program().Crop(source);
    }

    public void Crop(Bitmap image)
    {

      int w = image.Width / 2;
      int h = image.Height / 2;

      int[,] array = new int[,] {
                { 0, 0 },
                { w, 0 },
                { 0, h },
                { w, h }
            };

      Parallel.For(
          0,
          4,
          (index) =>
          {
            var img = image.Clone(new System.Drawing.Rectangle(array[index, 0], array[index, 1], w, h), image.PixelFormat);
            var monochromeImage = ConvertBmp(img);
            monochromeImage.Save($"output/car_{index}.jpeg");
          }
      );
    }

    public Bitmap ConvertBmp(Bitmap image)
    {
      for (int y = 0; y < image.Height; y++)
      {
        for (int x = 0; x < image.Width; x++)
        {
          Color c = image.GetPixel(x, y);
          int luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
          image.SetPixel(x, y, Color.FromArgb(luma, luma, luma));
        }
      }
      return image;
    }
  }

}

