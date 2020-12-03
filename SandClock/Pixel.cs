using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandClock
{


    public class Pixel
    {
        static int
            BACKGROUND = 0,
            EDGE = 1,
            AIR = 2,
            SAND = 3;

        private int width;
        private int height;
        private int xPos;
        private int yPos;
        private int type;
        private Bitmap image;

        public Pixel() { }


        public Pixel(Bitmap image, int xPos, int yPos, int width, int height, int type)
        {
            setImage(image);
            setXPos(xPos);
            setYPos(yPos);
            setWidth(width);
            setHeight(height);
            setType(type);
        }

        public Bitmap getImage()
        {
            return this.image;
        }
        public void setImage(Bitmap image)
        {
            this.image = image;
        }
        public int getXPos()
        {
            return this.xPos;
        }
        public void setXPos(int xPos)
        {
            this.xPos = xPos;
        }
        public int getYPos()
        {
            return this.yPos;
        }
        public void setYPos(int yPos)
        {
            this.yPos = yPos;
        }
        public int getWidth()
        {
            return this.width;
        }
        public void setWidth(int width)
        {
            this.width = width;
        }
        public int getHeight()
        {
            return this.height;
        }
        public void setHeight(int height)
        {
            this.height = height;
        }
        public int getType()
        {
            return this.type;
        } 
        public void setType(int type)
        {
            this.type = type;
        }
    }
}
