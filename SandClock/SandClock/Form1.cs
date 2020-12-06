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
        int fill = FULL;
        int ticks = 0;

        Small small = new Small(1213, FULL, Brushes.Gold, Brushes.White, Brushes.Black);
        Large large = new Large(7152, FULL, Brushes.Gold, Brushes.White, Brushes.Black);

        Boolean timeSelected = true;

        Boolean startUp = true;
        Boolean clicked = false;

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

            if (timeSelected == false)
            {
                this.Text = "You must select a time to begin.";
            }

            else if (startUp == true)
            {
                timer1.Enabled = true;
                timer1.Interval = 125;
                timer1.Start();
                startUp = false;
                clicked = true;
            }

            else if(startUp == false && clicked == true)
            {
                timer1.Stop();
                clicked = false;
            }


            else if (startUp == false && clicked == false)
            {
                timer1.Interval = ticks;
                timer1.Start();
                clicked = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;

            if (clicked == true && size == SMALL)
            {
                if(ticks == small.getTime())
                {
                    timer1.Stop();
                    ticks = 0;
                    this.Text = "TIMES UP!";
                    return;
                }
               pictureBox1.Image = small.refreshImage();
            }
            else if(clicked == true && size == LARGE)
            {
                if (ticks == large.getTime())
                {
                    timer1.Stop();
                    ticks = 0;
                    this.Text = "TIMES UP!";
                    return;
                }
                pictureBox1.Image = large.refreshImage();
            }
            this.Text = ticks.ToString();
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
                        small.setTime(1213);
                    }
                    else if(fill == FULL)
                    {
                        small.setTime(1801);
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
                        large.setTime(2598);
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
                small.setTime(1213);
                large.setTime(2598);
            }
            else if (text == "Full")
            {
                fill = FULL;
                small.setTime(1801);
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
                        small.setTime(1213);
                        this.timer1.Interval = 25;
                    }
                    else if (text == "2.5 min")
                    {
                        small.setTime(1213);
                        this.timer1.Interval = 125;
                    }
                    else if (text == "5 min")
                    {
                        small.setTime(1213);
                        this.timer1.Interval = 250;
                    }
                    else if (text == "10 min")
                    {
                        small.setTime(1213);
                        this.timer1.Interval = 500;
                    }
                    else if (text == "20 min")
                    {
                        small.setTime(1213);
                        this.timer1.Interval = 1000;
                    }
                }
                else if(fill == FULL)
                {
                    if (text == "45 sec")
                    {
                        small.setTime(1801);
                        this.timer1.Interval = 25;
                    }
                    else if (text == "3.75 min")
                    {
                        small.setTime(1801);
                        this.timer1.Interval = 125;
                    }
                    else if (text == "7.5 min")
                    {
                        small.setTime(1801);
                        this.timer1.Interval = 250;
                    }
                    else if (text == "15 min")
                    {
                        small.setTime(1801);
                        this.timer1.Interval = 500;
                    }
                    else if (text == "30 min")
                    {
                        small.setTime(1801);
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
                        large.setTime(2598);
                        this.timer1.Interval = 25;
                    }
                    else if (text == "5 min")
                    {
                        large.setTime(2598);
                        this.timer1.Interval = 125;
                    }
                    else if (text == "10 min")
                    {
                        large.setTime(2598);
                        this.timer1.Interval = 250;
                    }
                    else if (text == "20 min")
                    {
                        large.setTime(2598);
                        this.timer1.Interval = 500;
                    }
                    else if (text == "40 min")
                    {
                        large.setTime(2598);
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
            
            sizeCheckClear(size);
            initalizeImage(size);
            fillImage(size);
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

            sizeCheckClear(size);
            initalizeImage(size);
            fillImage(size);
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

            sizeCheckClear(size);
            initalizeImage(size);
            fillImage(size);
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

        private void button2_Click(object sender, EventArgs e)
        {
            clicked = false;
            startUp = true;
            ticks = 0;
            timer1.Stop();
            sizeCheckClear(SMALL);
            sizeCheckClear(LARGE);
            small = new Small(1213, FULL, Brushes.Gold, Brushes.White, Brushes.Black);
            large = new Large(7152, FULL, Brushes.Gold, Brushes.White, Brushes.Black);
            initalizeImage(SMALL);
            fillImage(SMALL);
            initalizeImage(LARGE);
            fillImage(LARGE);
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
