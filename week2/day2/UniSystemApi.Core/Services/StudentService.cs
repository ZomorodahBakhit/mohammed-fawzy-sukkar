using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using UniSystemApi.Core.DTOs;
using UniSystemApi.Core.Exceptions;
using UniSystemApi.Core.Forms;
using UniSystemApi.Data.Entities;
using UniSystemApi.Data.Repositories;
using UniversitySystemSummer.Core.Validations;

namespace UniSystemApi.Core.Services
{
    public interface IStudentService
    {
        StudentDTO? GetById(int id);
        List<StudentDTO> GetAll();
        void Create(CreateStudentForm form);
        void Update(int id, UpdateStudentForm form);
        void Delete(int id);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repository, ILogger<StudentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public StudentDTO? GetById(int id)
        {
            var student = _repository.GetById(id);

            if (student == null)
            {
                _logger.LogWarning("GetById failed: Student with ID {Id} was not found.", id);
                throw new NotFoundException($"Student with ID {id} was not found.");
            }

            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };
        }

        public List<StudentDTO> GetAll()
        {
            var students = _repository.GetAll();
            return students.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
            }).ToList();
        }

        public void Create(CreateStudentForm form)
        {
            try
            {
                try
                {
                    FormValidator.Validate(form);
                }
                catch (BusinessException ex)
                {
                    _logger.LogWarning("Validation failed for student creation: {Errors}", ex.Message);
                    throw;
                }

                var existStudents = _repository.GetAll();
                if (existStudents.Any(s => s.Email == form.Email))
                {
                    _logger.LogWarning("Validation failed: Email address {Email} is already exist", form.Email);
                    throw new BusinessException("Email address is already exist");
                }

                var student = new Student
                {
                    Name = form.Name,
                    Email = form.Email,
                };

                _repository.Add(student);
                _logger.LogInformation("Student created successfully with Email: {Email}", form.Email);
            }
            catch (Exception ex) when (ex is not BusinessException)
            {
                _logger.LogError(ex, "An unexpected error occurred while creating a student.");
                throw;
            }
        }

        public void Update(int id, UpdateStudentForm form)
        {
            try
            {
                try
                {
                    FormValidator.Validate(form);
                }
                catch (BusinessException ex)
                {
                    _logger.LogWarning("Validation failed for student update (ID: {Id}): {Errors}", id, ex.Message);
                    throw;
                }

                var student = _repository.GetById(id);

                if (student == null)
                {
                    _logger.LogWarning("Update failed: Student with ID {Id} was not found.", id);
                    throw new NotFoundException($"Cannot update. Student with ID {id} was not found.");
                }

                student.Name = form.Name ?? student.Name;
                student.Email = form.Email ?? student.Email;

                _repository.Update(student);
                _logger.LogInformation("Student with ID {Id} was updated successfully.", id);
            }
            catch (Exception ex) when (ex is not BusinessException && ex is not NotFoundException)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating student with ID {Id}.", id);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var student = _repository.GetById(id);

                if (student == null)
                {
                    _logger.LogWarning("Delete failed: Student with ID {Id} was not found.", id);
                    throw new NotFoundException($"Cannot delete. Student with ID {id} was not found.");
                }

                _repository.Delete(id);
                _logger.LogInformation("Student with ID {Id} was deleted successfully.", id);
            }
            catch (Exception ex) when (ex is not NotFoundException)
            {
                _logger.LogError(ex, "An unexpected error occurred while deleting student with ID {Id}.", id);
                throw;
            }
        }
    }
}