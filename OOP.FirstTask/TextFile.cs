using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    class TextFile: BasicFile
    {
        public string Content { get; set; }

        public TextFile(string Extension, string Size,string Content,string Name)
        {
            this.Type = "Text files";
            this.Extension = Extension;
            this.Size =new Size(Size);
            this.Content = Content;
            this.Name = Name;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\t{Name}\r\n");
            stringBuilder.Append($"\t\tExtension:{Extension}\r\n");
            stringBuilder.Append($"\t\tSize:{Size}\r\n");
            stringBuilder.Append($"\t\tContent:\"{Content}\"\r\n");
            return stringBuilder.ToString();

        }
    }
}
