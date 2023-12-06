using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService studentService)
        {
            _service = studentService;
        }

        [HttpGet("students")]
        public IActionResult Get()
        {
            var result = _service.Read(x=> x.IsActive == true);
            
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("students/{id}")]
        public IActionResult Get(int id)
        {
            var result = _service.Read(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
