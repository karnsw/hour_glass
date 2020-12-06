using System.Drawing;

namespace SandClock
{
    public class Small : HourGlass
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

        Bitmap finalImage = new Bitmap(102, 206);
        int count = 25;

        int O0 = 1;
        int O1 = 1;
        int O2 = 1;
        int O3 = 1;
        int side = CENTER;
        int level = 1;
        int end = (51 * 103) - 1 - 25;
        int buffer = 0;
        int botPos = (51 * 103) - 1 - 25 - 51;
        int maxbotpos = (51 * 103) - 1 - 25 - 51;
        int tearWidth = 5;

        int tearWidth1 = 3;
        int U0 = 1;
        int U1 = 1;
        int U2 = 1;
        int U3 = 1;
        int U4 = 1;
        int U5 = 1;
        int U6 = 1;
        int side1 = CENTER;
        int level1 = 1;
        int start; //initalized when start is (in time set)
        int buffer1 = 0;
        int topPos; //initalized when start is (in time set)



        public Small()
            : base("Small", 102 * 206, Brushes.LightGray)
        {
            setScale(2);
            setBackgroundColor(Brushes.Honeydew);
            setEdgeColor(Brushes.Honeydew);
            setSandColor(Brushes.Honeydew);
        }


        public Small(int time, int fillLevel, Brush sandColor, Brush edgeColor, Brush backgroundColor)
            : base("Small", 102 * 206, Brushes.LightGray) // 51x103 (24x50 per quatrent)
        {
            setScale(2);
            setTime(time);
            setFillLevel(fillLevel);
            setSandColor(sandColor);
            setEdgeColor(edgeColor);
            setBackgroundColor(backgroundColor);
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


        public void setScale(int scale)
        {
            this.scale = scale;
        }
        public int getScale()
        {
            return this.scale;
        }

        public override int bitIMGCount()
        {
            return this.getHourGlassSize() / this.scale;
        }

        public override void clearHourGlass()
        {
            this.getHourGlassIMGall().Clear();
        }

        public override Bitmap refreshImage()
        {
            int _scale = 2;

            Pixel local1 = new Pixel();

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
            else if (level1 == 7)
            {
                buffer1 = U6;
            }
            Pixel tmp1L = this.getHourGlassIMG(start - buffer1 - ((level1 - 1) * 51));
            Pixel tmp1R = this.getHourGlassIMG(start + buffer1 - ((level1 - 1) * 51));

            if ((tmp1L.getType() != EDGE || tmp1R.getType() != EDGE) && side1 != CENTER)
            {
                if (side1 == LEFT)
                {
                    local1.setXPos(tmp1L.getXPos());
                    local1.setYPos(tmp1L.getYPos());
                    local1.setWidth(tmp1L.getWidth());
                    local1.setHeight(tmp1L.getHeight());
                    topPos = start - buffer1 - ((level1 - 1) * 51);
                    side1 = RIGHT;
                }
                else if (side1 == RIGHT)
                {
                    local1.setXPos(tmp1R.getXPos());
                    local1.setYPos(tmp1R.getYPos());
                    local1.setWidth(tmp1R.getWidth());
                    local1.setHeight(tmp1R.getHeight());
                    topPos = start + buffer1 - ((level1 - 1) * 51);
                    side1 = LEFT;

                    if (level1 == 1)
                    {
                        if (U0 == level1 * tearWidth1 && U1 >= level1 * tearWidth1)
                        {
                            level1 = 2;
                        }
                        else if (U0 == level1 * tearWidth1)
                        {
                            side1 = CENTER;
                        }
                        U0++;
                    }
                    else if (level1 == 2)
                    {
                        if (U1 == level1 * tearWidth1 && U2 >= level1 * tearWidth1)
                        {
                            level1 = 3;
                        }
                        else if (U1 == level1 * tearWidth1)
                        {
                            side1 = CENTER;
                            U0 = 1 * tearWidth1 + 1;
                        }
                        U1++;  
                    }
                    else if (level1 == 3)
                    {
                        if (U2 == level1 * tearWidth1 && U3 >= level1 * tearWidth1)
                        {
                            level1 = 4;
                        }
                        else if (U2 == level1 * tearWidth1)
                        {
                            side1 = CENTER;
                            U0 = 1 * tearWidth1 + 1;
                            U1 = 2 * tearWidth1 + 1;
                        }
                        U2++;
                    }
                    else if (level1 == 4)
                    {
                        if (U3 == level1 * tearWidth1 && U4 >= level1 * tearWidth1)
                        {
                            level1 = 5;
                        }
                        else if (U3 == level1 * tearWidth1)
                        {
                            side1 = CENTER;
                            U0 = 1 * tearWidth1 + 1;
                            U1 = 2 * tearWidth1 + 1;
                            U2 = 3 * tearWidth1 + 1;
                        }
                        U3++;
                    }
                    else if (level1 == 5)
                    {
                        if (U4 == level1 * tearWidth1 && U5 >= level1 * tearWidth1)
                        {
                            level1 = 6;
                        }
                        else if (U4 == level1 * tearWidth1)
                        {
                            side1 = CENTER;
                            U0 = 1 * tearWidth1 + 1;
                            U1 = 2 * tearWidth1 + 1;
                            U2 = 3 * tearWidth1 + 1;
                            U3 = 4 * tearWidth1 + 1;
                        }
                        U4++;
                    }
                    else if (level1 == 6)
                    {
                        if (U5 == level1 * tearWidth1 && U6 >= level1 * tearWidth1)
                        {
                            level1 = 7;
                        }
                        else if (U5 == level1 * tearWidth1)
                        {
                            side1 = CENTER;
                            U0 = 1 * tearWidth1 + 1;
                            U1 = 2 * tearWidth1 + 1;
                            U2 = 3 * tearWidth1 + 1;
                            U3 = 4 * tearWidth1 + 1;
                            U4 = 5 * tearWidth1 + 1;
                        }
                        U5++;
                    }
                    else if(level1 == 7)
                    {
                        U6++;
                    }
                }
            }
            else if ((tmp1L.getType() == EDGE && tmp1R.getType() == EDGE) || side1 == CENTER)
            {
                start = start + 51; //jump up a row

                Pixel tmp1C = this.getHourGlassIMG(start);
                local1.setXPos(tmp1C.getXPos());
                local1.setYPos(tmp1C.getYPos());
                local1.setWidth(tmp1C.getWidth());
                local1.setHeight(tmp1C.getHeight());
                topPos = start;
                side1 = LEFT;

                U6 = U5;
                U5 = U4;
                U4 = U3;
                U3 = U2;
                U2 = U1;
                U1 = U0;
                U0 = 1;

                level1 = 1;
            }

            Bitmap bmp9 = new Bitmap(this.scale, this.scale);
            using (Graphics graph = Graphics.FromImage(bmp9))
            {
                Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                graph.FillRectangle(this.backgroundColor, ImageSize);
            }
            Pixel p9 = new Pixel(bmp9, local1.getXPos(), local1.getYPos(), local1.getWidth(), local1.getHeight(), AIR);
            this.removeHourGlassIMG(topPos);
            this.insertHourGlassIMG((topPos), p9);



            //TRICKLE            
            int increment = 51;
            for (int i = (51 * 50) + 25; i < botPos; i += increment)
            {
                
                 if(i > maxbotpos - 51)      //fix with time
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
                    this.removeHourGlassIMG(i);
                    this.insertHourGlassIMG((i), p3);
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
                    this.removeHourGlassIMG(i);
                    this.insertHourGlassIMG((i), p3);
                }
            }
            count += 51;
            count = count % 204;



            //ADD Pixels to bottom
            Pixel local = new Pixel();
            if (side == CENTER)
            {
                end = end - 51; //jump up a row
                Pixel tmpC = this.getHourGlassIMG(end);
                local.setXPos(tmpC.getXPos());
                local.setYPos(tmpC.getYPos());
                local.setWidth(tmpC.getWidth());
                local.setHeight(tmpC.getHeight());
                botPos = end;
                side = LEFT;
                goto Print;
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
                     
                O0 = O1;
                O1 = O2;
                O2 = O3;
                O3 = 1;
                side = CENTER;
            }

            Print:
            Bitmap bmp2 = new Bitmap(this.scale, this.scale);
            using (Graphics graph = Graphics.FromImage(bmp2))
            {
                Rectangle ImageSize = new Rectangle(0, 0, _scale, _scale);
                graph.FillRectangle(this.sandColor, ImageSize);
            }
            Pixel p2 = new Pixel(bmp2, local.getXPos(), local.getYPos(), local.getWidth(), local.getHeight(), SAND);
            this.removeHourGlassIMG(botPos);
            this.insertHourGlassIMG((botPos), p2);

            if(botPos < maxbotpos)
            {
                maxbotpos = botPos;
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
                int X = 0;
                int Y = 0;
                int index = 0;
                int type;

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
                            graph.FillRectangle(this.getFormColor(), ImageSize);
                            type = BACKGROUND;
                        }
                        else
                        {
                            graph.FillRectangle(this.backgroundColor, ImageSize);
                            type = AIR;
                        }
                    }
                    g.DrawImage(bmp, new Rectangle(X, Y, bmp.Width, bmp.Height));
                    Pixel p = new Pixel(bmp, X, Y, bmp.Width, bmp.Height, type);
                    this.insertHourGlassIMG(index, p);
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

        public override Bitmap addTime()
        {
            int time = this.getTime();

            int upperBottom = (51*50) + 25; //col*row + 1/2(col)
            int pos = 0;
            int count = 0;

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                while (count < time)
                {
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
                            this.removeHourGlassIMG(upperBottom - pos);
                            this.insertHourGlassIMG(upperBottom - pos, p);
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
