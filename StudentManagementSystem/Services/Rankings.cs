

using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Services
{
    internal static class Rankings
    {
        public static void ShowRank(this List<Student> students, int rank = 1)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students available.");
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
                if (standard == s.GetClass())
                {
                    studentsOfClass.Add(s);
                }
            }

            if (rank <= 0 || rank > studentsOfClass.Count)
            {
                Console.WriteLine("Invalid rank.");
                return;
            }

            studentsOfClass.Sort((s1, s2) =>
                s2.GetPercentage().CompareTo(s1.GetPercentage()));

           Console.WriteLine($" Rank {rank} in class {standard} : {studentsOfClass[rank - 1].GetRollNo}");

            Console.WriteLine("Want to check full details press y ");
            if(Console.ReadLine() == "y")
            studentsOfClass[rank - 1].ShowDetails();
                    
        }
    }

}

