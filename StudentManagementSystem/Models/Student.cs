using StudentManagementSystem.Enums;
using StudentManagementSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StudentManagementSystem.Models
{
    public class Student
    {
       // Static Field for Count RollNumber
        private static Dictionary<ClassStandard, int> _rollCount =
            new Dictionary<ClassStandard, int>
            {
                { ClassStandard.Class9, 9000 },
                { ClassStandard.Class10, 10000 },
                { ClassStandard.Class11, 11000 },
                { ClassStandard.Class12, 12000 }
            };

        private static readonly object _rollLock = new object();

        
        private static readonly List<Student> _studentRegistry = new List<Student>();
        private static readonly object _studentLock = new object();

        // Instance Fields
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private int age;
        private int RollNo;
        private ClassStandard ClassStandard;
        private Address _address = new Address();

        private List<string> _hobbies = new List<string>();
        private List<Subject> _subjects = new List<Subject>();
        private Dictionary<Subject, int> subjectMarks = new Dictionary<Subject, int>();

        private int _totalMarks;
        private DateTime studentEnrollmentTime;

        // constructor
        public Student() { }

        public Student(
            string _firstName,
            string _middleName,
            string _lastName,
            int age,
            ClassStandard _classStandard,
            Address _address,
            List<string> _hobbies,
            Dictionary<Subject, int> _subjectMarksInput)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(_firstName))
                throw new StudentValidationException("First name is required");

            if (string.IsNullOrWhiteSpace(_lastName))
                throw new StudentValidationException("Last name is required");

            if (age <= 0 || age > 30)
                throw new StudentValidationException("Invalid age");

            if (_hobbies == null || _hobbies.Count < 1 || _hobbies.Count > 7)
                throw new StudentValidationException("Hobbies must be between 1 and 7");

            if (_subjectMarksInput == null || _subjectMarksInput.Count < 1 || _subjectMarksInput.Count > 6)
                throw new StudentValidationException("Subjects must be between 1 and 6");

            
            lock (_studentLock)
            {
                foreach (Student s in _studentRegistry)
                {
                    if (s._firstName.Equals(_firstName, StringComparison.OrdinalIgnoreCase) &&
                        s._lastName.Equals(_lastName, StringComparison.OrdinalIgnoreCase) &&
                        s.ClassStandard == _classStandard)
                    {
                        throw new StudentValidationException("Duplicate student detected");
                    }
                }
            }

            this._firstName = _firstName.Trim();
            this._middleName = _middleName?.Trim();
            this._lastName = _lastName.Trim();
            this.age = age;
            this.ClassStandard = _classStandard;
            this._address = _address ?? throw new ArgumentNullException(nameof(_address));
            this._hobbies = _hobbies;

            //Used lock so that no multiple threads may not access static _rollCount
            lock (_rollLock)
            {
                _rollCount[_classStandard]++;
                RollNo = _rollCount[_classStandard];
            }

            // Marks validation
            _totalMarks = 0;
            foreach (var item in _subjectMarksInput)
            {
                if (item.Value < 0 || item.Value > 100)
                    throw new StudentValidationException("Marks must be between 0 and 100");

                _subjects.Add(item.Key);
                subjectMarks[item.Key] = item.Value;
                _totalMarks += item.Value;
            }

            studentEnrollmentTime = DateTime.Now;

            // Register student
            lock (_studentLock)
            {
                _studentRegistry.Add(this);
            }
        }

        // Input
        public void ReadStudentDetailsFromConsole()
        {
            try
            {
                Console.Write("Enter First Name: ");
                _firstName = Console.ReadLine()?.Trim();

                Console.Write("Enter Middle Name: ");
                _middleName = Console.ReadLine()?.Trim();

                Console.Write("Enter Last Name: ");
                _lastName = Console.ReadLine()?.Trim();

                while (true)
                {
                    Console.Write("Enter Age: ");
                    if (int.TryParse(Console.ReadLine(), out age) && age > 0 && age <= 30)
                        break;
                    Console.WriteLine("Invalid age.");
                }

                while (true)
                {
                    Console.WriteLine("\nSelect Class:");
                    foreach (ClassStandard std in Enum.GetValues(typeof(ClassStandard)))
                        Console.WriteLine($"{(int)std} - {std}");

                    if (int.TryParse(Console.ReadLine(), out int value) &&
                        Enum.IsDefined(typeof(ClassStandard), value))
                    {
                        ClassStandard = (ClassStandard)value;
                        break;
                    }

                    Console.WriteLine("Invalid class.");
                }

                _address.SetAddressDetails();
                SetHobbies();
                SetSubjects();
                SetSubjectMarks();

                studentEnrollmentTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        
        private void SetHobbies()
        {
            Console.WriteLine("\nEnter Hobbies (Min 1, Max 7)");
            while (_hobbies.Count < 7)
            {
                Console.Write($"Hobby {_hobbies.Count + 1}: ");
                string input = Console.ReadLine();

                if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
                {
                    if (_hobbies.Count > 0) break;
                    Console.WriteLine("At least one hobby required.");
                    continue;
                }

                if (!Regex.IsMatch(input, @"^[A-Za-z ]+$"))
                {
                    Console.WriteLine("Only letters allowed.");
                    continue;
                }

                if (_hobbies.Exists(h => h.Equals(input, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Duplicate hobby.");
                    continue;
                }

                _hobbies.Add(input.Trim());
            }
        }

        private void SetSubjects()
        {
            Console.WriteLine("\nEnter Subjects (Min 1, Max 6)");
            while (_subjects.Count < 6)
            {
                Console.Write($"Subject {_subjects.Count + 1}: ");
                string input = Console.ReadLine();

                if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
                {
                    if (_subjects.Count > 0) break;
                    Console.WriteLine("At least one subject required.");
                    continue;
                }

                if (Enum.TryParse(input, true, out Subject subject) &&
                    !_subjects.Contains(subject))
                {
                    _subjects.Add(subject);
                }
                else
                {
                    Console.WriteLine("Invalid or duplicate subject.");
                }
            }
        }

        private void SetSubjectMarks()
        {
            _totalMarks = 0;
            subjectMarks.Clear();

            foreach (Subject sub in _subjects)
            {
                int marks;
                while (true)
                {
                    Console.Write($"Marks for {sub}: ");
                    if (int.TryParse(Console.ReadLine(), out marks) &&
                        marks >= 0 && marks <= 100)
                        break;

                    Console.WriteLine("Invalid marks.");
                }

                subjectMarks[sub] = marks;
                _totalMarks += marks;
            }
        }


        public void ShowDetails()
        {
            Console.WriteLine("\n----- STUDENT DETAILS -----");
            Console.WriteLine($"Name     : {_firstName} {_middleName} {_lastName}");
            Console.WriteLine($"Age      : {age}");
            Console.WriteLine($"Class    : {ClassStandard}");
            Console.WriteLine($"Roll No  : {RollNo}");

            _address.ShowAddress();

            Console.WriteLine("\nHobbies:");
            foreach (string h in _hobbies) 
            { 
            Console.WriteLine($"- {h}");
            }

            Console.WriteLine("\nSubjects & Marks:");
            foreach (var s in subjectMarks)
                Console.WriteLine($"{s.Key} : {s.Value}");

            Console.WriteLine($"Percentage : {GetPercentage():F2}%");
            Console.WriteLine($"Enrolled   : {studentEnrollmentTime}");
        }

        // Get
        public int GetAge => age;
        public ClassStandard GetClass => ClassStandard;
        public int GetRollNo => RollNo;
        public Address GetAddress => _address;
        public double GetPercentage()
        {
            if (subjectMarks.Count == 0) return 0;
            return (double)_totalMarks / subjectMarks.Count;
        }
        public DateTime GetEnrollmentTime => studentEnrollmentTime;
        public string GetFirstName => _firstName;
        public string GetMiddleName => _middleName;
        public string GetLastName => _lastName;
        public List<string> GetHobbies => _hobbies;
        public List<Subject> GetSubjects => _subjects;
    }
}
