using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._List_Operations
{
    class Program
    {
        static void Main()
        {
            List<int> someNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] fullCommand = input.Split(" ");
                string command = fullCommand[0];

                switch (command)
                {
                    case "Add":

                        int number = int.Parse(fullCommand[1]);
                        someNumbers.Add(number);
                        break;

                    case "Insert":
                        number = int.Parse(fullCommand[1]);
                        int index = int.Parse(fullCommand[2]);

                        if (index > someNumbers.Count - 1 || index < 0)
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        someNumbers.Insert(index, number);
                        break;

                    case "Remove":
                        index = int.Parse(fullCommand[1]);
                        if (index > someNumbers.Count - 1 || index < 0)
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        someNumbers.RemoveAt(index);
                        break;

                    case "Shift":
                        string direction = fullCommand[1];
                        int count = int.Parse(fullCommand[2]);
                        switch (direction)
                        {
                            case "left":
                                for (int i = 0; i < count; i++)
                                {
                                    someNumbers.Add(someNumbers[0]);
                                    someNumbers.RemoveAt(0);
                                }
                                break;

                            case "right":

                                for (int i = 0; i < count; i++)
                                {
                                    someNumbers.Insert(0, someNumbers[someNumbers.Count - 1]);
                                    someNumbers.RemoveAt(someNumbers.Count - 1);
                                }

                                break;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", someNumbers));
        }
    }
}
