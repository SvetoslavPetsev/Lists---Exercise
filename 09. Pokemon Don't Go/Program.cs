using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> removedNumbers = new List<int>();

            while (numbers.Count != 0)
            {
                int targetIndex = int.Parse(Console.ReadLine());
                int numberInTargetIndex = 0;
                if (targetIndex < 0)
                {
                    numberInTargetIndex = numbers[0];
                    removedNumbers.Add(numbers[0]);
                    numbers.RemoveAt(0);
                    int numberForInsert = numbers[numbers.Count - 1];
                    numbers.Insert(0, numberForInsert);
                }
                else if (targetIndex > numbers.Count - 1)
                {
                    numberInTargetIndex = numbers[numbers.Count - 1];
                    removedNumbers.Add(numbers[numbers.Count - 1]);
                    numbers.RemoveAt(numbers.Count - 1);
                    int numberForInsert = numbers[0];
                    numbers.Add(numberForInsert);
                }
                else
                {
                    numberInTargetIndex = numbers[targetIndex];

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int currentNumber = numbers[i];
                        if (i == targetIndex)
                        {
                            removedNumbers.Add(numbers[i]);
                            numbers.RemoveAt(i);
                        }
                    }
                }
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j] <= numberInTargetIndex)
                    {
                        numbers[j] += numberInTargetIndex;
                    }
                    else
                    {
                        numbers[j] -= numberInTargetIndex;
                    }
                }
            }
            int sumOfRemovedNumbers = removedNumbers.Sum();
            Console.WriteLine(sumOfRemovedNumbers);
        }
    }
}
