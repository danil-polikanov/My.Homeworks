using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Calculator
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                return 0;

            if (numbers.Count() > 1)
            {
                int[] negative = new int[numbers.Length];
                var prepair = numbers.Replace(".", ".\n").Replace("//", "!\n").Replace("?", "?\n").Replace(";", ",");
                String[] lines = prepair.Split(new char[] { '\n', '\r', '!', '?', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
                numbers = string.Join(',', lines);
                numbers.Split(',');
                int[] numArray = numbers.Replace(",", "").Select(a => a - '0').ToArray();
                for (int i = 0, j = 0; i < numArray.Length; i++)
                {
                    if (uint.TryParse(numArray[i].ToString(), out uint checkNegative))
                    {

                    }
                    else
                    {
                        if (checkNegative == 0) negative[j] = numbers[i];
                        j++;
                    }
                    if (i == numbers.Length - 1&&j>0)
                    {
                        throw new Exception($"negatives not allowed: {negative.Where(x => x < 0).Select(x => x)}");
                        for (int z = 0; z < negative.Length; z++)
                        {
                            Console.WriteLine("Негативные числа" + negative[z]);
                        }
                    }

                }
                int num = numbers.Replace(",", "").Select(a => a - '0').ToArray().Sum();
                return num;

            }
            return int.Parse(numbers);
        }

    }
}
