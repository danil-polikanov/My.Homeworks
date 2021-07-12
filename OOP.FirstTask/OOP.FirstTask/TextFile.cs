using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    class TextFile: BasicFile
    {
        public string content { get; set; }

        public TextFile(string extension, string size,string content,string name)
        {
            this.extension = extension;
            this.size =new Size(size);
            this.content = content;
            this.name = name;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\t{name}\r\n");
            stringBuilder.Append($"\t\tExtension:{extension}\r\n");
            stringBuilder.Append($"\t\tSize:{size}\r\n");
            stringBuilder.Append($"\t\tContent:\"{content}\"\r\n");
            return stringBuilder.ToString();

        }
    }
}
