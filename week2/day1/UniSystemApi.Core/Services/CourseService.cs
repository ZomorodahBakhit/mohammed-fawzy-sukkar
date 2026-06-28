using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSystemApi.Core.DTOs;
using UniSystemApi.Core.Forms;
using UniSystemApi.Data.Entities;
using UniSystemApi.Data.Repositories;

namespace UniSystemApi.Core.Services
{
    public interface ICourseService
    {
        CourseDTO? GetById(int id);
        List<CourseDTO> GetAll();
        void Create(CreateCourseForm form);
        void Update(int id, UpdateCourseForm form);
        void Delete(int id);
    }
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        } 
        public CourseDTO? GetById(int id)
        {
            var course = _repository.GetById(id);
            if (course == null) return null;

            return new CourseDTO
            {
                Id = course.Id,
                Title = course.Title,
                StartDate = course.StartDate,
                EndDate = course.EndDate
            };
        }
        public List<CourseDTO> GetAll()
        {
            var courses = _repository.GetAll();
            return courses.Select(c => new CourseDTO
            {
                Id = c.Id,
                Title = c.Title,
                StartDate = c.StartDate,
                EndDate = c.EndDate
            }).ToList();
        }
        public void Create(CreateCourseForm form)
        {
            var course = new Course
            {
                Title = form.Title,
                StartDate = form.StartDate,
                EndDate = form.EndDate
            };
            _repository.Add(course);
        }
        public void Update(int id, UpdateCourseForm form)
        {
            var course = _repository.GetById(id);
            if (course != null)
            {
                course.Title = form.Title ?? course.Title;
                course.StartDate = form.StartDate ?? course.StartDate;
                course.EndDate = form.EndDate ?? course.EndDate;

                _repository.Update(course);
            }
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
