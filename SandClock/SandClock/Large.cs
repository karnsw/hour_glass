using System.Drawing;

namespace SandClock
{
    public class Large : HourGlass
    {
        static int
            BACKGROUND = 0,
            EDGE = 1,
            AIR = 2,
            SAND = 3,

            LEFT = 9,
            CENTER = 10,
            RIGHT = 11;

        Bitmap finalImage = new Bitmap(202, 406);
        private int scale;
        private Brush edgeColor;
        private Brush sandColor;
        private Brush backgroundColor;
        private int time;
        int count = 50;

        int botL1_offCtrPos = 1;
        int botL2_offCtrPos = 1;
        int botL3_offCtrPos = 1;
        int botL4_offCtrPos = 1;
        int botCurrLRC = CENTER;
        int botCurrLvl = 1;
        int botCtrPos = (101 * 203) - 1 - 50;
        int botCurrOffCtrPos = 0;
        int botPos = (101 * 203) - 1 - 50;
        int maxbotpos = (101 * 203) - 1 - 50;
        int botLvlStepWidth = 10;

        int topLvlStepWidth = 6;
        int topL1_offCtrPos = 1;
        int topL2_offCtrPos = 1;
        int topL3_offCtrPos = 1;
        int topL4_offCtrPos = 1;
        int topL5_offCtrPos = 1;
        int topL6_offCtrPos = 1;
        int topL7_offCtrPos = 1;
        int topCurrLRC = CENTER;
        int topCurrLvl = 1;
        int topCurrOffCtrPos = 0;
        int topCtrPos; //initalized when start is (in time set)
        int topPos; //initalized when start is (in time set)



        public Large()
            : base("Large", 202 * 406, Brushes.LightGray)
        {
            setScale(2);
            setBackgroundColor(Brushes.Honeydew);
            setEdgeColor(Brushes.Honeydew);
            setSandColor(Brushes.Honeydew);
        }


        public Large(int time, int fillLevel, Brush sandColor, Brush edgeColor, Brush backgroundColor)
            : base("Large", 202 * 406, Brushes.LightGray) // 51x103 (24x50 per quatrent)
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
            Pixel local1 = new Pixel();

            if (topCurrLvl == 1)
            {
                topCurrOffCtrPos = topL1_offCtrPos;
            }
            else if (topCurrLvl == 2)
            {
                topCurrOffCtrPos = topL2_offCtrPos;
            }
            else if (topCurrLvl == 3)
            {
                topCurrOffCtrPos = topL3_offCtrPos;
            }
            else if (topCurrLvl == 4)
            {
                topCurrOffCtrPos = topL4_offCtrPos;
            }
            else if (topCurrLvl == 5)
            {
                topCurrOffCtrPos = topL5_offCtrPos;
            }
            else if (topCurrLvl == 6)
            {
                topCurrOffCtrPos = topL6_offCtrPos;
            }
            else if (topCurrLvl == 7)
            {
                topCurrOffCtrPos = topL7_offCtrPos;
            }
            Pixel tmp1L = getHourGlassIMG(topCtrPos - topCurrOffCtrPos - ((topCurrLvl - 1) * 101));
            Pixel tmp1R = getHourGlassIMG(topCtrPos + topCurrOffCtrPos - ((topCurrLvl - 1) * 101));

            if ((tmp1L.getType() != EDGE || tmp1R.getType() != EDGE) && topCurrLRC != CENTER)
            {
                if (topCurrLRC == LEFT)
                {
                    local1.setXPos(tmp1L.getXPos());
                    local1.setYPos(tmp1L.getYPos());
                    local1.setWidth(tmp1L.getWidth());
                    local1.setHeight(tmp1L.getHeight());
                    topPos = topCtrPos - topCurrOffCtrPos - ((topCurrLvl - 1) * 101);
                    topCurrLRC = RIGHT;
                }
                else if (topCurrLRC == RIGHT)
                {
                    local1.setXPos(tmp1R.getXPos());
                    local1.setYPos(tmp1R.getYPos());
                    local1.setWidth(tmp1R.getWidth());
                    local1.setHeight(tmp1R.getHeight());
                    topPos = topCtrPos + topCurrOffCtrPos - ((topCurrLvl - 1) * 101);
                    topCurrLRC = LEFT;

                    if (topCurrLvl == 1)
                    {
                        if (topL1_offCtrPos == topCurrLvl * topLvlStepWidth && topL2_offCtrPos >= topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLvl = 2;
                        }
                        else if (topL1_offCtrPos == topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLRC = CENTER;
                        }
                        topL1_offCtrPos++;
                    }
                    else if (topCurrLvl == 2)
                    {
                        if (topL2_offCtrPos == topCurrLvl * topLvlStepWidth && topL3_offCtrPos >= topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLvl = 3;
                        }
                        else if (topL2_offCtrPos == topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLRC = CENTER;
                            topL1_offCtrPos = 1 * topLvlStepWidth + 1;
                        }
                        topL2_offCtrPos++;
                    }
                    else if (topCurrLvl == 3)
                    {
                        if (topL3_offCtrPos == topCurrLvl * topLvlStepWidth && topL4_offCtrPos >= topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLvl = 4;
                        }
                        else if (topL3_offCtrPos == topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLRC = CENTER;
                            topL1_offCtrPos = 1 * topLvlStepWidth + 1;
                            topL2_offCtrPos = 2 * topLvlStepWidth + 1;
                        }
                        topL3_offCtrPos++;
                    }
                    else if (topCurrLvl == 4)
                    {
                        if (topL4_offCtrPos == topCurrLvl * topLvlStepWidth && topL5_offCtrPos >= topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLvl = 5;
                        }
                        else if (topL4_offCtrPos == topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLRC = CENTER;
                            topL1_offCtrPos = 1 * topLvlStepWidth + 1;
                            topL2_offCtrPos = 2 * topLvlStepWidth + 1;
                            topL3_offCtrPos = 3 * topLvlStepWidth + 1;
                        }
                        topL4_offCtrPos++;
                    }
                    else if (topCurrLvl == 5)
                    {
                        if (topL5_offCtrPos == topCurrLvl * topLvlStepWidth && topL6_offCtrPos >= topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLvl = 6;
                        }
                        else if (topL5_offCtrPos == topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLRC = CENTER;

                            topL1_offCtrPos = 1 * topLvlStepWidth + 1;
                            topL2_offCtrPos = 2 * topLvlStepWidth + 1;
                            topL3_offCtrPos = 3 * topLvlStepWidth + 1;
                            topL4_offCtrPos = 4 * topLvlStepWidth + 1;
                        }
                        topL5_offCtrPos++;
                    }
                    else if (topCurrLvl == 6)
                    {
                        if (topL6_offCtrPos == topCurrLvl * topLvlStepWidth && topL7_offCtrPos >= topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLvl = 7;
                        }
                        else if (topL6_offCtrPos == topCurrLvl * topLvlStepWidth)
                        {
                            topCurrLRC = CENTER;

                            topL1_offCtrPos = 1 * topLvlStepWidth + 1;
                            topL2_offCtrPos = 2 * topLvlStepWidth + 1;
                            topL3_offCtrPos = 3 * topLvlStepWidth + 1;
                            topL4_offCtrPos = 4 * topLvlStepWidth + 1;
                            topL5_offCtrPos = 5 * topLvlStepWidth + 1;
                        }
                        topL6_offCtrPos++;
                    }
                    else if (topCurrLvl == 7)
                    {
                        topL7_offCtrPos++;
                    }
                }
            }
            else if ((tmp1L.getType() == EDGE && tmp1R.getType() == EDGE) || topCurrLRC == CENTER)
            {
                topCtrPos = topCtrPos + 101; //jump up a row

                Pixel tmp1C = getHourGlassIMG(topCtrPos);
                local1.setXPos(tmp1C.getXPos());
                local1.setYPos(tmp1C.getYPos());
                local1.setWidth(tmp1C.getWidth());
                local1.setHeight(tmp1C.getHeight());
                topPos = topCtrPos;
                topCurrLRC = LEFT;

                topL7_offCtrPos = topL6_offCtrPos;
                topL6_offCtrPos = topL5_offCtrPos;
                topL5_offCtrPos = topL4_offCtrPos;
                topL4_offCtrPos = topL3_offCtrPos;
                topL3_offCtrPos = topL2_offCtrPos;
                topL2_offCtrPos = topL1_offCtrPos;
                topL1_offCtrPos = 1;

                topCurrLvl = 1;
            }

            Bitmap bmp9 = new Bitmap(scale, scale);
            using (Graphics graph = Graphics.FromImage(bmp9))
            {
                Rectangle ImageSize = new Rectangle(0, 0, scale, scale);
                graph.FillRectangle(backgroundColor, ImageSize);
            }
            Pixel p9 = new Pixel(bmp9, local1.getXPos(), local1.getYPos(), local1.getWidth(), local1.getHeight(), AIR);
            removeHourGlassIMG(topPos);
            insertHourGlassIMG((topPos), p9);


            //TRICKLE            
            int increment = 101;
            for (int i = (101 * 100) + 50; i < maxbotpos; i += increment)
            {
                if (i % 404 == count)
                {
                    Pixel tmp3 = getHourGlassIMG(i);
                    Bitmap bmp3 = new Bitmap(scale, scale);
                    using (Graphics graph = Graphics.FromImage(bmp3))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, scale, scale);
                        graph.FillRectangle(this.sandColor, ImageSize);
                    }
                    Pixel p3 = new Pixel(bmp3, tmp3.getXPos(), tmp3.getYPos(), tmp3.getWidth(), tmp3.getHeight(), SAND);
                    removeHourGlassIMG(i);
                    insertHourGlassIMG((i), p3);
                }
                else if (i % 101 != 0)
                {
                    Pixel tmp3 = getHourGlassIMG(i);
                    Bitmap bmp3 = new Bitmap(scale, scale);
                    using (Graphics graph = Graphics.FromImage(bmp3))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, scale, scale);
                        graph.FillRectangle(backgroundColor, ImageSize);
                    }
                    Pixel p3 = new Pixel(bmp3, tmp3.getXPos(), tmp3.getYPos(), tmp3.getWidth(), tmp3.getHeight(), AIR);
                    removeHourGlassIMG(i);
                    insertHourGlassIMG((i), p3);
                }
            }
            count += 101;
            count = count % 404;
                

            //ADD Pixels to bottom
            Pixel local = new Pixel();
            if (botCurrLRC == CENTER)
            {
                botCtrPos = botCtrPos - 101;
                botPos = botCtrPos;

                Pixel tmpC = getHourGlassIMG(botPos);
                local.setXPos(tmpC.getXPos());
                local.setYPos(tmpC.getYPos());
                local.setWidth(tmpC.getWidth());
                local.setHeight(tmpC.getHeight());

                botCurrLRC = LEFT;
                goto Print;
            }

            if (botCurrLvl == 1)
            {
                botCurrOffCtrPos = botL1_offCtrPos;
            }
            else if (botCurrLvl == 2)
            {
                botCurrOffCtrPos = botL2_offCtrPos;
            }
            else if (botCurrLvl == 3)
            {
                botCurrOffCtrPos = botL3_offCtrPos;
            }
            else if (botCurrLvl == 4)
            {
                botCurrOffCtrPos = botL4_offCtrPos;
            }
            Pixel tmpL = getHourGlassIMG(botCtrPos - botCurrOffCtrPos - ((botCurrLvl - 1) * 101));
            Pixel tmpR = getHourGlassIMG(botCtrPos + botCurrOffCtrPos - ((botCurrLvl - 1) * 101));

            if (tmpL.getType() != EDGE || tmpR.getType() != EDGE)
            {
                if (botCurrLRC == LEFT)
                {
                    local.setXPos(tmpL.getXPos());
                    local.setYPos(tmpL.getYPos());
                    local.setWidth(tmpL.getWidth());
                    local.setHeight(tmpL.getHeight());
                    botPos = botCtrPos - botCurrOffCtrPos - ((botCurrLvl - 1) * 101);
                    botCurrLRC = RIGHT;
                }
                else if (botCurrLRC == RIGHT)
                {
                    local.setXPos(tmpR.getXPos());
                    local.setYPos(tmpR.getYPos());
                    local.setWidth(tmpR.getWidth());
                    local.setHeight(tmpR.getHeight());
                    botPos = botCtrPos + botCurrOffCtrPos - ((botCurrLvl - 1) * 101);
                    botCurrLRC = LEFT;

                    if (botCurrOffCtrPos == botL1_offCtrPos)
                    {
                        if (botL1_offCtrPos == 50 - (botCurrLvl * botLvlStepWidth))
                        {
                            botCurrLvl = 2;
                        }
                        botL1_offCtrPos++;
                    }
                    else if (botCurrOffCtrPos == botL2_offCtrPos)
                    {
                        if (botL2_offCtrPos == 50 - (botCurrLvl * botLvlStepWidth))
                        {
                            botCurrLvl = 3;
                        }
                        botL2_offCtrPos++;
                    }
                    else if (botCurrOffCtrPos == botL3_offCtrPos)
                    {
                        if (botL3_offCtrPos == 50 - (botCurrLvl * botLvlStepWidth))
                        {
                            botCurrLvl = 4;
                        }
                        botL3_offCtrPos++;
                    }
                    else if (botCurrOffCtrPos == botL4_offCtrPos)
                    {
                        if (botL4_offCtrPos == 50 - (botCurrLvl * botLvlStepWidth))
                        {
                            botCurrLvl = 1;
                        }
                        botL4_offCtrPos++;
                    }
                }
            }
            else if ((tmpL.getType() == EDGE && tmpR.getType() == EDGE))
            {
                botL1_offCtrPos = botL2_offCtrPos;
                botL2_offCtrPos = botL3_offCtrPos;
                botL3_offCtrPos = botL4_offCtrPos;
                botL4_offCtrPos = 1;
                botCurrLRC = CENTER;
            }

        Print:
            Bitmap bmp2 = new Bitmap(scale, scale);
            using (Graphics graph = Graphics.FromImage(bmp2))
            {
                Rectangle ImageSize = new Rectangle(0, 0, scale, scale);
                graph.FillRectangle(sandColor, ImageSize);
            }
            Pixel p2 = new Pixel(bmp2, local.getXPos(), local.getYPos(), local.getWidth(), local.getHeight(), SAND);
            removeHourGlassIMG(botPos);
            insertHourGlassIMG((botPos), p2);

            if (botPos < maxbotpos)
            {
                maxbotpos = botPos;
            }

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                foreach (Pixel p4 in getHourGlassIMGall())
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
                int xCoordinate = 0;
                int yCoordinate = 0;
                int listIndex = 0;
                int type;

                while (xCoordinate < 202 && yCoordinate < 406)
                {
                    Bitmap bmp = new Bitmap(scale, scale);
                    using (Graphics graph = Graphics.FromImage(bmp))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, scale, scale);

                        if (
                            //top
                            yCoordinate == 0 || //y:[0-2]
                            //left top straight
                            xCoordinate == 0 && yCoordinate >= 2 && yCoordinate <= 100 || //x:[0-2], y:[2-4]-[100-102]
                            //left top angle
                            xCoordinate <= 98 && xCoordinate + 102 == yCoordinate ||  //x:[0-2]-[48-50], y:[102-104]-[200-202]
                            //left middle
                            xCoordinate == 98 && yCoordinate == 202 || //x:[98-100], y:[202-204]
                            //left bottom angle
                            xCoordinate <= 98 && 302 - xCoordinate == yCoordinate || //x:[0-2]-[98-100], y:[204-206]-[302-304]
                            //left bottom staraight
                            xCoordinate == 0 && yCoordinate >= 304 && yCoordinate <= 402 || //x:[0-2], y:[304-306]-[402-404]
                            //right top straight
                            xCoordinate == 200 && yCoordinate >= 2 && yCoordinate <= 100 || //x:[200-202], y:[2-4]-[100-102]
                            //right top angle
                            xCoordinate >= 102 && 302 - yCoordinate == xCoordinate || //x:[102-104]-[200-202], y:[102-104]-[200-202]
                            //right middle
                            xCoordinate == 102 && yCoordinate == 202 || //x:[102-104], y:[202-204]
                            //right bottom angle
                            xCoordinate >= 102 && xCoordinate + 102 == yCoordinate ||  //x:[102-104]-[200-202], y:[204-206]-[302-304]
                            //bottom right straight
                            xCoordinate == 200 && yCoordinate >= 304 && yCoordinate <= 402 || //x:[0-2], y:[304-306]-[402-404]
                            //bottom
                            yCoordinate == 404) //y:[404-406]
                        {
                            graph.FillRectangle(edgeColor, ImageSize);
                            type = EDGE;
                        }
                        else if (
                            //Top left
                            xCoordinate < yCoordinate - 100 && yCoordinate > 100 && yCoordinate < 202 ||
                            //Bottom Left
                            xCoordinate + yCoordinate < 304 && yCoordinate > 202 && yCoordinate < 304 ||
                            //Top Right
                            xCoordinate > 302 - yCoordinate && xCoordinate > 100 && yCoordinate > 100 && yCoordinate < 202 ||
                            //Top Left
                            yCoordinate < 102 + xCoordinate && xCoordinate >= 102 && yCoordinate >= 204 && yCoordinate <= 302 ||
                            //middle left
                            yCoordinate == 202 && xCoordinate < 98 ||
                            //middle right
                            yCoordinate == 202 && xCoordinate > 102)
                        {
                            graph.FillRectangle(getFormColor(), ImageSize);
                            type = BACKGROUND;
                        }
                        else
                        {
                            graph.FillRectangle(backgroundColor, ImageSize);
                            type = AIR;
                        }
                    }
                    g.DrawImage(bmp, new Rectangle(xCoordinate, yCoordinate, bmp.Width, bmp.Height));
                    Pixel p = new Pixel(bmp, xCoordinate, yCoordinate, bmp.Width, bmp.Height, type);
                    insertHourGlassIMG(listIndex, p);
                    listIndex++;
                    xCoordinate = (xCoordinate + scale);
                    if (xCoordinate >= 202)
                    {
                        xCoordinate = 0;
                        yCoordinate = yCoordinate + scale;
                    }
                }
            }
            return finalImage;
        }

        public override Bitmap addTime()
        {
            time = getTime();
            int centerCorrect = -52;

            int upperBottom = (101 * 100) + 49; //col*row + 1/2(col)
            int pos = 0;
            int count = 0;

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                while (count < time)
                {
                    if (getHourGlassIMG(upperBottom - pos).getType() != EDGE)
                    {
                            
                        Bitmap bmp = new Bitmap(scale, scale);
                        using (Graphics graph = Graphics.FromImage(bmp))
                        {
                            Rectangle ImageSize = new Rectangle(0, 0, scale, scale);
                            graph.FillRectangle(sandColor, ImageSize);

                            Pixel tmp = this.getHourGlassIMG(upperBottom - pos);

                            g.DrawImage(bmp, new Rectangle(tmp.getXPos(), tmp.getYPos(), scale, scale));
                            Pixel p = new Pixel(bmp, tmp.getXPos(), tmp.getYPos(), bmp.Width, bmp.Height, SAND);
                            removeHourGlassIMG(upperBottom - pos);
                            insertHourGlassIMG(upperBottom - pos, p);
                        }
                            
                        topCtrPos = (upperBottom - pos) + centerCorrect;
                        topPos = (upperBottom - pos) + centerCorrect;
                        count++;
                        pos++;
                    }
                    else
                    {
                        while (getHourGlassIMG(upperBottom - pos - 1).getType() != EDGE)
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
