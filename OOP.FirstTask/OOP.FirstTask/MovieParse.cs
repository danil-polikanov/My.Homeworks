using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
   public class MovieParse:IParser
    {
        public BasicFile Parse(string text)
        {
            //logan.2017.mkv(19GB); 1920х1080; 2h12m”;
            string[] firstResult = text.Split(';', '(', ')');
            string[] secondResult= firstResult[0].Split('.');
            string[] thirdResult = firstResult[4].Split('h');
            thirdResult[1]=thirdResult[1].Trim('h','m');
            string lng = thirdResult[0].Trim() + ":"+thirdResult[1].Trim();
            DateTime lenght = DateTime.Parse(lng);
       
            MovieFile movieFile = new MovieFile(secondResult.LastOrDefault(), firstResult[1], firstResult[3].Trim(), firstResult[0], lenght);
            return movieFile;
        }
    //    Regex regex = new Regex("[0-9]{1}h[0-9]{2}m");
    //    MatchCollection result = regex.Matches(firstResult[4]);
    //        foreach (Match match in result) {
    //            thirdResult[0] = match.ToString();
    //        }
    //DateTime lenght = new DateTime(Convert.ToInt32(thirdResult[0]));
}
}
