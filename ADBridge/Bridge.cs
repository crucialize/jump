using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpAdbClient;

namespace ADBridge
{
    public class Bridge
    {
		public AdbClient client;

		public Bridge(string ADBPath)
		{
			AdbServer.Instance.StartServer(ADBPath, false);
			client = new AdbClient();
		}

		public List<DeviceData> GetDevices()
		{
			return client.GetDevices();
		}
    }
}
