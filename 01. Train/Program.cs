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

                    if (newPassangers > maxCapacity)
                    {
                        continue;
                    }

                    int indexOfWagonWithFreePlaces = GiveIndexFirstWagonWithFreePlaces(wagons,maxCapacity, newPassangers);
                    
                    wagons[indexOfWagonWithFreePlaces] += newPassangers;
                }
            }
        }
        static int GiveIndexFirstWagonWithFreePlaces(List<int> wagons, int maxCapacity, int incommingPassengers)
        {  
            int index = 0;
            for (int i = 0; i < wagons.Count; i++)
            {
                int emptySpaceInWagon = maxCapacity - wagons[i];
                if (emptySpaceInWagon >= incommingPassengers)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
