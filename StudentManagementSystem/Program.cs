using StudentManagementSystem;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using System;
class Program
{
    static void Main()
    {
        List<Address> addresses = new List<Address>
{
    new Address(12, 4, "Andheri East", "Mumbai", "Maharashtra", 400069),
    new Address(45, 10, "Whitefield", "Bengaluru", "Karnataka", 560066),
    new Address(7, 22, "Salt Lake Sector V", "Kolkata", "West Bengal", 700091),
    new Address(89, 3, "Hitech City", "Hyderabad", "Telangana", 500081),
    new Address(16, 9, "Anna Nagar", "Chennai", "Tamil Nadu", 600040),
    new Address(101, 15, "Baner", "Pune", "Maharashtra", 411045),
    new Address(33, 6, "Vasant Kunj", "New Delhi", "Delhi", 110070),
    new Address(58, 12, "Sector 62", "Noida", "Uttar Pradesh", 201309),
    new Address(24, 18, "Alkapuri", "Vadodara", "Gujarat", 390007),
    new Address(5, 1, "Boring Road", "Patna", "Bihar", 800001)
};
        List<Student> students = new List<Student>
{
    new Student(
        "Rahul", "Kumar", "Sharma", 18,
        ClassStandard.Class10,
        addresses[0],
        new List<string> { "Cricket", "Music" },
        new Dictionary<Subject, int>
        {
            { Subject.Maths, 88 },
            { Subject.Science, 92 },
            { Subject.English, 81 }
        }
    ),

    new Student(
        "Ananya", null, "Verma", 17,
        ClassStandard.Class9,
        addresses[1],
        new List<string> { "Painting", "Music" },
        new Dictionary<Subject, int>
        {
            { Subject.Maths, 76 },
            { Subject.Science, 85 },
            { Subject.SocialStudies, 79 }
        }
    ),

    new Student(
        "Amit", "Raj", "Singh", 19,
        ClassStandard.Class11,
        addresses[2],
        new List<string> { "Chess", "Coding" },
        new Dictionary<Subject, int>
        {
            { Subject.Physics, 90 },
            { Subject.Chemistry, 87 },
            { Subject.Maths, 93 }
        }
    ),

    new Student(
        "Sneha", null, "Iyer", 18,
        ClassStandard.Class10,
        addresses[3],
        new List<string> { "Dancing", "Yoga" },
        new Dictionary<Subject, int>
        {
            { Subject.Maths, 82 },
            { Subject.Biology, 88 },
            { Subject.English, 80 }
        }
    ),

    new Student(
        "Rohan", "Deepak", "Patil", 20,
        ClassStandard.Class10,
        addresses[4],
        new List<string> { "Gym", "Running" },
        new Dictionary<Subject, int>
        {
            { Subject.Physics, 91 },
            { Subject.Chemistry, 89 },
            { Subject.Maths, 94 }
        }
    ),

    new Student(
        "Pooja", null, "Mehta", 17,
        ClassStandard.Class9,
        addresses[5],
        new List<string> { "Writing", "Sketching" },
        new Dictionary<Subject, int>
        {
            { Subject.Maths, 73 },
            { Subject.Science, 78 },
            { Subject.English, 75 }
        }
    ),

    new Student(
        "Karan", "Ajay", "Malhotra", 21,
        ClassStandard.Class11,
        addresses[6],
        new List<string> { "Photography", "Travel" },
        new Dictionary<Subject, int>
        {
            { Subject.Science, 86 },
            { Subject.English, 90 },
            { Subject.Hindi, 88 }
        }
    ),

    new Student(
        "karan", null, "Gupta", 18,
        ClassStandard.Class11,
        addresses[7],
        new List<string> { "Singing", "Blogging" },
        new Dictionary<Subject, int>
        {
            { Subject.English, 84 },
            { Subject.Maths, 80 },
            { Subject.SocialStudies, 82 }
        }
    ),

    new Student(
        "Arjun", "Vijay", "Nair", 19,
        ClassStandard.Class11,
        addresses[8],
        new List<string> { "Swimming", "Badminton" },
        new Dictionary<Subject, int>
        {
            { Subject.Physics, 88 },
            { Subject.Chemistry, 85 },
            { Subject.Biology, 90 }
        }
    ),

    new Student(
        "Kavya", null, "Joshi", 16,
        ClassStandard.Class9,
        addresses[9],
        new List<string> { "Calligraphy", "Craft" },
        new Dictionary<Subject, int>
        {
            { Subject.Maths, 91 },
            { Subject.Science, 89 },
            { Subject.ComputerScience, 95 }
        }
    )
};


        int choice=0;
        bool loopChoice = true;


        do
        {
            try
            {
                Console.WriteLine(@"------------MENU : ------------
1. Add Students
2. Get All Student Details
3. Filter Students based on
4. Students whose age is between 15 to 25
5. Topper of Class Details
6. Nth position in topper list
7. Find all Class where students belong to 10 secs");

                Console.Write("\nEnter your choice: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                       
                            Student s1 = new Student();

                        try
                        {
                            Thread t1 = new Thread(s1.ReadStudentDetailsFromConsole);


                            t1.Start();

                            students.Add(s1);
                            t1.Join();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to add student: " + ex.Message);
                        }
                        break;

                    case 2:
                        try
                        {
                            foreach (Student s in students)
                              s.ShowDetails();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error displaying students: " + ex.Message);
                        }
                        break;

                    case 3:
                        try
                        {
                            FilterStudents.Filter(students)
;                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Filter error: " + ex.Message);
                        }
                        break;

                    case 4:
                        try
                        {
                            List<Student> AgeRange = FilterStudents.AgeRange(students, 15, 25);
                            foreach (Student s in AgeRange)
                                s.ShowDetails();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Age filter error: " + ex.Message);
                        }
                        break;

                    case 5:
                        try
                        {
                            Rankings.ShowRank(students);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ranking error: " + ex.Message);
                        }
                        break;

                    case 6:
                        try
                        {
                            int rank;
                            Console.WriteLine("Enter the Rank ?");
                            if (int.TryParse(Console.ReadLine(), out rank))
                                Rankings.ShowRank(students, rank);
                            else
                                Console.WriteLine("Invalid Input");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Rank error: " + ex.Message);
                        }
                        break;

                    case 7:
                        try
                        {
                            ClassFinderDelegate del =
                             () => ClassMonitor.FindClassesEvery10Seconds(students);

                            
                            Thread thread = new Thread(new ThreadStart(del));
                            thread.IsBackground = true;
                            thread.Start();

                        
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Time-based query error: " + ex.Message);
                        }
                        break;

                    default:
                        Console.WriteLine("bye bye");
                        loopChoice = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Menu execution error: " + ex.Message);
            }

        } while (choice == 0 || choice < 8);
    }

}
