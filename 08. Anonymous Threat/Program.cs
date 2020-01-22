using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listForTransorm = Console.ReadLine()
                .Split(" ")
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "3:1")
            {
                string[] commandText = input.Split(" ");

                string command = commandText[0];

                switch (command)
                {
                    case "merge":
                        int startIndex = int.Parse(commandText[1]);
                        int endIndex = int.Parse(commandText[2]);

                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        if (endIndex > listForTransorm.Count - 1)
                        {
                            endIndex = listForTransorm.Count - 1;
                        }


                        for (int i = 0; i < listForTransorm.Count; i++)
                        {
                            int currentIndex = i;
                            if (currentIndex == startIndex)
                            {
                                int countToRemove = endIndex - startIndex;
                                for (int j = countToRemove; j > 0; j--)
                                {
                                    listForTransorm[i] = listForTransorm[startIndex] + listForTransorm[startIndex + 1];
                                    listForTransorm.RemoveAt(startIndex + 1);
                                }
                            }
                        }

                        break;
                    case "divide":
                        int indexToDivide = int.Parse(commandText[1]);
                        int partitions = int.Parse(commandText[2]);

                        List<char> temp = listForTransorm[indexToDivide].ToList();
 
                        int countInPartitions = temp.Count / partitions;

                        List<string> listWithPartition = new List<string>(partitions);

                        for (int i = 0; i < partitions - 1; i++)
                        {
                            string midElement = "";
                            for (int j = 0; j < countInPartitions; j++)
                            {
                                midElement += temp[0];
                                temp.RemoveAt(0);
                            }
                            listWithPartition.Add(midElement);

                        }
                        string lastElement = "";
                        for (int i = 0; i < temp.Count; i++)
                        {
                            lastElement += temp[i];
                        }
                        listWithPartition.Add(lastElement);

                        listForTransorm.RemoveAt(indexToDivide);
                        listForTransorm.InsertRange(indexToDivide, listWithPartition);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", listForTransorm));
        }
    }
}
