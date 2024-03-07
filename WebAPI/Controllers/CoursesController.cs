using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("add")]
        public IActionResult Add(Course course)
        {
            var result = _courseService.Add(course);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Course course)
        {
            var result = _courseService.Update(course);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Course course)
        {
            var result = _courseService.Delete(course);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int Id)
        {
            var result = _courseService.GetById(Id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _courseService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcoursedetails")]
        public IActionResult GetCourseDetails(int CategoryId)
        {
            var result = _courseService.GetCourseDetails(c => c.CategoryId == CategoryId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
