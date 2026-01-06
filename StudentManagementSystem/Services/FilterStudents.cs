using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Services
{
    internal static class FilterStudents
    {

        public static List<Student> AgeRange(List<Student> students , int min , int max)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                if (s.GetAge() > min && s.GetAge() < max)
                    result.Add(s);
            }

            return result;
        }

        public static List<Student> BasedOnFirstName(List<Student> students, string findName)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                if (string.Equals(s.GetFirstName(), findName, StringComparison.OrdinalIgnoreCase))
                    result.Add(s);
            }

            return result;
        }

        public static List<Student> BasedOnMiddleName(List<Student> students, string findName)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                if (!string.IsNullOrWhiteSpace(s.GetMiddleName()) &&
                    string.Equals(s.GetMiddleName(), findName, StringComparison.OrdinalIgnoreCase))
                    result.Add(s);
            }

            return result;
        }

        public static List<Student> BasedOnLastName(List<Student> students, string findName)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                if (string.Equals(s.GetLastName(), findName, StringComparison.OrdinalIgnoreCase))
                    result.Add(s);
            }

            return result;
        }

        public static List<Student> BasedOnHobby(List<Student> students, string hobby)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                foreach (string h in s.GetHobbies())
                {
                    if (string.Equals(h, hobby, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(s);
                        break;
                    }
                }
            }

            return result;
        }

        public static List<Student> BasedOnClass(List<Student> students, ClassStandard cls)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                if (s.GetClass() == cls)
                    result.Add(s);
            }

            return result;
        }

        public static List<Student> BasedOnEnrollmentTime(List<Student> students, int seconds)
        {
            List<Student> result = new List<Student>();
            DateTime limit = DateTime.Now.AddSeconds(-seconds);

            foreach (Student s in students)
            {
                if (s.GetEnrollmentTime() >= limit)
                    result.Add(s);
            }

            return result;
        }
        public static List<Student> BasedOnMultipleSubjects(List<Student> students, List<Subject> selectedSubjects)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                bool hasAllSubjects = true;

                foreach (Subject sub in selectedSubjects)
                {
                    bool found = false;

                    foreach (Subject studentSub in s.GetSubjects())
                    {
                        if (studentSub == sub)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        hasAllSubjects = false;
                        break;
                    }
                }

                if (hasAllSubjects)
                    result.Add(s);
            }

            return result;
        }

        public static void Filter(List<Student> students)
        {
            List<Student> filtered;
            int choice;

            Console.WriteLine("=========================================");
            Console.WriteLine("          STUDENT FILTER MENU");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Filter by First Name");
            Console.WriteLine("2. Filter by Middle Name");
            Console.WriteLine("3. Filter by Last Name");
            Console.WriteLine("4. Filter by Subjects");
            Console.WriteLine("5. Filter by Hobby");
            Console.WriteLine("6. Filter by Address");
            Console.WriteLine("7. Filter by Class");
            Console.WriteLine("8. Filter by Enrollment Time");
            Console.WriteLine("9. Back to Main Menu");
            Console.WriteLine("=========================================");
            Console.Write("\nEnter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {


                switch (choice)
                {
                    case 1:
                        Console.Write("Enter First Name: ");
                        string name = Console.ReadLine();
                        filtered = BasedOnFirstName(students, name);
                        Show(filtered);
                        break;

                    case 2:
                        Console.Write("Enter Middle Name: ");
                        filtered = BasedOnMiddleName(students, Console.ReadLine());
                        Show(filtered);
                        break;

                    case 3:
                        Console.Write("Enter Last Name: ");
                        filtered = BasedOnLastName(students, Console.ReadLine());
                        Show(filtered);
                        break;

                    case 4:
                        List<Subject> subject = SelectMultipleSubjects();
                        filtered = BasedOnMultipleSubjects(students, subject);
                        Show(filtered);
                        break;

                    case 5:
                        Console.Write("Enter Hobby: ");
                        filtered = BasedOnHobby(students, Console.ReadLine());
                        Show(filtered);
                        break;

                    case 6:
                        filtered = BasedOnAddress(students);
                        Show(filtered);
                        break;

                    case 7:
                        ClassStandard cls = SelectClass();
                        filtered = BasedOnClass(students, cls);
                        Show(filtered);
                        break;

                    case 8:
                        filtered = BasedOnEnrollmentTime(students, 10);
                        Show(filtered);
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            }
        }
        public static List<Student> BasedOnAddress(List<Student> students)
        {
            List<Student> result = new List<Student>();
            int choice;

            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("        ADDRESS FILTER MENU");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Filter by City");
            Console.WriteLine("2. Filter by Area");
            Console.WriteLine("3. Filter by State");
            Console.WriteLine("4. Filter by Pincode");
            Console.WriteLine("=================================");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
                return result;

            switch (choice)
            {
                case 1:
                    Console.Write("Enter City: ");
                    string city = Console.ReadLine();

                    foreach (Student s in students)
                    {
                        if (s.GetAddress != null &&
                            string.Equals(s.GetAddress.GetCity(), city, StringComparison.OrdinalIgnoreCase))
                        {
                            result.Add(s);
                        }
                    }
                    break;

                case 2:
                    Console.Write("Enter Area: ");
                    string area = Console.ReadLine();

                    foreach (Student s in students)
                    {
                        if (s.GetAddress != null &&
                            string.Equals(s.GetAddress.GetArea(), area, StringComparison.OrdinalIgnoreCase))
                        {
                            result.Add(s);
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter State: ");
                    string state = Console.ReadLine();

                    foreach (Student s in students)
                    {
                        if (s.GetAddress != null &&
                            string.Equals(s.GetAddress.GetState(), state, StringComparison.OrdinalIgnoreCase))
                        {
                            result.Add(s);
                        }
                    }
                    break;

                case 4:
                    Console.Write("Enter Pincode: ");
                    if (int.TryParse(Console.ReadLine(), out int pin))
                    {
                        foreach (Student s in students)
                        {
                            if (s.GetAddress != null && s.GetAddress.GetPincode() == pin)
                            {
                                result.Add(s);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid pincode.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            return result;
        }

        private static void Show(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (Student s in students)
                s.ShowDetails();
        }

        private static ClassStandard SelectClass()
        {
            while (true)
            {
                Console.WriteLine("\nSelect Class:");
                foreach (ClassStandard std in Enum.GetValues(typeof(ClassStandard)))
                    Console.WriteLine($"{(int)std} - {std}");

                if (int.TryParse(Console.ReadLine(), out int value) &&
                    Enum.IsDefined(typeof(ClassStandard), value))
                    return (ClassStandard)value;

                Console.WriteLine("Invalid class. Try again.");
            }
        }
        private static List<Subject> SelectMultipleSubjects()
        {
            List<Subject> selectedSubjects = new List<Subject>();

            Console.WriteLine("\nAvailable Subjects:");
            foreach (Subject sub in Enum.GetValues(typeof(Subject)))
                Console.WriteLine($"{(int)sub} - {sub}");

            Console.WriteLine("\nEnter subject numbers separated by comma (e.g. 1,3,4):");
            string input = Console.ReadLine();

            string[] values = input.Split(',');

            foreach (string v in values)
            {
                if (int.TryParse(v.Trim(), out int num) &&
                    Enum.IsDefined(typeof(Subject), num))
                {
                    Subject subject = (Subject)num;

                    if (!selectedSubjects.Contains(subject))
                        selectedSubjects.Add(subject);
                }
            }

            return selectedSubjects;
        }
    }
}
