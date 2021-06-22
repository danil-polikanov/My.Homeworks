using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            var first = manager.GetSortingTable_SecondTask();
            //manager.ShowTable(first);
            var second = manager.JoinsFirstTask();
            //manager.ShowTable(second);
            var third=manager.SixPointSix();
            //manager.ShowTable(third);
            var fourth=manager.SevenPointOne();
            //manager.ShowTable(fourth);
            var fifth=manager.SevenPointTwo();
            //manager.ShowTable(fifth);
            var six=manager.SevenPointThree();
            //manager.ShowTable(six);
            Console.Read();
        }

    }
}
