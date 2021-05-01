using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    public class TextParse:IParser
    {
        
        public BasicFile Parse(string text)
        {
            //file.txt(6B);Some string content
            string[] firstResult = text.Split(';', '(', ')');
            string[] secondResult = firstResult[0].Split('.');
            TextFile textFile = new TextFile(secondResult.LastOrDefault(), firstResult[1], firstResult[3].Trim(), firstResult[0]);
            return textFile;
        }
    }
}
