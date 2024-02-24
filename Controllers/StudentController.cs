using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using studentregestration.Helper;
using studentregestration.Models;

namespace studentregestration.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentHandler _studentHandler;
        private readonly IConfiguration _configuration;
        public StudentController(IStudentHandler studentHandler)
        {
            _studentHandler = studentHandler;
           
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var students = await _studentHandler.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching students: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(StudentRquestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var studentId = await _studentHandler.SaveStudentAsync(model);
                return CreatedAtAction(nameof(Get), new { id = studentId }, model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while saving the student: {ex.Message}");
            }
        }
    }
}

