using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpAdbClient;

namespace ADBridge
{
	class DeviceHelper
	{
		private DeviceData device;
		private AdbClient client;

		public DeviceHelper(AdbClient c, DeviceData d)
		{
			client = c;
			device = d;
		}

		public void ExecuteADBShell(string command)
		{
			client.ExecuteRemoteCommand(command, device, null);
		}

		public Image GetScreenShot()
		{
			ExecuteADBShell("/system/bin/screencap -p /sdcard/screenshot.png");
			var service = new SyncService(device);
			var stream = new MemoryStream();
			service.Pull("/sdcard/screenshot.png", stream, null, System.Threading.CancellationToken.None);

			Bitmap img = new Bitmap(stream);
			stream.Dispose();

			return img;
		}

		public void Swipe(int x1,int y1,int x2,int y2,int time_ms)
		{
			ExecuteADBShell($"input swipe {x1} {y1} {x2} {y2} {time_ms}");
		}

		public void Swipe(int x,int y,int time_ms)
		{
			Swipe(x, y, x, y, time_ms);
		}
	}
}
