using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Services
{
    internal class Rankings
    {
          public static void Ranks(List<Student> students ,int rank = 1)
        {
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

            List<Student> StudentOfClass = new List<Student>();
            foreach (Student s in students)
            {
                if (standard.Equals(s.ClassObj))
                    StudentOfClass.Add(s);
            }
            StudentOfClass.Sort((s1, s2) =>
            s2.GetPercentage().CompareTo(s1.GetPercentage()));
            StudentOfClass[rank-1].ShowDetails();
        }
    

    }
}
