using StudentManagementSystem.Constants;
using StudentManagementSystem.Enums;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StudentManagementSystem.Services
{
    internal static class FilterStudentsService
    {
      
        private static string ReadValidatedName(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) &&
                    Regex.IsMatch(input, @"^[A-Za-z ]+$"))
                    return input.Trim();

                Console.WriteLine("Only letters and spaces allowed.");
            }
        }

        private static string ReadValidatedAddressText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) &&
                    Regex.IsMatch(input, @"^[A-Za-z0-9]+([\s-]+[A-Za-z0-9]+)*$"))
                    return input.Trim();

                Console.WriteLine("Invalid address format.");
            }
        }

        private static int ReadValidatedPincode()
        {
            while (true)
            {
                Console.Write("Enter Pincode: ");
                if (int.TryParse(Console.ReadLine(), out int pin) &&
                    pin >= 100000 && pin <= 999999)
                    return pin;

                Console.WriteLine("Pincode must be exactly 6 digits.");
            }
        }

        private static int ReadPositiveInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                    return value;

                Console.WriteLine("Enter a positive number.");
            }
        }

        public static List<Student> AgeRange(List<Student> students, int min, int max)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                if (s.Age >= min && s.Age <= max)
                    result.Add(s);
            }

            return result;
        }

        public static List<Student> BasedOnFirstName(List<Student> students, string name)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
                if (string.Equals(s.FirstName, name, StringComparison.OrdinalIgnoreCase))
                    result.Add(s);

            return result;
        }

        public static List<Student> BasedOnMiddleName(List<Student> students, string name)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
                if (!string.IsNullOrWhiteSpace(s.MiddleName) &&
                    string.Equals(s.MiddleName, name, StringComparison.OrdinalIgnoreCase))
                    result.Add(s);

            return result;
        }

        public static List<Student> BasedOnLastName(List<Student> students, string name)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
                if (string.Equals(s.LastName, name, StringComparison.OrdinalIgnoreCase))
                    result.Add(s);

            return result;
        }

        public static List<Student> BasedOnHobby(List<Student> students, string hobby)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                foreach (string h in s.Hobbies)
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
                if (s.Class == cls)
                    result.Add(s);

            return result;
        }

        public static List<Student> BasedOnEnrollmentTime(
    List<Student> students, DateTime date)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                if (s.EnrollmentDate.Date == date.Date)
                    result.Add(s);
            }

            return result;
        }


        public static List<Student> BasedOnMultipleSubjects(List<Student> students, List<Subject> selectedSubjects)
        {
            List<Student> result = new List<Student>();

            foreach (Student s in students)
            {
                bool hasAll = true;

                foreach (Subject sub in selectedSubjects)
                {
                    if (!s.Subjects.Contains(sub))
                    {
                        hasAll = false;
                        break;
                    }
                }

                if (hasAll)
                    result.Add(s);
            }

            return result;
        }

        public static void Filter(List<Student> students)
        {
            Console.WriteLine("\n========== STUDENT FILTER MENU ==========");
            Console.WriteLine("1. Filter by First Name");
            Console.WriteLine("2. Filter by Middle Name");
            Console.WriteLine("3. Filter by Last Name");
            Console.WriteLine("4. Filter by Subjects");
            Console.WriteLine("5. Filter by Hobby");
            Console.WriteLine("6. Filter by Address");
            Console.WriteLine("7. Filter by Class");
            Console.WriteLine("8. Filter by Enrollment Date");
            Console.WriteLine("9. Back to Main Menu");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            List<Student> filtered;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter FirstName ");
                    filtered = BasedOnFirstName(students, Console.ReadLine().Trim());
                    break;

                case 2:
                    Console.WriteLine("Enter MiddleName ");
                    filtered = BasedOnMiddleName(students, Console.ReadLine().Trim());
                    break;

                case 3:
                    Console.WriteLine("Enter LastName ");
                    filtered = BasedOnLastName(students, Console.ReadLine().Trim());
                    break;

                case 4:
                    filtered = BasedOnMultipleSubjects(students, SelectMultipleSubjects());
                    break;

                case 5:
                    filtered = BasedOnHobby(students, ReadValidatedName("Enter Hobby: "));
                    break;

                case 6:
                    filtered = BasedOnAddress(students);
                    break;

                case 7:
                    filtered = BasedOnClass(students, SelectClass());
                    break;

                case 8:
                    Console.WriteLine("Enter Enrollment Date (dd-MM-yyyy):");

                    filtered = new List<Student>();
                    DateTime inputDate;

                    while (true)
                    {
                        if (DateTime.TryParseExact(
                            Console.ReadLine(),
                            "dd-MM-yyyy",
                            null,
                            System.Globalization.DateTimeStyles.None,
                            out inputDate))
                        {
                            filtered = BasedOnEnrollmentTime(students, inputDate);
                            break;
                        }

                        Console.WriteLine("Invalid format. Use dd-MM-yyyy");
                    }
                    break;

                case 9:
                    return;

                default:
                    Console.WriteLine(Messages.SelectValidOption);
                    filtered = null;
                    break;
            }

            Show(filtered);
        }

        public static List<Student> BasedOnAddress(List<Student> students)
        {
            List<Student> result = new List<Student>();

            Console.WriteLine("\nADDRESS FILTER MENU");
            Console.WriteLine("1. City");
            Console.WriteLine("2. Area");
            Console.WriteLine("3. State");
            Console.WriteLine("4. Pincode");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                return result;

            switch (choice)
            {
                case 1:
                    string city = ReadValidatedName("Enter City: ");
                    foreach (Student s in students)
                        if (s.Address != null &&
                            string.Equals(s.Address.GetCity, city, StringComparison.OrdinalIgnoreCase))
                            result.Add(s);
                    break;

                case 2:
                    string area = ReadValidatedAddressText("Enter Area: ");
                    foreach (Student s in students)
                        if (s.Address != null &&
                            string.Equals(s.Address.GetArea, area, StringComparison.OrdinalIgnoreCase))
                            result.Add(s);
                    break;

                case 3:
                    string state = ReadValidatedName("Enter State: ");
                    foreach (Student s in students)
                        if (s.Address != null &&
                            string.Equals(s.Address.GetState, state, StringComparison.OrdinalIgnoreCase))
                            result.Add(s);
                    break;

                case 4:
                    int pin = ReadValidatedPincode();
                    foreach (Student s in students)
                        if (s.Address != null && s.Address.GetPincode == pin)
                            result.Add(s);
                    break;
                default:
                    Console.WriteLine(Messages.SelectValidOption);
                    break;
            }

            return result;
        }

        private static void Show(List<Student> students)
        {

            if (students==null)
            {return;
            }


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
            while (true)
            {
                List<Subject> selected = new List<Subject>();
                Subject[] all = (Subject[])Enum.GetValues(typeof(Subject));

                Console.WriteLine("\nAvailable Subjects:");
                for (int i = 0; i < all.Length; i++)
                    Console.WriteLine($"{i + 1}. {all[i]}");

                Console.Write("Enter subject numbers (comma separated): ");
                string[] values = Console.ReadLine().Split(',');

                bool valid = true;

                foreach (string v in values)
                {
                    if (!int.TryParse(v.Trim(), out int index) ||
                        index < 1 || index > all.Length)
                    {
                        valid = false;
                        break;
                    }

                    Subject sub = all[index - 1];
                    if (!selected.Contains(sub))
                        selected.Add(sub);
                }

                if (valid && selected.Count > 0)
                    return selected;

                Console.WriteLine("Invalid subject selection. Try again.\n");
            }
        }
    }
}
