using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_Cows
{
    class Logic
    {
        string number;
        int[] numbers;
        char[] allNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public void Game()
        {
          
            List<string> counter = new List<string>();
            for (int i = 0; i < allNumbers.Length; i++)
            {
                for (int j = 0; j < allNumbers.Length; j++)
                {
                    for (int k = 0; k < allNumbers.Length; k++)
                    {
                        for (int z = 0; z < allNumbers.Length; z++)
                        {


                            counter.Add((allNumbers[i].ToString()
                                + allNumbers[j].ToString()
                                + allNumbers[k].ToString()
                                + allNumbers[z].ToString()));

                            Random rnd = new Random();
                        }
                    }
                }
            }
            Console.WriteLine("Введите число");
            number = (Console.ReadLine());
            numbers = number.Select(u => u - '0').ToArray();

            string computerNumber;
            int[] computerNumbers;
            Random random = new Random();
            computerNumber = counter[random.Next(counter.Count())];
            computerNumbers = computerNumber.Select(u => u - '0').ToArray();
            byte countCows = 0;
            byte countBulls = 0;
            byte userCows = 0;
            byte userBulls = 0;
            int choice = 0;
            int attempts = 0;
            while (countBulls != 4 && choice != 1)
            {
                ++attempts;
                countCows = 0;
                countBulls = 0;

                List<char> comDetails = computerNumber.ToList();
                List<char> mainDetails = number.ToList();
                List<int> indexToDelete = new List<int>();
                for (int i = 0; i < 4; ++i)
                {
                    if (number[i] == computerNumber[i])
                    {
                        ++countBulls;
                        indexToDelete.Add(i);
                    }
                }
                indexToDelete.Reverse();
                foreach (int index in indexToDelete)
                {
                    comDetails.RemoveAt(index);
                    mainDetails.RemoveAt(index);
                }

                foreach (char symbol in mainDetails)
                {
                    if (comDetails.Contains(symbol))
                    {
                        ++countCows;
                        comDetails.Remove(symbol);
                    }
                }
                if (countCows == 0 && countBulls == 0)
                {
                    counter.RemoveAll(x =>
                    {
                        foreach (char symbol in computerNumber)
                        {
                            if (x.Contains(symbol))
                            {
                                return true;
                            }
                        }
                        return false;
                    });
                }
                else
                {
                    counter.RemoveAll(x => RemoteNumbers(x, computerNumber, countBulls, countCows));
                }
                Console.WriteLine($"Ваше число; {computerNumber}?:Введите 1 если да или 2 если нет");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine($"Компьютер угадал с {attempts} попытки!");
                }
                else
                {
                    Console.WriteLine("Введите количество быков");
                    userBulls = byte.Parse(Console.ReadLine());
                    Console.WriteLine("Введите количество коров");
                    userCows = byte.Parse(Console.ReadLine());
                    Random random1 = new Random();
                    computerNumber = counter[random.Next(counter.Count())];
                    computerNumbers = computerNumber.Select(u => u - '0').ToArray();
                }
            }
        }
        static bool RemoteNumbers(string allNumbers, string prediction, int bulls, int cows)
        {
            int bullCounter = 0;
            int cowCounter = 0;
            List<char> partOfPrediction = prediction.ToList();
            List<char> possibleNumbers = allNumbers.ToList();
            List<int> indexToDelete = new List<int>();
            for (int i = 0; i < 4; ++i)
            {
                if (allNumbers[i] == prediction[i])
                {
                    ++bullCounter;
                    indexToDelete.Add(i);
                }
            }

            indexToDelete.Reverse();
            foreach (int index in indexToDelete)
            {
                partOfPrediction.RemoveAt(index);
                possibleNumbers.RemoveAt(index);
            }

            foreach (char symbol in possibleNumbers)
            {
                if (partOfPrediction.Contains(symbol))
                {
                    ++cowCounter;
                    partOfPrediction.Remove(symbol);
                }
            }

            return !(cowCounter == cows && bullCounter == bulls);
        }
    }
}
