using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1234
{
    public class NetworkRouter : Device
    {
        private string _wifiStandard;

        public NetworkRouter(string name, string wifiStandard) : base(name)
        {
            _wifiStandard = wifiStandard;
        }

        public string WifiStandard
        {
            get => _wifiStandard;
            set => _wifiStandard = value;
        }

        public override void Connect()
        {
            base.Connect();
            Log("Маршрутизатор подключён к сети.");
        }

        public override string GetInfo()
        {
            return $"Маршрутизатор: {Name}, ID: {Id}, Wi-Fi: {WifiStandard}";
        }

        public override string ToString() => GetInfo();
    }
}
