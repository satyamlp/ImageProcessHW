using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace ImageProcessing
{
    class Program
    {
        public static void TestBlurImage()
        {
            // Be forwarned that when you write arrays directly in C# as below,
            // each "row" of text is a column of your image--the numbers get
            // transposed.
            
            PixImage image1 = PixImage.array2PixImage(new int[][]
            {
        new int[] {0, 10, 240},
        new int[] {30, 120, 250},
        new int[] {80, 250, 255}
            });
            Console.WriteLine("Testing getWidth/getHeight on a 3x3 image.  " + "Input image:");
            Console.Write(image1);
            PixImage.doTest(image1.Width == 3 && image1.Height == 3, "Incorrect image width and height.");

            //Console.WriteLine("Print data");
            //PixImage.PrintData();
            //Console.WriteLine("DONE Print data");

            /*
            Console.WriteLine("Testing blurring on a 3x3 image.");
            PixImage.doTest(image1.boxBlur(1).Equals(PixImage.array2PixImage(new int[][]
            {
        new int[] {40, 108, 155},
        new int[] {81, 137, 187},
        new int[] {120, 164, 218}
            })), "Incorrect box blur (1 rep):\n" + image1.boxBlur(1));

            
            Console.WriteLine("SECOND TEST");
            PixImage.doTest(image1.boxBlur(2).Equals(PixImage.array2PixImage(new int[][]
            {
        new int[] {91, 118, 146},
        new int[] {108, 134, 161},
        new int[] {125, 151, 176}
            })), "Incorrect box blur (2 rep):\n" + image1.boxBlur(2));

            
            PixImage.doTest(image1.boxBlur(2).Equals(image1.boxBlur(1).boxBlur(1)), "Incorrect box blur (1 rep + 1 rep):\n" + image1.boxBlur(2) + image1.boxBlur(1).boxBlur(1));
            */

            //Console.ReadLine();
            
            Console.WriteLine("Testing edge detection on a 3x3 image.");
            PixImage.doTest(image1.sobelEdges().Equals(PixImage.array2PixImage(new int[][]
            {
        new int[] {104, 189, 180},
        new int[] {160, 193, 157},
        new int[] {166, 178, 96}
            })), "Incorrect Sobel:\n" + image1.sobelEdges());

            Console.ReadLine();
            /*
            PixImage image2 = array2PixImage(new int[][]
            {
        new int[] {0, 100, 100},
        new int[] {0, 0, 100}
            });
            Console.WriteLine("Testing getWidth/getHeight on a 2x3 image.  " + "Input image:");
            Console.Write(image2);
            doTest(image2.Width == 2 && image2.Height == 3, "Incorrect image width and height.");

            Console.WriteLine("Testing blurring on a 2x3 image.");
            doTest(image2.boxBlur(1).Equals(array2PixImage(new int[][]
            {
        new int[] {25, 50, 75},
        new int[] {25, 50, 75}
            })), "Incorrect box blur (1 rep):\n" + image2.boxBlur(1));

            Console.WriteLine("Testing edge detection on a 2x3 image.");
            

            doTest(image2.sobelEdges().Equals(PixImage.array2PixImage(new int[][]
            {
        new int[] {122, 143, 74},
        new int[] {74, 143, 122}
            })), "Incorrect Sobel:\n" + image2.sobelEdges());
            */
        }
   
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

             //TestBlurImage();
            //return;
            /*if (args.Length == 0)
            {
                Console.WriteLine("usage:  Blur imagefile [iterations]");
                Console.WriteLine("  imagefile is an image in TIFF format.");
                Console.WriteLine("  interations is the number of blurring iterations" + " (default 1).");
                Console.WriteLine("The blurred image is written to blur_imagefile.");
                Environment.Exit(0);
            }*/

            int numIterations = 1;
            if (args.Length > 1)
            {
                try
                {
                    numIterations = int.Parse(args[1]);
                }
                catch (System.FormatException)
                {
                    Console.Error.WriteLine("The second argument must be a number.");
                    Environment.Exit(1);
                }
            }

            //ImageProcessing.Blur.blurFile("mouse.tif", 30);
            ImageProcessing.Sobel.sobelFile("images.tiff", 1, true);
        }

    }
}
