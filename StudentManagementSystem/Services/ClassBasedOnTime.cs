using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Services
{
    internal class ClassBasedOnTime
    {
        public static List<ClassStandard> GetClassesOfStudentsEnrolledInLast10Seconds(List<Student> students)
        {
            List<ClassStandard> classes = new List<ClassStandard>();

            DateTime now = DateTime.Now;

            foreach (Student s in students)
            {
                TimeSpan diff = now - s.GetEnrollmentTime();

                if (diff.TotalSeconds <= 10)
                {
                    if (!classes.Contains(s.ClassObj))
                    {
                        classes.Add(s.ClassObj);
                    }
                }
            }

            return classes;
        }
    }
}
