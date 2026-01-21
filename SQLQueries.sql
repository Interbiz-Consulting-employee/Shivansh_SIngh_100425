--1.Get the list of students who belong with a University Name is ‘AAAAAA’.

SELECT s.StudentID, s.StudentName , d.DepartmentName, c.CollegeName , u.UniversityName
FROM student s
JOIN  department d ON s.DepartmentID = d.DepartmentID 
JOIN  college c ON d.CollegeID = c.CollegeID  
JOIN  university u ON c.UniversityID = u.UniversityID 
Where u.UniversityName = 'AAAAAA'
Order by StudentID;

--2. Group the students university-wise, college-wise, and department-wise.

SELECT s.StudentName , u.UniversityName ,  c.CollegeName , d.DepartmentName
FROM student s
JOIN  department d ON s.DepartmentID = d.DepartmentID 
JOIN  college c ON d.CollegeID = c.CollegeID  
JOIN  university u ON c.UniversityID = u.UniversityID 
group by  u.UniversityName ,  c.CollegeName , d.DepartmentName , s.StudentName  ;


--3. Get the list of professors (University name, 'Collegename' , 'DepartmentName', 'ProfessorId', 'ProfessorName', 'ProfessorAddress', 'ProfessorAge') whose salary is more than $ 50,000.00

Select u.UniversityName , c.CollegeName , d.DepartmentName , p.ProfessorID , p.ProfessorName , p.ProfessorAddress , p.ProfessorAge
From professor p
JOIN  department d ON p.DepartmentID = d.DepartmentID 
JOIN  college c ON d.CollegeID = c.CollegeID  
JOIN  university u ON c.UniversityID = u.UniversityID 
Where p.ProfessorSalary > 50000 ;


--4. Get the sum of salary whose belonging university Name is ‘BBBBBB’.

SELECT u.UniversityName, SUM(p.ProfessorSalary) AS Total_Salary
FROM Professor p
JOIN Department d ON p.DepartmentID = d.DepartmentID
JOIN College c ON d.CollegeID = c.CollegeID
JOIN University u ON c.UniversityID = u.UniversityID
WHERE u.UniversityName = 'BBBBBB'
GROUP BY u.UniversityName;

--5. Count students university-wise who have passed the first, second and third division.

SELECT u.UniversityName,
    SUM(CASE WHEN s.StudentPercentage >= 60 THEN 1 ELSE 0 END) AS First_Division,
    SUM(CASE WHEN s.StudentPercentage BETWEEN 45 AND 59.99 THEN 1 ELSE 0 END) AS Second_Division,
    SUM(CASE WHEN s.StudentPercentage BETWEEN 33 AND 44.99 THEN 1 ELSE 0 END) AS Third_Division
FROM Student s
JOIN Department d ON s.DepartmentID = d.DepartmentID
JOIN College c ON d.CollegeID = c.CollegeID
JOIN University u ON c.UniversityID = u.UniversityID
Where s.StudentResult = 'Pass' 
GROUP BY u.UniversityName;


--6. Get List of students who study in the ‘Computer Science’ department


SELECT s.StudentID, s.StudentName , d.DepartmentName , c.CollegeName
FROM student s
JOIN  department d ON s.DepartmentID = d.DepartmentID
JOIN  College c ON c.CollegeID = d.CollegeID
Where d.DepartmentName = 'Computer Science'; 


--7. Get the name of the university who have passed with maximum marks.

SELECT StudentName, StudentMarks, UniversityName
FROM (
    SELECT s.StudentName,
           s.StudentMarks,
           u.UniversityName,
           RANK() OVER (ORDER BY s.StudentMarks DESC) AS rnk
    FROM Student s
    JOIN Department d ON s.DepartmentID = d.DepartmentID
    JOIN College c ON d.CollegeID = c.CollegeID
    JOIN University u ON c.UniversityID = u.UniversityID
    WHERE s.StudentResult = 'Pass'
) t
WHERE rnk = 1;

--8. Get list of students who study in grade ‘A’ University

SELECT  s.StudentName , u.UniversityName , u.universityGrade
FROM Student s
JOIN Department d ON s.DepartmentID = d.DepartmentID
JOIN College c ON d.CollegeID = c.CollegeID
JOIN University u ON c.UniversityID = u.UniversityID
Where u.UniversityGrade = 'A';        

--9. The percentage of passed students who belong with a University Name is ‘AAAAAA’.


SELECT u.UniversityName,(SUM(CASE WHEN s.StudentResult = 'Pass' THEN 1 ELSE 0 END) * 100.0 / COUNT(s.StudentID)) AS Pass_Percentage
FROM Student s
JOIN Department d ON s.DepartmentID = d.DepartmentID
JOIN College c ON d.CollegeID = c.CollegeID
JOIN University u ON c.UniversityID = u.UniversityID
WHERE u.UniversityName = 'AAAAAA'
GROUP BY u.UniversityName;

--10. Get the percentage of the result college wise.


SELECT c.CollegeName, (SUM(CASE WHEN s.StudentResult = 'Pass' THEN 1 ELSE 0 END) * 100.0 / COUNT(s.StudentID)) AS Pass_Percentage
FROM dbo.Student s
JOIN dbo.Department d ON s.DepartmentID = d.DepartmentID
JOIN dbo.College c ON d.CollegeID = c.CollegeID
GROUP BY c.CollegeName;
