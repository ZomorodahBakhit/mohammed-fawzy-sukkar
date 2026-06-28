using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        } 
        public StudentDTO? GetById(int id)
        {
            var student = _repository.GetById(id);
            if (student == null) return null;

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
            FormValidator.Validate(form);
            var ExistSydents = _repository.GetAll();
            if(ExistSydents.Any(s => s.Email == form.Email))
            {
                throw new BusinessException("Email address is already exist");
            }
            var student = new Student
            {
                Name = form.Name,
                Email = form.Email,
            };
            _repository.Add(student);
        }
        public void Update(int id, UpdateStudentForm form)
        {
            var student = _repository.GetById(id);
            if (student != null)
            {
                student.Name = form.Name ?? student.Name;
                student.Email = form.Email ?? student.Email;

                _repository.Update(student);
            }
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
