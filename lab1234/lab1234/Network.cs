using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1234
{
    public class Network<T> where T : IConnectable
    {
        private List<T> _devices;
        private static int _totalDevicesInAllNetworks = 0;

        public Network(IEnumerable<T> devices)
        {
            _devices = new List<T>(devices);
            _totalDevicesInAllNetworks += _devices.Count;
        }

        public static int TotalDevicesInAllNetworks => _totalDevicesInAllNetworks;

        public void ConnectAll()
        {
            Console.WriteLine($"\nПодключение всех устройств в сети (всего {_devices.Count})");
            foreach (var device in _devices)
            {
                if (!device.IsConnected)
                    device.Connect();
                else
                    Console.WriteLine($"Устройство {device} уже подключено.");
            }
        }

        public void DisconnectAll()
        {
            Console.WriteLine($"\nОтключение всех устройств в сети");
            foreach (var device in _devices)
            {
                if (device.IsConnected)
                    device.Disconnect();
                else
                    Console.WriteLine($"Устройство {device} уже отключено.");
            }
        }

        public List<T> GetConnectedDevices()
        {
            return _devices.Where(d => d.IsConnected).ToList();
        }

        public void PrintAllDevicesInfo()
        {
            Console.WriteLine($"\nИнформация об устройствах в сети (всего {_devices.Count})");
            foreach (var device in _devices)
            {
                Console.WriteLine(device is Device d ? d.GetInfo() : device.ToString());
            }
        }
    }
}
