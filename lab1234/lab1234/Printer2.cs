using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1234
{
    public class Printer2 : Device
    {
        private string _printType;
        public Printer2(string name, string printType) : base(name)
        {
            _printType = printType;
        }
        public string PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }
        public override void Connect()
        {
            base.Connect();  
            Log("Принтер готов к печати.");
        }
        public override void Disconnect()
        {
            base.Disconnect();
            Log("Принтер отключён от сети.");
        }
        public override string GetInfo()
        {
            return $"Принтер: {Name}, ID: {Id}, Тип печати: {PrintType}";
        }
    }
}
