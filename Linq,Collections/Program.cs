using System;
using System.Linq;

namespace Linq_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1
            //Numbers();
            ////2
            //NumbersByThree();
            ////3
            //ShowLinqTen();
            //4
            //5
            //WordWithA();
            //6
            //TrueOrFalse();
            //7
            //LongWord();
            //8
            //AverageLength();
            //9
            //ShortReverse();
            //CheckWordForBB();
            LastWordEndWithBB();
        }

        static void Numbers()
        { 
            int[] array = Enumerable.Range(10, 41).ToArray();
            Console.WriteLine($"Числа: {string.Join(",", array)}");
        }
        static void NumbersByThree()
        {
            int[] array = Enumerable.Range(10,41).Where(x=>x%3==0).ToArray();
            Console.WriteLine($"Числа: {string.Join(",", array)}");
        }
        static void ShowLinqTen()
        {
            foreach (string s in Enumerable.Repeat("Linq", 10).Select((x, i) => $"{i + 1}:{x}"))
            {
                Console.WriteLine(s);
            }
        }
        static void WordWithA()
        {
            Console.WriteLine("Введите слова");
            string text=Console.ReadLine();
            string[] separeted = text.Split("; ");
            var result = from i in separeted where i.Contains("a") select i;
            string final = null;
            byte tnp = 1;
            foreach (var item in result)
            {
                final = string.Join(",", item).ToString();
                Console.WriteLine($"Слово с а номер {tnp}: {final}");
                tnp++;
            }

            foreach (var item in result)
            {
                char[] letters = item.ToCharArray();
                var letter = letters.Where(a => a == 'a');
                string.Join(",", letter);
                Console.Write($"{letter.Count()}");
                
                
            }  
        }
        static void TrueOrFalse() {
            Console.WriteLine("Введите слова");
            string text = Console.ReadLine();
            string[] separeted = text.Split("; ");
            foreach (var item in separeted)
            {
                Console.WriteLine($"{item.Contains("abb")}");
            }
        }

        static void LongWord()
        {
            Console.WriteLine("Введите слова");
            string text = Console.ReadLine();
            string[] separeted = text.Split("; ");
            string wordWithMaxLenght = string.Empty;
            foreach (var item in separeted)
            {
                if (item.Length > wordWithMaxLenght.Length)
                {
                    wordWithMaxLenght = item;
                }

            }
            Console.WriteLine($"{wordWithMaxLenght}");

        }
        static void AverageLength()
        {
            Console.WriteLine("Введите слова");
            string text = Console.ReadLine();
            string[] separeted = text.Split("; ");
            double res = 0;
            foreach (var item in separeted)
            {
                res =res+item.Count();
            }
            Console.WriteLine($"{res/separeted.Count()}");

        }
        static void ShortReverse()
        {
            Console.WriteLine("Введите слова");
            string text = Console.ReadLine();
            string[] separeted = text.Split("; ");
            string wordWithShortLenght = text;
            foreach (var item in separeted)
            {
                if (item.Length < wordWithShortLenght.Length)
                {
                    wordWithShortLenght = item;
                    wordWithShortLenght.Reverse().ToArray();
                }

            }
            Console.WriteLine($"{wordWithShortLenght}");
        }
        static void checkWordForBB()
        {
            Console.WriteLine("Введите слова");
            string text = Console.ReadLine();
            string[] separeted = text.Split("; ");

                Console.WriteLine(text.Split("; ").First(y => y.StartsWith("aa")).Skip(2).All(y => y == 'b'));
            
        }
        static void LastWordEndWithBB()
        {
            Console.WriteLine("Введите слова");
            string text = Console.ReadLine();

            Console.WriteLine(text.Split("; ").Where(x => x.EndsWith("bb")).Take(2).LastOrDefault());
        }
    }
   
}
