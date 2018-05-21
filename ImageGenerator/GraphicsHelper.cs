using System;
using System.Drawing;

namespace ImageGenerator
{
    internal static class GraphicsHelper
    {
        internal static void PlotLine(Bitmap bmp, int x0, int y0, int x1, int y1, Color color)
        {
            if (Math.Abs(y1 - y0) < Math.Abs(x1 - x0))
            {
                if (x0 > x1)
                {
                    PlotLineLow(bmp, x1, y1, x0, y0, color);
                }
                else
                {
                    PlotLineLow(bmp, x0, y0, x1, y1, color);
                }
            }
            else
            {
                if (y0 > y1)
                {
                    PlotLineHigh(bmp, x1, y1, x0, y0, color);
                }
                else
                {
                    PlotLineHigh(bmp, x0, y0, x1, y1, color);
                }
            }
        }

        private static void PlotLineLow(Bitmap bmp, int x0, int y0, int x1, int y1, Color color)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int yi = 1;
            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }

            int d = 2 * dy - dx;
            int y = y0;

            for (int x = x0; x < x1; x = x + (dx > 0 ? 1 : -1))
            {
                bmp.SetPixel(x, y, color);
                if (d > 0)
                {
                    y = y + yi;
                    d = d - 2 * dx;
                }

                d = d + 2 * dy;
            }
        }

        private static void PlotLineHigh(Bitmap bmp, int x0, int y0, int x1, int y1, Color color)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }

            int d = 2 * dx - dy;
            int x = x0;

            for (int y = y0; y < y1; y = y + (dy > 0 ? 1 : -1))
            {
                bmp.SetPixel(x, y, color);
                if (d > 0)
                {
                    x = x + xi;
                    d = d - 2 * dy;
                }

                d = d + 2 * dx;
            }
        }
    }
}