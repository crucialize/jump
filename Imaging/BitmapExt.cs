using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Imaging
{
	public static class BitmapExt
	{
		public static Bitmap CrossMark(this Bitmap p,int px,int py,int length,int hwidth,Color c)
		{
			for(var x = px - hwidth; x <= px + hwidth; x++)
			{
				//   |
				for (var y = py - length; y <= py + length; y++)
				{
					try
					{
						p.SetPixel(x, y, c);
					}
					catch { }
				}
			}

			for(var y = py - hwidth; y <= py + hwidth; y++)
			{
				//   ------
				for (var x = px - length; x <= px + length; x++)
				{
					try
					{
						p.SetPixel(x, y, c);
					}
					catch { }
				}
					
			}

			//p.Save(@"C:\Users\chenj\Desktop\1.jpg");
			return p;
		}
	}
}
