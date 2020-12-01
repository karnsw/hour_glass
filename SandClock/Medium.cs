using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandClock
{
    public class Medium : HourGlass
    {
        private int scale;
        private Brush edgeColor;
        private Brush sandColor;
        private Brush backgroundColor;
        private Brush formColor;
        private int time;
        Bitmap finalImage = new Bitmap(100, 200);
        int count = 25;
        int index = 0;


        public Medium()
            : base("Medium", 100 * 200)
        {
            setScale(2);
            setBackgroundColor(Brushes.Honeydew);
            setEdgeColor(Brushes.Honeydew);
            setSandColor(Brushes.Honeydew);
            setFormColor(Brushes.LightGray);
        }


        public Medium(int scale, Brush sandColor, Brush edgeColor, int time)
            : base("Medium", 100 * 200)
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

        public override Bitmap refreshImage(int ticks)
        {
            int size = 5000;
            int _scale = 2;

            //REMOVE Pixels from top




            Pixel temp = this.getHourGlassIMG(ticks);

            if (temp.getXPos() != 0 &&
                temp.getXPos() != 100-_scale && 
                temp.getYPos() != 0)// &&
                //(temp.getXPos() != 50 - this.scale && temp.getYPos() < 25) &&
                //(temp.getXPos() > temp.getYPos() - 25 && temp.getYPos() > 25 && temp.getYPos() < 50) &&
                //(temp.getYPos() > 50 - (temp.getXPos() - 25) && temp.getXPos() > 25 && temp.getYPos() > 25 && temp.getYPos() < 50))
            {
                if(temp.getYPos() >= 50 && temp.getYPos() < 100)
                {
                    index = temp.getYPos()-50;

                }
                else if (temp.getYPos() > 100 && temp.getYPos() <= 150)
                {
                    index = (index + 100) - temp.getYPos();
                }
                else
                {
                    index = 0;
                }
                Console.WriteLine("temp.getYPos()- " + temp.getYPos() + "    index- " + index);
                temp = this.getHourGlassIMG(ticks + index);
                Bitmap bmp = new Bitmap(_scale, _scale);
                using (Graphics graph = Graphics.FromImage(bmp))
                {
                    Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                    graph.FillRectangle(this.backgroundColor, ImageSize);
                }
                Pixel p = new Pixel(bmp, temp.getXPos(), temp.getYPos(), temp.getWidth(), temp.getHeight());
                this.removeHourGlass(ticks + index);
                this.addHourGlass(ticks + index, p);
            }
           




            //TRICKLE            
            int increment = 25;
            for (int i = (size / 2); i < size; i += increment)
            {
                if (i >= size - ticks-2)
                {
                    break;
                }
                else if (i%200 == count)
                {
                    Pixel tmp3 = this.getHourGlassIMG(i);
                    Bitmap bmp3 = new Bitmap(_scale, _scale);
                    using (Graphics graph = Graphics.FromImage(bmp3))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                        graph.FillRectangle(this.sandColor, ImageSize);
                    }
                    Pixel p3 = new Pixel(bmp3, tmp3.getXPos(), tmp3.getYPos(), tmp3.getWidth(), tmp3.getHeight());
                    this.removeHourGlass(i);
                    this.addHourGlass((i), p3);
                }
                else if(i%50 != 0)
                {
                    Pixel tmp3 = this.getHourGlassIMG(i);
                    Bitmap bmp3 = new Bitmap(_scale, _scale);
                    using (Graphics graph = Graphics.FromImage(bmp3))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                        graph.FillRectangle(this.backgroundColor, ImageSize);
                    }
                    Pixel p3 = new Pixel(bmp3, tmp3.getXPos(), tmp3.getYPos(), tmp3.getWidth(), tmp3.getHeight());
                    this.removeHourGlass(i);
                    this.addHourGlass((i), p3);
                }

            }
            count += 50;
            count = count % 200;

            





            //ADD Pixels to bottom
            Pixel tmp2 = this.getHourGlassIMG(size - ticks-index);
            if ((tmp2.getXPos() != 0) &&
               (tmp2.getXPos() != 100 - _scale) &&
               (tmp2.getYPos() != 200- _scale))// &&
               //(tmp2.getXPos() + tmp2.getYPos() < 75 && tmp2.getYPos() > 50 && tmp2.getYPos() < 75) &&
               //(tmp2.getYPos() - tmp2.getXPos() < 25 && tmp2.getXPos() > 25 && tmp2.getYPos() > 50 && tmp2.getYPos() < 75))
            {
                //tmp2 = this.getHourGlassIMG(size - ticks-index);
                Bitmap bmp2 = new Bitmap(this.scale, this.scale);
                using (Graphics graph = Graphics.FromImage(bmp2))
                {
                    Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                    graph.FillRectangle(this.sandColor, ImageSize);
                }
                Pixel p2 = new Pixel(bmp2, tmp2.getXPos(), tmp2.getYPos(), tmp2.getWidth(), tmp2.getHeight());
                this.removeHourGlass(size - ticks - index);
                this.addHourGlass((size - ticks - index), p2);
            }


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
                g.Clear(Color.White);
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
                            offsetY == (finalImage.Height - this.scale) ||
                            offsetX == 0 && offsetY < 50 ||
                            offsetX == finalImage.Width - this.scale && offsetY < 50 ||

                            offsetX == offsetY - 50 && offsetX < 50 ||
                            offsetX + offsetY == 150 && offsetX < 50 ||
                            offsetX == offsetY - 50 && offsetX > 50 ||
                            offsetX + offsetY == 150 && offsetX > 50 ||

                            offsetX == 0 && offsetY > 150 ||
                            offsetX == finalImage.Width - this.scale && offsetY > 150 ||

                            offsetY == 100 && offsetX == 48 ||
                            offsetY == 100 && offsetX == 52)
                        {
                            graph.FillRectangle(this.edgeColor, ImageSize);
                        }


                        else if (offsetX < offsetY - 50 && offsetY > 50 && offsetY < 100 ||
                            offsetX + offsetY < 150 && offsetY > 100 && offsetY < 150 ||

                            offsetX > 100 - (offsetY - 50) && offsetX > 50 && offsetY > 50 && offsetY < 100 ||
                            offsetY - offsetX < 50 && offsetX > 50 && offsetY > 100 && offsetY < 150 ||

                            offsetY == 100 && offsetX < 48 ||
                            offsetY == 100 && offsetX > 52)
                        {
                            graph.FillRectangle(this.formColor, ImageSize);
                        }


                        else if (offsetX > offsetY - 50 && offsetX < 150 - offsetY)
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
                    Pixel p = new Pixel(bmp, offsetX, offsetY, bmp.Width, bmp.Height);
                    this.addHourGlass(index, p);
                    index++;
                    offsetX = (offsetX + this.scale);
                    if (offsetX >= finalImage.Width)
                    {
                        offsetX = 0;
                        offsetY = offsetY + this.scale;
                    }
                }

            }
            return finalImage;
        }
    }
}

