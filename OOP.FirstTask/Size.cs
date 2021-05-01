using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    public class Size : IComparable<Size>
    {
        public enum Si { B,KB,MB,GB}
        public int Numbers { get; private set; }
        public Si Metric { get; private set; }

        public Size(string text)
        {
            Regex separator = new Regex(@"(\d+)([a-zA-Z]+)");
            Match result = separator.Match(text);

            Numbers = int.Parse(result.Groups[1].Value);
            Metric = (Si)Enum.Parse(typeof(Si),result.Groups[2].Value);

        }

        public override string ToString()
        {
            return $"{Numbers}{Enum.GetName(typeof(Si),Metric)}";
        }

        public int CompareTo(Size size)
        {
            if (this.Metric != size.Metric)
                return this.Metric - size.Metric;
            else return this.Numbers - size.Numbers;
           
        }

      
    }
}
