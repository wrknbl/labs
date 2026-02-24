using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1234
{
    public class Scanner : Device
    {
        private int _resolution;
        public Scanner(string name, int resolution) : base(name)
        {
            _resolution = resolution;
        }
        public int Resolution
        {
            get { return _resolution; }
            set { _resolution = value; }
        }
        public override void Connect()
        {
            base.Connect();
            Log("Сканер готов к работе.");
        }
        public override void Disconnect()
        {
            base.Disconnect();
            Log("Сканер отключён от сети.");
        }
        public override string GetInfo()
        {
            return $"Сканер: {Name}, ID: {Id}, Разрешение: {Resolution} dpi";
        }
    }
}
