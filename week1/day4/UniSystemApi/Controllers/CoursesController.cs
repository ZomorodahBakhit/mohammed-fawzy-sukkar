using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniSystemApi.Core.Forms;
using UniSystemApi.Core.Services;
using UniSystemApi.Data.Entities;

namespace UniSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;
        public CoursesController(ICourseService courseService)
        {
            _service = courseService;

        }
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            var course = _service.GetById(id);
            return new ApiResponse(course);
        }
        [HttpGet]
        public ApiResponse GetAll()
        {
            return new ApiResponse(_service.GetAll());
        }
        [HttpPost]
        public ApiResponse Create([FromBody] CreateCourseForm form)
        {
            _service.Create(form);
            return new ApiResponse("Course created successfully");
        }
        [HttpPut("{id}")]
        public ApiResponse Update(int id, [FromBody] UpdateCourseForm form)
        {
            _service.Update(id, form);
            return new ApiResponse("Course updated successfully");
        }
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            _service.Delete(id);
            return new ApiResponse("Course deleted successfully");
        }
    }
}
