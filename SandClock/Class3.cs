using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandClock
{

    class Pixel
    {
        private int width;
        private int height;
        private int xPos;
        private int yPos;
        private Bitmap image;

        Pixel(Bitmap image, int xPos, int yPos, int width, int height)
        {
            setImage(image);
            setXPos(xPos);
            setYPos(yPos);
            setWidth(width);
            setHeight(height);
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
        public Bitmap getImage() {
            return this.image;
        }
        public void setImage(Bitmap image)
        {
            this.image = image;
        }
    }
}
