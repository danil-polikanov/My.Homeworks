using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    public class ImageParse : IParser
    {
        public BasicFile Parse(string text)
        {
            //img.bmp(19MB); 1920х1080
            string[]firstResult= text.Split(';', '(', ')');
            string[] secondResult = firstResult[0].Split('.');
            ImageFile imageFile = new ImageFile(secondResult.LastOrDefault(), firstResult[1].Trim(), firstResult[3].Trim(), firstResult[0]);
            return imageFile;
        }
    }
}
