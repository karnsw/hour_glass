using SandClock.SandClock;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SandClock
{
    public partial class Form1 : Form
    {
        static int HALF = 0,
            FULL = 1,
            SMALL = 0,
            LARGE = 1;


        int size = LARGE;
        int fill = HALF;

        private int ticks = 0;
        private bool clicked = false;
        Small small = new Small(1200, HALF, Brushes.Gold, Brushes.White, Brushes.Black);
        Large large = new Large(2598, HALF, Brushes.Gold, Brushes.White, Brushes.Black);

        Boolean backgroundColorSelected = false;
        Boolean trimColorSelected = false;
        Boolean sandColorSelected = false;
        Boolean airColorSelected = false;
        Boolean timeSelected = true;
        Boolean sizeSelected = false;
        Boolean fillSelected = false;


        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.LightGray;
            large.setFormColor(Brushes.LightGray);
            small.setFormColor(Brushes.LightGray);

            initalizeImage(SMALL);
            fillImage(SMALL);
            initalizeImage(LARGE);
            fillImage(LARGE);
        }


        private void button1_Click(object sender, EventArgs e)
        {
           timer1.Enabled = true;
           timer1.Stop();
           timer1.Start();

           clicked = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;

            if (clicked == true && size == SMALL)
            {
               pictureBox1.Image = small.refreshImage();
                this.Text = ticks.ToString();
            }
            else if(clicked == true && size == LARGE)
            {
                pictureBox1.Image = large.refreshImage();
                this.Text = ticks.ToString();
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = listBox1.GetItemText(listBox1.SelectedItem);
            label3.Text = listBox1.SelectedItem.ToString();

            if (text == "Small")
            {
                if (size == LARGE)
                {
                    if(fill == HALF)
                    {
                        small.setTime(1200);
                    }
                    else if(fill == FULL)
                    {
                        small.setTime(1800);
                    }
                }
                size = SMALL;
            }
            else if (text == "Large")
            {
                if (size == SMALL)
                {
                    if (fill == HALF)
                    {
                        large.setTime(2400);
                    }
                    else if (fill == FULL)
                    {
                        large.setTime(7152);
                    }
                }
                size = LARGE;
            }

            label4.ResetText();
            timeSelected = false;
            updateTimeList();

            sizeCheckClear(size);
            initalizeImage(size);
            fillImage(size);
        }
        private void listBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String text = listBox5.GetItemText(listBox5.SelectedItem);
            label7.Text = listBox5.SelectedItem.ToString();

            if (text == "Half")
            {
                fill = HALF;
                small.setTime(1200);
                large.setTime(2400);
            }
            else if (text == "Full")
            {
                fill = FULL;
                small.setTime(1800);
                large.setTime(7152);
            }

            label4.ResetText();
            updateTimeList();
            timeSelected = false;

            sizeCheckClear(size);
            initalizeImage(size);
            fillImage(size);
        }


        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = listBox4.GetItemText(listBox4.SelectedItem);
            label4.Text = listBox4.SelectedItem.ToString();

            if (size == SMALL)
            {
                if (fill == HALF)
                {
                    if (text == "30 sec")
                    {
                        small.setTime(1200);
                        this.timer1.Interval = 25;
                    }
                    else if (text == "2.5 min")
                    {
                        small.setTime(1200);
                        this.timer1.Interval = 125;
                    }
                    else if (text == "5 min")
                    {
                        small.setTime(1200);
                        this.timer1.Interval = 250;
                    }
                    else if (text == "10 min")
                    {
                        small.setTime(1200);
                        this.timer1.Interval = 500;
                    }
                    else if (text == "20 min")
                    {
                        small.setTime(1200);
                        this.timer1.Interval = 1000;
                    }
                }
                else if(fill == FULL)
                {
                    if (text == "45 sec")
                    {
                        small.setTime(1800);
                        this.timer1.Interval = 25;
                    }
                    else if (text == "3.75 min")
                    {
                        small.setTime(1800);
                        this.timer1.Interval = 125;
                    }
                    else if (text == "7.5 min")
                    {
                        small.setTime(1800);
                        this.timer1.Interval = 250;
                    }
                    else if (text == "15 min")
                    {
                        small.setTime(1800);
                        this.timer1.Interval = 500;
                    }
                    else if (text == "30 min")
                    {
                        small.setTime(1800);
                        this.timer1.Interval = 1000;
                    }
                }
            }
            else if(size == LARGE)
            {
                if (fill == HALF)
                {
                    if (text == "1 min")
                    {
                        large.setTime(2400);
                        this.timer1.Interval = 25;
                    }
                    else if (text == "5 min")
                    {
                        large.setTime(2400);
                        this.timer1.Interval = 125;
                    }
                    else if (text == "10 min")
                    {
                        large.setTime(2400);
                        this.timer1.Interval = 250;
                    }
                    else if (text == "20 min")
                    {
                        large.setTime(2400);
                        this.timer1.Interval = 500;
                    }
                    else if (text == "40 min")
                    {
                        large.setTime(2400);
                        this.timer1.Interval = 1000;
                    }
                }
                if (fill == FULL)
                {
                    if (text == "3 min")
                    {
                        large.setTime(7152);
                        this.timer1.Interval = 25;
                    }
                    else if (text == "15 min")
                    {
                        large.setTime(7152);
                        this.timer1.Interval = 125;
                    }
                    else if (text == "30 min")
                    {
                        large.setTime(7152);
                        this.timer1.Interval = 250;
                    }
                    else if (text == "60 min")
                    {
                        large.setTime(7152);
                        this.timer1.Interval = 500;
                    }
                    else if (text == "120 min")
                    {
                        large.setTime(7152);
                        this.timer1.Interval = 1000;
                    }
                }
            }
            fillImage(size);
            timeSelected = true;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = listBox2.GetItemText(listBox2.SelectedItem);
            label5.Text = listBox2.SelectedItem.ToString();

             if (text == "White")
            {
                Console.WriteLine(text);
                small.setEdgeColor(Brushes.White);
                large.setEdgeColor(Brushes.White);
            }
            else if (text == "Black")
            {
                Console.WriteLine(text);
                small.setEdgeColor(Brushes.Black);
                large.setEdgeColor(Brushes.Black);
            }
            else if (text == "Red")
            {
                Console.WriteLine(text);
                small.setEdgeColor(Brushes.Red);
                large.setEdgeColor(Brushes.Red);
            }
            
            
            if(timeSelected == false)
            {
                sizeCheckClear(size);
                initalizeImage(size);
            }
            else if(timeSelected == true)
            {
                sizeCheckClear(size);
                initalizeImage(size);
                fillImage(size);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = listBox3.GetItemText(listBox3.SelectedItem);
            label6.Text = listBox3.SelectedItem.ToString();

            if (text == "Black")
            {
                small.setBackgroundColor(Brushes.Black);
                large.setBackgroundColor(Brushes.Black);
            }
            else if (text == "Honey Dew")
            {
                small.setBackgroundColor(Brushes.Honeydew);
                large.setBackgroundColor(Brushes.Honeydew);
            }
            else if (text == "White")
            {
                small.setBackgroundColor(Brushes.White);
                large.setBackgroundColor(Brushes.White);
            }

            if (timeSelected == false)
            {
                sizeCheckClear(size);
                initalizeImage(size);
            }
            else if (timeSelected == true)
            {
                sizeCheckClear(size);
                initalizeImage(size);
                fillImage(size);
            }
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = listBox6.GetItemText(listBox6.SelectedItem);
            label8.Text = listBox6.SelectedItem.ToString();

            if (text == "Blue")
            {
                small.setSandColor(Brushes.CadetBlue);
                large.setSandColor(Brushes.CadetBlue);
            }
            else if (text == "Gold")
            {
                small.setSandColor(Brushes.Gold);
                large.setSandColor(Brushes.Gold);
            }
            else if (text == "Pink")
            {
                small.setSandColor(Brushes.Pink);
                large.setSandColor(Brushes.Pink);
            }

            if (timeSelected == false)
            {
                sizeCheckClear(size);
                initalizeImage(size);
            }
            else if (timeSelected == true)
            {
                sizeCheckClear(size);
                initalizeImage(size);
                fillImage(size);
            }
        }








        private void updateTimeList()
        {
            this.listBox4.Items.Clear();
            if (size == SMALL)
            {
                if (fill == HALF)
                {
                    this.listBox4.Items.AddRange(new object[] {
                        "30 sec",
                        "2.5 min",
                        "5 min",
                        "10 min",
                        "20 min"
                        });
                }
                else if (fill == FULL)
                {
                    this.listBox4.Items.AddRange(new object[] {
                        "45 sec",
                        "3.75 min",
                        "7.5 min",
                        "15 min",
                        "30 min"
                        });
                }
            }
            else if (size == LARGE)
            {
                if (fill == HALF)
                {
                    this.listBox4.Items.AddRange(new object[] {
                        "1 min",
                        "5 min",
                        "10 min",
                        "20 min",
                        "40 min"
                        });
                }
                else if (fill == FULL)
                {
                    this.listBox4.Items.AddRange(new object[] {
                        "3 min",
                        "15 min",
                        "30 min",
                        "60 min",
                        "120 min"});
                }
            }
        }




        private void sizeCheckClear(int SIZE)
        {
            if (SIZE == SMALL)
            {
                small.clearHourGlass();
            }
            else if (SIZE == LARGE)
            {
                large.clearHourGlass();
            }
        }

        private void initalizeImage(int SIZE)
        {
            if (SIZE == SMALL)
            {
                pictureBox1.Image = small.initalizeHourGlass();
            }
            else if (SIZE == LARGE)
            {
                pictureBox1.Image = large.initalizeHourGlass();
            }
        }

        private void fillImage(int SIZE)
        {
            if (SIZE == SMALL)
            {
                pictureBox1.Image = small.addTime();
            }
            else if (SIZE == LARGE)
            {
                pictureBox1.Image = large.addTime();
            }
        }
    }  
}
