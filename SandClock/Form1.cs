using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandClock
{
    public partial class Form1 : Form
    {
        private int ticks = 0;
        private bool clicked = false;
        private int xpos = 0;
        private int ypos = 0;
        List<Bitmap> sand = new List<Bitmap>();
        Bitmap finalImage = new Bitmap(100, 100);

        public Form1()
        {
            InitializeComponent();
            this.Text = "ayyyyyy";
            timer1.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
  
            //DrawFilledRectangle(500, 500);


            var b = new Bitmap(1, 1);
            b.SetPixel(0, 0, Color.Red);

            var result = new Bitmap(b, 400, 400);
            pictureBox1.Image = result;
            pictureBox1.Image = DrawFilledRectangle(50,100);
            


            clicked = true;

        }

        private Bitmap DrawFilledRectangle(int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(Brushes.Aqua, ImageSize);
            }
            return bmp;
        }

        private Bitmap AddFilledRectangle(int x, int y)
        {
            Bitmap bmp = new Bitmap(2, 2);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(x, y, 2 , 2);
                graph.FillRectangle(Brushes.Black, ImageSize);
            }
            return bmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTime.Now.ToString());
            ticks++;





            if (clicked == true)
            {
                Border();

                
                this.Text = ticks.ToString();
                /*
                sand.Add(AddFilledRectangle(xpos, ypos));
                this.label1.Text = "xpos- " + xpos;
                this.label2.Text = "size- " + sand.Count;

                using (Graphics g = Graphics.FromImage(finalImage))
                {
                    g.Clear(Color.White);
                    int offsetX = 0;
                    int offsetY = 0;
                    foreach (Bitmap pixel in sand)
                    {
                        Bitmap bmp = new Bitmap(2, 2);
                        using (Graphics graph = Graphics.FromImage(bmp))
                        {
                            Rectangle ImageSize = new Rectangle(0, 0, 2, 2);
                            graph.FillRectangle(Brushes.Aqua, ImageSize);
                        }
                        g.DrawImage(bmp, new Rectangle(offsetX, offsetY, pixel.Width, pixel.Height));
                        offsetX = (offsetX + 2);
                        if(offsetX >= finalImage.Width)
                        {
                            offsetX = 0;
                            offsetY = offsetY + 2;
                        }
                    }


                    xpos = xpos + 2;
                    ypos = ypos + 2;
                    this.label1.Text = "xpos- " + xpos;
                    this.label2.Text = "size- " + sand.Count;
                    pictureBox1.Image = finalImage;


                    //finalImage.Dispose();
                }
                //this.pictureBox1.Image = finalImage;
                //sand.Clear();

                */

                if (ticks == 10)
                {
                    this.Text = "Cheese";
                    //timer1.Stop();
                }
                if(ticks >  13)
                {
                    timer1.Stop();
                    timer1.Start();
                    ticks = 0;
                    Console.WriteLine(this.Text = ticks.ToString());
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Border()
        {
            int xTL = finalImage.Width / 4;
            int yTL = finalImage.Height / 4;

            int xTR = (3*finalImage.Width) / 4;
            int yTR = finalImage.Height / 4;

            int xBL = finalImage.Width / 4;
            int yBL = (3*finalImage.Height) / 4;

            int xBR = (3 * finalImage.Width) / 4;
            int yBR = (3 * finalImage.Height) / 4;

            int lineWidth = finalImage.Width / 8;
            int lineHeight = finalImage.Height / 8;



            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen graphPen = new Pen(Color.Blue, 0))
                {
                    g.DrawLine()
                }


                    g.Clear(Color.White);
                //int offsetX = 0;
                //int offsetY = 0;


                for (int xPos = -5; xPos < 5 + 1; xPos++)
                {
                    int yPosTL = ((int)(.1 * Math.Pow(xPos, 3)));
                    int yPosNEG = ((int)(-.1 * Math.Pow(xPos, 3)));
                    int xPosTL = xPos;
                    Console.WriteLine( "x- " + xPosTL.ToString());
                    Console.WriteLine( "y- " + yPosTL.ToString());


                    
                        this.label2.Text = "PRINT";
                        Bitmap bmp = new Bitmap(2, 2);
                        using (Graphics graph = Graphics.FromImage(bmp))
                        {
                            Rectangle ImageSize = new Rectangle(0, 0, 2, 2);
                            graph.FillRectangle(Brushes.Black, ImageSize);
                        }
                        g.DrawImage(bmp, new Rectangle(xPosTL + xTL, yPosTL + yTL, bmp.Width, bmp.Height));
                        g.DrawImage(bmp, new Rectangle(xPosTL + xTR, yPosNEG + yTR, bmp.Width, bmp.Height));
                        g.DrawImage(bmp, new Rectangle(xPosTL + xBL, yPosTL + yBL, bmp.Width, bmp.Height));
                        g.DrawImage(bmp, new Rectangle(xPosTL + xBR, yPosNEG + yBR, bmp.Width, bmp.Height));
                }
            }
            pictureBox1.Image = finalImage;
        }
    }  
}
