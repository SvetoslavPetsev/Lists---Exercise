using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main()
        {
            List<string> scheduleSoftUni = Console.ReadLine()
                .Split(", ")
                .ToList();

            while (true)
            {

                List<string> inputCommands = Console.ReadLine()
                    .Split(":")
                    .ToList();

                string command = inputCommands[0];

                if (command == "course start")
                {
                    for (int i = 0; i < scheduleSoftUni.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{scheduleSoftUni[i]}");
                    }
                    break;
                }

                string lessonTitle = inputCommands[1];
                if (command == "Add")
                {
                    if (scheduleSoftUni.Contains(lessonTitle))
                    {
                        continue;
                    }
                    else
                    {
                        scheduleSoftUni.Add(lessonTitle);
                    }
                }
                else if (command == "Insert")
                {
                    if (scheduleSoftUni.Contains(lessonTitle))
                    {
                        continue;
                    }
                    else
                    {
                        int indexToInsert = int.Parse(inputCommands[2]);
                        scheduleSoftUni.Insert(indexToInsert, lessonTitle);
                    }
                }
                else if (command == "Remove")
                {
                    if (scheduleSoftUni.Contains(lessonTitle))
                    {
                        scheduleSoftUni.Remove(lessonTitle);
                    }
                    if (scheduleSoftUni.Contains($"{lessonTitle}-Exercise"))
                    {
                        scheduleSoftUni.Remove($"{lessonTitle}-Exercise");
                    }
                }
                else if (command == "Swap")
                {
                    string lessonTitleTwo = inputCommands[2];
                    List<string> first = new List<string>();
                    List<string> second = new List<string>();

                    if (scheduleSoftUni.Contains(lessonTitle) && scheduleSoftUni.Contains(lessonTitleTwo))
                    {
                        first.Add(lessonTitle);
                        second.Add(lessonTitleTwo);

                        if (scheduleSoftUni.Contains($"{lessonTitle}-Exercise"))
                        {
                            first.Add($"{lessonTitle}-Exercise");
                        }

                        else if (scheduleSoftUni.Contains($"{lessonTitleTwo}-Exercise"))
                        {
                            second.Add($"{lessonTitleTwo}-Exercise");
                        }

                        for (int i = 0; i < scheduleSoftUni.Count; i++)
                        {
                            string curentLection = scheduleSoftUni[i];

                            if (curentLection == lessonTitle)
                            {
                                scheduleSoftUni.RemoveRange(i, first.Count);
                                scheduleSoftUni.InsertRange(i, second);
                            }
                            if (curentLection == lessonTitleTwo)
                            {
                                scheduleSoftUni.RemoveRange(i, second.Count);
                                scheduleSoftUni.InsertRange(i, first);
                            }
                        }
                    }
                }
                else if (command == "Exercise")
                {
                    if (scheduleSoftUni.Contains(lessonTitle))
                    {
                        int indexOfLeson = scheduleSoftUni.IndexOf(lessonTitle);
                        if (!scheduleSoftUni.Contains(lessonTitle + "-Exercise"))
                        {
                            if (indexOfLeson == scheduleSoftUni.Count - 1)
                            {
                                scheduleSoftUni.Add(lessonTitle + "-Exercise");
                            }
                            else
                            {
                                scheduleSoftUni.Insert(indexOfLeson + 1, lessonTitle + "-Exercise");
                            }
                        }
                    }
                    else if (!scheduleSoftUni.Contains(lessonTitle + "-Exercise"))
                    {
                        scheduleSoftUni.Add(lessonTitle);
                        scheduleSoftUni.Add(lessonTitle + "-Exercise");
                    }
                }
            }
        }
    }
}
