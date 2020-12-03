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
        static int
            BACKGROUND = 0,
            EDGE = 1,
            AIR = 2,
            SAND = 3,

            LEFT = 9,
            CENTER = 10,
            RIGHT = 11;


        private int scale;
        private Brush edgeColor;
        private Brush sandColor;
        private Brush backgroundColor;
        private Brush formColor;
        private int time;
        Bitmap finalImage = new Bitmap(102, 206);
        int count = 25;
        int index = 0;
        int counter = 2;
        int width = 102;
        int height = 206;


        int startPos = 0;
        int OX = 1;



        int O0 = 1;
        int O1 = 1;
        int O2 = 1;
        int O3 = 1;
        int side = CENTER;
        int level = 1;
        int end = (51 * 103) - 1 - 25;
        int buffer = 0;
        int botPos = (51 * 103) - 1 - 25 - 51;
        int tearWidth = 5;


        int tearWidth1 = 3;
        int U0 = 1;
        int U1 = 1;
        int U2 = 1;
        int U3 = 1;
        int U4 = 1;
        int U5 = 1;
        int side1 = CENTER;
        int level1 = 1;
        int start; //initalized when start is (in time set)
        int buffer1 = 0;
        int topPos; //initalized when start is (in time set)





        public Medium()
            : base("Medium", 102 * 206)
        {
            setScale(2);
            setBackgroundColor(Brushes.Honeydew);
            setEdgeColor(Brushes.Honeydew);
            setSandColor(Brushes.Honeydew);
            setFormColor(Brushes.LightGray);
        }


        public Medium(int scale, Brush sandColor, Brush edgeColor, int time)
            : base("Medium", 102 * 206) // 51x103 (24x50 per quatrent)
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
            int _scale = 2;

            Console.WriteLine("start- " + start);
            Console.WriteLine("topPos- " + topPos);

            Pixel local1 = new Pixel();
            if (side1 == CENTER)
            {
                Console.WriteLine("DROP!");
                start = start + 51; //jump up a row
                Pixel tmp1C = this.getHourGlassIMG(start);
                local1.setXPos(tmp1C.getXPos());
                local1.setYPos(tmp1C.getYPos());
                local1.setWidth(tmp1C.getWidth());
                local1.setHeight(tmp1C.getHeight());
                topPos = start;
                side1 = LEFT;
            }

            if (level1 == 1)
            {
                buffer1 = U0;
            }
            else if (level1 == 2)
            {
                buffer1 = U1;
            }
            else if (level1 == 3)
            {
                buffer1 = U2;
            }
            else if (level1 == 4)
            {
                buffer1 = U3;
            }
            else if (level1 == 5)
            {
                buffer1 = U4;
            }
            else if (level1 == 6)
            {
                buffer1 = U5;
            }
            Pixel tmp1L = this.getHourGlassIMG(start - buffer1 + ((level1 - 1) * 51));
            Pixel tmp1R = this.getHourGlassIMG(start + buffer1 + ((level1 - 1) * 51));

            //Console.WriteLine("tempL- " + tmpL.getType());
            //Console.WriteLine("tempR- " + tmpR.getType());
            Console.WriteLine("level1- " + level1);
            if (tmp1L.getType() != EDGE || tmp1R.getType() != EDGE)
            {
                if (side1 == LEFT)
                {
                    local1.setXPos(tmp1L.getXPos());
                    local1.setYPos(tmp1L.getYPos());
                    local1.setWidth(tmp1L.getWidth());
                    local1.setHeight(tmp1L.getHeight());
                    topPos = start - buffer1 + ((level1 - 1) * 51);
                    side1 = RIGHT;
                }
                else if (side1 == RIGHT)
                {
                    local1.setXPos(tmp1R.getXPos());
                    local1.setYPos(tmp1R.getYPos());
                    local1.setWidth(tmp1R.getWidth());
                    local1.setHeight(tmp1R.getHeight());
                    topPos = start + buffer1 + ((level1 - 1) * 51);
                    side1 = LEFT;

                    if (buffer1 == U0)
                    {
                        if (U0 == 25 - (level1 * tearWidth1))
                        {
                            level1 = 2;
                        }
                        U0++;
                    }
                    else if (buffer1 == U1)
                    {
                        if (U1 == 25 - (level1 * tearWidth1))
                        {
                            level1 = 3;
                        }
                        U1++;
                    }
                    else if (buffer1 == U2)
                    {
                        if (U2 == 25 - (level1 * tearWidth1))
                        {
                            level1 = 4;
                        }
                        U2++;
                    }
                    else if (buffer1 == U3)
                    {
                        if (U3 == 25 - (level1 * tearWidth1))
                        {
                            level1 = 5;
                        }
                        U3++;
                    }
                    else if (buffer1 == U4)
                    {
                        if (U4 == 25 - (level1 * tearWidth1))
                        {
                            level1 = 6;
                        }
                        U4++;
                    }
                    else if (buffer1 == U5)
                    {
                        if (U5 == 25 - (level1 * tearWidth1))
                        {
                            level1 = 1;
                        }
                        U5++;
                    }
                }
            }
            else if ((tmp1L.getType() == EDGE && tmp1R.getType() == EDGE))
            {
                Console.WriteLine("DROP!");
                start = start + 51; //jump up a row

                Pixel tmp1C = this.getHourGlassIMG(start);
                local1.setXPos(tmp1C.getXPos());
                local1.setYPos(tmp1C.getYPos());
                local1.setWidth(tmp1C.getWidth());
                local1.setHeight(tmp1C.getHeight());
                topPos = start;
                side = LEFT;

                U0 = U1;
                U1 = U2;
                U2 = U3;
                U3 = U4;
                U4 = U5;
                U5 = 1;
            }

            Bitmap bmp9 = new Bitmap(this.scale, this.scale);
            using (Graphics graph = Graphics.FromImage(bmp9))
            {
                Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                graph.FillRectangle(this.backgroundColor, ImageSize);
            }
            Pixel p9 = new Pixel(bmp9, local1.getXPos(), local1.getYPos(), local1.getWidth(), local1.getHeight(), AIR);
            this.removeHourGlass(topPos);
            this.addHourGlass((topPos), p9);

















            /*
            //REMOVE Pixels from top
            Pixel temp = this.getHourGlassIMG(start + OX);

            if (temp.getYPos() >= 48 ||
                temp.getXPos() != 0 &&
                temp.getXPos() != 100 && 
                temp.getYPos() != 0)
            {
                if(temp.getYPos() == 100)
                {
                    Console.WriteLine("TIMES UP!");
                    return finalImage;
                }
                else if (temp.getYPos() >= 50 && temp.getXPos() == 100 - counter)
                {
                    index += counter;
                    counter += 4;
                }
               // else
                //{
                //    index = 0;
               // }
                Console.WriteLine("temp.getXPos()- " + temp.getXPos() + "temp.getYPos()- " + temp.getYPos() + "    index- " + index);
                temp = this.getHourGlassIMG(start + OX + index);
                Bitmap bmp = new Bitmap(_scale, _scale);
                using (Graphics graph = Graphics.FromImage(bmp))
                {
                    Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                    graph.FillRectangle(this.backgroundColor, ImageSize);
                }
                Pixel p = new Pixel(bmp, temp.getXPos(), temp.getYPos(), temp.getWidth(), temp.getHeight(), AIR);
                this.removeHourGlass(start + OX + index);
                this.addHourGlass(start + OX + index, p);
            }
            */








            //TRICKLE            
            int increment = 51;
            for (int i = (51 * 50) + 25; i < botPos; i += increment)
            {
                if(i >= botPos-51)      //fix with time
                {
                    break;
                }
                else if (i % 204 == count)
                {
                    Pixel tmp3 = this.getHourGlassIMG(i);
                    Bitmap bmp3 = new Bitmap(_scale, _scale);
                    using (Graphics graph = Graphics.FromImage(bmp3))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                        graph.FillRectangle(this.sandColor, ImageSize);
                    }
                    Pixel p3 = new Pixel(bmp3, tmp3.getXPos(), tmp3.getYPos(), tmp3.getWidth(), tmp3.getHeight(), SAND);
                    this.removeHourGlass(i);
                    this.addHourGlass((i), p3);
                }
                else if (i % 51 != 0)
                {
                    Pixel tmp3 = this.getHourGlassIMG(i);
                    Bitmap bmp3 = new Bitmap(_scale, _scale);
                    using (Graphics graph = Graphics.FromImage(bmp3))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                        graph.FillRectangle(this.backgroundColor, ImageSize);
                    }
                    Pixel p3 = new Pixel(bmp3, tmp3.getXPos(), tmp3.getYPos(), tmp3.getWidth(), tmp3.getHeight(), AIR);
                    this.removeHourGlass(i);
                    this.addHourGlass((i), p3);
                }
            }
            count += 51;
            count = count % 204;


















            //ADD Pixels to bottom
            Pixel local = new Pixel();
            if (side == CENTER)
            {
                Console.WriteLine("JUMP!");
                end = end - 51; //jump up a row
                Pixel tmpC = this.getHourGlassIMG(end);
                local.setXPos(tmpC.getXPos());
                local.setYPos(tmpC.getYPos());
                local.setWidth(tmpC.getWidth());
                local.setHeight(tmpC.getHeight());
                botPos = end;
                side = LEFT;
            }

            if (level == 1)
            {
                buffer = O0;
            }
            else if(level == 2)
            {
                buffer = O1;
            }
            else if(level == 3)
            {
                buffer = O2;
            }
            else if(level == 4)
            {
                buffer = O3;
            }
            Pixel tmpL = this.getHourGlassIMG(end - buffer - ((level-1) * 51));
            Pixel tmpR = this.getHourGlassIMG(end + buffer - ((level-1) * 51));

            //Console.WriteLine("tempL- " + tmpL.getType());
            //Console.WriteLine("tempR- " + tmpR.getType());
            Console.WriteLine("level- " + level);
            if (tmpL.getType() != EDGE || tmpR.getType() != EDGE)
            {
                if(side == LEFT)
                {
                    local.setXPos(tmpL.getXPos());
                    local.setYPos(tmpL.getYPos());
                    local.setWidth(tmpL.getWidth());
                    local.setHeight(tmpL.getHeight());
                    botPos = end - buffer - ((level-1) * 51);
                    side = RIGHT;
                }
                else if(side == RIGHT)
                {
                    local.setXPos(tmpR.getXPos());
                    local.setYPos(tmpR.getYPos());
                    local.setWidth(tmpR.getWidth());
                    local.setHeight(tmpR.getHeight());
                    botPos = end + buffer - ((level-1) * 51);
                    side = LEFT;

                    if (buffer == O0)
                    {
                        if(O0 == 25 - (level * tearWidth))
                        {
                            level = 2;
                        }
                        O0++;
                    }
                    else if (buffer == O1)
                    {
                        if (O1 == 25 - (level * tearWidth))
                        {
                            level = 3;
                        }
                        O1++;
                    }
                    else if (buffer == O2)
                    {
                        if (O2 == 25 - (level * tearWidth))
                        {
                            level = 4;
                        }
                        O2++;
                    }
                    else if (buffer == O3)
                    {
                        if (O3 == 25 - (level * tearWidth))
                        {
                            level = 1;
                        }
                        O3++;
                    }
                }
            }
            else if ((tmpL.getType() == EDGE && tmpR.getType() == EDGE))
            {
                Console.WriteLine("JUMP!");
                end = end - 51; //jump up a row

                Pixel tmpC = this.getHourGlassIMG(end);
                local.setXPos(tmpC.getXPos());
                local.setYPos(tmpC.getYPos());
                local.setWidth(tmpC.getWidth());
                local.setHeight(tmpC.getHeight());
                botPos = end;
                side = LEFT;

                O0 = O1;
                O1 = O2;
                O2 = O3;
                O3 = 1;
            }

            Bitmap bmp2 = new Bitmap(this.scale, this.scale);
            using (Graphics graph = Graphics.FromImage(bmp2))
            {
                Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                graph.FillRectangle(this.sandColor, ImageSize);
            }
            Pixel p2 = new Pixel(bmp2, local.getXPos(), local.getYPos(), local.getWidth(), local.getHeight(), SAND);
            this.removeHourGlass(botPos);
            this.addHourGlass((botPos), p2);

























            using (Graphics g = Graphics.FromImage(finalImage))
            {
                foreach (Pixel p4 in this.getHourGlassIMGall())
                {
                    g.DrawImage(p4.getImage(), new Rectangle(p4.getXPos(), p4.getYPos(), p4.getWidth(), p4.getHeight()));
                }
            }

            OX++;
            return finalImage;
        }
        



        public override Bitmap initalizeHourGlass()
        {

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                //g.Clear(Color.White);
                int X = 0;
                int Y = 0;
                int index = 0;
                int type;

                Console.WriteLine("height-   " + finalImage.Height);
                Console.WriteLine("width-   " + finalImage.Width);

                while (X < finalImage.Width && Y < finalImage.Height)
                {
                    Bitmap bmp = new Bitmap(this.scale, this.scale);
                    using (Graphics graph = Graphics.FromImage(bmp))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, this.scale, this.scale);

                        if (
                            //top
                            Y == 0 || //y:[0-2]

                            //left top straight
                            X == 0 && Y >= 2 && Y <= 50 || //x:[0-2], y:[2-4]-[50-52]
                            //left top angle
                            X <= 48 && X + 52 == Y ||  //x:[0-2]-[48-50], y:[52-54]-[100-102]
                            //left middle
                            X == 48 && Y == 102 || //x:[48-50], y:[102-104]
                            //left bottom angle
                            X <= 48 && 152 - X == Y || //x:[0-2]-[48-50], y:[104-106]-[152-154]
                                                       //left bottom staraight
                            X == 0 && Y >= 154 && Y <= 202 || //x:[0-2], y:[154-156]-[202-204]

                            //right top straight
                            X == 100 && Y >= 2 && Y <= 50 || //x:[100-102], y:[2-4]-[50-52]
                                                             //right top angle
                            X >= 52 && 152 - Y == X || //x:[52-54]-[100-102], y:[52-54]-[100-102]

                            //right middle
                            X == 52 && Y == 102 || //x:[52-54], y:[102-104]
                                                   //right bottom angle
                            X >= 52 && X + 52 == Y ||  //x:[52-54]-[100-102], y:[104-106]-[152-154]
                                                       //bottom right straight
                            X == 100 && Y >= 154 && Y <= 202 || //x:[0-2], y:[154-156]-[202-204]

                            //bottom
                            Y == 204) //y:[204-206]
                        {
                            graph.FillRectangle(this.edgeColor, ImageSize);
                            type = EDGE;
                        }




                        ///CLEAN
                        else if (
                            X < Y - 50 && Y > 50 && Y < 102 ||
                            X + Y < 154 && Y > 102 && Y < 154 ||

                            X > 102 - (Y - 50) && X > 50 && Y > 50 && Y < 102 ||
                           
                            Y < 52 + X && X >= 52 && Y >= 104 && Y <= 152 ||

                            Y == 102 && X < 48 ||
                            Y == 102 && X > 52)
                        {
                            graph.FillRectangle(this.formColor, ImageSize);
                            type = BACKGROUND;
                        }





                        else
                        {
                            graph.FillRectangle(this.backgroundColor, ImageSize);
                            type = AIR;
                        }
                        /*

                        if (Y == 50 || Y == 154)
                        {
                            graph.FillRectangle(Brushes.Crimson, ImageSize);
                        }

                        
                        if (X > Y - 52 && X < 152 - Y)
                        {
                            graph.FillRectangle(this.sandColor, ImageSize);
                        }
                        
                        else
                        {
                            graph.FillRectangle(this.backgroundColor, ImageSize);
                        }
                        */
                        /////////////////////
                    }
                    g.DrawImage(bmp, new Rectangle(X, Y, bmp.Width, bmp.Height));
                    Pixel p = new Pixel(bmp, X, Y, bmp.Width, bmp.Height, type);
                    this.addHourGlass(index, p);
                    index++;
                    X = (X + this.scale);
                    if (X >= finalImage.Width)
                    {
                        X = 0;
                        Y = Y + this.scale;
                    }
                }

            }
            return finalImage;
        }

        public Bitmap addTime(int time)
        {

            int middleX = 26;
            int middleY = 51;
            int upperBottom = (51*50) + 25; //col*row + 1/2(col)
            int pos = 0;
            int count = 0;

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                while (count < time)
                {
                    Console.WriteLine("Type- " + this.getHourGlassIMG(upperBottom - pos).getType());
                    Console.WriteLine("pos- " + pos);


                    if (this.getHourGlassIMG(upperBottom - pos).getType() != EDGE)
                    {
                        Bitmap bmp = new Bitmap(2, 2);
                        using (Graphics graph = Graphics.FromImage(bmp))
                        {
                            Rectangle ImageSize = new Rectangle(0, 0, 2, 2);
                            graph.FillRectangle(this.sandColor, ImageSize);

                            Pixel tmp = this.getHourGlassIMG(upperBottom - pos);

                            g.DrawImage(bmp, new Rectangle(tmp.getXPos(), tmp.getYPos(), 2, 2));
                            Pixel p = new Pixel(bmp, tmp.getXPos(), tmp.getYPos(), bmp.Width, bmp.Height, SAND);
                            this.removeHourGlass(upperBottom - pos);
                            this.addHourGlass(upperBottom - pos, p);
                        }

                        start = (upperBottom - pos) - 27;
                        topPos = (upperBottom - pos) - 27;
                        count++;
                        pos++;
                    }
                    else
                    {
                        while (this.getHourGlassIMG(upperBottom - pos - 1).getType() != EDGE)
                        {
                            pos++;
                        }
                        pos++;
                        pos++;
                        if (upperBottom - pos < 0)
                        {
                            break;
                        }
                    }
                }

            }
            


            return finalImage;
        }


    }
}
