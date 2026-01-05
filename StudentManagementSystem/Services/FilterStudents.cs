using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Services
{
    internal class FilterStudents
    { 
        public static List<Student> AgeRange(List<Student> students)
        {
            List<Student> list = new List<Student>();
            foreach (Student s in students)
            {
                if (s.GetAge() > 10 && s.GetAge() < 25)
                    list.Add(s);

            }
                return list;
        }

        public static void BasedOnFirstName(List<Student> students , String findName)
        {
            List<Student> list = new List<Student>();
            foreach (Student s in students)
            {
                findName.ToLower();
                if (findName.Equals(s.GetFirstName().ToLower()))
                {
                    
                    list.Add(s);
                }
                    
            }
            
        }

        public static void Filter(List<Student> students, int choice)
        { 
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Filter Based on First Name");
                        Console.WriteLine("Enter First Name");
                        BasedOnFirstName(students,Console.ReadLine());
                        break;

                    case 2:
                        Console.WriteLine("Filter Based on Middle Name");
                        // ShowAllStudents();
                        break;

                    case 3:
                        Console.WriteLine("Filter Based on Last Name");
                        // FilterStudents();
                        break;

                    case 4:
                        Console.WriteLine("Age filter selected");
                        // StudentsAgeBetween(15, 25);
                        break;

                    case 5:
                        Console.WriteLine("Topper of class selected");
                        // ShowTopper();
                        break;

                    case 6:
                        Console.WriteLine("Nth rank selected");
                        // ShowNthRank();
                        break;

                    case 7:
                        Console.WriteLine("Recent enrollment selected");
                        // ShowStudentsEnrolledInLast10Seconds();
                        break;

                    case 0:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();

        }
    }
}
