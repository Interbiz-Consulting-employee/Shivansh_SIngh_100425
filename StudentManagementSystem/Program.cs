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
        new List<string> { "Cricket", "Reading" },
        new Dictionary<string, int>
        {
            { "Maths", 88 },
            { "Science", 92 },
            { "English", 81 }
        }
    ),

    new Student(
        "Ananya", null, "Verma", 17,
        ClassStandard.Class9,
        addresses[1],
        new List<string> { "Painting", "Music" },
        new Dictionary<string, int>
        {
            { "Maths", 76 },
            { "Science", 85 },
            { "Social Studies", 79 }
        }
    ),

    new Student(
        "Amit", "Raj", "Singh", 19,
        ClassStandard.Class11,
        addresses[2],
        new List<string> { "Chess", "Coding" },
        new Dictionary<string, int>
        {
            { "Physics", 90 },
            { "Chemistry", 87 },
            { "Maths", 93 }
        }
    ),

    new Student(
        "Sneha", null, "Iyer", 18,
        ClassStandard.Class10,
        addresses[3],
        new List<string> { "Dancing", "Yoga" },
        new Dictionary<string, int>
        {
            { "Maths", 82 },
            { "Biology", 88 },
            { "English", 80 }
        }
    ),

    new Student(
        "Rohan", "Deepak", "Patil", 20,
        ClassStandard.Class12,
        addresses[4],
        new List<string> { "Gym", "Running" },
        new Dictionary<string, int>
        {
            { "Physics", 91 },
            { "Chemistry", 89 },
            { "Maths", 94 }
        }
    ),

    new Student(
        "Pooja", null, "Mehta", 17,
        ClassStandard.Class9,
        addresses[5],
        new List<string> { "Writing", "Sketching" },
        new Dictionary<string, int>
        {
            { "Maths", 73 },
            { "Science", 78 },
            { "English", 75 }
        }
    ),

    new Student(
        "Karan", "Ajay", "Malhotra", 21,
        ClassStandard.Class12,
        addresses[6],
        new List<string> { "Photography", "Travel" },
        new Dictionary<string, int>
        {
            { "Accountancy", 86 },
            { "Business Studies", 90 },
            { "Economics", 88 }
        }
    ),

    new Student(
        "Neha", null, "Gupta", 18,
        ClassStandard.Class11,
        addresses[7],
        new List<string> { "Singing", "Blogging" },
        new Dictionary<string, int>
        {
            { "History", 84 },
            { "Geography", 80 },
            { "Civics", 82 }
        }
    ),

    new Student(
        "Arjun", "Vijay", "Nair", 19,
        ClassStandard.Class11,
        addresses[8],
        new List<string> { "Swimming", "Badminton" },
        new Dictionary<string, int>
        {
            { "Physics", 88 },
            { "Chemistry", 85 },
            { "Biology", 90 }
        }
    ),

    new Student(
        "Kavya", null, "Joshi", 16,
        ClassStandard.Class9,
        addresses[9],
        new List<string> { "Calligraphy", "Craft" },
        new Dictionary<string, int>
        {
            { "Maths", 91 },
            { "Science", 89 },
            { "Computer", 95 }
        }
    )
};



        int choice;
        bool loopChoice = true ;    
        do
        {
            Console.WriteLine(@"------------MENU : ------------
             1. Add Students
             2. Get All Student Details
             3. Filter Students based on 
             4. Students whose age is between 15 to 25
             5. Topper of Class Details
             6. Nth position in topper list
             7. Find all Class where students belong to 10 secs 
             Press Any other number...");
            while (true)
            {
                Console.Write("\nEnter your choice: ");
                int.TryParse(Console.ReadLine(), out choice);
                break;
            }

            switch (choice)
            {
                case 1:
                    Student s1 = new Student();
                    s1.GetDetails();
                    students.Add(s1);
                    break;

                case 2:
                   
                    foreach (Student s in students)
                    {
                        Console.WriteLine(s.GetFirstName());
                    }   
                    break;

                case 3:
                    Console.WriteLine(@"------------FILTERATION MENU : ------------
        1.First Name
        2.Middle Name
        3.Last Name
        4.Age
        5.Roll Number
        6.Class
        7.Subjects
        8.Hobby
        9.City/State
        10.Enrollment Date/Time");
                    int c;
                    int.TryParse(Console.ReadLine(),out c );
                    FilterStudents.Filter(students ,c);
                    break;

                case 4:
                    List<Student> AgeRange = FilterStudents.AgeRange(students);
                    foreach (Student s in AgeRange)
                        s.ShowDetails();
                    break;

                case 5:

                    Rankings.Ranks(students);
                    
                    break;

                case 6:
                    int rank;
                    Console.WriteLine("Enter the Rank ?");
                    if (int.TryParse(Console.ReadLine(), out rank))
                        Rankings.Ranks(students, rank);
                    else
                        Console.WriteLine("Invalid Input");
                        break;

                case 7:
                    List<ClassStandard> recentClasses =
    ClassBasedOnTime.GetClassesOfStudentsEnrolledInLast10Seconds(students);

                    if (recentClasses.Count == 0)
                    {
                        Console.WriteLine("No students enrolled in last 10 seconds.");
                    }
                    else
                    {
                        Console.WriteLine("Classes with students enrolled in last 10 seconds:");
                        foreach (ClassStandard cls in recentClasses)
                        {
                            Console.WriteLine(cls);
                        }
                    }
                    break;


                default:
                    Console.WriteLine("bye bye");
                    loopChoice = false;
                    break;

            }
            Console.WriteLine("At the end of loop"+ choice);
        } while (choice == 0 || choice < 8 );
     

    }

    
    
}

