using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    class MovieFile: BasicFile
    {
       public string Resolution { get; set; }
       public string Length { get; set;}

        public MovieFile(string Extension, string Size, string Resolution, string Name, string Length)
        {
            this.Type = "Movies";
            this.Extension = Extension;
            this.Size = new Size(Size);
            this.Resolution = Resolution;
            this.Name = Name;
            this.Length = Length;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\t{Name}\r\n");
            stringBuilder.Append($"\t\tExtension:{Extension}\r\n");
            stringBuilder.Append($"\t\tSize:{Size}\r\n");
            stringBuilder.Append($"\t\tResolution:{Resolution}\r\n");
            stringBuilder.Append($"\t\tLength:{Length}\r\n");
            return stringBuilder.ToString();

        }
    }
}
