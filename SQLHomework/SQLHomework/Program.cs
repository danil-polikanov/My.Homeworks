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
            manager.Sorting_SecondTask();
            manager.JoinsFirstTask();
            manager.SixPointSix();
            manager.SevenPointOne();
            manager.SevenPointTwo();
            manager.SevenPointThree();

            Console.Read();
        }

    }
}
