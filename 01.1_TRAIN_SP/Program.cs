using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Train
{
    class Program
    {
        static void Main()
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                List<string> command = Console.ReadLine()
                    .Split()
                    .ToList();

                if (command[0] == "end")
                {
                    Console.WriteLine(string.Join(" ", wagons));
                    break;
                }
                else if (command[0] == "Add")
                {
                    int countOfPassangers = int.Parse(command[1]);
                    if (countOfPassangers > maxCapacity)
                    {
                        countOfPassangers = maxCapacity;
                    }
                    wagons.Add(countOfPassangers);
                }
                else
                {
                    int newPassangers = int.Parse(command[0]);
                    int passengersOnBoard = 0;

                    while (newPassangers != 0)
                    {
                        int indexOfWagonWithFreePlaces = GiveIndexFirstWagonWithFreePlaces(wagons, maxCapacity);
                        int emptySpaceInWagon = maxCapacity - wagons[indexOfWagonWithFreePlaces];

                        if (emptySpaceInWagon >= newPassangers)
                        {
                            passengersOnBoard = newPassangers;
                        }
                        else
                        {
                            passengersOnBoard = emptySpaceInWagon;
                        }

                        wagons[indexOfWagonWithFreePlaces] += passengersOnBoard;
                        newPassangers -= passengersOnBoard;
                    }
                }
            }
        }
        static int GiveIndexFirstWagonWithFreePlaces(List<int> wagons, int capacity)
        {
            int index = 0;
            for (int i = 0; i < wagons.Count; i++)
            {

                if (wagons[i] < capacity)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
