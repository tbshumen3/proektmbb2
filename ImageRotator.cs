using System;
using System.Drawing;

namespace ImageProcessing
{
    public class ImageRotator
    {
        private Bitmap myBitmap;
        private Bitmap newBitmap;

        private void RotatePoint(int xi, int yi, double beta)
        {
            double x = (double)xi - (myBitmap.Width / 2);
            double y = (double)yi - (myBitmap.Height / 2);

            // Calculate the radius vector and angle
            double R = Math.Sqrt(x * x + y * y);
            double alpha = Math.Atan2(y, x);

            // Calculate new angle and coordinates
            double alpha1 = alpha + beta;
            double x1 = R * Math.Cos(alpha1);
            double y1 = R * Math.Sin(alpha1);

            // Convert back to image coordinates
            int newX = (int)Math.Round(x1 + (newBitmap.Width / 2));
            int newY = (int)Math.Round(y1 + (newBitmap.Height / 2));

            if (newX >= 0 && newX < newBitmap.Width && newY >= 0 && newY < newBitmap.Height)
            {
                Color myPoint = myBitmap.GetPixel(xi, yi);
                newBitmap.SetPixel(newX, newY, myPoint);
            }
        }

        public void RotateImage(string inputPath, string outputPath, double angle)
        {
            try
            {
                myBitmap = new Bitmap(inputPath);

                // Calculate new dimensions to accommodate rotated image
                double sin = Math.Abs(Math.Sin(angle));
                double cos = Math.Abs(Math.Cos(angle));
                int newWidth = (int)(myBitmap.Width * cos + myBitmap.Height * sin);
                int newHeight = (int)(myBitmap.Width * sin + myBitmap.Height * cos);

                newBitmap = new Bitmap(newWidth, newHeight);
                
                // Fill with white background
                using (Graphics g = Graphics.FromImage(newBitmap))
                {
                    g.Clear(Color.White);
                }

                // Rotate each pixel
                for (int x = 0; x < myBitmap.Width; x++)
                {
                    for (int y = 0; y < myBitmap.Height; y++)
                    {
                        RotatePoint(x, y, angle);
                    }
                }

                newBitmap.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error rotating image: {ex.Message}");
            }
            finally
            {
                if (myBitmap != null) myBitmap.Dispose();
                if (newBitmap != null) newBitmap.Dispose();
            }
        }
    }
}