using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab1234
{
    public abstract class Device : IConnectable
    {
        private string _name;
        private readonly int _id;
        private static int _nextId = 1;
        protected bool _isConnected;

        public Device(string name)
        {
            _name = name;
            _id = _nextId++;
            _isConnected = false;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value ?? "Unknown"; }
        }
        public int Id => _id;
        public bool IsConnected => _isConnected;

        public virtual void Connect()
        {
            _isConnected = true;
            Console.WriteLine($"[{GetType().Name}] {Name} подключён.");
        }

        public virtual void Disconnect()
        {
            _isConnected = false;
            Console.WriteLine($"[{GetType().Name}] {Name} отключён.");
        }

        public abstract string GetInfo();

        protected void Log(string message)
        {
            Console.WriteLine($"LOG ({GetType().Name}): {message}");
        }
    }
}
