using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandClock
{
    public class Min15 : HourGlass
    {
        private int scale;

        public Min15(int scale)
            : base("15 Minutes", 900)// Brushes.Red, Brushes.Black)
        {
            this.scale = scale;
        }
        public override int pixlesRemaining()
        {
            return this.scale * this.getSeconds();
        }

        public Bitmap initalizeHourGlass()
        {
            Bitmap finalImage = new Bitmap(200, 400);

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.White);
                int offsetX = 0;
                int offsetY = 0;
                int factor = 2;
                int index = 0;

                while (offsetX < finalImage.Width && offsetY < finalImage.Height)
                {
                    Bitmap bmp = new Bitmap(factor, factor);
                    using (Graphics graph = Graphics.FromImage(bmp))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, factor, factor);
                        if (offsetY == 0 ||
                            offsetY == (finalImage.Height-factor) ||
                            offsetX == 0 && offsetY < 100 ||
                            offsetX == finalImage.Width-factor && offsetY < 100 ||

                            offsetX == offsetY - 100 && offsetX < 100 ||
                            offsetX + offsetY == 300 && offsetX < 100 ||
                            offsetX == offsetY - 100 && offsetX > 100 ||
                            offsetX + offsetY == 300 && offsetX > 100 ||

                            offsetX == 0 && offsetY > 300 ||
                            offsetX == finalImage.Width-factor && offsetY > 300)
                        {
                            graph.FillRectangle(Brushes.Black, ImageSize);
                        }
                        else if (offsetX > offsetY - 100 && offsetX < 300-offsetY)
                        {
                            graph.FillRectangle(Brushes.Blue, ImageSize);
                        }
                        else
                        {
                            graph.FillRectangle(Brushes.Honeydew, ImageSize);
                        }
   /////////////////////
                    }
                    g.DrawImage(bmp, new Rectangle(offsetX, offsetY, bmp.Width, bmp.Height));
                    Pixel p = new Pixel(bmp, offsetX, offsetY, bmp.Width, bmp.Height);
                    this.addHourGlass(index, p);
                    //factor = factor + 2;
                    index++;
                    offsetX = (offsetX + 2);
                    if (offsetX >= finalImage.Width)
                    {
                        //factor = 0;
                        offsetX = 0;
                        offsetY = offsetY + 2;
                    }
                }

            }
            return finalImage;
        }
    }
}
