using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;



namespace WorkWithSringsAndFormat
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("1)   Написать метод, который принимает строку и печатает на экран все ее символы, которые являются цифрой.");
            Console.WriteLine("Введите строку где есть цифры");
            string numbersFromString = Console.ReadLine();
            ReturnNumber(numbersFromString);

            Console.WriteLine("2)	Преобразовать результат деления двух чисел в число с 2-мя знаками после запятой");
            Console.WriteLine("Введите первое число");
            double firstNumberDivide = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            double secondNumberDivide = double.Parse(Console.ReadLine());
            DivisionOfNumbers(firstNumberDivide, secondNumberDivide);

            Console.WriteLine("3)   Прочитать целое число с консоли. Разрешить ввод в экспоненциальной форме.");
            Console.WriteLine("Введите Значение в экспоненциальной форме");
            string exponentialValue = (Console.ReadLine());
            ExponentialForm1(exponentialValue);

            Console.WriteLine("4)	Представить текущую дату и время в формате ISO-8601 ");
            DateTimeIso();

            Console.WriteLine("5)	Дана строка с датой: “2016 21-07”. Распарсить в DateTime ");
            string notParsedDatedate = "2016 21-07";
            Console.WriteLine(ParseDateTime(notParsedDatedate));

            Console.WriteLine("6)   Написать метод, который принимает строку и печатает на экран все ее символы, которые являются цифрой.");
            Console.WriteLine("Введите числа через запятую");
            string textWithNumbers = Console.ReadLine();
            Console.WriteLine(SumNumbersOfText(textWithNumbers));

            Console.WriteLine("a)	Найти в тексте все подстроки, которые имеют вид “текст123” (любое кол-во символов за которыми следует любое кл-во чисел).");
            Console.WriteLine("Введите текст");
            string someText = Console.ReadLine();

            FindSubstrings(someText);
            Console.WriteLine("b)	Валидировать пароль пользователя по след. правилам: минимальная длина - 6 символов, минимум одна прописная буква, заглавная, цифра.");
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            PasswordValidation(password);

            Console.WriteLine("c)	Валидировать ввод на Post Code по след. правилу: 3 цифры, тире, 3 цифры (123-456).");
            Console.WriteLine("Введите пароль на Post Code");
            string postPass = Console.ReadLine();
            PostCodeValidation(postPass);

            Console.WriteLine("d)	Валидировать ввод на телефонный номер формата +380-98-123-45-67. и   e)	Заменить все телефонные номера в тексте (по шаблону выше) на строку  + XXX - XX - XXX - XX - XX");
            Console.WriteLine("Введите номер телефона");
            string number = Console.ReadLine();
            PhoneNumber(number);
            Console.WriteLine("8)	Задан массив строк имен и фамилий:");
            string[] people = { "иван иванов", "светлана иванова-петренко" };
            MakeTextToUpper(people);

            Console.WriteLine("9)	Дана строка в формате base64 - 1");
            Console.WriteLine("Введите строку в Base64");
            string base64Text = Console.ReadLine();
            var simpleTextBytes = Encoding.UTF8.GetBytes(base64Text);
            string enText = Convert.ToBase64String(simpleTextBytes);

            Console.WriteLine("10)Реализовать алгоритм быстрой сортировки в стиле generics");
            Console.WriteLine(enText);
            double[] arr = { 9, 1.5, 34.4, 234, 1, 56.5 };
            Quicksort<double>(arr, 0, arr.Length - 1);
            Console.WriteLine();

        }

        static void ReturnNumber(string numbersFromString)
        {
            char[] texter = numbersFromString.ToCharArray();
            for (int i = 0; i < texter.Length; i++)
            {
                if (char.IsDigit(texter[i]))
                {
                    Console.WriteLine(texter[i]);
                }
            }
        }

        static void DivisionOfNumbers(double firstNumberDivide, double secondNumberDivide)
        {
            double result = firstNumberDivide / secondNumberDivide;
            string transformednumber = string.Format("{0:F2}", result);
            Console.WriteLine(transformednumber);
        }

        static void ExponentialForm1(string exponentialValue)
        {
            int result = 0;
            if (!int.TryParse(exponentialValue, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                Console.WriteLine("Неудалось конвертировать");
            }


            Console.WriteLine(result);
        }

        static void DateTimeIso()
        {
            Console.WriteLine(DateTime.Now.ToString("G"));
        }

        static DateTime ParseDateTime(string notParsedDatedate)
        {
            string[] FirstDate = notParsedDatedate.Split('-', ' ');

            FirstDate[0] = FirstDate[0] + '.';
            FirstDate[1] = FirstDate[1];
            FirstDate[2] = FirstDate[2].Remove(0, 0) + '.';
            notParsedDatedate = (FirstDate[0] + FirstDate[2] + FirstDate[1]).ToString();
            DateTime date = new DateTime();
            return DateTime.Parse(notParsedDatedate);
        }
        static int SumNumbersOfText(string textWithNumbers)
        {
            int SumResult = 0;
            string[] listNum = textWithNumbers.Split(',');
            foreach (var u in listNum)
            {

                SumResult = SumResult + int.Parse(u.Replace(",", " "));
            }
            return SumResult;
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
        static void PostCodeValidation(string postPass)
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
            Regex secondRegex = new Regex(@"^\+[0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}$");
            MatchCollection secondMatches = secondRegex.Matches(number);
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
            if (secondMatches.Count > 0)
            {
                foreach (Match match in secondMatches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("Совпадений не найдено, номер не соответствует требованиям");
            }
        }

        static void MakeTextToUpper(string[] people)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in people)
            {
                Console.WriteLine("{0}-->{1}", value, textInfo.ToTitleCase(value));
            }
        }

        static int Partition<T>(T[] array, int value, int arrayLenght) where T : IComparable<T>
        {
            int i = value;
            for (int j = value; j <= arrayLenght; j++)
            {
                if (array[j].CompareTo(array[arrayLenght]) <= 0)
                {
                    T t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                    i++;
                }
            }
            return i - 1;
        }

        static void Quicksort<T>(T[] array, int value, int arrayLenght) where T : IComparable<T>
        {
            if (value >= arrayLenght) return;
            int c = Partition(array, value, arrayLenght);
            Quicksort(array, value, c - 1);
            Quicksort(array, value, c - 1);
            Quicksort(array, c + 1, arrayLenght);
        }
    }
}

