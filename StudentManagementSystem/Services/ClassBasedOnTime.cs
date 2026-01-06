using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Services
{
    public delegate void ClassFinderDelegate();

    public static class ClassMonitor
    {
        public static void FindClassesEvery10Seconds(List<Student> students)
        {
            while (true)
            {
                lock (students)
                {
                    if (students.Count == 0)
                    {
                        Console.WriteLine("\n No students available.");
                    }
                    else
                    {
                        List<ClassStandard> classes = new List<ClassStandard>();

                        foreach (Student s in students)
                        {
                            ClassStandard cls = s.GetClass();

                            if (!classes.Contains(cls))
                            {
                                classes.Add(cls);
                            }
                        }

                        Console.WriteLine("\nUpdated Classes having students:");
                        foreach (ClassStandard c in classes)
                        {
                            Console.WriteLine(c);
                        }
                    }
                }

                Thread.Sleep(20000); // 20 seconds
            }
        }
    }

}