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
            stringBuilder.AppendJoin(',', propertiesList);

            foreach (var person in personList)
            {
                stringBuilder.Append("\n");
                foreach (var propety in propertiesList)
                {

                    myPropertyInfo = myType.GetProperty(propety);
                    if (myPropertyInfo.GetValue(person) != null)
                    {
                        if (myPropertyInfo.GetValue(person).ToString().Contains(','))
                        {

                            stringBuilder.Append($"\"{myPropertyInfo.GetValue(person)}\"");

                        }
                        else { stringBuilder.Append(myPropertyInfo.GetValue(person, null)); }
                    }
                    else { stringBuilder.Append(myPropertyInfo.GetValue(person, null)); }
                  
                    stringBuilder.Append(',');
                }

            }


            using (var file = new StreamWriter(filename))
            {
                file.Write(stringBuilder.ToString());
            }
        }


    }
}

