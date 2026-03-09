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
        private static int _totalDevicesInAllNetworks = 0; // статическое поле (лекция 3, стр. 2-5)

        public Network(IEnumerable<T> devices)
        {
            _devices = new List<T>(devices);
            _totalDevicesInAllNetworks += _devices.Count; // увеличиваем счётчик при создании сети
        }

        // Статическое свойство для доступа к счётчику
        public static int TotalDevicesInAllNetworks => _totalDevicesInAllNetworks;

        // Метод для подключения всех устройств
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

        // Метод для отключения всех устройств
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

        // Метод, возвращающий список подключённых устройств
        public List<T> GetConnectedDevices()
        {
            return _devices.Where(d => d.IsConnected).ToList();
        }

        // Для удобства выведем информацию о всех устройствах в сети
        public void PrintAllDevicesInfo()
        {
            Console.WriteLine($"\nИнформация об устройствах в сети (всего {_devices.Count})");
            foreach (var device in _devices)
            {
                // Поскольку T : IConnectable, но не обязательно Device, используем GetInfo если есть,
                // либо просто ToString. Для наших классов это сработает.
                Console.WriteLine(device is Device d ? d.GetInfo() : device.ToString());
            }
        }
    }
}
