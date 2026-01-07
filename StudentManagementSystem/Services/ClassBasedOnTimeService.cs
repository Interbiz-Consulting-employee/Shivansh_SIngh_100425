using StudentManagementSystem.Enums;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace StudentManagementSystem.Services
{
    public static class ClassMonitor
    {
        private static volatile bool _stopRequested = false;
        private static readonly object _lockObj = new object();

        public static void FindClassesEveryInterval(
            List<Student> students,
            int intervalSeconds = 10)
        {
            if (students == null)
            {
                Console.WriteLine("Student list is null. Monitoring stopped.");
                return;
            }

            _stopRequested = false;

            while (!_stopRequested)
            {
                lock (_lockObj)
                {
                    if (students.Count == 0)
                    {
                        Console.WriteLine("\nNo students available.");
                    }
                    else
                    {
                        List<ClassStandard> classes = new List<ClassStandard>();

                        foreach (Student s in students)
                        {
                            ClassStandard cls = s.GetClass;
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

                for (int i = 0; i < intervalSeconds && !_stopRequested; i++)
                {
                    Thread.Sleep(1000);
                }
            }

            Console.WriteLine("Class monitoring stopped gracefully.");
        }
        public static void Stop()
        {
            _stopRequested = true;
        }
    }
}
