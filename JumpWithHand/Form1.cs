using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADBridge;
using Algorithm.Imaging;
using Algorithm;
using System.Threading;

namespace JumpWithHand
{
	public partial class Form1 : Form
	{
		DeviceHelper A;

		public Form1()
		{
			InitializeComponent();
			var adb = new Bridge("c:/adb/adb.exe");
			var device = adb.GetDevices()[0];
			A = new DeviceHelper(adb.client, device);
			button1_Click(null, null);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			clear();
			var img = (Bitmap)A.GetScreenShot();
			var ratio = (double)img.Width / img.Height;

			int height2 = pictureBox1.Height;
			int width2 = (int)(ratio * height2);

			var timg = img.GetThumbnailImage(width2, height2, null,IntPtr.Zero);

			pictureBox1.Width = width2;
			//img.GetThumbnailImage()
			pictureBox1.Image = timg;
			original = (Bitmap)timg.Clone();
		}

		int state = 0;
		Point StartPoint = new Point();
		Point EndPoint = new Point();

		Bitmap original = null;

		void clear()
		{
			pictureBox1.Image = original;
			state = 0;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (state == 2)
				return;

			var em = (MouseEventArgs)e;
			int x = em.X, y = em.Y;
			var pic = (Bitmap)pictureBox1.Image;
			pic.CrossMark(x, y, 10,1, Color.Gold);
			pictureBox1.Image = pic;//update

			if (state == 0)
			{
				state = 1;
				StartPoint = em.Location;
				return;
			}
			if (state == 1)
			{
				state = 2;
				EndPoint = em.Location;
				return;
			}

		}

		private void button2_Click(object sender, EventArgs e)
		{
			clear();
		}

		double factor = 5.2;//TODO:二分

		private void button3_Click(object sender, EventArgs e)
		{
			double
				x1 = StartPoint.X,
				y1 = StartPoint.Y,
				x2 = EndPoint.X,
				y2 = EndPoint.Y;

			double k = Math.Sqrt(3) / 3.0;

			if (x1 > x2)
				k = -k;

			double dist = GeoAlgorithm.Dist(x1, y1, x2, y2, k);
			int time = (int)(dist * factor);

			var r = new Random();
			int x = r.Next(500, 600); //TODO:Percent%
			int y = r.Next(500, 700);

			A.Swipe(x, y, time);
			clear();
			Thread.Sleep(1800);

			button1_Click(null, null);
		}
	}
}
