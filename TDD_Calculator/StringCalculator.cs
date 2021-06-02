using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Calculator
{

    public class StringCalculator
    {
        private int counter = 0;
        public event Action<string, int> AddOccured;
        public StringCalculator()
        {
            AddOccured += some;
        }
        public int GetCalledCount()
        {
            return counter;
        }
        public void some(string a,int b)
        {
            Console.WriteLine(a, b);
        }
        public int Add(string numbers)
        {
            counter++;
            AddOccured?.Invoke("Использован метод add", counter);
            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            if (numbers.Count() > 1)
            {
                List<int> negative = new List<int>();
                var prepair = numbers.Replace(".", ".\n").Replace("//", "!\n").Replace("?", "?\n").Replace(";", ",").Replace("%", ",").Replace("\\", ",").Replace("*", ",");
                String[] lines = prepair.Split(new string[] { "\n", "\r", "!", "?", ".", "," }, StringSplitOptions.RemoveEmptyEntries);
                int[] numArray = lines.Where(s=>s.Length<4).Select(s => int.Parse(s)).ToArray();
                for (int i = 0, j = 0; i < numArray.Length; i++)
                {
                    if (uint.TryParse(numArray[i].ToString(), out uint checkNegative))
                    {

                    }
                    else
                    {
                        if (checkNegative == 0) negative.Add(numArray[i]);
                        j++;
                    }
                    if (i == numArray.Length - 1 && j > 0)
                    {
                        throw new Exception($"negatives not allowed:{string.Join(",", negative.Where(x => x < 0))}");
                    }
                }
                int num = numArray.Sum();
                return num;

            }
            return int.Parse(numbers);
        }
    }
}
