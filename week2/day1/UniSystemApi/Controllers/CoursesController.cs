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
        private readonly ILogger<CoursesController> _logger;
        public CoursesController(ICourseService courseService, ILogger<CoursesController> logger)
        {
            _service = courseService;
            _logger = logger;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]        
        public ApiResponse GetById(int id)
        {
            _logger.LogInformation("Get Course By Id");
            var course = _service.GetById(id);
            return new ApiResponse(course);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse GetAll()
        {
            _logger.LogInformation("Get All Courses");
            return new ApiResponse(_service.GetAll());
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Create([FromBody] CreateCourseForm form)
        {
            _logger.LogInformation("Create Course");
            _service.Create(form);
            return new ApiResponse("Course created successfully");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Update(int id, [FromBody] UpdateCourseForm form)
        {
            _logger.LogInformation("Update Course");
            _service.Update(id, form);
            return new ApiResponse("Course updated successfully");
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Delete(int id)
        {
            _logger.LogInformation("Delete Course");
            _service.Delete(id);
            return new ApiResponse("Course deleted successfully");
        }
    }
}
