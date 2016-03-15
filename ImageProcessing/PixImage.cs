using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/**
 *  The PixImage class represents an image, which is a rectangular grid of
 *  color pixels.  Each pixel has red, green, and blue intensities in the range
 *  0...255.  Descriptions of the methods you must implement appear below.
 *  They include a constructor of the form
 *
 *      public PixImage(int width, int height);
 *
 *  that creates a black (zero intensity) image of the specified width and
 *  height.  Pixels are numbered in the range (0...width - 1, 0...height - 1).
 *
 *  All methods in this class must be implemented to complete Part I.
 */


namespace ImageProcessing
{
    public class PixImage
    {
        /// <summary>
        ///  Define any variables associated with a PixImage object here.  These
        ///  variables MUST be private.
        /// </summary>
        private Color[,] m_image;
        //private Bitmap m_image;
        private int m_maxWidth;
        private int m_maxHeight;

        public struct Pixel
        {
            public int x;
            public int y;
        }

        public bool IsBoundary(int x, int y)
        {
            if ((x == 0) || (x == m_maxWidth) || (y == 0) || (y == m_maxHeight))
            {
                return true;
            }
            return false;
        }

        public int AvgNeighbors(int x, int y)
        {
            int row = x;
            int col = y;

            // previous neighbor = -1, current = 0, next neighbor = 1 for both row & col
            int iRow = -1; 
            int iCol = -1;
            int avg = 0;
            int r, c = 0;
            int numOfNeighbors = 0;
            while (iCol<=1)
            {
                iRow = -1;
                while (iRow <= 1)
                {
                    r = row + iRow;
                    c = col + iCol;
                    if ( r>=0 && r<m_maxWidth && c>=0 && c<m_maxHeight )
                    {
                        Color color = m_image[r, c];
                        avg += color.ToArgb();
                        numOfNeighbors++;
                    }
                    iRow++;
                }
                iCol++;
            }
            if (numOfNeighbors>0)
            {
                avg = avg / numOfNeighbors;
            }
            return avg;   
        }

        public Color AvgNeighborsIter(int x, int y, Color[,] imgData)
        {
            int row = x;
            int col = y;
            Color retColor = Color.FromArgb(0,0,0);
            int redSum = 0;
            int greenSum = 0;
            int blueSum = 0;

            // previous neighbor = -1, current = 0, next neighbor = 1 for both row & col
            int iRow = -1;
            int iCol = -1;
            int avg = 0;
            int r, c = 0;
            int numOfNeighbors = 0;
            while (iCol <= 1)
            {
                iRow = -1;
                while (iRow <= 1)
                {
                    r = row + iRow;
                    c = col + iCol;
                    if (r >= 0 && r < m_maxWidth && c >= 0 && c < m_maxHeight)
                    {
                        Color color = imgData[r, c];
                        //Console.WriteLine("{0}", imgData[r, c]);
                        //avg += color.ToArgb();
                        redSum += color.R;
                        greenSum += color.G;
                        blueSum += color.B;
                        numOfNeighbors++;
                    }
                    iRow++;
                }
                iCol++;
            }
            if (numOfNeighbors > 0)
            {
                //double avrg = avg / numOfNeighbors;
                //avg = (int) Math.Floor(avrg);
                redSum = (short) redSum / numOfNeighbors;
                greenSum = (short) greenSum / numOfNeighbors;
                blueSum = (short) blueSum / numOfNeighbors;
                retColor = Color.FromArgb(redSum, greenSum, blueSum);
            }
            //return avg;
            return retColor;
        }

        /// <summary>
        /// PixImage() constructs an empty PixImage with a specified width and height.
        /// Every pixel has red, green, and blue intensities of zero (solid black).
        /// </summary>
        /// <param name="width"> the width of the image. </param>
        /// <param name="height"> the height of the image. </param>
        public PixImage(int width, int height)
        {
            // Your solution here.
            m_maxWidth = width;
            m_maxHeight = height;
            m_image = new Color[width, height];
            //m_image = new int[width, height];
        }

        /// <summary>
        /// returns the width of the image.
        /// </summary>
        public virtual int Width
        {
            get
            {
                // Replace the following line with your solution.
                return m_maxWidth;
            }
        }

        /// <summary>
        /// returns the height of the image.
        /// </summary>
        public virtual int Height
        {
            get
            {
                // Replace the following line with your solution.
                return m_maxHeight;
            }
        }

        /// <summary>
        /// getRed() returns the red intensity of the pixel at coordinate (x, y).
        /// </summary>
        /// <param name="x"> the x-coordinate of the pixel. </param>
        /// <param name="y"> the y-coordinate of the pixel. </param>
        /// <returns> the red intensity of the pixel at coordinate (x, y). </returns>
        public virtual short getRed(int x, int y)
        {
            // Replace the following line with your solution.
            return m_image[x, y].R;
            //int val = m_image[x, y];
            //return Color.FromArgb(val).R;
            //return 0;
        }

        /// <summary>
        /// getGreen() returns the green intensity of the pixel at coordinate (x, y).
        /// </summary>
        /// <param name="x"> the x-coordinate of the pixel. </param>
        /// <param name="y"> the y-coordinate of the pixel. </param>
        /// <returns> the green intensity of the pixel at coordinate (x, y). </returns>
        public virtual short getGreen(int x, int y)
        {
            // Replace the following line with your solution.
            return m_image[x, y].G;
            //int val = m_image[x, y];
            //return Color.FromArgb(val).G;
            //return color.G;
        }

        /// <summary>
        /// getBlue() returns the blue intensity of the pixel at coordinate (x, y).
        /// </summary>
        /// <param name="x"> the x-coordinate of the pixel. </param>
        /// <param name="y"> the y-coordinate of the pixel. </param>
        /// <returns> the blue intensity of the pixel at coordinate (x, y). </returns>
        public virtual short getBlue(int x, int y)
        {
            // Replace the following line with your solution.
            return m_image[x, y].B;
            //int val = m_image[x, y];
            //return Color.FromArgb(val).B;
            //return color.B;
        }
        /// <summary>
        /// setPixel() sets the pixel at coordinate (x, y) to specified red, green,
        /// and blue intensities.
        ///   
        /// If any of the three color intensities is NOT in the range 0...255, then
        /// this method does NOT change any of the pixel intensities.
        /// </summary>
        /// <param name="x"> the x-coordinate of the pixel. </param>
        /// <param name="y"> the y-coordinate of the pixel. </param>
        /// <param name="red"> the new red intensity for the pixel at coordinate (x, y). </param>
        /// <param name="green"> the new green intensity for the pixel at coordinate (x, y). </param>
        /// <param name="blue"> the new blue intensity for the pixel at coordinate (x, y). </param>
        public virtual void setPixel(int x, int y, short red, short green, short blue)
        {
            //int val = Color.FromArgb(red, green, blue);
            // Your solution here.
            Color color = Color.FromArgb(red, green, blue);
            m_image[x, y] = color;
        }

        /// <summary>
        /// toString() returns a String representation of this PixImage.
        /// 
        /// This method isn't required, but it should be very useful to you when
        /// you're debugging your code.  It's up to you how you represent a PixImage
        /// as a String.
        /// </summary>
        /// <returns> a String representation of this PixImage. </returns>
        public override string ToString()
        {
            // Replace the following line with your solution.
            return "";
        }

        /// <summary>
        /// boxBlur() returns a blurred version of "this" PixImage.
        /// 
        /// If numIterations == 1, each pixel in the output PixImage is assigned
        /// a value equal to the average of its neighboring pixels in "this" PixImage,
        /// INCLUDING the pixel itself.
        /// 
        /// A pixel not on the image boundary has nine neighbors--the pixel itself and
        /// the eight pixels surrounding it.  A pixel on the boundary has six
        /// neighbors if it is not a corner pixel; only four neighbors if it is
        /// a corner pixel.  The average of the neighbors is the sum of all the
        /// neighbor pixel values (including the pixel itself) divided by the number
        /// of neighbors, with non-integer quotients rounded toward zero (as C# does
        /// naturally when you divide two integers).
        /// 
        /// Each color (red, green, blue) is blurred separately.  The red input should
        /// have NO effect on the green or blue outputs, etc.
        /// 
        /// The parameter numIterations specifies a number of repeated iterations of
        /// box blurring to perform.  If numIterations is zero or negative, "this"
        /// PixImage is returned (not a copy).  If numIterations is positive, the
        /// return value is a newly constructed PixImage.
        /// 
        /// IMPORTANT:  DO NOT CHANGE "this" PixImage!!!  All blurring/changes should
        /// appear in the new, output PixImage only.
        /// </summary>
        /// <param name="numIterations"> the number of iterations of box blurring. </param>
        /// <returns> a blurred version of "this" PixImage. </returns>
        public virtual PixImage boxBlur(int numIterations)
        {
            // Replace the following line with your solution.
            if (numIterations <= 0)
                return this;

            PixImage newPixImg = new PixImage(m_maxWidth, m_maxHeight);
            int avgColor = 0;
            Color[,] prevImgData = m_image;
            //int[,] prevImgData = m_image;

            for (int i=0; i< numIterations; i++)
            {
                if (i > 0)
                {
                    prevImgData = newPixImg.m_image;
                    newPixImg = new PixImage(m_maxWidth, m_maxHeight);
                }
                    
                
                for (int row = 0; row < m_maxWidth; row++)
                {
                    for (int col = 0; col < m_maxHeight; col++)
                    {
                        Color color = AvgNeighborsIter(row, col, prevImgData);
                        //Color color = Color.FromArgb(avgColor);
                        newPixImg.setPixel(row, col, color.R, color.G, color.B);
                    }
                }
            }
            
            // Make each 
            //Console.WriteLine("After Blurring Data is");
            //newPixImg.PrintData();
            return newPixImg;
        }

        /// <summary>
        /// mag2gray() maps an energy (squared vector magnitude) in the range
        /// 0...24,969,600 to a grayscale intensity in the range 0...255.  The map
        /// is logarithmic, but shifted so that values of 5,080 and below map to zero.
        /// 
        /// DO NOT CHANGE THIS METHOD.  If you do, you will not be able to get the
        /// correct images and pass the autograder.
        /// </summary>
        /// <param name="mag"> the energy (squared vector magnitude) of the pixel whose
        /// intensity we want to compute. </param>
        /// <returns> the intensity of the output pixel. </returns>
        private static short mag2gray(long mag)
        {
            short intensity = (short)(30.0 * Math.Log(1.0 + (double)mag) - 256.0);

            // Make sure the returned intensity is in the range 0...255, regardless of
            // the input value.
            if (intensity < 0)
            {
                intensity = 0;
            }
            else if (intensity > 255)
            {
                intensity = 255;
            }
            return intensity;
        }

        /// <summary>
        /// sobelEdges() applies the Sobel operator, identifying edges in "this"
        /// image.  The Sobel operator computes a magnitude that represents how
        /// strong the edge is.  We compute separate gradients for the red, blue, and
        /// green components at each pixel, then sum the squares of the three
        /// gradients at each pixel.  We convert the squared magnitude at each pixel
        /// into a grayscale pixel intensity in the range 0...255 with the logarithmic
        /// mapping encoded in mag2gray().  The output is a grayscale PixImage whose
        /// pixel intensities reflect the strength of the edges.
        ///   
        /// See http://en.wikipedia.org/wiki/Sobel_operator#Formulation for details.
        /// </summary>
        /// <returns> a grayscale PixImage representing the edges of the input image.
        /// Whiter pixels represent stronger edges. </returns>
        public virtual PixImage sobelEdges()
        {
            // Replace the following line with your solution.
            PixImage pixImg = new PixImage(m_maxWidth, m_maxHeight);

            short gxRed, gyRed, gxGreen, gyGreen, gxBlue, gyBlue = 0;
            for (int y = 0; y < m_maxHeight; y++)
            {
                for (int x = 0; x < m_maxWidth; x++)
                {
                    Color color = m_image[x, y];
                    if ( (x==0) || (x==m_maxWidth-1) || (y==0) || (y==m_maxHeight-1) )
                    {
                        // boundary set the same pixels as original image
                        pixImg.setPixel(x, y, m_image[x,y].R, m_image[x, y].R, m_image[x, y].R);
                    }
                    else
                    {
                        gxRed = CalculateGradient(x, y, "X", Color.Red);
                        gyRed = CalculateGradient(x, y, "Y", Color.Red);

                        gxGreen = CalculateGradient(x, y, "X", Color.Green);
                        gyGreen = CalculateGradient(x, y, "Y", Color.Green);

                        gxBlue = CalculateGradient(x, y, "X", Color.Blue);
                        gyBlue = CalculateGradient(x, y, "Y", Color.Blue);

                        int pixEnergy = (gxRed * gxRed) + (gyRed * gyRed) + (gxGreen * gxGreen) + (gyGreen * gyGreen) + (gxBlue * gxBlue) + (gyBlue * gyBlue);
                        short intensity = mag2gray(pixEnergy);
                        pixImg.setPixel(x, y, intensity, intensity, intensity);
                    }
                }
            }

            /*
            // print
            Console.WriteLine("After edging data is......");
            for (int x = 0; x < m_maxWidth; x++)
            {
                for (int y = 0; y < m_maxHeight; y++)
                {
                    Console.WriteLine("{0}", pixImg.m_image[x, y].R);
                }
            }*/
                    return pixImg;
        }

        public short CalculateGradient(int x, int y, string gradient, Color type)
        {
            short gradientSum = 0;
            short[,] GradientX = new short[3, 3] { {1,0,-1 },
                { 2, 0, -2},
                { 1,0,-1 }
            };

            short[,] GradientY = new short[3,3] {
                { 1, 2, 1},
                { 0, 0, 0},
                { -1, -2, -1}
            };

            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {
                    if (!( (x+i>=0) && (x+i<m_maxWidth) && (y+j>=0) && (y+j<m_maxHeight)) )
                    {
                        // boundary conditions. dont proceed
                        break;
                    }
                    // if not boundary
                    short color = getColor(m_image[x + i, y + j], type);
                    if (gradient == "X")
                    {
                        gradientSum = (short) (gradientSum + (color * GradientX[i + 1, j + 1]));
                    }
                    else
                    {
                        gradientSum = (short) (gradientSum + (color * GradientY[i + 1, j + 1]));
                    }
                }
            }
            return gradientSum;
        }
        
        private short getColor(Color inColor, Color type)
        {
            if (type==Color.Red)
            {
                return inColor.R;
            }
            else if (type==Color.Green)
            {
                return inColor.G;
            }
            else if (type==Color.Blue)
            {
                return inColor.B;
            }
            return 0;
        }

        /// <summary>
        /// TEST CODE:  YOU DO NOT NEED TO FILL IN ANY METHODS BELOW THIS POINT.
        /// You are welcome to add tests, though.  Methods below this point will not
        /// be tested.  This is not the autograder, which will be provided separately.
        /// </summary>
        public void PrintData()
        {
            for (int row=0; row<m_maxWidth; row++)
            {
                for (int col=0; col<m_maxHeight; col++)
                {
                    Console.WriteLine("{0}", m_image[row, col]);
                }
            }
        }

        /// <summary>
        /// doTest() checks whether the condition is true and prints the given error
        /// message if it is not.
        /// </summary>
        /// <param name="b"> the condition to check. </param>
        /// <param name="msg"> the error message to print if the condition is false. </param>
        public static void doTest(bool b, string msg)
        {
            if (b)
            {
                Console.WriteLine("Good.");
            }
            else
            {
                Console.Error.WriteLine(msg);
            }
        }

        /// <summary>
        /// array2PixImage() converts a 2D array of grayscale intensities to
        /// a grayscale PixImage.
        /// </summary>
        /// <param name="pixels"> a 2D array of grayscale intensities in the range 0...255. </param>
        /// <returns> a new PixImage whose red, green, and blue values are equal to
        /// the input grayscale intensities. </returns>
        public static PixImage array2PixImage(int[][] pixels)
        {
            int width = pixels.Length;
            int height = pixels[0].Length;
            PixImage image = new PixImage(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int val = pixels[x][y];
                    image.setPixel(x, y, (short)pixels[x][y], (short)pixels[x][y], (short)pixels[x][y]);
                }
            }

            //Console.WriteLine("Print data");
            //image.PrintData();
            //Console.WriteLine("DONE Print data");

            //PrintData();
            return image;
        }

        /// <summary>
        /// equals() checks whether two images are the same, i.e. have the same
        /// dimensions and pixels.
        /// </summary>
        /// <param name="image"> a PixImage to compare with "this" PixImage. </param>
        /// <returns> true if the specified PixImage is identical to "this" PixImage. </returns>
        public virtual bool Equals(PixImage image)
        {
            int width = Width;
            int height = Height;

            if (image == null || width != image.Width || height != image.Height)
            {
                return false;
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (!(getRed(x, y) == image.getRed(x, y) && getGreen(x, y) == image.getGreen(x, y) && getBlue(x, y) == image.getBlue(x, y)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        /*
        /// <summary>
        /// main() runs a series of tests to ensure that the convolutions (box blur
        /// and Sobel) are correct.
        /// </summary>
        public static void Main(string[] args)
        {
            // Be forwarned that when you write arrays directly in C# as below,
            // each "row" of text is a column of your image--the numbers get
            // transposed.
            PixImage image1 = array2PixImage(new int[][]
            {
        new int[] {0, 10, 240},
        new int[] {30, 120, 250},
        new int[] {80, 250, 255}
            });
            Console.WriteLine("Testing getWidth/getHeight on a 3x3 image.  " + "Input image:");
            Console.Write(image1);
            doTest(image1.Width == 3 && image1.Height == 3, "Incorrect image width and height.");

            Console.WriteLine("Testing blurring on a 3x3 image.");
            doTest(image1.boxBlur(1).Equals(array2PixImage(new int[][]
            {
        new int[] {40, 108, 155},
        new int[] {81, 137, 187},
        new int[] {120, 164, 218}
            })), "Incorrect box blur (1 rep):\n" + image1.boxBlur(1));
            doTest(image1.boxBlur(2).Equals(array2PixImage(new int[][]
            {
        new int[] {91, 118, 146},
        new int[] {108, 134, 161},
        new int[] {125, 151, 176}
            })), "Incorrect box blur (2 rep):\n" + image1.boxBlur(2));
            doTest(image1.boxBlur(2).Equals(image1.boxBlur(1).boxBlur(1)), "Incorrect box blur (1 rep + 1 rep):\n" + image1.boxBlur(2) + image1.boxBlur(1).boxBlur(1));

            Console.WriteLine("Testing edge detection on a 3x3 image.");
            doTest(image1.sobelEdges().Equals(array2PixImage(new int[][]
            {
        new int[] {104, 189, 180},
        new int[] {160, 193, 157},
        new int[] {166, 178, 96}
            })), "Incorrect Sobel:\n" + image1.sobelEdges());


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
            
            doTest(image2.sobelEdges().Equals(array2PixImage(new int[][]
            {
        new int[] {122, 143, 74},
        new int[] {74, 143, 122}
            })), "Incorrect Sobel:\n" + image2.sobelEdges());
        }
        */
    }
}
