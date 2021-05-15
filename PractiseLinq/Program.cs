using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PractiseLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
            new Customer(1, "Tawana Shope", new DateTime(2017, 7, 15), 15.8),
            new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
            new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
            new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
            new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
            new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
            new Customer(7, "Silvia Stefano", new DateTime(2017, 7, 15), 40),
            new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
            new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
            new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
            new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
            new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
            new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
            new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
            new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
            new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
            new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
            new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
            new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
            new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
            };

          
            //1
            var firstDatedPerson = customers.OrderBy(x => x.RegistrationDate).FirstOrDefault();
            Console.WriteLine("Первое задание;");
            Console.WriteLine($"Пользователь,который зарегистрировался раньше всех :{firstDatedPerson.Name}");
            //2
            Console.WriteLine(AverageBalance(customers));
            //3
            FilterByDate(customers, customers[5].RegistrationDate, customers[9].RegistrationDate);
            //4
            FilterById(customers, customers[5].Id, customers[7].Id);
            //5
            Console.WriteLine("Введите часть имени потребителей");
            string name = Console.ReadLine();
            FilterByName(customers, name);
            //6
            FilterByMonth(customers);
            //7
            Console.WriteLine("Введите по какому полю сортировать");
            string property = Console.ReadLine();
            Console.WriteLine("Введите направление текстом:\"ascending\" or \"descending\"");
            string choice = Console.ReadLine();
            FilterByType(customers, property, choice);
            //8
            GetNames(customers);




        }
        static double AverageBalance(List<Customer> customers)
        {
            Console.WriteLine("Второе задание;");
            Console.WriteLine($"Среднее арифмитическое всех балансов:");
            return customers.Average(x => x.Balance);
        }


        static void FilterByDate(List<Customer> customers, DateTime start, DateTime end)
        {
            Console.WriteLine("Третье задание:");
            Console.WriteLine("Список потребителей по определенной дате:");
            var result = from u in customers
                         where u.RegistrationDate >= start && u.RegistrationDate <= end
                         select u;
            if (!result.Any())
                Console.WriteLine("No result");
            else
                foreach (var s in result)
                {
                    Console.WriteLine($"Id:{s.Id}Name:{s.Name};RegistrationDate:{s.RegistrationDate}");
                }
        
        }
        static void FilterById(List<Customer> customers, long start, long end)
        {
            Console.WriteLine("Четвертое задание:");
            Console.WriteLine("Фильтр потребителей по айди от (x,y)");
            var result = from u in customers
                         where u.Id >= start && u.Id <= end
                         select u;
            foreach (var s in result)
                Console.WriteLine($"Id:{s.Id};Name:{s.Name}");
        }
        static void FilterByName(List<Customer> customers, string name)
        {
            Console.WriteLine("Пятое задание:");
            Console.WriteLine("Фильтр потребителей по части имени");
            var sortByName = from u in customers
                             where u.Name.ToString().ToUpper().StartsWith(name.ToUpper())
                             orderby u.Name descending
                             select u;
            foreach (var s in sortByName)
            {
                Console.WriteLine($"Id:{s.Id};Name:{s.Name}");
            }
        }
        static void FilterByMonth(List<Customer> customers)
        {
            Console.WriteLine("Шестое задание:");
            Console.WriteLine("Фильтр потребителей по хронологии и имени");
            var filtByMonth = customers.
            OrderBy(x => x.RegistrationDate.Month).ThenBy(x => x.Name).
            GroupBy(x => x.RegistrationDate.Month);

            foreach (IGrouping<int, Customer> g in filtByMonth)
            {
                Console.WriteLine($"Registration month:{g.Key}\n");
                foreach (var t in g)
                {
                    Console.WriteLine($"Name:{t.Name}");
                }
            }
        }
        static void FilterByType(List<Customer> customers, string property, string choice)
        {
            Console.WriteLine("Седьмое задание:");
            Console.WriteLine("Фильтр потребителей по заданому имени и полю");
            Type myType = typeof(Customer);

            PropertyInfo myPropertyInfo;
            myPropertyInfo = myType.GetProperty(property);
            switch (choice)
            {
                case "ascending":
                    var filtedByAscending
          = customers.OrderBy
          (x => myPropertyInfo
          .GetValue(x, null));

                    foreach (var u in filtedByAscending)
                        Console.WriteLine($"Name:{u.Name}");
                    ; break;

                case "descending":
                    var filtedByDescending
                        = customers.OrderByDescending
                        (x => myPropertyInfo
                        .GetValue(x, null));

                    foreach (var u in filtedByDescending)
                        Console.WriteLine($"Name:{u.Name}");
                    ; break;
            }
        }

        static void GetNames(List<Customer> customers)
        {
            Console.WriteLine("Восьмое задание:");
            Console.WriteLine("Фильтр имена всех потребителей");
            Console.WriteLine(string.Join(", ", customers.Select(x => x.Name)));
        }

    }
}
