
namespace SandClock
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(24, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 135);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start/\r\nPause";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 125;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Items.AddRange(new object[] {
            "Small",
            "Large"});
            this.listBox1.Location = new System.Drawing.Point(41, 289);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(173, 66);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.AllowDrop = true;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 31;
            this.listBox2.Items.AddRange(new object[] {
            "White",
            "Black",
            "Red"});
            this.listBox2.Location = new System.Drawing.Point(44, 789);
            this.listBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(170, 97);
            this.listBox2.TabIndex = 5;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 31;
            this.listBox4.Items.AddRange(new object[] {
            "1 min",
            "5 min",
            "10 min",
            "20 min",
            "40 min"});
            this.listBox4.Location = new System.Drawing.Point(48, 925);
            this.listBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(161, 159);
            this.listBox4.TabIndex = 7;
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox4_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 36);
            this.label3.TabIndex = 8;
            this.label3.Text = "Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 887);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 36);
            this.label4.TabIndex = 9;
            this.label4.Text = "Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 750);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 36);
            this.label5.TabIndex = 10;
            this.label5.Text = "Edge";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 31;
            this.listBox3.Items.AddRange(new object[] {
            "Black",
            "White",
            "Honey Dew"});
            this.listBox3.Location = new System.Drawing.Point(48, 649);
            this.listBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(161, 97);
            this.listBox3.TabIndex = 11;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 611);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 36);
            this.label6.TabIndex = 12;
            this.label6.Text = "Background";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(262, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(776, 1083);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 1083);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.ItemHeight = 31;
            this.listBox5.Items.AddRange(new object[] {
            "Half",
            "Full"});
            this.listBox5.Location = new System.Drawing.Point(44, 399);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(170, 66);
            this.listBox5.TabIndex = 14;
            this.listBox5.SelectedIndexChanged += new System.EventHandler(this.listBox5_SelectedIndexChanged_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 36);
            this.label7.TabIndex = 15;
            this.label7.Text = "Level";
            // 
            // listBox6
            // 
            this.listBox6.FormattingEnabled = true;
            this.listBox6.ItemHeight = 31;
            this.listBox6.Items.AddRange(new object[] {
            "Blue",
            "Gold",
            "Pink"});
            this.listBox6.Location = new System.Drawing.Point(48, 508);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(166, 97);
            this.listBox6.TabIndex = 16;
            this.listBox6.SelectedIndexChanged += new System.EventHandler(this.listBox6_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(42, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 36);
            this.label8.TabIndex = 17;
            this.label8.Text = "Sand";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightPink;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(24, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 86);
            this.button2.TabIndex = 18;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1068, 1112);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBox5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1100, 1200);
            this.Name = "Form1";
            this.Text = "Hour Glass";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
    }
}

