using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing
{

    /* DO NOT CHANGE THIS FILE. */
    /* YOUR SUBMISSION MUST WORK CORRECTLY WITH _OUR_ COPY OF THIS FILE. */

    /* You may wish to make temporary changes or insert print statements     */
    /* while testing your code.  When you're finished testing and debugging,     */
    /* though, make sure your code works with the original version of this file. */

    /// <summary>
    ///  The ImageUtils class reads and writes TIFF file, converting to and from
    ///  pixel arrays in PixImage format or run-length encodings in
    ///  RunLengthEncoding format.  Methods are also included for displaying images
    ///  in PixImage format.
    /// 
    /// 
    /// </summary>



    /// <summary>
    ///  ImageUtils contains utilities for reading, writing, and displaying images.
    /// 
    /// </summary>

    public class ImageUtils
    {
        /// <summary>
        ///  buffer2PixImage() converts a BufferedImage to a PixImage. </summary>
        ///  <param name="bImage"> the image to convert. </param>
        ///  <returns> a PixImage with the same pixels as the BufferedImage. </returns>
        private static PixImage buffer2PixImage(Bitmap bImage)
        {
            PixImage pImage = new PixImage(bImage.Width, bImage.Height);
            for (int x = 0; x < bImage.Width; x++)
            {
                for (int y = 0; y < bImage.Height; y++)
                {
                    Color color = bImage.GetPixel(x, y);
                    pImage.setPixel(x, y, (short)color.R, (short)color.G, (short)color.B);
                }
            }
            return pImage;
        }

        /// <summary>
        ///  pixImage2buffer() converts a PixImage to a BufferedImage. </summary>
        ///  <param name="pImage"> the image to convert. </param>
        ///  <returns> a BufferedImage with the same pixels as the PixImage. </returns>
        internal static Bitmap pixImage2buffer(PixImage pImage)
        {
            Bitmap bImage = new Bitmap(pImage.Width, pImage.Height);
            for (int x = 0; x < bImage.Width; x++)
            {
                for (int y = 0; y < bImage.Height; y++)
                {
                    bImage.SetPixel(x, y, (Color.FromArgb(pImage.getRed(x, y), pImage.getGreen(x, y), pImage.getBlue(x, y))));
                }
            }
            return bImage;
        }

        /// <summary>
        ///  readTIFF() reads an image from a file and formats it as a BufferedImage. </summary>
        ///  <param name="filename"> the name of the file to read. </param>
        ///  <returns> a BufferedImage of the file </returns>
        private static Bitmap readTIFF(string filename)
        {
            return (Bitmap)Image.FromFile(filename, true);
        }

        /// <summary>
        ///  readTIFFPix() reads an image from a file and formats it as a PixImage. </summary>
        ///  <param name="filename"> the name of the file to read. </param>
        ///  <returns> a PixImage of the file </returns>
        public static PixImage readTIFFPix(string filename)
        {
            return buffer2PixImage(readTIFF(filename));
        }


        /// <summary>
        ///  writeTIFF() writes a BufferedImage to a specified file in TIFF format. </summary>
        ///  <param name="rle"> the input BufferedImage. </param>
        ///  <param name="filename"> the output filename. </param>
        private  static void writeTIFF(Bitmap image, string filename)
        {
            image.Save(filename, ImageFormat.Tiff);
        }

        /// <summary>
        ///  writeTIFF() writes a PixImage to a specified file in TIFF format. </summary>
        ///  <param name="image"> the input PixImage. </param>
        ///  <param name="filename"> the output filename. </param>
        public static void writeTIFF(PixImage image, string filename)
        {
            writeTIFF(pixImage2buffer(image), filename);
        }


    }
}
