using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    public class Resolution
    {
       public int Height { get; private set;}
       public int Width { get; private set;}

       public Resolution(string text)
        {
            string[] result=text.Split('х');
            Width = int.Parse(result[0]);
            Height = int.Parse(result[1]);
            
        }

        public override string ToString()
        {
            return $"{Width}x{Height}";
        }
    }
}
