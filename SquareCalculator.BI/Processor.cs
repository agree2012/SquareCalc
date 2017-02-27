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
        public static Result Calc(Bitmap bmp)
        {
            Color pixelColor3 = bmp.GetPixel(0, 10);
            int width = 1;
            int height = 1;
            int square = 0;
            int rectangle = 0;
            for (int @string = 0; @string < 10; @string++)
            {
                for (int column = 0; column < 10; column++)
                {
                    if (bmp.GetPixel(column, @string).ToString() == "Color [A=255, R=0, G=0, B=0]")
                    {
                        for (int i = column; i < 10; i++)
                        {
                            if (bmp.GetPixel(i, @string) == bmp.GetPixel(i + 1, @string))
                                width++;
                            else
                            {
                                for (int j = @string; j < 10; j++)
                                {
                                    if (bmp.GetPixel(i, j) == bmp.GetPixel(i, j + 1))
                                        height++;
                                    else
                                    {
                                        for (int set = i; set >= (i + 1 - width); set--)
                                        {
                                            for (int sset = j; sset >= (j + 1 - height); sset--)
                                            {
                                                bmp.SetPixel(set, sset, pixelColor3);

                                            }
                                        }
                                        bmp.Save("D:\\bmp.bmp");
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (height == width)
                            square++;
                        else
                            rectangle++;
                        width = 1;
                        height = 1;
                    }
                }
            }
            string result = "Число квадратов = " + square.ToString() + ";  Число прямоугольников = " + rectangle.ToString();
            return new Result { Square = square, Rectangle = rectangle };
        }
    }
}
