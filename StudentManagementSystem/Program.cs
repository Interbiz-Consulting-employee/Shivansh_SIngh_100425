using StudentManagementSystem;
using StudentManagementSystem.Constants;
using StudentManagementSystem.Enums;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using System;

class Program
{
    static void Main()
    {
        //List<Address> addresses = new List<Address>
//        {
//            new Address(12, 4, "Andheri East", "Mumbai", "Maharashtra", 400069),
//            new Address(45, 10, "Whitefield", "Bengaluru", "Karnataka", 560066),
//            new Address(7, 22, "Salt Lake Sector V", "Kolkata", "West Bengal", 700091),
//            new Address(89, 3, "Hitech City", "Hyderabad", "Telangana", 500081),
//            new Address(16, 9, "Anna Nagar", "Chennai", "Tamil Nadu", 600040),
//            new Address(101, 15, "Baner", "Pune", "Maharashtra", 411045),
//            new Address(33, 6, "Vasant Kunj", "New Delhi", "Delhi", 110070),
//            new Address(58, 12, "Sector 62", "Noida", "Uttar Pradesh", 201309),
//            new Address(24, 18, "Alkapuri", "Vadodara", "Gujarat", 390007),
//            new Address(5, 1, "Boring Road", "Patna", "Bihar", 800001)
//        };
        List<Student> students = new List<Student>();
//{
//    new Student(
//        "Rahul", "Kumar", "Sharma", 18,
//        ClassStandard.Class10,
//        addresses[0],
//        new List<string> { "Cricket", "Music" },
//        new Dictionary<Subject, int>
//        {
//            { Subject.Maths, 88 },
//            { Subject.Science, 92 },
//            { Subject.English, 81 }
//        }
//    ),

//    new Student(
//        "Ananya", null, "Verma", 17,
//        ClassStandard.Class9,
//        addresses[1],
//        new List<string> { "Painting", "Music" },
//        new Dictionary<Subject, int>
//        {
//            { Subject.Maths, 76 },
//            { Subject.Science, 85 },
//            { Subject.SocialStudies, 79 }
//        }
//    ),

//    new Student(
//        "Amit", "Raj", "Singh", 19,
//        ClassStandard.Class11,
//        addresses[2],
//        new List<string> { "Chess", "Coding" },
//        new Dictionary<Subject, int>
//        {
//            { Subject.Physics, 90 },
//            { Subject.Chemistry, 87 },
//            { Subject.Maths, 93 }
//        }
//    ),

//    new Student(
//        "Sneha", null, "Iyer", 18,
//        ClassStandard.Class10,
//        addresses[3],
//        new List<string> { "Dancing", "Yoga" },
//        new Dictionary<Subject, int>
//        {
//            { Subject.Maths, 82 },
//            { Subject.Biology, 88 },
//            { Subject.English, 80 }
//        }
//    ),

//    new Student(
//        "Rohan", "Deepak", "Patil", 20,
//        ClassStandard.Class10,
//        addresses[4],
//        new List<string> { "Gym", "Running" },
//        new Dictionary<Subject, int>
//        {
//            { Subject.Physics, 91 },
//            { Subject.Chemistry, 89 },
//            { Subject.Maths, 94 }
//        }
//    ),

//    new Student(
//        "Pooja", null, "Mehta", 17,
//        ClassStandard.Class9,
//        addresses[5],
//        new List<string> { "Writing", "Sketching" },
//        new Dictionary<Subject, int>
//        {
//            { Subject.Maths, 73 },
//            { Subject.Science, 78 },
//            { Subject.English, 75 }
//        }
//    ),

//    new Student(
//        "Karan", "Ajay", "Malhotra", 21,
//        ClassStandard.Class11,
//        addresses[6],
//        new List<string> { "Photography", "Travel" },
//        new Dictionary<Subject, int>
//        {
//            { Subject.Science, 86 },
//            { Subject.English, 90 },
//            { Subject.Hindi, 88 }
//        }
//    ),

//    new Student(
//        "karan", null, "Gupta", 18,
//        ClassStandard.Class11,
//        addresses[7],
//        new List<string> { "Singing", "Blogging" },
//        new Dictionary<Subject, int>
//        {
//            { Subject.English, 84 },
//            { Subject.Maths, 80 },
//            { Subject.SocialStudies, 82 }
//        }
//    ),

//    new Student(
//        "Arjun", "Vijay", "Nair", 19,
//        ClassStandard.Class11,
//        addresses[8],
//        new List<string> { "Swimming", "Badminton" },
//        new Dictionary<Subject, int>
//        {
//            { Subject.Physics, 88 },
//            { Subject.Chemistry, 85 },
//            { Subject.Biology, 90 }
//        }
//    ),

//    new Student(
//        "Kavya", null, "Joshi", 16,
//        ClassStandard.Class9,
//        addresses[9],
//        new List<string> { "Calligraphy", "Craft" },
//        new Dictionary<Subject, int>
//        {
//            { Subject.Maths, 91 },
//            { Subject.Science, 89 },
//            { Subject.ComputerScience, 95 }
//        }
//    )
//};


        int choice;
        bool loopChoice = true;

        do
        {
            Console.WriteLine(@"
------------ MENU ------------
1. Add Students
2. Get All Student Details
3. Filter Students
4. Students whose age is between 15 to 25
5. Topper of Class Details
6. Nth position in topper list
7. Find all Class where students belong (every 10 secs)
0. Exit
");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter numbers only.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    try
                    {
                        Student s1 = new Student();
                        Thread t1 = new Thread(s1.ReadStudentDetailsFromConsole);
                        t1.Start();
                        t1.Join();
                        students.Add(s1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to add student: " + ex.Message);
                    }
                    break;

                case 2:
                    foreach (Student s in students)
                        s.ShowDetails();
                    break;

                case 3:
                    FilterStudentsService.Filter(students);
                    break;

                case 4:
                    foreach (Student s in FilterStudentsService.AgeRange(students, 15, 25))
                        s.ShowDetails();
                    break;

                case 5:
                    RankingsService.ShowRank(students);
                    break;

                case 6:
                    Console.Write("Enter Rank: ");
                    if (int.TryParse(Console.ReadLine(), out int rank))
                        RankingsService.ShowRank(students, rank);
                    else
                        Console.WriteLine("Invalid rank input.");
                    break;

                case 7:
                    Thread monitorThread = new Thread(() =>
                        ClassMonitor.FindClassesEveryInterval(students, 10));

                    monitorThread.IsBackground = true;
                    monitorThread.Start();

                    Console.WriteLine("Press ENTER to stop monitoring...");
                    Console.ReadLine();

                    ClassMonitor.Stop();
                    monitorThread.Join();
                    break;

                case 0:
                    Console.WriteLine("Exiting application...");
                    loopChoice = false;
                    break;

                default:
                    Console.WriteLine(Messages.SelectValidOption);
                    break;
            }

        } while (loopChoice);
      }

    }
