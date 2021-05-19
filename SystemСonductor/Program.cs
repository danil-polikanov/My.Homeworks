using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SystemСonductor
{
    class Program
    {
        static void Main(string[] args)
        {
            LogicOfConductor logicOfConductor = new LogicOfConductor();
            logicOfConductor.Conduct();
        }
    }
}