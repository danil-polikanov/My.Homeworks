using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Entities
{
     public class ImageFile : File
    {
        public int Heigth { get; set; }
        public int Width { get; set; }
    }
}
