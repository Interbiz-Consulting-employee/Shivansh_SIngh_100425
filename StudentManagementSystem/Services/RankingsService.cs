using StudentManagementSystem.Enums;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Services
{
    internal static class RankingsService
    {
        public static void ShowRank(this List<Student> students, int rank = 1)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }
            if (rank <= 0 )
            {
                Console.WriteLine("Invalid rank.");
                return;
            }
            ClassStandard standard;

            while (true)
            {
                Console.WriteLine("\nSelect Class:");
                foreach (ClassStandard std in Enum.GetValues(typeof(ClassStandard)))
                {
                    Console.WriteLine($"{(int)std} - {std}");
                }

                Console.Write("Enter Class Number: ");
                if (int.TryParse(Console.ReadLine(), out int value) &&
                    Enum.IsDefined(typeof(ClassStandard), value))
                {
                    standard = (ClassStandard)value;
                    break;
                }

                Console.WriteLine("Invalid class. Try again.");
            }

            List<Student> studentsOfClass = new List<Student>();

            foreach (Student s in students)
            {
                if (s.GetClass == standard)
                {
                    studentsOfClass.Add(s);
                }
            }

            if (studentsOfClass.Count == 0)
            {
                Console.WriteLine("No students found in selected class.");
                return;
            }

            if ( rank > studentsOfClass.Count)
            {
                Console.WriteLine("Invalid rank.");
                return;
            }

            studentsOfClass.Sort((s1, s2) =>
                s2.GetPercentage().CompareTo(s1.GetPercentage()));

            Student rankedStudent = studentsOfClass[rank - 1];

            Console.WriteLine(
                $"Rank {rank} in class {standard} : Roll No {rankedStudent.GetRollNo}");

            Console.WriteLine("Want to check full details? Press Y");
            string choice = Console.ReadLine();

            if (choice?.Trim().ToLower() == "y")
            {
                rankedStudent.ShowDetails();
            }
        }
    }
}
