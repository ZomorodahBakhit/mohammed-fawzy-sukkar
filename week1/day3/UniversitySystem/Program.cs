// See https://aka.ms/new-console-template for more information
using UniversitySystem;
using UniversitySystem.Models;
using Microsoft.EntityFrameworkCore;
Console.WriteLine("Hello, World!");

using var context = new UniversityDbContext();
context.Database.EnsureDeleted();
context.Database.Migrate();
var users = new List<User>
{
    new User {userName = "feryal_f", firstName = "Feryal", lastName = "f", email = "feryal@gmail.com", phoneNumber = "0941111111", role = "Teacher"},
    new User {userName = "sami hijazi", firstName = "sami", lastName = "hijazi", email = "sami@gmail.com", phoneNumber = "0941377777", role = "Teacher" },
    new User {userName = "Fawzy Sukkar", firstName = "Fawzy", lastName = "Sukkar", email = "fawzy@gmail.com", phoneNumber = "0943333333", role = "Student" },
    new User {userName = "Zuheir Alhomsi", firstName = "Zuheir", lastName = "Alhomsi", email = "zuheirAlhomsi73@gmail.com", phoneNumber = "0944444444", role = "Student" },
};
context.Users.AddRange(users);
context.SaveChanges();

var syllabuses = new List<Syllabus>
{
    new Syllabus { description = "SQL Server Basics, Queries, Joins, and Stored Procedures" },
    new Syllabus { description = "C# Fundamentals, OOP, and LINQ" },
    new Syllabus { description = "Entity Framework Core, Code First, and Migrations" },
    new Syllabus { description = "RESTful Web API, Controllers, and Routing" },
    new Syllabus { description = "React Components, Hooks, and State Management" }
};
context.Syllabus.AddRange(syllabuses);
context.SaveChanges();

var courses = new List<Course>
{
    new Course { name = "SQL", teacherId = users[0].id, syllabusId = syllabuses[0].id, startDate = new DateTime(2026, 11, 11), endDate = new DateTime(2027, 11, 11) },
    new Course { name = "C#", teacherId = users[1].id, syllabusId = syllabuses[1].id, startDate = new DateTime(2026, 11, 11), endDate = new DateTime(2027, 11, 11) },
    new Course { name = "Entity FrameWork", teacherId = users[1].id, syllabusId = syllabuses[2].id, startDate = new DateTime(2026, 11, 11), endDate = new DateTime(2027, 11, 11) },
    new Course { name = "Web Api", startDate = new DateTime(2026, 11, 11), endDate = new DateTime(2027, 11, 11), syllabusId = syllabuses[3].id },
    new Course { name = "React", startDate = new DateTime(2026, 11, 11), endDate = new DateTime(2027, 11, 11), syllabusId = syllabuses[4].id }
};
context.Courses.AddRange(courses);
context.SaveChanges();

var assignments = new List<Assignment>
{
    new Assignment { courseId = 1, title = "Basic Selects", description = "Practice basic select queries", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 5, 10) },
    new Assignment { courseId = 1, title = "Joins", description = "Practice Inner and Outer Joins", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 5, 15) },
    new Assignment { courseId = 1, title = "Grouping", description = "Group by and Having clauses", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 5, 20) },
    new Assignment { courseId = 1, title = "Stored Procedures", description = "Create procedures", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 5, 25) },
    new Assignment { courseId = 1, title = "Functions", description = "Create scalar functions", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 5, 30) },
    new Assignment { courseId = 2, title = "Variables & Loops", description = "Basic syntax", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 6, 1) },
    new Assignment { courseId = 2, title = "Classes & Objects", description = "OOP concepts", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 6, 5) },
    new Assignment { courseId = 2, title = "Inheritance", description = "Base and derived classes", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 6, 10) },
    new Assignment { courseId = 2, title = "Interfaces", description = "Implementing interfaces", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 6, 15) },
    new Assignment { courseId = 2, title = "LINQ Queries", description = "Filtering data with LINQ", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 6, 20) },
    new Assignment { courseId = 3, title = "DbSets", description = "Setting up DbContext", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 6, 10) },
    new Assignment { courseId = 3, title = "Migrations", description = "Adding migrations", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 6, 15) },
    new Assignment { courseId = 3, title = "Relations 1-to-Many", description = "Configuring relations", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 6, 20) },
    new Assignment { courseId = 3, title = "Relations Many-to-Many", description = "Fluent API relations", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 6, 25) },
    new Assignment { courseId = 3, title = "CRUD Operations", description = "Insert, update, delete", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 6, 30) },
    new Assignment { courseId = 4, title = "First Controller", description = "Get requests", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 7, 1) },
    new Assignment { courseId = 4, title = "Post & Put", description = "Creating and updating resources", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 7, 5) },
    new Assignment { courseId = 4, title = "Dependency Injection", description = "Injecting services", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 7, 10) },
    new Assignment { courseId = 4, title = "Status Codes", description = "Returning correct HTTP codes", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 7, 15) },
    new Assignment { courseId = 4, title = "Middleware", description = "Custom middleware", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 7, 20) },
    new Assignment { courseId = 5, title = "JSX Basics", description = "Rendering elements", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 7, 15) },
    new Assignment { courseId = 5, title = "Props", description = "Passing data to components", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 7, 20) },
    new Assignment { courseId = 5, title = "useState", description = "Managing component state", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 7, 25) },
    new Assignment { courseId = 5, title = "useEffect", description = "Handling side effects", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 7, 30) },
    new Assignment { courseId = 5, title = "React Router", description = "Navigating between pages", weight = 20, maxGrade = 100, dueDate = new DateTime(2026, 8, 5) }
};
context.Assignments.AddRange(assignments);
context.SaveChanges();

var comments = new List<Comment>
{
    new Comment { assignmentId = 1, userId = 3, createdDate = new DateTime(2026, 5, 12), content = "easy 1" },
    new Comment { assignmentId = 2, userId = 4, createdDate = new DateTime(2026, 5, 13), content = "easy 2" },
    new Comment { assignmentId = 2, userId = 1, createdDate = new DateTime(2026, 5, 14), content = "easy 3" },
    new Comment { assignmentId = 6, userId = 3, createdDate = new DateTime(2026, 5, 15), content = "easy 4" },
    new Comment { assignmentId = 6, userId = 2, createdDate = new DateTime(2026, 5, 16), content = "easy 5" },
    new Comment { assignmentId = 15, userId = 4, createdDate = new DateTime(2026, 5, 17), content = "easy 6" },
    new Comment { assignmentId = 21, userId = 3, createdDate = new DateTime(2026, 5, 18), content = "easy 7" },
    new Comment { assignmentId = 23, userId = 4, createdDate = new DateTime(2026, 5, 19), content = "easy 8" },
    new Comment { assignmentId = 23, userId = 2, createdDate = new DateTime(2026, 5, 20), content = "very hard" },
    new Comment { assignmentId = 25, userId = 3, createdDate = new DateTime(2026, 5, 21), content = "easy 9" }
};
context.Comments.AddRange(comments);
context.SaveChanges();

var random = new Random();
var grades = new List<Grade>();
var studentIds = new List<int> { 1, 2, 3, 4 };

foreach (var assignment in assignments)
{
    foreach (var studentId in studentIds)
    {
        grades.Add(new Grade
        {
            assignmentId = assignment.id,
            studentId = studentId,
            grade = random.Next(50, 101)
        });
    }
}
context.Grades.AddRange(grades);
context.SaveChanges();


Service service = new Service(context);
// 1. getCourses
var s_courses = service.getCourses();
Console.WriteLine("Courses:");
foreach(var course in s_courses)
{
    Console.WriteLine($"{course.name}");
}

// 2. getAssignementsByCourse
var s_assignments = service.getAssignementsByCourse(1);
Console.WriteLine($"Assignments for Course 1:");
foreach (var i in s_assignments)
{
    Console.WriteLine($"- {i.title} , Max Grade: {i.maxGrade} , Due: {i.dueDate.ToShortDateString()}");
}

// 3. getStudents
var students = service.getStudents();
Console.WriteLine($"Students: {students.Count}");

// 4. getCommentsByAssignment
var s_comments = service.getCommentsByAssignment(1);
Console.WriteLine("Comments for Assignment 1: ");
foreach(var comment in s_comments)
{
    Console.WriteLine(comment.content);
}

// 5. getStudentGrade
var s_grades = service.getStudentGrade(3);
Console.WriteLine($"Grades for Student 3: ");
foreach(var grade in s_grades)
{
    Console.WriteLine($"- Assignment id: {grade.assignmentId} , Grade: {grade.grade}");
}

// 6. getAssignementWithRelations
var assignmentsWithRelations = service.getAssignementWithRelations();
Console.WriteLine("Assignments with relations:");
foreach (var i in assignmentsWithRelations)
{
    Console.WriteLine($"- {i.AssignmentName} , Course: {i.CourseName} , Teacher: {i.TeacherName}");
}

// 7. getAvgGradePerCourse
var avgPerCourse = service.getAvgGradePerCourse();
foreach (var i in avgPerCourse)
{
    Console.WriteLine($"Course: {i.courseName} , Average Grade: {i.avg:F2}");
}

// 8. getStudentGradeLetter
var gradeLetter = service.getStudentGradeLetter(3, 1);
Console.WriteLine($"Student 3 Grade Letter for Course 1: {gradeLetter}");

// 9. CalculateGPA
var gpa = service.CalculateGPA(3);
Console.WriteLine($"Student 3 GPA: {gpa}");

// 10. updateaRoleTeacher
service.updateaRoleTeacher(3);
Console.WriteLine("Updated student 3 to Teacher");

// 11. deleteComment
service.deleteComment(10);
Console.WriteLine("Deleted comment 10");

Console.WriteLine("Finished");

/*
 اظن هون عدقة كتير بهاد التابع وبتنحل بباقي التاسكات وبصير في تقسيم فولدرات أفضل بس خليتهن هيك
ببداية الكلاس مسحت الداتابيز مششان لما اعمل رن مايصير في تضارب هيك عادي ؟ لانو مافيني هون اعمل رن لجزء معين متل ال
sqlserver
اسماء التوابع والمتغيرات بصراحة احترت كيف سميها وشو الصيغة المعتادة لل
.net: Pasccal/camelCase/snake_case....
الdbcontext انا بدي عدله كل مرة بايدي ولا في طريقة أفضل ؟

 البيئة بتخلتف شي اذا استخدمت vs code / vs comunity ?
لانو متعةد على ال vs code ومابعرف اذا لفقدام لما نشتغل على نفس المشروع ممكن يسببلنا مشاكل
حاليا هاد التاسك اشتغلته على vs comunity 2022
 
 */