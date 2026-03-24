using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1234
{
    public static class ConnectableExtensions
    {
        public static void ToggleConnection(this IConnectable device)
        {
            if (device.IsConnected)
                device.Disconnect();
            else
                device.Connect();
        }
    }
}
