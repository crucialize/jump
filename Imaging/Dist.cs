using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Algorithm
{
	public static class GeoAlgorithm
	{
		public static double Dist(double x1,double y1,double x2,double y2)
		{
			double dx = x1 - x2, dy = y1 - y2;
			return Sqrt(dx * dx + dy * dy);
		}

		public static double Dist(double x1,double y1,double x2,double y2,double k)
		{
			//y=kx+m
			double m1 = y1 - k * x1, m2 = y2 - k * x2;
			double d = Abs(m1 - m2) / Sqrt(k * k + 1);
			return d;
		}
	}
}
