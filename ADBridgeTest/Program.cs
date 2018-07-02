using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADBridge;

namespace ADBridgeTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var adb = new Bridge("C:/adb/adb.exe");
			var device = adb.GetDevices()[0];
			var helper = new DeviceHelper(adb.client, device);
			
			var img = helper.GetScreenShot();
			img.Save("1.png");
			

			//helper.Swipe(100, 100, 1000, 100, 2000);


		}
	}
}
