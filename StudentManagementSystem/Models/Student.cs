using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
   

    public class Student
    {
        private static Dictionary<ClassStandard, int> rollCount =
            new Dictionary<ClassStandard, int>
            {
                { ClassStandard.Class9, 9000 },
                { ClassStandard.Class10, 10000 },
                { ClassStandard.Class11, 11000 },
                { ClassStandard.Class12, 12000 }
            };

        private string firstName;
        private string middleName;
        private string lastName;
        private int age;

        private List<string> hobbies = new List<string>();

        private int totalMarks;

        public int RollNo { get; private set; }
        public ClassStandard ClassObj { get; private set; }

        public Address address = new Address();
        private List<string> subjects = new List<string>();
        private Dictionary<string, int> subjectMarks = new Dictionary<string, int>();
        private DateTime studentEnrollmentTime;

        public Student() { }

        public Student(
    string firstName,
    string middleName,
    string lastName,
    int age,
    ClassStandard classObj,
    Address address,
    List<string> hobbies,
    Dictionary<string, int> subjectMarksInput)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required");

            if (age <= 0 || age > 30)
                throw new ArgumentException("Invalid age");

            if (hobbies == null || hobbies.Count < 1 || hobbies.Count > 7)
                throw new ArgumentException("Hobbies must be between 1 and 7");

            if (subjectMarksInput == null || subjectMarksInput.Count < 1 || subjectMarksInput.Count > 6)
                throw new ArgumentException("Subjects must be between 1 and 6");

            this.firstName = firstName.Trim();
            this.middleName = middleName?.Trim();
            this.lastName = lastName.Trim();
            this.age = age;
            this.ClassObj = classObj;
            this.address = address;
            this.hobbies = hobbies;

            rollCount[ClassObj]++;
            this.RollNo = rollCount[ClassObj];

            foreach (var item in subjectMarksInput)
            {
                if (string.IsNullOrWhiteSpace(item.Key))
                    throw new ArgumentException("Subject name cannot be empty");

                if (item.Value < 0 || item.Value > 100)
                    throw new ArgumentException("Marks must be between 0 and 100");

                subjects.Add(item.Key.Trim());
                subjectMarks[item.Key.Trim()] = item.Value;
                totalMarks += item.Value;
            }

            studentEnrollmentTime = DateTime.Now;
        }


        public void GetDetails()
        {
            Console.Write("Enter First Name: ");
            firstName = Console.ReadLine();

            Console.Write("Enter Middle Name: ");
            middleName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            lastName = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter Age: ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0 && age <= 30)
                    break;
                Console.WriteLine("Invalid age. Try again.");
            }

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
                    ClassObj = (ClassStandard)value;
                    break;
                }

                Console.WriteLine("Invalid class. Try again.");
            }

            rollCount[ClassObj]++;
            RollNo = rollCount[ClassObj];

            address.GetAddressDetails();

            Console.WriteLine("\nEnter Hobbies (Min 1, Max 7)");
            Console.WriteLine("Type 'done' when finished");

            while (hobbies.Count < 7)
            {
                Console.Write($"Enter hobby {hobbies.Count + 1}: ");
                string input = Console.ReadLine();

                if (input.Equals("done"))
                {
                    if (hobbies.Count >= 1)
                        break;
                    Console.WriteLine("At least one hobby required.");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Hobby cannot be empty.");
                    continue;
                }

                hobbies.Add(input.Trim());
            }

            GetSubjects();
            GetSubjectMarks();

            studentEnrollmentTime = DateTime.Now;
        }

        private void GetSubjects()
        {
            Console.WriteLine("\nEnter Subjects (Min 1, Max 6)");
            Console.WriteLine("Type 'done' when finished");

            while (subjects.Count < 6)
            {
                Console.Write($"Enter subject {subjects.Count + 1}: ");
                string input = Console.ReadLine();

                if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
                {
                    if (subjects.Count >= 1)
                        break;
                    Console.WriteLine("At least one subject required.");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Subject cannot be empty.");
                    continue;
                }

                if (subjects.Contains(input.Trim()))
                {
                    Console.WriteLine("Subject already added.");
                    continue;
                }

                subjects.Add(input.Trim());
            }
        }

        private void GetSubjectMarks()
        {
            Console.WriteLine("\nEnter Marks (0 - 100)");

            foreach (string sub in subjects)
            {
                int marks;
                while (true)
                {
                    Console.Write($"Enter marks for {sub}: ");
                    if (int.TryParse(Console.ReadLine(), out marks) &&
                        marks >= 0 && marks <= 100)
                        break;

                    Console.WriteLine("Invalid marks.");
                }

                subjectMarks[sub] = marks;
                totalMarks += marks;
            }
        }

        public void ShowDetails()
        {
            Console.WriteLine("\n----- STUDENT DETAILS -----");
            if(middleName == null && middleName == "")
                Console.WriteLine($"Name     : {firstName} {lastName}");
            else
                Console.WriteLine($"Name     : {firstName} {middleName} {lastName}");
            Console.WriteLine($"Age      : {age}");
            Console.WriteLine($"Class    : {ClassObj}");
            Console.WriteLine($"Roll No  : {RollNo}");

            address.ShowAddress();

            Console.WriteLine("\nHobbies:");
            foreach (string hobby in hobbies)
                Console.WriteLine($"- {hobby}");

            Console.WriteLine("\nSubjects & Marks:");
            foreach (var item in subjectMarks)
                Console.WriteLine($"{item.Key} : {item.Value}");

            Console.WriteLine($"Total Marks : {totalMarks}");
            Console.WriteLine($"Percentage  : {(double)totalMarks / subjectMarks.Count:F2}%");

            Console.WriteLine($"Enrollment Time : {studentEnrollmentTime}");
        }
        public int GetAge()
        {
            return age;
        }
        public ClassStandard GetClass()
        {
            return ClassObj;
        }

        public double GetPercentage()
        {
            return (double)totalMarks / subjectMarks.Count;
        }
        public DateTime GetEnrollmentTime()
        {
            return studentEnrollmentTime;
        }
        public string GetFirstName()
        {
            return firstName;
        }
        public string GetMiddleName()
        {
            return middleName;
        }
        public string GetLastName()
        {
            return lastName;
        }

    }

    
}
