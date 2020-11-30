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
		private int seconds;
		private Brushes edgeColor;
		private Brushes sandColor;
		List<Pixel> hourGlass = new List<Pixel>();


		public abstract int pixlesRemaining();


		public HourGlass()
		{
		}
		public HourGlass(string name, int seconds)// Brushes sandColor, Brushes edgeColor)
		{
			setName(name);
			setSeconds(seconds);
			setSandColor(sandColor);
			setEdgeColor(edgeColor);
		}

		public string getName()
		{
			return this.name;
		}
		public void setName(string name)
		{
			this.name = name;
		}

		public int getSeconds()
		{
			return this.seconds;
		}
		public void setSeconds(int seconds)
		{
			this.seconds = seconds;
		}

		public Brushes getSandColor()
		{
			return this.sandColor;
		}
		public void setSandColor(Brushes sandColor)
		{
			this.sandColor = sandColor;
		}

		public Brushes getEdgeColor()
		{
			return this.edgeColor;
		}
		public void setEdgeColor(Brushes edgeColor)
		{
			this.edgeColor = edgeColor;
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
	}
}