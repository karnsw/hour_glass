using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandClock
{
    public class Min15Round : HourGlass
    {
        private int scale;

        public Min15Round(int scale)
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
            Bitmap finalImage = new Bitmap(100, 200);

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.White);
                int offsetX = 0;
                int offsetY = 0;
                int factor = 0;

                while (offsetX < finalImage.Width && offsetY < finalImage.Height)
                {
                    Bitmap bmp = new Bitmap(2, 2);
                    using (Graphics graph = Graphics.FromImage(bmp))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, 2, 2);
                        if (offsetY == 0 || offsetY == finalImage.Height ||
                            offsetX == 0 && offsetY < 50 ||
                            offsetX == finalImage.Width && offsetY < 50 ||

                            offsetX == offsetY - 50 && offsetX < 48 ||
                            offsetX == offsetY - 50 && offsetX > 52 ||
                            offsetX == offsetY - 100 && offsetX < 52 ||
                            offsetX == offsetY - 100 && offsetX > 48 ||

                            offsetX == 0 && offsetY > 150 ||
                            offsetX == finalImage.Width && offsetY > 150)
                        {
                            graph.FillRectangle(Brushes.Black, ImageSize);
                        }
                        else
                        {
                            graph.FillRectangle(Brushes.Blue, ImageSize);
                        }

                    }
                    g.DrawImage(bmp, new Rectangle(offsetX, offsetY, bmp.Width, bmp.Height));
                    //factor = factor + 2;
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
