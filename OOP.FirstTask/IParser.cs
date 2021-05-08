using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    public interface IParser
    {
        abstract BasicFile Parse(string text);
    }
}
