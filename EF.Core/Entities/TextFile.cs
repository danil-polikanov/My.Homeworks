using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Entities
{
    public class TextFile:File
    {
        public string Content { get; set; }
    }
}
