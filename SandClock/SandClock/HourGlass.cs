using System.Collections.Generic;
using System.Linq;
using System.Drawing;


namespace SandClock
{
	public abstract class HourGlass
	{
		private string name;
		private int pixels;
		private int time;
		private int fillLevel;
		private Brush formColor;
		private List<Pixel> hourGlass = new List<Pixel>();

		private int timeZ { get; set; }

		public abstract int bitIMGCount();
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


		public string getName()
		{
			return name;
		}
		private void setName(string name)
		{
			this.name = name;
		}

		public int getPixelCount()
		{
			return pixels;
		}
		private void setPixelCount(int pixels)
		{
			this.pixels = pixels;
		}

		public Brush getFormColor()
		{
			return formColor;
		}
		public void setFormColor(Brush formColor)
		{
			this.formColor = formColor;
		}


		//non abstract methods
		public void setTime(int time)
		{
			this.time = time;
		}
		public int getTime()
		{
			return time;
		}
		public int getFillLevel()
		{
			return fillLevel;
		}
		public void setFillLevel(int fillLevel)
		{
			this.fillLevel = fillLevel;
		}

		public void insertHourGlassIMG(int pos, Pixel pixel)
		{
			hourGlass.Insert(pos, pixel);
		}

		public void removeHourGlassIMG(int pos)
		{
			hourGlass.RemoveAt(pos);
		}

		public Pixel getHourGlassIMG(int pos)
		{
			return hourGlass.ElementAt(pos);
		}

		public List<Pixel> getHourGlassIMGall()
		{
			return hourGlass;
		}
		public int getHourGlassSize()
		{
			return hourGlass.Count();
		}


	}
}