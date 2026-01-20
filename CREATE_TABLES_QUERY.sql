CREATE TABLE University (
    UniversityID INT IDENTITY(100,1) PRIMARY KEY,
    UniversityName VARCHAR(50) NOT NULL,
    UniversityType VARCHAR(20) NOT NULL CHECK (UniversityType IN ('Public', 'Private')),
    UniversityGrade VARCHAR(2) CHECK (UniversityGrade IN ('A+', 'A', 'B+', 'B', 'C', 'D', 'F')),
    UniversityAddress VARCHAR(100) NOT NULL,
    CONSTRAINT UQ_UniversityName UNIQUE (UniversityName)
);

CREATE TABLE College (
    CollegeID INT IDENTITY(200,1) PRIMARY KEY,
    CollegeName VARCHAR(50) NOT NULL,
    CollegeType VARCHAR(20) NOT NULL CHECK (CollegeType IN ('Engineering', 'Medical', 'Arts', 'Business', 'Other')),
    CollegeAddress VARCHAR(100) NOT NULL,
    UniversityID INT NOT NULL,
    CONSTRAINT FK_College_University FOREIGN KEY (UniversityID)
        REFERENCES University(UniversityID)
);

CREATE TABLE Department (
    DepartmentID INT IDENTITY(10,1) PRIMARY KEY,
    DepartmentName VARCHAR(50) NOT NULL,
    NuOfClass INT CHECK (NuOfClass >= 0),
    DepartmentHead VARCHAR(50) NOT NULL,
    CollegeID INT NOT NULL,
    CONSTRAINT FK_Department_College FOREIGN KEY (CollegeID)
        REFERENCES College(CollegeID)
);

CREATE TABLE Professor (
    ProfessorID INT IDENTITY(500,1) PRIMARY KEY,
    ProfessorName VARCHAR(50) NOT NULL,
    ProfessorAddress VARCHAR(100) NOT NULL,
    ProfessorAge INT CHECK (ProfessorAge >= 25 AND ProfessorAge <= 80),
    ProfessorSalary DECIMAL(10,2) CHECK (ProfessorSalary >= 0),
    DepartmentID INT NOT NULL,
    CONSTRAINT FK_Professor_Department FOREIGN KEY (DepartmentID)
        REFERENCES Department(DepartmentID)
);

CREATE TABLE Student (
    StudentID INT IDENTITY(1000,1) PRIMARY KEY,
    StudentName VARCHAR(50) NOT NULL,
    StudentAddress VARCHAR(100) NOT NULL,
    StudentAge INT CHECK (StudentAge >= 15 AND StudentAge <= 30),
    StudentPercentage DECIMAL(5,2) CHECK (StudentPercentage >= 0 AND StudentPercentage <= 100),
    StudentMarks INT CHECK (StudentMarks >= 0),
    StudentResult VARCHAR(10) CHECK (StudentResult IN ('Pass', 'Fail')),
    DepartmentID INT NOT NULL,
    CONSTRAINT FK_Student_Department FOREIGN KEY (DepartmentID)
        REFERENCES Department(DepartmentID)
);
