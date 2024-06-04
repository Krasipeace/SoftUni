using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SCP_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] command = input.Split(":");

                lessons = SoftUniCoursePlanning(lessons, command);
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }

        static List<string> SoftUniCoursePlanning(List<string> lessons, string[] command)
        {
            switch (command[0])
            {
                case "Add":
                    lessons = LessonAdd(lessons, command);
                    break;
                case "Insert":
                    lessons = LessonInsert(lessons, command);
                    break;
                case "Remove":
                    lessons = LessonRemove(lessons, command);
                    break;
                case "Swap":
                    lessons = LessonSwap(lessons, command);
                    break;
                case "Exercise":
                    lessons = ExerciseAdd(lessons, command);
                    break;
            }
            return lessons;
        }

        static List<string> ExerciseAdd(List<string> lessons, string[] command)
        {
            string lessonTitle = command[1];

            if (lessons.Contains(lessonTitle) && !lessons.Contains(lessonTitle + "-Exercise"))
            {
                int index = lessons.IndexOf(lessonTitle);

                lessons.Insert(index + 1, lessonTitle + "-Exercise");
            }

            else if (!lessons.Contains(lessonTitle))
            {
                lessons.Add(lessonTitle);
                lessons.Add(lessonTitle + "-Exercise");
            }
            return lessons;
        }

        static List<string> LessonSwap(List<string> lessons, string[] command)
        {
            string lessonOne = command[1];
            string lessonTwo = command[2];

            int indexOne = lessons.IndexOf(lessonOne);
            int indexTwo = lessons.IndexOf(lessonTwo);

            if (lessons.Contains(lessonOne) && lessons.Contains(lessonTwo))
            {
                string tempLessonTitle1 = lessons.ElementAt(indexOne);

                lessons[indexOne] = lessons[indexTwo];
                lessons[indexTwo] = tempLessonTitle1;
            }

            if (lessons.Contains(lessonOne + "-Exercise") && lessons.Contains(lessons[indexOne]))
            {
                indexOne = lessons.IndexOf(lessonOne);
                lessons.Remove(lessonOne + "-Exercise");
                lessons.Insert(indexOne + 1, lessonOne + "-Exercise");
            }
            else if (lessons.Contains(lessonTwo + "-Exercise") && lessons.Contains(lessons[indexTwo]))
            {
                indexTwo = lessons.IndexOf(lessonTwo);
                lessons.Remove(lessonTwo + "-Exercise");
                lessons.Insert(indexTwo + 1, lessonTwo + "-Exercise");
            }
            return lessons;
        }
        static List<string> LessonRemove(List<string> lessons, string[] command)
        {
            string lessonTitle = command[1];
            if (lessons.Contains(lessonTitle))
            {
                lessons.Remove(lessonTitle);
            }
            else if (lessons.Contains(lessonTitle + "-Exercise"))
            {
                lessons.Remove(lessonTitle + "-Exercise");
            }
            return lessons;
        }
        static List<string> LessonInsert(List<string> lessons, string[] command)
        {
            string lessonTitle = command[1];
            int index = int.Parse(command[2]);

            if (index < 0 || index >= lessons.Count)
            {
                return lessons;
            }
            else if (!lessons.Contains(lessonTitle))
            {
                lessons.Insert(index, lessonTitle);
            }
            return lessons;
        }

        static List<string> LessonAdd(List<string> lessons, string[] command)
        {
            string lessonTitle = command[1];

            if (!lessons.Contains(lessonTitle))
            {
                lessons.Add(lessonTitle);
            }
            return lessons;
        }
    }
}
