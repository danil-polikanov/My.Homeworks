using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    public class ImageFile : BasicFile
    {
        public Resolution Resolution { get; set; }

        public ImageFile(string Extension, string Size, string Resolution, string Name)
        {
            this.Type="Images";
            this.Extension = Extension;
            this.Size = new Size(Size);
            this.Resolution = new Resolution(Resolution);
            this.Name = Name;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\t{Name}\r\n");
            stringBuilder.Append($"\t\tExtension:{Extension}\r\n");
            stringBuilder.Append($"\t\tSize:{Size}\r\n");
            stringBuilder.Append($"\t\tResolution:{Resolution}\r\n");
            return stringBuilder.ToString();

        }

    }
}
