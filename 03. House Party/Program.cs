using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main()
        {
            int numberOfComands = int.Parse(Console.ReadLine());

            List<string> listOfGests = new List<string>();

            for (int i = 0; i < numberOfComands; i++)
            {
                List<string> command = Console.ReadLine()
                    .Split(" ")
                    .ToList();

                string name = command[0];
                bool chekPeopleInList = listOfGests.Contains(name);

                if (command[2] == "going!" && chekPeopleInList == false)
                {
                    listOfGests.Add(name);
                }
                else if (command[2] == "going!" && chekPeopleInList == true)
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else if (command[2] == "not" && chekPeopleInList == false)
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
                else if (command[2] == "not" && chekPeopleInList == true)
                {
                    listOfGests.Remove(name);
                }

            }
            foreach (var name in listOfGests)
            {
                Console.WriteLine(name);
            }
        }
    }
}
