using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        private int RollNo;
        private ClassStandard ClassStandard;

        private Address address = new Address();
        private List<Subject> subjects = new List<Subject>();
        private Dictionary<Subject, int> subjectMarks = new Dictionary<Subject, int>();
        private DateTime studentEnrollmentTime;

        private static readonly object _rollLock = new object();

        public Student() { }

        public Student(
            string firstName,
            string middleName,
            string lastName,
            int age,
            ClassStandard ClassStandard,
            Address address,
            List<string> hobbies,
            Dictionary<Subject, int> subjectMarksInput)
        {
            try
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
                this.ClassStandard = ClassStandard;
                this.address = address;
                this.hobbies = hobbies;

                lock (_rollLock)
                {
                    rollCount[ClassStandard]++;
                    RollNo = rollCount[ClassStandard];
                }

                foreach (var item in subjectMarksInput)
                {
                    if (item.Value < 0 || item.Value > 100)
                        throw new ArgumentException("Marks must be between 0 and 100");

                    subjects.Add(item.Key);
                    subjectMarks[item.Key] = item.Value;
                    totalMarks += item.Value;
                }

                studentEnrollmentTime = DateTime.Now;
            }
            catch
            {
                throw;
            }
        }

        private delegate void SubjectWorkflowDelegate();
        private SubjectWorkflowDelegate subjectWorkflow;
        public void ReadStudentDetailsFromConsole()
        {
            try
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
                        Console.WriteLine($"{(int)std} - {std}");

                    Console.Write("Enter Class Number: ");
                    if (int.TryParse(Console.ReadLine(), out int value) &&
                        Enum.IsDefined(typeof(ClassStandard), value))
                    {
                        ClassStandard = (ClassStandard)value;
                        break;
                    }

                    Console.WriteLine("Invalid class. Try again.");
                }

                lock (_rollLock)
                {
                    rollCount[ClassStandard]++;
                    RollNo = rollCount[ClassStandard];
                }

                address.SetAddressDetails();
                SetHobbies();
                SetSubjects();
                SetSubjectMarks();

                studentEnrollmentTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while entering student details: {ex.Message}");
            }
        }

        private void SetHobbies()
        {
            try
            {
                Console.WriteLine("\nEnter Hobbies (Min 1, Max 7)");
                Console.WriteLine("Type 'done' when finished");

                while (hobbies.Count < 7)
                {
                    Console.Write($"Enter hobby {hobbies.Count + 1}: ");
                    string input = Console.ReadLine();

                    if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
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

                    string hobby = input.Trim();

                    if (!Regex.IsMatch(hobby, @"^[A-Za-z ]+$"))
                    {
                        Console.WriteLine("Hobby must contain only letters.");
                        continue;
                    }

                    if (hobbies.Exists(h => h.Equals(hobby, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("Hobby already added.");
                        continue;
                    }

                    hobbies.Add(hobby);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding hobbies: {ex.Message}");
            }
        }

        private void SetSubjects()
        {
            try
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

                    if (!Enum.TryParse(input.Trim(), true, out Subject subject) ||
                        !Enum.IsDefined(typeof(Subject), subject))
                    {
                        Console.WriteLine("Invalid subject.");
                        continue;
                    }

                    if (subjects.Contains(subject))
                    {
                        Console.WriteLine("Subject already added.");
                        continue;
                    }

                    subjects.Add(subject);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding subjects: {ex.Message}");
            }
        }

        private void SetSubjectMarks()
        {
            try
            {
                Console.WriteLine("\nEnter Marks (0 - 100)");

                foreach (Subject sub in subjects)
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error while entering marks: {ex.Message}");
            }
        }

        public void ShowDetails()
        {
            try
            {
                Console.WriteLine("\n----- STUDENT DETAILS -----");

                if (string.IsNullOrWhiteSpace(middleName))
                    Console.WriteLine($"Name     : {firstName} {lastName}");
                else
                    Console.WriteLine($"Name     : {firstName} {middleName} {lastName}");

                Console.WriteLine($"Age      : {age}");
                Console.WriteLine($"Class    : {ClassStandard}");
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error while displaying student details: {ex.Message}");
            }
        }

        public int GetAge()
        {
          return  age;
        }
        public ClassStandard GetClass() => ClassStandard;
        public double GetPercentage() => (double)totalMarks / subjectMarks.Count;
        public DateTime GetEnrollmentTime() => studentEnrollmentTime;
        public string GetFirstName() => firstName;
        public string GetMiddleName() => middleName;
        public string GetLastName() => lastName;
        public List<string> GetHobbies() => hobbies;

        public List<Subject> GetSubjects() {
            return subjects;
        }
        
        public Address GetAddress => address;
        public int GetRollNo => RollNo;

    }
}
