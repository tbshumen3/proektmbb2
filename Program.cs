using System;
using ImageProcessing;
using System.Windows.Forms;

namespace ImageProcessing
{
   class Program
   {
       static void Main(string[] args)
       {
           bool running = true;
           while (running)
           {
               Console.Clear();
               Console.WriteLine("1. Blur Filter");
               Console.WriteLine("2. Spiral");
               Console.WriteLine("3. Rotation");
               Console.WriteLine("4. Flip");
               Console.WriteLine("5. Exit");

               string choice = Console.ReadLine();
               switch (choice)
               {
                   case "1":
                       Console.WriteLine("Enter input image path:");
                       string inputPath = Console.ReadLine();
                       Console.WriteLine("Enter output image path:");
                       string outputPath = Console.ReadLine();
                       var blur = new BlurFilter();
                       blur.ProcessImage(inputPath, outputPath);
                       Console.WriteLine($"Image saved to {outputPath}");
                       break;
                   case "2":
                       var spiral = new SpiralForm();
                       Application.Run(spiral);
                       break;
                   case "3":
                       Console.WriteLine("Enter input image path:");
                       inputPath = Console.ReadLine();
                       Console.WriteLine("Enter output image path:");
                       outputPath = Console.ReadLine();
                       Console.WriteLine("Enter rotation angle in degrees:");
                       double angleDegrees = double.Parse(Console.ReadLine());
                       var rotator = new ImageRotator();
                       rotator.RotateImage(inputPath, outputPath, angleDegrees * Math.PI / 180);
                       Console.WriteLine($"Image saved to {outputPath}");
                       break;
                   case "4":
                       Console.WriteLine("Enter input image path:");
                       inputPath = Console.ReadLine();
                       Console.WriteLine("Enter output image path:");
                       outputPath = Console.ReadLine();
                       var flip = new FlipProcessor();
                       flip.FlipImage(inputPath, outputPath);
                       Console.WriteLine($"Image saved to {outputPath}");
                       break;
                   case "5":
                       running = false;
                       break;
               }

               if (running)
               {
                   Console.WriteLine("\nPress any key to continue...");
                   Console.ReadKey();
               }
           }
       }
   }
}