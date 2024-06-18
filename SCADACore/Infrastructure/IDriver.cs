using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADACore.Infrastructure
{
    internal interface IDriver
    {
        double ReadValue(int address);
    }
}
