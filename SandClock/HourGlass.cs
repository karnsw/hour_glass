using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SandClock
{
	public abstract class HourGlass
	{
		private string name;
		private int pixels;
		private int seconds;
		private int time;
		private int fillLevel;
		private Brush formColor;
		List<Pixel> hourGlass = new List<Pixel>();


		public abstract int bitmapCount();
		public abstract Bitmap refreshImage();
		public abstract Bitmap initalizeHourGlass();
		public abstract Bitmap addTime();
		public abstract void clearHourGlass();


		public HourGlass(string name, int pixels, Brush formColor)
		{
			setName(name);
			setPixelCount(pixels);
			setFormColor(formColor);
		}




		public Brush getFormColor()
		{
			return this.formColor;
		}
		public void setFormColor(Brush formColor)
		{
			this.formColor = formColor;
		}


		public int getfillLevel()
		{
			return this.fillLevel;
		}
		public void setFillLevel(int level)
		{
			this.fillLevel = level;
		}


		public string getName()
		{
			return this.name;
		}
		public void setName(string name)
		{
			this.name = name;
		}

		public int getPixels()
		{
			return this.pixels;
		}
		public void setPixelCount(int pixels)
		{
			this.pixels = pixels;
		}
		public int getSeconds()
		{
			return this.seconds;
		}
		public void setSecondsCount(int seconds)
		{
			this.seconds = seconds;
		}

		public void addHourGlass(int pos, Pixel pixel)
		{
			this.hourGlass.Insert(pos, pixel);
		}

		public void removeHourGlass(int pos)
		{
			this.hourGlass.RemoveAt(pos);
		}

		public Pixel getHourGlassIMG(int pos)
		{
			return this.hourGlass.ElementAt(pos);
		}

		public int getSize()
        {
			return this.hourGlass.Count();
        }

		public List<Pixel> getHourGlassIMGall()
		{
			return this.hourGlass;
		}


		public void setTime(int time)
		{
			this.time = time;
		}
		public int getTime()
		{
			return this.time;
		}
	}
}