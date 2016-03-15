using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* DO NOT CHANGE THIS FILE. */
/* YOUR SUBMISSION MUST WORK CORRECTLY WITH _OUR_ COPY OF THIS FILE. */

/* You may wish to make temporary changes or insert print statements     */
/* while testing your code.  When you're finished testing and debugging,     */
/* though, make sure your code works with the original version of this file. */

/**
 *  The Sobel class is a program that reads an image file in TIFF format,
 *  performs Sobel edge detection and uses it to create a grayscale image
 *  showing the intensities of the strongest edges, writes the grayscale image
 *  as a TIFF file, and displays both images.  Optionally, it can also blur the
 *  image with one or more iterations of a 3x3 box blurring kernel (similar to
 *  our Blur program) before performing edge detection, which tends to make
 *  edge detection more robust.  If blurring is selected, this program writes
 *  both the blurred image and the grayscale-edge image to files and displays
 *  all three images (the input image and the two output images).
 *
 *  The Sobel program takes up to three parameters.  The first parameter is
 *  the name of the TIFF-format file to read.  (The output image file is
 *  constructed by adding "edge_" to the beginning of the input filename.)
 *  An optional second parameter specifies the number of iterations of the
 *  box blurring operation.  (The default is zero iterations.)  If a third
 *  parameter is present (regardless of what it is), a second output grayscale
 *  image is written, run-length encoded to reduce its file size, with prefix
 *  "rle_".  For example, if you run
 *
 *         Sobel engine.tiff 5 blah
 *
 *  then Sobel will read engine.tiff, perform 5 iterations of blurring, perform
 *  Sobel edge detection, map the Sobel gradients to grayscale intensities,
 *  write the blurred image to blur_engine.tiff, write a grayscale-edge image
 *  to edge_engine.tiff, and write a run-length encoded grayscale-edge image to
 *  rle_engine.tiff.
 *
 */
namespace ImageProcessing
{

    public class Sobel
    {

        /// <summary>
        ///  sobelFile() reads a TIFF image file, performs Sobel edge detection, maps
        ///  the Sobel gradients to grayscale intensities, writes the edges to a new
        ///  grayscale TIFF image file, and displays both images.  Optionally, it can
        ///  blurs the image before edge detection, in which case it also writes the
        ///  blurred image to a file and display all three images.
        /// </summary>
        ///  <param name="filename"> the name of the input TIFF image file. </param>
        ///  <param name="numIterations"> the number of iterations of blurring to perform. </param>
        ///  <param name="rle"> true if the output TIFF file should be run-length encoded. </param>
        public static void sobelFile(string filename, int numIterations, bool rle)
        {
            Console.WriteLine("Reading image file " + filename);
            PixImage image = ImageUtils.readTIFFPix(filename);
            PixImage blurred = image;

            if (numIterations > 0)
            {
                Console.WriteLine("Blurring image file.");
                blurred = image.boxBlur(numIterations);

                string blurname = "blur_" + filename;
                Console.WriteLine("Writing blurred image file " + blurname);
                ImageUtils.writeTIFF(blurred, blurname);
            }

            Console.WriteLine("Performing Sobel edge detection on image file.");
            PixImage sobeled = blurred.sobelEdges();

            string edgename = "edge_" + filename;
            Console.WriteLine("Writing grayscale-edge image file " + edgename);
            ImageUtils.writeTIFF(sobeled, edgename);

            if (numIterations > 0)
            {
                Console.WriteLine("Open the input image, blurred image, and " + "grayscale-edge image.");
                Console.WriteLine("Close the image to quit.");
            }
            else
            {
                Console.WriteLine("Open the image and grayscale-edge image to view the outcome.");
                Console.WriteLine("Close the image to quit.");
            }
        }

        /*
        /// <summary>
        ///  main() reads the command-line arguments and initiates the blurring.
        /// 
        ///  The first command-line argument is the name of the image file.
        ///  An optional second argument is number of iterations of blurring.
        ///  An optional third argument triggers the writing of a run-length encoded
        ///  grayscale-edge image.
        /// </summary>
        ///  <param name="args"> the usual array of command-line argument Strings. </param>
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("usage:  java Sobel imagefile [iterations] [RLE]");
                Console.WriteLine("  imagefile is an image in TIFF format.");
                Console.WriteLine("  interations is the number of blurring iterations" + " (default 0).");
                Console.WriteLine("  any third argument (RLE) turns on run-length " + "encoding in the output file");
                Console.WriteLine("The grayscale-edge image is written to " + "edge_imagefile.");
                Console.WriteLine("If blurring is selected, " + "the blurred image is written to blur_imagefile.");
                Environment.Exit(0);
            }

            int numIterations = 0;
            if (args.Length >= 2)
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

            sobelFile(args[0], numIterations, args.Length >= 3);
        }
        */
    }

}
