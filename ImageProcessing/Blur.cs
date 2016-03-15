using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{

    /* DO NOT CHANGE THIS FILE. */
    /* YOUR SUBMISSION MUST WORK CORRECTLY WITH _OUR_ COPY OF THIS FILE. */

    /* You may wish to make temporary changes or insert print statements     */
    /* while testing your code.  When you're finished testing and debugging,     */
    /* though, make sure your code works with the original version of this file. */

    /// <summary>
    ///  The Blur class is a program that reads an image file in TIFF format, blurs
    ///  it with a 3x3 box blurring kernel, writes the blurred image as a TIFF file,
    ///  and displays both images.
    /// 
    ///  The Blur program takes up to two parameters.  The first parameter is
    ///  the name of the TIFF-format file to read.  (The output image file is
    ///  constructed by adding "blur_" to the beginning of the input filename.)
    ///  An optional second parameter specifies the number of iterations of the
    ///  box blurring operation.  (The default is one iteration.)  For example, if
    ///  you run  then Blur will read engine.tiff, perform 5 iterations of blurring, and
    ///  write the blurred image to blur_engine.tiff .
    /// 
    /// </summary>

    public class Blur
    {

        /// <summary>
        ///  blurFile() reads a TIFF image file, blurs it, write the blurred image to
        ///  a new TIFF image file, and displays both images.
        /// </summary>
        ///  <param name="filename"> the name of the input TIFF image file. </param>
        ///  <param name="numIterations"> the number of iterations of blurring to perform. </param>
        public static void blurFile(string filename, int numIterations)
        {
            Console.WriteLine("Reading image file " + filename);
            PixImage image = ImageUtils.readTIFFPix(filename);

            Console.WriteLine("Blurring image file.");
            PixImage blurred = image.boxBlur(numIterations);

            string blurname = "blur_" + filename;
            Console.WriteLine("Writing blurred image file " + blurname);
            ImageUtils.writeTIFF(blurred, blurname);

            Console.WriteLine("Open the saved tiff file to view input image and blurred image.");
        }

        /*
        /// <summary>
        ///  main() reads the command-line arguments and initiates the blurring.
        /// 
        ///  The first command-line argument is the name of the image file.
        ///  An optional second argument is number of iterations of blurring.
        /// </summary>
        ///  <param name="args"> the usual array of command-line argument Strings. </param>
        public static void Main(string[] args)
        {
            blurFile("mouse.tif", 10);
            
        return;
         
        if (args.Length == 0)
            {
                Console.WriteLine("usage:  Blur imagefile [iterations]");
                Console.WriteLine("  imagefile is an image in TIFF format.");
                Console.WriteLine("  interations is the number of blurring iterations" + " (default 1).");
                Console.WriteLine("The blurred image is written to blur_imagefile.");
                Environment.Exit(0);
            }

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

            blurFile("", 10);
        }
        */
    }

}
