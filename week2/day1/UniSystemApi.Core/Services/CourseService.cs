using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using UniSystemApi.Core.DTOs;
using UniSystemApi.Core.Forms;
using UniSystemApi.Data.Entities;
using UniSystemApi.Data.Repositories;
using UniversitySystemSummer.Core.Validations;
using UniSystemApi.Core.Exceptions;

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
        private readonly ILogger<CourseService> _logger;

        public CourseService(ICourseRepository repository, ILogger<CourseService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public CourseDTO? GetById(int id)
        {
            var course = _repository.GetById(id);

            if (course == null)
            {
                _logger.LogWarning($"GetById failed: Course with ID {id} was not found.");
                throw new NotFoundException($"Course with ID {id} was not found.");
            }

            return new CourseDTO
            {
                Id = course.Id,
                Title = course.Title,
                Weight = course.Weight,
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
                Weight = c.Weight,
                StartDate = c.StartDate,
                EndDate = c.EndDate
            }).ToList();
        }

        public void Create(CreateCourseForm form)
        {
            try
            {
                try
                {
                    FormValidator.Validate(form);
                }
                catch (BusinessException ex)
                {
                    _logger.LogWarning("Validation failed for course creation: {Errors}", ex.Message);
                    throw;
                }

                var course = new Course
                {
                    Title = form.Title,
                    Weight = form.Weight,
                    StartDate = form.StartDate,
                    EndDate = form.EndDate
                };

                _repository.Add(course);
                _logger.LogInformation("Course '{Title}' was created successfully.", form.Title);
            }
            catch (Exception ex) when (ex is not BusinessException)
            {
                _logger.LogError(ex, "An unexpected error occurred while creating a course.");
                throw;
            }
        }

        public void Update(int id, UpdateCourseForm form)
        {
            try
            {
                try
                {
                    FormValidator.Validate(form);
                }
                catch (BusinessException ex)
                {
                    _logger.LogWarning("Validation failed for course {Id} update : {Errors}", id, ex.Message);
                    throw;
                }

                var course = _repository.GetById(id);

                if (course == null)
                {
                    _logger.LogWarning("Update failed: Course with ID {Id} was not found.", id);
                    throw new NotFoundException($"Cannot update. Course with ID {id} was not found.");
                }

                course.Title = form.Title ?? course.Title;
                course.Weight = form.Weight ?? course.Weight;
                course.StartDate = form.StartDate ?? course.StartDate;
                course.EndDate = form.EndDate ?? course.EndDate;

                _repository.Update(course);
                _logger.LogInformation("Course with ID {Id} was updated successfully.", id);
            }
            catch (Exception ex) when (ex is not BusinessException && ex is not NotFoundException)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating course with ID {Id}.", id);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var course = _repository.GetById(id);

                if (course == null)
                {
                    _logger.LogWarning("Delete failed: Course with ID {Id} was not found.", id);
                    throw new NotFoundException($"Cannot delete. Course with ID {id} was not found.");
                }

                _repository.Delete(id);
                _logger.LogInformation("Course with ID {Id} was deleted successfully.", id);
            }
            catch (Exception ex) when (ex is not NotFoundException)
            {
                _logger.LogError(ex, "An unexpected error occurred while deleting course with ID {Id}.", id);
                throw;
            }
        }
    }
}