using System;
using System.Drawing;

namespace ImageProcessing
{
    public class FlipProcessor
    {
        private Bitmap myBitmap;
        private Bitmap newBitmap;

        private void FlipPoint(int xi, int yi)
        {
            int y1 = myBitmap.Height - yi;

            if (y1 >= 0 && y1 < newBitmap.Height)
            {
                Color myPoint = myBitmap.GetPixel(xi, yi);
                Color myPoint2 = myBitmap.GetPixel(xi, y1);
                newBitmap.SetPixel(xi, y1, myPoint);
                newBitmap.SetPixel(xi, yi, myPoint2);
            }
        }

        public void FlipImage(string inputPath, string outputPath)
        {
            try
            {
                myBitmap = new Bitmap(inputPath);
                newBitmap = new Bitmap(myBitmap.Width, myBitmap.Height);

                for (int x = 0; x < myBitmap.Width; x++)
                {
                    for (int y = 0; y < myBitmap.Height / 2; y++)
                    {
                        FlipPoint(x, y);
                    }
                }

                newBitmap.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error flipping image: {ex.Message}");
            }
            finally
            {
                if (myBitmap != null) myBitmap.Dispose();
                if (newBitmap != null) newBitmap.Dispose();
            }
        }
    }
}