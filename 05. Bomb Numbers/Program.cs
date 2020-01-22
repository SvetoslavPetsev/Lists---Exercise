using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> function = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int targetNumber = function[0];
            int powerOfExplosion = function[1];

            while (numbers.Contains(targetNumber))
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    int currentNumber = numbers[i];
                    if (currentNumber == targetNumber)
                    {
                        int explosionRange = powerOfExplosion * 2 + 1;
                        int startIndex = i - powerOfExplosion;
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                            explosionRange += i - powerOfExplosion;
                        }

                        int finalIndex = i + powerOfExplosion;
                        if (finalIndex > numbers.Count - 1)
                        {
                            finalIndex = numbers.Count;
                            explosionRange = finalIndex - startIndex;
                        }

                        numbers.RemoveRange(startIndex, explosionRange);
                    }
                }
            }
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}
