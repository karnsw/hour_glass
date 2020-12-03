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
        private Brush edgeColor;
        private Brush sandColor;
        private Brush backgroundColor;
        private Brush formColor;
        private int time;
        Bitmap finalImage = new Bitmap(200, 400);
        int count = 0;


        public Large()
            : base("Large", 200 * 400) {
            setScale(2);
            setBackgroundColor(Brushes.Honeydew);
            setEdgeColor(Brushes.Honeydew);
            setSandColor(Brushes.Honeydew);
            setFormColor(Brushes.LightGray);
        }


        public Large(int scale, Brush sandColor, Brush edgeColor, int time)
            : base("Large", 200*400)
        {
            setScale(scale);
            setBackgroundColor(Brushes.Honeydew);
            setSandColor(sandColor);
            setEdgeColor(edgeColor);
            setTime(time);
        }



        public Brush getformColor()
        {
            return this.formColor;
        }
        public void setFormColor(Brush formColor)
        {
            this.formColor = formColor;
        }

        public Brush getSandColor()
        {
            return this.sandColor;
        }
        public void setSandColor(Brush sandColor)
        {
            this.sandColor = sandColor;
        }

        public Brush getEdgeColor()
        {
            return this.edgeColor;
        }
        public void setEdgeColor(Brush edgeColor)
        {
            this.edgeColor = edgeColor;
        }
        public Brush getBackgroundColor()
        {
            return this.backgroundColor;
        }
        public void setBackgroundColor(Brush backgroundColor)
        {
            this.backgroundColor = backgroundColor;
        }

        public void setTime(int time)
        {
            this.time = time;
        }
        public int getTime()
        {
            return this.time;
        }
        public void setScale(int scale)
        {
            this.scale = scale;
        }
        public int getScale()
        {
            return this.scale;
        }

        public override int bitmapCount()
        {
            return this.getSize() / this.scale;
        }

        
        public override Bitmap refreshImage()
        {
            int ticks = 10;///////////fix

            //REMOVE Pixels from top
            Pixel temp = this.getHourGlassIMG(ticks);
            Bitmap bmp = new Bitmap(this.scale, this.scale);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, this.scale, this.scale);
                graph.FillRectangle(this.backgroundColor, ImageSize);
            }
            Pixel p = new Pixel(bmp, temp.getXPos(), temp.getYPos(), temp.getWidth(), temp.getHeight(), 0); ///////////fix
            this.removeHourGlass(ticks);
            this.addHourGlass(ticks, p);


            //ADD Pixels to bottom
            Pixel tmp2 = this.getHourGlassIMG(this.bitmapCount() - ticks);
            if (tmp2.getXPos() == 0 || tmp2.getXPos() == finalImage.Width - this.scale ||
                tmp2.getYPos() == 0 || tmp2.getYPos() == finalImage.Height - this.scale)
            {
                ticks = ticks + this.scale;
            }
            tmp2 = this.getHourGlassIMG(this.bitmapCount() - ticks);
            Bitmap bmp2 = new Bitmap(this.scale, this.scale);
            using (Graphics graph = Graphics.FromImage(bmp2))
            {
                Rectangle ImageSize = new Rectangle(0, 0, this.scale, this.scale);
                graph.FillRectangle(this.sandColor, ImageSize);
            }
            Pixel p2 = new Pixel(bmp2, tmp2.getXPos(), tmp2.getYPos(), tmp2.getWidth(), tmp2.getHeight(), 0); ///////////fix
            this.removeHourGlass(this.bitmapCount() - ticks);
            this.addHourGlass((this.bitmapCount() - ticks), p2);





            int increment = finalImage.Width / this.getScale();
            for (int i = (this.bitmapCount()/4); i < this.bitmapCount(); i += increment)
            {
                if(i % 4 == count)
                {
                    Pixel tmp3 = this.getHourGlassIMG(i);
                    Bitmap bmp3 = new Bitmap(this.scale, this.scale);
                    using (Graphics graph = Graphics.FromImage(bmp3))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, this.scale, this.scale);
                        graph.FillRectangle(this.sandColor, ImageSize);
                    }
                    Pixel p3 = new Pixel(bmp3, tmp3.getXPos(), tmp3.getYPos(), tmp3.getWidth(), tmp3.getHeight(), 0); ///////////fix
                    this.removeHourGlass(this.bitmapCount() - ticks);
                    this.addHourGlass((this.bitmapCount() - ticks), p3);
                }
                else
                {
                    Pixel tmp3 = this.getHourGlassIMG(i);
                    Bitmap bmp3 = new Bitmap(this.scale, this.scale);
                    using (Graphics graph = Graphics.FromImage(bmp3))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, this.scale, this.scale);
                        graph.FillRectangle(this.backgroundColor, ImageSize);
                    }
                    Pixel p3 = new Pixel(bmp3, tmp3.getXPos(), tmp3.getYPos(), tmp3.getWidth(), tmp3.getHeight(), 0); ///////////fix
                    this.removeHourGlass(this.bitmapCount() - ticks);
                    this.addHourGlass((this.bitmapCount() - ticks), p3);
                }
            }
            count++;
            count = count % 4;



            using (Graphics g = Graphics.FromImage(finalImage))
            {
                foreach (Pixel p4 in this.getHourGlassIMGall())
                {
                    g.DrawImage(p4.getImage(), new Rectangle(p4.getXPos(), p4.getYPos(), p4.getWidth(), p4.getHeight()));
                }
            }

            return finalImage;
        }
        

        public override Bitmap initalizeHourGlass()
        {

            using (Graphics g = Graphics.FromImage(finalImage))
            {

                int offsetX = 0;
                int offsetY = 0;
                int index = 0;

                while (offsetX < finalImage.Width && offsetY < finalImage.Height)
                {
                    Bitmap bmp = new Bitmap(this.scale, this.scale);
                    using (Graphics graph = Graphics.FromImage(bmp))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, this.scale, this.scale);
                        if (offsetY == 0 ||
                            offsetY == (finalImage.Height- this.scale) ||
                            offsetX == 0 && offsetY < 100 ||
                            offsetX == finalImage.Width- this.scale && offsetY < 100 ||

                            offsetX == offsetY - 100 && offsetX < 100 ||
                            offsetX + offsetY == 300 && offsetX < 100 ||
                            offsetX == offsetY - 100 && offsetX > 100 ||
                            offsetX + offsetY == 300 && offsetX > 100 ||

                            offsetX == 0 && offsetY > 300 ||
                            offsetX == finalImage.Width- this.scale && offsetY > 300 ||

                            offsetY == 200 && offsetX == 98 ||
                            offsetY == 200 && offsetX == 102)
                        {
                            graph.FillRectangle(this.edgeColor, ImageSize);
                        }


                        else if (offsetX < offsetY - 100 && offsetY > 100 && offsetY < 200 ||
                            offsetX + offsetY < 300 && offsetY > 200 && offsetY < 300 ||
                           
                            offsetX > 200 - (offsetY - 100) && offsetX > 100 && offsetY > 100 && offsetY < 200 ||
                            offsetY-offsetX < 100 && offsetX > 100 && offsetY > 200 && offsetY < 300 ||

                            offsetY == 200 && offsetX < 98 ||
                            offsetY == 200 && offsetX > 102)
                        {
                            graph.FillRectangle(this.formColor, ImageSize);
                        }


                        else if (offsetX > offsetY - 100 && offsetX < 300-offsetY)
                        {
                            graph.FillRectangle(this.sandColor, ImageSize);
                        }
                        else
                        {
                            graph.FillRectangle(this.backgroundColor, ImageSize);
                        }
   /////////////////////
                    }
                    g.DrawImage(bmp, new Rectangle(offsetX, offsetY, bmp.Width, bmp.Height));
                    //Pixel p = new Pixel(bmp, offsetX, offsetY, bmp.Width, bmp.Height);
                    //this.addHourGlass(index, p);
                    index++;
                    offsetX = (offsetX + 2);
                    if (offsetX >= finalImage.Width)
                    {
                        offsetX = 0;
                        offsetY = offsetY + 2;
                    }
                }

            }
            return finalImage;
        }


    }
}
