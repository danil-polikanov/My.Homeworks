using System;
using System.Linq;

namespace Linq_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Выведите все числа от 10 до 50 через запятую.");
            Numbers();
            Console.WriteLine("2. Выведите только те числа от 10 до 50, которые можно разделить на 3.");
            NumbersByThree();
            Console.WriteLine("3. Выведите слово «Linq» 10 раз.");
            ShowLinqTen();
            Console.WriteLine("4. Вывести все слова с буквой «а» в строку «aaa; abb; ccc; dap».");
            WordWithA();
            Console.WriteLine("5. Выведите количество букв «а» в словах с этой буквой в строке «aaa; abb; ccc; dap» через запятую.");
            CountWordWithA();
            Console.WriteLine("6. Выведите true, если слово «abb» существует в строке «aaa; xabbx; abb; ccc; dap», в противном случае - false.");
            TrueOrFalse();
            Console.WriteLine("7. Найдите самое длинное слово в строке «aaa; xabbx; abb; ccc; dap».");
            LongWord();
            Console.WriteLine("8. Вычислить среднюю длину слова в строке «aaa; xabbx; abb; ccc; dap».");
            AverageLength();
            Console.WriteLine("9. Выведите самое короткое слово в перевернутом виде в строке «aaa; xabbx; abb; ccc; dap; zh»..");
            ShortReverse();
            Console.WriteLine("10. Выведите true, если в первом слове, начинающемся с «aa», все буквы - «b», в противном случае - false «baaa; aabb; aaa; xabbx; abb; ccc; dap; zh».");
            CheckWordForBB();
            Console.WriteLine("11.Выведите последнее слово в последовательности, за исключением первых двух элементов, заканчивающихся на «bb».");
            LastWordEndWithBB();
        }

        static void Numbers()
        {
            Console.WriteLine($"Числа: {string.Join(",", Enumerable.Range(10, 41))}");
        }
        static void NumbersByThree()
        {
            Console.WriteLine($"Числа: {string.Join(",", Enumerable.Range(10, 41).Where(x => x % 3 == 0))}");
        }
        static void ShowLinqTen()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("Linq", 10)));
        }
        static void WordWithA()
        {
            string text = "aaa; abb; ccc; dap";
            Console.WriteLine(String.Join(',', text.Split("; ").Where(x => x.Contains('a'))));
        }
        static void CountWordWithA()
        {
            string text = "aaa; abb; ccc; dap";
            char a = 'a';
            Console.WriteLine(String.Join(',', text.Split("; ").Where(x => x.Contains('a')).Select(x => x.Count('a'.Equals))));
        }
        static void TrueOrFalse()
        {
            string text = "aaa; xabbx; abb; ccc; dap";
            Console.WriteLine($"{text.Split("; ").Contains("abb")}");
        }
        static void LongWord()
        {
            string text = "aaa; xabbx; abb; ccc; dap");
            Console.WriteLine(text.Split("; ").Where(x => x.Length == text.Split("; ").Max(x => x.Length)).FirstOrDefault());
        }
        static void AverageLength()
        {
            string text = "aaa; xabbx; abb; ccc; dap";
            Console.WriteLine(text.Split("; ").Average(x => x.Length));
        }
        static void ShortReverse()
        {
            string text = "aaa; xabbx; abb; ccc; dap; zh";
            Console.WriteLine(new String(text.Split("; ").
                Where(x => x.Length == text.Split("; ").Min(x => x.Length)).FirstOrDefault().Reverse().ToArray()));
        }
        static void CheckWordForBB()
        {
            string text = "baaa; aabb; aaa; xabbx; abb; ccc; dap; zh";
            string[] separeted = text.Split("; ");
            Console.WriteLine(text.Split("; ").First(y => y.StartsWith("aa")).Skip(2).All(y => y == 'b'));
        }
        static void LastWordEndWithBB()
        {
            string text = "baaa; aabb; aaa; xabbx; abb; ccc; dap; zh";
            Console.WriteLine(text.Split("; ").Where(x => x.EndsWith("bb")).Take(2).LastOrDefault());
        }
    }

}
