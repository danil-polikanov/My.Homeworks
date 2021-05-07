using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    public class ImageFile : BasicFile
    {
        public Resolution resolution { get; set; }

        public ImageFile(string extension, string size, string resolution, string name)
        {
            this.type="Images";
            this.extension = extension;
            this.size = new Size(size);
            this.resolution = new Resolution(resolution);
            this.name = name;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\t{name}\r\n");
            stringBuilder.Append($"\t\tExtension:{extension}\r\n");
            stringBuilder.Append($"\t\tSize:{size}\r\n");
            stringBuilder.Append($"\t\tResolution:{resolution}\r\n");
            return stringBuilder.ToString();

        }

    }
}
