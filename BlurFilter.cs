using System;
using System.Drawing;

namespace ImageProcessing 
{
    public class BlurFilter
    {
        private Bitmap myBitmap;
        private Bitmap resultBitmap;

        private void BlurPoint(int x, int y)
        {
            Color c = myBitmap.GetPixel(x, y);
            Color t = myBitmap.GetPixel(x, y - 1);
            Color b = myBitmap.GetPixel(x, y + 1);
            Color l = myBitmap.GetPixel(x - 1, y);
            Color r = myBitmap.GetPixel(x + 1, y);
            Color tl = myBitmap.GetPixel(x - 1, y - 1);
            Color tr = myBitmap.GetPixel(x + 1, y - 1);
            Color bl = myBitmap.GetPixel(x - 1, y + 1);
            Color br = myBitmap.GetPixel(x + 1, y + 1);

            int red = (c.R + t.R + b.R + l.R + r.R + tr.R + bl.R + tl.R + br.R) / 9;
            int green = (c.G + t.G + b.G + l.G + r.G + tr.G + bl.G + tl.G + br.G) / 9;
            int blue = (c.B + t.B + b.B + l.B + r.B + tr.B + bl.B + tl.B + br.B) / 9;
            int alpha = (c.A + t.A + b.A + l.A + r.A + tr.A + bl.A + tl.A + br.A) / 9;

            Color newColor = Color.FromArgb(alpha, red, green, blue);
            resultBitmap.SetPixel(x, y, newColor);
        }

        private void BlurImage()
        {
            for (int x = 1; x < myBitmap.Width - 1; x++)
            {
                for (int y = 1; y < myBitmap.Height - 1; y++)
                {
                    BlurPoint(x, y);
                }
            }
            myBitmap = new Bitmap(resultBitmap);
        }

        public void ProcessImage(string inputPath, string outputPath, int iterations = 1)
        {
            try
            {
                myBitmap = new Bitmap(inputPath);
                resultBitmap = new Bitmap(myBitmap.Width, myBitmap.Height);

                for (int i = 0; i < iterations; i++)
                {
                    BlurImage();
                }

                resultBitmap.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing image: {ex.Message}");
            }
            finally
            {
                myBitmap?.Dispose();
                resultBitmap?.Dispose();
            }
        }
    }
}