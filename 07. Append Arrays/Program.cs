using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main()
        {
            List<string> bigSequance = Console.ReadLine()
                .Split('|')
                .ToList();

            List<string> listWithRemoveSpace = new List<string>();

            for (int i = 0; i < bigSequance.Count; i++)
            {
                bigSequance.Insert(i, bigSequance[bigSequance.Count - 1]);
                bigSequance.RemoveAt(bigSequance.Count - 1);

                string numbers = bigSequance[i];

                List<string> temp = numbers.Split(" ")
                    .ToList();

                for (int j = 0; j < temp.Count; j++)
                {
                    if (temp[j] != "")
                    {
                        continue;
                    }
                    temp.RemoveAt(j);
                    j--;
                }
                listWithRemoveSpace.AddRange(temp);
            }

            Console.WriteLine(String.Join(" ", listWithRemoveSpace));
        }
    }
}
