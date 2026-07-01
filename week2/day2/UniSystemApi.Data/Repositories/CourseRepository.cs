using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSystemApi.Data.Entities;

namespace UniSystemApi.Data.Repositories
{
    public interface ICourseRepository
    {
        Course? GetById(int id);
        List<Course> GetAll();
        void Add(Course course);
        void Update(Course course);
        void Delete(int id);
    }
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext _context;
        public CourseRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public Course? GetById(int id)
        {
            return _context.Courses.Find(id);
        }
        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }
        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course); ;
                _context.SaveChanges();
            }
        }
    }
}
