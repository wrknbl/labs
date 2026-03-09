using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1234
{
    public interface IConnectable
    {
        bool IsConnected { get; }
        void Connect();
        void Disconnect();
    }
}
