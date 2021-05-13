using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConverterToCsv
{
    public class Converter
    {
        public List<Person> personList;
        public List<string> propertiesList;

        public Converter(List<Person> list)
        {
            personList = list;
            propertiesList = new List<string>();

        }
        public void Convert(string properties, string filename = "ListOfPerson.csv")
        {
            Type myType = typeof(Person);
            var separated = properties.Split(',');

            foreach (var property in separated)
            {
                propertiesList.Add(property.Trim());
            }

            PropertyInfo myPropertyInfo = null;


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("sep=,\n");
            //var filted = personList.(x => myPropertyInfo.GetValue(x, null));
            foreach (var i in propertiesList)
            {
                if (propertiesList.LastIndexOf(i) != propertiesList.Count - 1)
                {
                    stringBuilder.Append(i + ',');
                }

                else
                {
                    stringBuilder.Append(i);

                    //if (propertiesList.LastIndexOf(i) == propertiesList.Count - 1)
                    //{
                    //    stringBuilder.Append("\n");
                    //}
                }


            }

            foreach (var u in personList)
            {
                stringBuilder.Append("\n");
                foreach (var z in propertiesList)
                {

                    myPropertyInfo = myType.GetProperty(z);
                    if (myPropertyInfo.GetValue(u) != null)
                    {
                        if (myPropertyInfo.GetValue(u).ToString().Contains(','))
                        {

                            stringBuilder.Append($"\"{myPropertyInfo.GetValue(u)}\"");

                        }
                        else { stringBuilder.Append(myPropertyInfo.GetValue(u, null)); }
                    }
                    //stringBuilder.Append(',');

                    else { stringBuilder.Append(myPropertyInfo.GetValue(u, null)); }
                    //if (personList.LastIndexOf(u) != personList.Count - 1)
                    //{
                    //    stringBuilder.Append(',');
                    //}
                    stringBuilder.Append(',');
                    //else
                    //{
                    //    stringBuilder.Append("\n");
                    //}

                }

            }


            using (var file = new StreamWriter(filename))
            {
                file.Write(stringBuilder.ToString());
            }
        }


    }
}

