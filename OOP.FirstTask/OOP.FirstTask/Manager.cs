using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.FirstTask
{
    public class Manager
    {
        public string text { get; set; }
        public List<BasicFile> FileList;
        public Dictionary<string, IParser> Parsers;


        public Manager(string ParsingText)
        {
            this.text = ParsingText;
            FileList = new List<BasicFile>();
            Parsers = new Dictionary<string, IParser>();
        }
        public void AddParser(string type,IParser name)
        {
            Parsers.Add(type, name);
        }

        public void WriteConsole()
        {
            string type = "";
            foreach(var file in FileList)
            {
                string result = file.GetType().ToString().Split('.').LastOrDefault();
                if (type != result)
                {
                    type = result;
                    Console.WriteLine($"{type}:");
                }
                Console.WriteLine(file.ToString());
            }
        }
        public void Parse()
        {
            string[] files = text.Split('\n');
            foreach(string file in files)
            {
                string[] type = file.Split(':');
                FileList.Add(Parsers[type[0].Trim()].Parse(type[1]));
              
            }
        }
        public void Sort()
        {
            var res = (from item in FileList
                       orderby item.size
                       group item
                       by item.name).ToList();
            var newList = new List<BasicFile>();
            foreach(var group in res)
            {
                foreach (BasicFile file in group)
                {
                    newList.Add(file);
                }
            }
            FileList = newList;
        }
    }
}
