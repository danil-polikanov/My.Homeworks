using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    class MovieFile: BasicFile
    {
       public string resolution { get; set; }
       public string length { get; set;}

        public MovieFile(string extension, string size, string resolution, string name, string length)
        {
            this.type = "Movies";
            this.extension = extension;
            this.size = new Size(size);
            this.resolution = resolution;
            this.name = name;
            this.length = length;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\t{name}\r\n");
            stringBuilder.Append($"\t\tExtension:{extension}\r\n");
            stringBuilder.Append($"\t\tSize:{size}\r\n");
            stringBuilder.Append($"\t\tResolution:{resolution}\r\n");
            stringBuilder.Append($"\t\tLength:{length}\r\n");
            return stringBuilder.ToString();

        }
    }
}
