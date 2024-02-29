using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost("add")]
        public IActionResult Add(Instructor ınstructor)
        {
            var result = _instructorService.Add(ınstructor);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Instructor ınstructor)
        {
            var result = _instructorService.Update(ınstructor);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Instructor ınstructor)
        {
            var result = _instructorService.Delete(ınstructor);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int InstructorId)
        {
            var result = _instructorService.GetById(InstructorId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _instructorService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
