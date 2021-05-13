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

            string name = "t";
            string ascending = "ascending";
            string descending = "descending";
            string property = "Name";
            //1
            var firstDatedPerson = customers.OrderBy(x => x.RegistrationDate).FirstOrDefault();
            Console.WriteLine(firstDatedPerson.Name);

            Console.WriteLine(AverageBalance(customers));

            FilterByDate(customers, customers[5].RegistrationDate, customers[9].RegistrationDate);
            FilterById(customers, customers[5].Id, customers[7].Id);
          
            FilterByName(customers, name);
            FilterByMonth(customers);

            FilterByType(customers, property, descending);
            GetNames(customers);
                
            
            //2
            double AverageBalance(List<Customer> customers)
            {
                return customers.Average(x => x.Balance);
            }
         
            //3
            void FilterByDate(List<Customer> customers, DateTime start, DateTime end)
            {
                var result = from u in customers
                             where u.RegistrationDate >= start && u.RegistrationDate <= end
                             select u;
                if (!result.Any())
                    Console.WriteLine("No result");
                else
                    foreach (var s in result)
                        Console.WriteLine($"Id:{s.Id}Name:{s.Name};RegistrationDate:{s.RegistrationDate}");
            }
           
            //4
            void FilterById(List<Customer> customers, long start, long end)
            {
                var result = from u in customers
                             where u.Id >= start && u.Id <= end
                             select u;
                foreach (var s in result)
                    Console.WriteLine($"Id:{s.Id};Name:{s.Name}");
            }
            FilterById(customers, customers[5].Id, customers[7].Id);

           //5
               void FilterByName(List<Customer> customers, string name)
            {
                var sortByName = from u in customers
                                 where u.Name.ToString().ToUpper().StartsWith(name.ToUpper())
                                 orderby u.Name descending
                                 select u;
                foreach (var s in sortByName)
                {
                    Console.WriteLine($"Id:{s.Id};Name:{s.Name}");
                }
            }
   
            //6
            void FilterByMonth(List<Customer> customers)
            {
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
     

            //7
            void FilterByType(List<Customer> customers, string property,string choice)
            {
                Type myType = typeof(Customer);

                PropertyInfo myPropertyInfo;
                myPropertyInfo = myType.GetProperty(property);
                switch (choice)
                {
                    case "ascending": var filtedByAscending
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

        
            FilterByType(customers, property, descending);
            //8
            void GetNames(List<Customer> customers)
            {
                Console.WriteLine(string.Join(", ", customers.Select(x => x.Name)));
                
            }
           



          
        }
    }
}
