using InterviewCRUD_NetCore.Repository.Models.DTO;
using InterviewCRUD_NetCore.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewCRUD_NetCore.Controllers.Api
{
    [Route("api/StudentCourseSelection")]
    [ApiController]
    public class StudentCourseSelectionController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentCourseSelectionController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAllStudentCourseSelection()
        {
            return Ok(_studentService.GetAllStudentCourses());
        }

        [HttpGet, Route("{studentNumber}")]
        public IActionResult GetStudentCourseSelection(string studentNumber)
        {
            return Ok(_studentService.GetStudentCourses(studentNumber));
        }

        [HttpPost]
        public IActionResult AddStudentCourseSelection(StudentCourseSelectionDTO studentCourseSelectionDTO)
        {
            _studentService.AddStudentCourse(studentCourseSelectionDTO);
            return Ok();
        }

        [HttpPut]
        public IActionResult ReplaceStudentCourseSelection(StudentCourseSelectionDTO studentCourseSelectionDTO)
        {
            _studentService.ReplaceStudentCourses(studentCourseSelectionDTO);
            return Ok();
        }

        [HttpDelete, Route("{studentNumber}")]
        public IActionResult DeleteStudentCourses(string studentNumber)
        {

            _studentService.DeleteStudentCourses(studentNumber);
            return Ok();
        }
    }
}