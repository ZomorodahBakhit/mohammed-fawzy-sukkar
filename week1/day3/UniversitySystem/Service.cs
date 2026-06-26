using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem.Models;

namespace UniversitySystem
{
    public class Service
    {
        private readonly UniversityDbContext context;

        public Service(UniversityDbContext context)
        {
            this.context = context;
        }

        public List<Course> getCourses()
        {
            return context.Courses.ToList();
        }

        public List<Assignment> getAssignementsByCourse(int courseId)
        {
            return context.Assignments.Where(a => a.courseId == courseId).ToList();
        }

        public List<User> getStudents()
        {
            return context.Users.Where(u => u.role == "Student").ToList();
        }

        public List<Comment> getCommentsByAssignment(int assignementId)
        {
            return context.Comments.Where(c => c.assignmentId == assignementId).ToList();
        }

        public List<Grade> getStudentGrade(int studentId)
        {
            return context.Grades.Where(g => g.studentId == studentId).ToList();
        }

        public IEnumerable<dynamic> getAssignementWithRelations()
        {
            return context.Assignments
                .Include(a => a.Course)
                .ThenInclude(c => c.teacher)
                .Select(a => new
                {
                    AssignmentName = a.title,
                    CourseName = a.Course.name,
                    TeacherName = a.Course.teacher != null ? a.Course.teacher.firstName + " " + a.Course.teacher.lastName : "No Teacher"
                }).ToList();
        }

        public IEnumerable<dynamic> getAvgGradePerCourse()
        {
            return context.Grades
                .Include(g => g.Assignment)
                .ThenInclude(a => a.Course)
                .GroupBy(g => g.Assignment.Course.name)
                .Select(group => new
                {
                    courseName = group.Key,
                    avg = group.Average(g => (double?)g.grade) ?? 0.0
                }).ToList();
        }

        public string getStudentGradeLetter(int studentId, int courseId)
        {
            var avg = context.Grades.Include(g => g.Assignment)
                .Where(g => g.studentId == studentId && g.Assignment.courseId == courseId)
                .Average(g => (double?)g.grade) ?? 0.0;

            if (avg >= 90) return "A";
            if (avg >= 80) return "B";
            if (avg >= 70) return "C";
            if (avg >= 60) return "D";
            return "F";
        }

        public double CalculateGPA(int studentId)
        {
            var avg = context.Grades.Where(g => g.studentId == studentId).Average(g => (double?)g.grade) ?? 0.0;
            return avg / 25.0;
        }

        public void updateaRoleTeacher(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.id == userId && u.role == "Student");
            if (user == null) return;
            user.role = "Teacher";
            context.SaveChanges();
        }

        public void deleteComment(int commentId)
        {
            var comment = context.Comments.Find(commentId);
            if (comment == null) return;
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
    }
}