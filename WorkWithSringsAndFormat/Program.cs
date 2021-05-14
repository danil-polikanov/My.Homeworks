using System;
using System.Globalization;

namespace WorkWithSringsAndFormat
{
    class Program
    {
        static void Main(string[] args)
        {   //1
            ////string text = "Привет 123ппавіпу6ф46";
            ////ReturnNubmer(text);
            ////void ReturnNubmer(string text)
            ////{
            ////    char[] texter = text.ToCharArray();
            ////    for (int i = 0; i < texter.Length; i++)
            ////    {
            ////        if (char.IsDigit(texter[i]))
            ////        {
            ////            Console.WriteLine(texter[i]);
            ////        }
            ////    }
            ////}
            ////2
            ////double firstNum = 70;
            ////double secondNum = 35.65;
            ////DivisionOfNumbers(firstNum, secondNum);
            ////void DivisionOfNumbers(double firstNum, double secondNum)
            ////{
            ////    double result = firstNum / secondNum;
            ////    string answer = string.Format("{0:F2}", result);
            ////    Console.WriteLine(answer);
            ////}
            ////3
            ////Console.WriteLine("Введите число");
            ////int value = int.Parse(Console.ReadLine());
            ////ExponentialForm(value);
            ////void ExponentialForm(int value)
            ////{
            ////    string expString = value.ToString("E", CultureInfo.InvariantCulture);
            ////    Console.WriteLine(expString);
            ////}
            ////4
            ////DateTimeIso();
            ////void DateTimeIso()
            ////{
            ////    Console.WriteLine(DateTime.Now.ToString("G"));
            ////}
            //5
            string Date = "2016 21-07";
            string[] FirstDate = Date.Split('-',' ');
            FirstDate[0] = FirstDate[0] + '.';
            FirstDate[1] = FirstDate[1];
            FirstDate[2] = FirstDate[2].Remove(0, 0) + '.';

            Date = (FirstDate[0]+FirstDate[2]+FirstDate[1]).ToString();
            
            DateTime date = new DateTime();
            date = DateTime.Parse(Date);

            Console.WriteLine(date);

        }
    }
}
