using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main()
        {
            List<int> firstPlayerCards = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayerCards = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();


            while (firstPlayerCards.Count != 0 && secondPlayerCards.Count != 0)
            {
                int i = 0;

                if (firstPlayerCards[i] == secondPlayerCards[i])
                {
                    firstPlayerCards.RemoveAt(i);
                    secondPlayerCards.RemoveAt(i);
                    continue;
                }

                else if (firstPlayerCards[i] > secondPlayerCards[i])
                {
                    firstPlayerCards.Add(firstPlayerCards[i]);
                    firstPlayerCards.Add(secondPlayerCards[i]);
                    firstPlayerCards.RemoveAt(i);
                    secondPlayerCards.RemoveAt(i);
                }
                else
                {
                    secondPlayerCards.Add(secondPlayerCards[i]);
                    secondPlayerCards.Add(firstPlayerCards[i]);
                    secondPlayerCards.RemoveAt(i);
                    firstPlayerCards.RemoveAt(i);
                }
            }
            int sum = 0;
            string winner = "First";
            if (firstPlayerCards.Count != 0)
            {
                sum = firstPlayerCards.Sum();
            }
            else
            {
                winner = "Second";
                sum = secondPlayerCards.Sum();
            }
            Console.WriteLine($"{winner} player wins! Sum: {sum}");
        }
    }
}
