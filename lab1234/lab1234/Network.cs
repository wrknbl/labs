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

        public Network()
        {
            _devices = new List<T>();
        }

        public static int TotalDevicesInAllNetworks => _totalDevicesInAllNetworks;

        public void ConnectAll()
        {
            Console.WriteLine($"\n--- Подключение всех устройств в сети (всего {_devices.Count}) ---");
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
            Console.WriteLine($"\n--- Отключение всех устройств в сети ---");
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
            Console.WriteLine($"\n--- Информация об устройствах в сети (всего {_devices.Count}) ---");
            foreach (var device in _devices)
            {
                Console.WriteLine(device is Device d ? d.GetInfo() : device.ToString());
            }
        }

        public Network<T> AddDevice(T device)
        {
            var newList = new List<T>(_devices) { device };
            return new Network<T>(newList);
        }

        public Network<T> RemoveDevice(T device)
        {
            var newList = new List<T>(_devices);
            newList.Remove(device);
            return new Network<T>(newList);
        }

        public Network<T> Intersect(Network<T> other)
        {
            var common = _devices.Intersect(other._devices).ToList();
            return new Network<T>(common);
        }

        public static Network<T> operator +(Network<T> network, T device)
        {
            return network.AddDevice(device);
        }

        public static Network<T> operator -(Network<T> network, T device)
        {
            return network.RemoveDevice(device);
        }

        public static Network<T> operator &(Network<T> a, Network<T> b)
        {
            return a.Intersect(b);
        }
    }
}
