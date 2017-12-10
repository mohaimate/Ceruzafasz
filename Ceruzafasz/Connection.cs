using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceruzafasz
{
    static class Connection
    {
        public static SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
    }
}
