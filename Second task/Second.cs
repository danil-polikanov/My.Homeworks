using System;
using System.Threading;

namespace Second_task
{
    class Second
    {
        static object locker = new object();
        static object locker1 = new object();
        static int[] mass = new int[1000];
        static int[] tempMass;
        static Random random = new Random();
        static void Main(string[] args)
        {
            Range range = new Range();
            range.start = 200;
            range.end = 500;
            tempMass = new int[range.end - range.start];
            Thread MyThread1 = new Thread(ArrayInit);
            Thread MyThread2 = new Thread(new ParameterizedThreadStart(MakeTempMass));
            Thread MyThread3 = new Thread(ArrayShow);
            MyThread1.Start();
            MyThread2.Start(range);
            MyThread3.Start();
        }
        public static void ArrayInit()
        {
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = random.Next(0, 1000);

            }
        }
        public static void MakeTempMass(object obj)
        {
            lock (locker1)
            {
                Range temp = (Range)obj;
                for (int i = temp.start, j = 0; i < temp.end; i++, j++)
                {
                    tempMass[j] = mass[i];
                }
            }
        }
        public static void ArrayShow()
        {
            lock (locker)
            {
                for (int i = 0; i < tempMass.Length; i++)
                {
                    Console.WriteLine(tempMass[i]);
                }
            }
        }
        public class Range
        {
            public int start;
            public int end;
        }
    }
}
