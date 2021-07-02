using System;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkWithThreads
{

    class Program
    {
        static int[] mass = new int[100];
        static Random random = new Random();
        static object locker = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("The number of processors " + "on this computer is {0}.", Environment.ProcessorCount);
            Thread MyThread1 = new Thread(new ParameterizedThreadStart(ArrayInit));
            Thread MyThread2 = new Thread(new ParameterizedThreadStart(ArrayInit));
            Thread MyThread3 = new Thread(new ParameterizedThreadStart(ArrayInit));
            Thread MyThread4 = new Thread(ArrayShow);
            Counter first = new Counter(0, mass.Length / 3);
            Counter second = new Counter(mass.Length / 3, mass.Length / 2);
            Counter third = new Counter(mass.Length / 2, mass.Length);
            MyThread1.Start(first);
            MyThread2.Start(second);
            MyThread3.Start(third);
            MyThread4.Start();
        }
        public static void ArrayInit(object obj)
        {
            Counter temp = (Counter)obj;
            for (int i = temp.x; i < temp.y; i++)
            {
                mass[i] = random.Next(0, 1000);

            }
        }
        public static void ArrayShow()
        {
            lock (locker)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    Console.WriteLine(mass[i]);
                }
            }
        }
    }
    public class Counter
    {
        public int x;
        public int y;
        public Counter(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

    }
}
