using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandClock
{
    public class Large : HourGlass
    {
        private int scale;
        Bitmap finalImage = new Bitmap(200, 400);


        public Large(int scale)
            : base("Large", 900)// Brushes.Red, Brushes.Black)
        {
            this.scale = scale;
        }
        public override int pixlesRemaining()
        {
            return this.scale * this.getSeconds();
        }

        public override Bitmap refreshImage(int ticks)
        {
            int size = (19900 - ticks);
            Console.WriteLine("2- " + size);
            Pixel tmp2 = this.getHourGlassIMG(19900 - ticks);
            if (tmp2.getXPos() == 0 || tmp2.getXPos() == finalImage.Width - 2)
            {
                ticks = ticks + 2;
            }
            tmp2 = this.getHourGlassIMG(19900 - ticks);
            Bitmap bmp2 = new Bitmap(2, 2);
            using (Graphics graph = Graphics.FromImage(bmp2))
            {
                Rectangle ImageSize = new Rectangle(0, 0, 2, 2);
                graph.FillRectangle(Brushes.BlueViolet, ImageSize);
            }
            Pixel p2 = new Pixel(bmp2, tmp2.getXPos(), tmp2.getYPos(), tmp2.getWidth(), tmp2.getHeight());
            this.removeHourGlass(19900 - ticks);
            this.addHourGlass((19900 - ticks), p2);





            Pixel temp = this.getHourGlassIMG(ticks);
            Bitmap bmp = new Bitmap(2, 2);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, 2, 2);
                graph.FillRectangle(Brushes.Honeydew, ImageSize);
            }
            Pixel p = new Pixel(bmp, temp.getXPos(), temp.getYPos(), temp.getWidth(), temp.getHeight());
            this.removeHourGlass(ticks);
            this.addHourGlass(ticks, p);





            using (Graphics g = Graphics.FromImage(finalImage))
            {
                foreach (Pixel p4 in this.getHourGlassIMGall())
                {
                    g.DrawImage(p4.getImage(), new Rectangle(p4.getXPos(), p4.getYPos(), p4.getWidth(), p4.getHeight()));
                }
            }

            return finalImage;
        }


        public Bitmap initalizeHourGlass()
        {

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
