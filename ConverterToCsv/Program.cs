using System;
using System.Reflection;

namespace ConverterToCsv
{
    class Program
    {
        static void Main(string[] args)
       { 
            Type myType = typeof(Person);
;
            var listOfPerson = PersonList.GetListPerson();
            Converter generate = new Converter(listOfPerson);
            //myPropertyInfo = myType.GetProperty(Person);
            Console.WriteLine("Какие поля хотите сохранить?");
           
            foreach (PropertyInfo u in myType.GetProperties())
            {
                Console.WriteLine($"{u.Name}");
            }
            string properties = Console.ReadLine();
            generate.Convert(properties);
        }
    }
}
