using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
   public class MovieParse:IParser
    {
        public BasicFile Parse(string text)
        {
            //logan.2017.mkv(19GB); 1920х1080; 2h12m”;
            string[] firstResult = text.Split(';', '(', ')');
            string[] secondResult = firstResult[0].Split('.');
            MovieFile movieFile = new MovieFile(secondResult.LastOrDefault(), firstResult[1], firstResult[3].Trim(), firstResult[0], firstResult[4].Trim());
            return movieFile;
        }
    }
}
