INSERT INTO University (UniversityName, UniversityType, UniversityGrade, UniversityAddress)
VALUES
('AAAAAA', 'Public', 'A', 'New Delhi, India'),
('BBBBBB', 'Private', 'B+', 'Mumbai, Maharashtra'),
('CCCCCC', 'Public', 'A+', 'Bengaluru, Karnataka');

INSERT INTO College (CollegeName, CollegeType, CollegeAddress, UniversityID)
VALUES
('Delhi Engineering College', 'Engineering', 'Delhi', 100),
('Delhi Medical College', 'Medical', 'Delhi', 100),
('Mumbai Business School', 'Business', 'Mumbai', 101),
('Mumbai Arts College', 'Arts', 'Mumbai', 101),
('Bangalore Engineering College', 'Engineering', 'Bengaluru', 102);


INSERT INTO Department (DepartmentName, NuOfClass, DepartmentHead, CollegeID)
VALUES
('Computer Science', 10, 'Dr. Rajesh Sharma', 200),
('Mechanical Engineering', 8, 'Dr. Anil Verma', 200),
('MBBS', 12, 'Dr. Sunita Rao', 201),
('Finance', 6, 'Dr. Ramesh Iyer', 202),
('English', 5, 'Dr. Kavita Nair', 203),
('Computer Science', 9, 'Dr. Prakash Kulkarni', 204);


INSERT INTO Professor (ProfessorName, ProfessorAddress, ProfessorAge, ProfessorSalary, DepartmentID)
VALUES
('Dr. Amit Kumar', 'Delhi', 45, 75000, 10),
('Dr. Suresh Mehta', 'Delhi', 55, 60000, 11),
('Dr. Neha Singh', 'Delhi', 42, 52000, 12),
('Dr. Rohan Deshpande', 'Mumbai', 50, 80000, 13),
('Dr. Meenal Joshi', 'Mumbai', 48, 65000, 14),
('Dr. Arvind Rao', 'Bengaluru', 46, 90000, 15);

INSERT INTO Student
(StudentName, StudentAddress, StudentAge, StudentPercentage, StudentMarks, StudentResult, DepartmentID)
VALUES
('Rahul Sharma', 'Delhi', 20, 85.50, 850, 'Pass', 10),
('Priya Verma', 'Delhi', 21, 62.00, 620, 'Pass', 10),
('Aman Gupta', 'Delhi', 22, 50.00, 500, 'Pass', 11),
('Neha Jain', 'Delhi', 19, 40.00, 400, 'Pass', 12), 
('Rohit Malhotra', 'Delhi', 23, 28.00, 280, 'Fail', 11),
('Sanket Patil', 'Mumbai', 21, 78.00, 780, 'Pass', 13),
('Pooja Kulkarni', 'Mumbai', 22, 55.00, 550, 'Pass', 13),
('Anjali Desai', 'Mumbai', 20, 35.00, 350, 'Pass', 14),
('Vikram Rao', 'Bengaluru', 22, 95.00, 950, 'Pass', 15);
