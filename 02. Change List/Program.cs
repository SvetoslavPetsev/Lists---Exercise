using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Change_List
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

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split(" ");

                switch (command[0])
                {
                    case "Delete":
                        int numberToDelete = int.Parse(command[1]);
                        someNumbers.RemoveAll(x => x == numberToDelete);
                        break;

                    case "Insert":

                        int numberToInsert = int.Parse(command[1]);
                        int indexToInsert = int.Parse(command[2]);
                        someNumbers.Insert(indexToInsert, numberToInsert);
                        break;

                }
            }
            Console.WriteLine(string.Join(" ", someNumbers));
        }
    }
}
