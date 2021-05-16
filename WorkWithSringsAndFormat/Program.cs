using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace WorkWithSringsAndFormat
{
    class Program
    {
        static void Main(string[] args)
        {   //1]
            Console.WriteLine("Введите строку где есть цифры");
            string text =Console.ReadLine();
            ReturnNumber(text);

            ////2
            double firstNum = 70;
            double secondNum = 35.65;
            DivisionOfNumbers(firstNum, secondNum);

            //3

            string value = (Console.ReadLine());

            ExponentialForm1(value);

            //4
            DateTimeIso();

            string Date = "2016 21-07";
            string[] FirstDate = Date.Split('-', ' ');
            FirstDate[0] = FirstDate[0] + '.';
            FirstDate[1] = FirstDate[1];
            FirstDate[2] = FirstDate[2].Remove(0, 0) + '.';

            Date = (FirstDate[0] + FirstDate[2] + FirstDate[1]).ToString();
            //5
            DateTime date = new DateTime();
            date = DateTime.Parse(Date);

            Console.WriteLine(date);

            //6
            Console.WriteLine("Введите числа через запятую");
            string textNumbers = Console.ReadLine();
            Console.WriteLine(Sum(textNumbers));
            //7
            Console.WriteLine("Введите текст");
            string someText = Console.ReadLine();
            //8
            FindSubstrings(someText);

            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();

            //9
            PasswordValidation(password);
            Console.WriteLine("Введите пароль на Post Code");
            string postPass = Console.ReadLine();

            PostCode(postPass);
            //10
            Console.WriteLine("Введите номер телефона");
            string number = Console.ReadLine();
            //11
            PhoneNumber(number);
            string[] people = { "иван иванов", "светлана иванова-петренко" };
            ToUpper(people);
            //12
            Console.WriteLine("Введите строку в Base64");
            string base64Text = Console.ReadLine();
            var simpleTextBytes = Encoding.UTF8.GetBytes(base64Text);
            string enText = Convert.ToBase64String(simpleTextBytes);
            //13
            Console.WriteLine(enText);
            double[] arr = { 9, 1.5, 34.4, 234, 1, 56.5 };
            quicksort<double>(arr, 0, arr.Length - 1);
            Console.WriteLine();

        }

        static void ReturnNumber(string text)
        {
            char[] texter = text.ToCharArray();
            for (int i = 0; i < texter.Length; i++)
            {
                if (char.IsDigit(texter[i]))
                {
                    Console.WriteLine(texter[i]);
                }
            }
        }

        static void DivisionOfNumbers(double firstNum, double secondNum)
        {
            double result = firstNum / secondNum;
            string answer = string.Format("{0:F2}", result);
            Console.WriteLine(answer);
        }

        static void ExponentialForm1(string value)
        {
            int result = 0;
            if (!int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                Console.WriteLine("Неудалось конвертировать");
            }


            Console.WriteLine(result);
        }

        static void DateTimeIso()
        {
            Console.WriteLine(DateTime.Now.ToString("G"));
        }

        static int Sum(string textNumbers)
        {
            int result = 0;
            string[] listNum = textNumbers.Split(',');
            foreach (var u in listNum)
            {

                result = result + int.Parse(u.Replace(",", " "));
            }
            return result;
        }

        static void FindSubstrings(string someText)
        {
            Regex regex = new Regex(@"[a-z]+[0-9]+", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(someText);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }
        }
        static void PasswordValidation(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$");
            MatchCollection matches = regex.Matches(password);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("Совпадений не найдено, Пароль не соответствует требованиям");
            }
        }
        static void PostCode(string postPass)
        {
            Regex regex = new Regex(@"^[0-9]{3}-[0-9]{3}$");
            MatchCollection matches = regex.Matches(postPass);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("Совпадений не найдено, Пароль не соответствует требованиям");
            }
        }


        static void PhoneNumber(string number)
        {
            Regex regex = new Regex(@"^\+380-[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}$");
            MatchCollection matches = regex.Matches(number);
            Regex secondR = new Regex(@"^\+[0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}$");
            MatchCollection secondM = secondR.Matches(number);
            Console.WriteLine("Проверка номера на +380");
            if (matches.Count > 0)
            {

                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("Совпадений не найдено, номер не соответствует требованиям");
            }

            Console.WriteLine("Проверка номера на +XXX");
            if (secondM.Count > 0)
            {
                foreach (Match match in secondM)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("Совпадений не найдено, номер не соответствует требованиям");
            }
        }
    
        string[] people = { "иван иванов", "светлана иванова-петренко" };
        static void ToUpper(string[] people)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in people)
            {
                Console.WriteLine("{0}-->{1}", value, ti.ToTitleCase(value));
            }
        }


        static int partition<T>(T[] m, int a, int b) where T : IComparable<T>
        {
            int i = a;
            for (int j = a; j <= b; j++)
            {
                if (m[j].CompareTo(m[b]) <= 0)
                {
                    T t = m[i];
                    m[i] = m[j];
                    m[j] = t;
                    i++;
                }
            }
            return i - 1;
        }

        static void quicksort<T>(T[] m, int a, int b) where T : IComparable<T>
        {
            if (a >= b) return;
            int c = partition(m, a, b);
            quicksort(m, a, c - 1);
            quicksort(m, c + 1, b);
        }
    }
}