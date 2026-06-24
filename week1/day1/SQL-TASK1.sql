USE University;
GO
CREATE TABLE Users (
    UserId INT PRIMARY KEY,
    UserName VARCHAR(64) NOT NULL,
    FirstName VARCHAR(64) NOT NULL,
    LastName VARCHAR(64) NOT NULL,
    EmailAddress VARCHAR(128) NOT NULL CONSTRAINT unique_email UNIQUE,
    PhoneNumber VARCHAR(16) NOT NULL,
    Role VARCHAR(32) NOT NULL
);

CREATE TABLE Syllabuses (
    SyllabusId INT PRIMARY KEY,
    Description TEXT NULL
);

CREATE TABLE Courses (
    CourseId INT PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    TeacherId INT NULL CONSTRAINT FK_Courses_Users REFERENCES Users(UserId),
    StartDate DateTime NOT NULL,
    EndDate DateTime NOT NULL,
    SyllabusId INT NULL CONSTRAINT FK_Courses_Syllabus REFERENCES Syllabuses(SyllabusId)
);

CREATE TABLE Assignments (
    AssignmentId INT PRIMARY KEY,
    CourseId INT NOT NULL CONSTRAINT FK_Assignments_Courses REFERENCES Courses(CourseId),
    AssignmentTitle VARCHAR(128) NOT NULL,
    Description TEXT NULL,
    Weight float NOT NULL CONSTRAINT CHK_Weight CHECK (Weight <= 100),
    MaxGrade INT NOT NULL,
    DueDate DATE NOT NULL
);

CREATE TABLE Comments (
    CommentId INT PRIMARY KEY,
    AssignmentId INT NOT NULL CONSTRAINT FK_Comments_Assignments REFERENCES Assignments(AssignmentId),
    CreatedByUserId INT NOT NULL CONSTRAINT FK_Comments_Users REFERENCES Users(UserId),
    CreatedDate DATETIME NOT NULL,
    CommentContent TEXT NULL
);

CREATE TABLE Grades (
    GradeId INT IDENTITY(1,1) PRIMARY KEY,
    AssignmentId INT NOT NULL CONSTRAINT FK_Grades_Assignments REFERENCES Assignments(AssignmentId),
    StudentId INT NOT NULL CONSTRAINT FK_Grades_Users REFERENCES Users(UserId),
    Grade INT NULL CONSTRAINT CHK_Grade CHECK (Grade <= 100) 
);


INSERT INTO Users(UserId, UserName, FirstName, LastName, EmailAddress, PhoneNumber, Role)
VALUES 
(1, 'feryal_f', 'Feryal', 'f', 'feryal@gmail.com', '0941111111', 'Teacher'),
(2, 'sami hijazi', 'sami', 'hijazi', 'sami@gmail.com', '0941377777', 'Teacher'),
(3, 'Fawzy Sukkar', 'Fawzy', 'Sukkar', 'fawzy@gmail.com', '0943333333', 'Student'),
(4, 'Zuheir Alhomsi', 'Zuheir', 'Alhomsi', 'zuheirAlhomsi73@gmail.com', '0944444444', 'Student');

INSERT INTO Syllabuses (SyllabusId, Description) VALUES
(1, 'SQL Server Basics, Queries, Joins, and Stored Procedures'),
(2, 'C# Fundamentals, OOP, and LINQ'),
(3, 'Entity Framework Core, Code First, and Migrations'),
(4, 'RESTful Web API, Controllers, and Routing'),
(5, 'React Components, Hooks, and State Management');

INSERT INTO Courses(CourseId, TeacherId, CourseName, SyllabusId, StartDate, EndDate)
VALUES
(1, 1,'SQL', 1, '2026-11-11', '2027-11-11'),
(2, 2,'C#', 2, '2026-11-11', '2027-11-11'),
(3, 2,'Entity FrameWork', 3, '2026-11-11', '2027-11-11'),
(4, NULL,'Web Api', 4, '2026-11-11', '2027-11-11'),
(5, NULL,'React', 5, '2026-11-11', '2027-11-11');


INSERT INTO Assignments (AssignmentId, CourseId, AssignmentTitle, Description, Weight, MaxGrade, DueDate) VALUES
(1, 1, 'Basic Selects', 'Practice basic select queries', 20, 100, '2026-05-10'),
(2, 1, 'Joins', 'Practice Inner and Outer Joins', 20, 100, '2026-05-15'),
(3, 1, 'Grouping', 'Group by and Having clauses', 20, 100, '2026-05-20'),
(4, 1, 'Stored Procedures', 'Create procedures', 20, 100, '2026-05-25'),
(5, 1, 'Functions', 'Create scalar functions', 20, 100, '2026-05-30'),

(6, 2, 'Variables & Loops', 'Basic syntax', 20, 100, '2026-06-01'),
(7, 2, 'Classes & Objects', 'OOP concepts', 20, 100, '2026-06-05'),
(8, 2, 'Inheritance', 'Base and derived classes', 20, 100, '2026-06-10'),
(9, 2, 'Interfaces', 'Implementing interfaces', 20, 100, '2026-06-15'),
(10, 2, 'LINQ Queries', 'Filtering data with LINQ', 20, 100, '2026-06-20'),

(11, 3, 'DbSets', 'Setting up DbContext', 20, 100, '2026-06-10'),
(12, 3, 'Migrations', 'Adding migrations', 20, 100, '2026-06-15'),
(13, 3, 'Relations 1-to-Many', 'Configuring relations', 20, 100, '2026-06-20'),
(14, 3, 'Relations Many-to-Many', 'Fluent API relations', 20, 100, '2026-06-25'),
(15, 3, 'CRUD Operations', 'Insert, update, delete', 20, 100, '2026-06-30'),

(16, 4, 'First Controller', 'Get requests', 20, 100, '2026-07-01'),
(17, 4, 'Post & Put', 'Creating and updating resources', 20, 100, '2026-07-05'),
(18, 4, 'Dependency Injection', 'Injecting services', 20, 100, '2026-07-10'),
(19, 4, 'Status Codes', 'Returning correct HTTP codes', 20, 100, '2026-07-15'),
(20, 4, 'Middleware', 'Custom middleware', 20, 100, '2026-07-20'),

(21, 5, 'JSX Basics', 'Rendering elements', 20, 100, '2026-07-15'),
(22, 5, 'Props', 'Passing data to components', 20, 100, '2026-07-20'),
(23, 5, 'useState', 'Managing component state', 20, 100, '2026-07-25'),
(24, 5, 'useEffect', 'Handling side effects', 20, 100, '2026-07-30'),
(25, 5, 'React Router', 'Navigating between pages', 20, 100, '2026-08-05');

INSERT INTO Comments (CommentId, AssignmentId, CreatedByUserId, CreatedDate, CommentContent) VALUES
(1, 1, 3, '2026-05-12', 'easy 1'),
(2, 2, 4, '2026-05-13', 'easy 2'),
(3, 2, 1, '2026-05-14', 'easy 3'),
(4, 6, 3, '2026-05-15', 'easy 4'),
(5, 6, 2, '2026-05-16', 'easy 5'),
(6, 15, 4, '2026-05-17', 'easy 6'),
(7, 21, 3, '2026-05-18', 'easy 7'),
(8, 23, 4, '2026-05-19', 'easy 8'),
(9, 23, 2, '2026-05-20', 'very hard'),
(10, 25, 3, '2026-05-21', 'easy 9');

INSERT INTO Grades (AssignmentId, StudentId, Grade)
SELECT A.AssignmentId, U.UserId, ABS(CHECKSUM(NEWID()) % 51) + 50 
FROM Assignments A
CROSS JOIN Users U
WHERE U.Role = 'Student';


SELECT * From Grades ;

SELECT * From Assignments WHERE CourseId = 2;

SELECT * From Users WHERE Role = 'Student';

Update Users SET Role='Teacher' Where UserId = 4 AND Role = 'Student';

DELETE From Comments WHERE CommentId = 9;

SELECT U.FirstName, U.LastName, G.Grade, A.AssignmentTitle
FROM Users U
JOIN Grades G ON U.UserId = G.StudentId
JOIN Assignments A ON G.AssignmentId = A.AssignmentId
WHERE U.Role = 'Student' AND A.CourseId = 1;

SELECT C.CourseName, AVG(G.Grade) AS AverageGrade
FROM Grades G
JOIN Assignments A ON G.AssignmentId = A.AssignmentId
JOIN Courses C ON A.CourseId = C.CourseId
GROUP BY C.CourseName;

SELECT * From Courses C JOIN Syllabuses S ON C.SyllabusId = S.SyllabusId;

SELECT * From Comments C JOIN Assignments A ON C.AssignmentId = A.AssignmentId WHERE A.CourseId = 2;

EXEC AddNewStudent 5, 'ahmad_y', 'Ahmad', 'Yassin', 'ahmad@gmail.com', '0955555555', 'Student';

EXEC AddNewAssignment 26, 1, 'Final Project', 10.0, 100, '2026-12-01';

SELECT dbo.GetStudentGradeLetter(3, 1) AS GradeLetter;

SELECT dbo.CalculateGPA(3) AS StudentGPA;
-------------------------------
GO
CREATE PROCEDURE AddNewStudent
    @UserId INT,
    @UserName VARCHAR(64),
    @FirstName VARCHAR(64),
    @LastName VARCHAR(64),
    @EmailAddress VARCHAR(128),
    @PhoneNumber VARCHAR(16),
    @Role VARCHAR(8)
As
BEGIN
INSERT INTO Users (UserId, UserName, FirstName, LastName, EmailAddress, PhoneNumber, Role)
VALUES (@UserId, @UserName, @FirstName, @LastName, @EmailAddress, @PhoneNumber, @Role);
END;

GO
CREATE OR ALTER PROCEDURE AddNewAssignment
    @AssignmentId INT,
    @CourseId INT,
    @Title VARCHAR(128),
    @Weight FLOAT,
    @MaxGrade INT,
    @DueDate DATE
AS
BEGIN
    DECLARE @CurrentTotalWeight FLOAT;

    SELECT @CurrentTotalWeight = ISNULL(SUM(Weight), 0) 
    FROM Assignments WHERE CourseId = @CourseId;

    IF (@CurrentTotalWeight + @Weight <= 100)
    BEGIN
        INSERT INTO Assignments (AssignmentId, CourseId, AssignmentTitle, Weight, MaxGrade, DueDate)
        VALUES (@AssignmentId, @CourseId, @Title, @Weight, @MaxGrade, @DueDate);
    END
END;

GO
CREATE FUNCTION GetStudentGradeLetter(@StudentId INT, @CourseId INT)
RETURNS VARCHAR(1)
AS
BEGIN
    DECLARE @Letter VARCHAR(1);
    DECLARE @AvgGrade FLOAT;
    SELECT @AvgGrade = AVG(G.Grade)
    FROM Grades G 
    JOIN Assignments A ON G.AssignmentId = A.AssignmentId
    WHERE G.StudentId = @StudentId AND A.CourseId = @CourseId
    IF @AvgGrade >= 90 SET @Letter = 'A';
    ELSE IF @AvgGrade >= 80 SET @Letter = 'B';
    ELSE IF @AvgGrade >= 70 SET @Letter = 'C';
    ELSE IF @AvgGrade >= 60 SET @Letter = 'D';
    ELSE SET @Letter = 'F';
    RETURN @Letter
END;

GO 
CREATE FUNCTION CalculateGPA(@StudentId INT)
RETURNS Float
As
BEGIN
    DECLARE @Avg Float
    SELECT @Avg = AVG(G.Grade) FROM Grades G WHERE StudentId = @StudentId;
    RETURN @Avg/25.0
END;

  --DROP TABLE IF EXISTS Grades;
  --DROP TABLE IF EXISTS Comments;
  --DROP TABLE IF EXISTS Assignments;
  --DROP TABLE IF EXISTS Courses;
  --DROP TABLE IF EXISTS Syllabuses;
  --DROP TABLE IF EXISTS Syllabus;
  --DROP TABLE IF EXISTS Users;