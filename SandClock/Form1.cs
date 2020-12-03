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
        Bitmap finalImage = new Bitmap(200, 400);
        Medium glass = new Medium();

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.LightGray;
            glass.setFormColor(Brushes.LightGray);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();

            pictureBox1.Image = glass.initalizeHourGlass();
            pictureBox1.Image = glass.addTime(1213 + 49*8);

           clicked = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;

            if (clicked == true)
            {
                pictureBox1.Image = glass.refreshImage();

                this.Text = ticks.ToString();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = listBox1.GetItemText(listBox1.SelectedItem);
            label3.Text = listBox1.SelectedItem.ToString();

            Console.WriteLine(text);
        }



        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = listBox4.GetItemText(listBox4.SelectedItem);
            label4.Text = listBox4.SelectedItem.ToString();

            if (text == "15 Min")
            {
                glass.setTime(900);
            }
            else if (text == "30 Min")
            {
                glass.setTime(1800);
            }
            else if (text == "60 Min")
            {
                glass.setTime(3600);
            }
            Console.WriteLine(text);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = listBox2.GetItemText(listBox2.SelectedItem);
            label5.Text = listBox2.SelectedItem.ToString();

             if (text == "Red/White")
            {
                Console.WriteLine(text);
                glass.setEdgeColor(Brushes.White);
                glass.setSandColor(Brushes.Red);
                Console.WriteLine("edge- " + glass.getEdgeColor());
                Console.WriteLine("sand- " + glass.getSandColor());
            }
            else if (text == "Blue/Black")
            {
                Console.WriteLine(text);
                glass.setEdgeColor(Brushes.Black);
                glass.setSandColor(Brushes.Blue);
            }
            else if (text == "Pink/Black")
            {
                Console.WriteLine(text);
                glass.setEdgeColor(Brushes.Black);
                glass.setSandColor(Brushes.Pink);
            }

            //pictureBox1.Image = glass.initalizeHourGlass();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = listBox3.GetItemText(listBox3.SelectedItem);
            label6.Text = listBox3.SelectedItem.ToString();

            if (text == "Black")
            {
                glass.setBackgroundColor(Brushes.Black);
            }
            else if (text == "HoneyDew")
            {
                glass.setBackgroundColor(Brushes.Honeydew);
            }
            else if (text == "White")
            {
                glass.setBackgroundColor(Brushes.White);
            }

            //pictureBox1.Image = glass.initalizeHourGlass();
        }
    }  
}
