using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessing
{
    public class SpiralForm : Form
    {
        private const int NumPoints = 1000;
        private const double Increment = 0.1;
        private const double A = 0.1;
        private const double B = 0.1;
        private System.Windows.Forms.Timer animationTimer;
        private double currentTheta = 0;

        public SpiralForm()
        {
            Text = "Spiral Animation";
            Size = new Size(800, 800);
            BackColor = Color.White;
            DoubleBuffered = true;
            CenterToScreen();

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 50;
            animationTimer.Tick += (s, e) => 
            {
                currentTheta += 0.1;
                Invalidate();
            };
            animationTimer.Start();

            FormClosing += (s, e) => animationTimer.Stop();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.FromArgb(0, 0, 255)))
            {
                double theta = currentTheta;
                for (int i = 0; i < NumPoints; i++)
                {
                    double x = A * theta * Math.Cos(theta);
                    double y = B * theta * Math.Sin(theta);

                    int screenX = (int)(x * 50) + Width / 2;
                    int screenY = (int)(y * 50) + Height / 2;

                    g.DrawEllipse(pen, screenX - 1, screenY - 1, 2, 2);

                    theta += Increment;
                }
            }
        }
    }
}