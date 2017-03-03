using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SquareCalculator.BI
{
    public class Result
    {
        public int Rectangle ;
        public int Square;
    }
    
    public static class Processor
    {
        static int width = 1;
        static int height = 1;
        static int square = 0;
        static int rectangle = 0;
        public static Result Calc(Bitmap bmp)
        {
            for (int @string = 0; @string < bmp.Height-1; @string++)
            {
                for (int column = 0; column < bmp.Width - 1; column++)
                {
                    if (bmp.GetPixel(column, @string).ToString() == "Color [A=255, R=0, G=0, B=0]")
                    {
                        for (int i = column; i < bmp.Width - 1; i++)
                        {
                            if (bmp.GetPixel(i, @string) == bmp.GetPixel(i + 1, @string))
                                width++;
                            else
                            {
                                for (int j = @string; j < bmp.Width - 1; j++)
                                {
                                    if (bmp.GetPixel(i, j) == bmp.GetPixel(i, j + 1))
                                        height++;
                                    else
                                    {
                                        ClearArea(i, j, bmp);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        IdentifyFigure(height, width);
                        width = 1;
                        height = 1;
                    }
                }
            }
            return new Result { Square = square, Rectangle = rectangle };
        }

        static void ClearArea(int x ,int y, Bitmap bmp)
        {
            Color pixelColor = bmp.GetPixel(0, 0);
            for (int @string = 0; @string < bmp.Height ; @string++)
            {
                for (int column = 0; column < bmp.Width ; column++)
                {
                    if (bmp.GetPixel(column, @string).ToString() == "Color [A=255, R=255, G=255, B=255]")
                    {
                        pixelColor = bmp.GetPixel(column, @string);
                        break;
                    }
                }
                if (pixelColor != bmp.GetPixel(0, 0))
                    break;
            }

            for (int set = x; set >= (x + 1 - width); set--)
            {
                for (int sset = y; sset >= (y + 1 - height); sset--)
                {
                    bmp.SetPixel(set, sset, pixelColor);
                }
            }
        }

        static void IdentifyFigure(int height, int width)
        {
            if (height == width)
                square++;
            else
                rectangle++;            
        }
    }
}
