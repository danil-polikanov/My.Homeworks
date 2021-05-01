using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
   public abstract class BasicFile
    {
        public string Name { get; set; }
        public Size Size { get; set; }
        public string Extension { get; set; }

        public string Type { get; set; }

    }
}
