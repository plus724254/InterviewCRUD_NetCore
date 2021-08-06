using InterviewCRUD_NetCore.Models.ViewModels;
using InterviewCRUD_NetCore.Repository.Models.CustomExceptions;
using InterviewCRUD_NetCore.Repository.Models.DTO;
using InterviewCRUD_NetCore.Service.Services;
using InterviewCRUD_NetCore.Tools;
using Microsoft.AspNetCore.Mvc;
using AutoMap = InterviewCRUD_NetCore.Tools.AutoMappers.AutoMap;

namespace InterviewCRUD_NetCore.Controllers.Api
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet, Route("{id:int}")]
        public IActionResult GetStudent(string number)
        {
            return Ok(new StudentViewModel());
        }

        [HttpPost]
        public IActionResult AddStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorAnalyze.GetModelStateError(ModelState));
            }

            try
            {
                _studentService.AddNewStudent(AutoMap.Mapper.Map<StudentDTO>(student));
                return Ok();
            }
            catch(DataErrorException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Route("{number}")]
        public IActionResult DeleteStudent(string number)
        {

            _studentService.DeleteStudent(number);
            return Ok();
        }

        [HttpPut, Route("{number}")]
        public IActionResult ReplaceStudent(string number, StudentViewModel editStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorAnalyze.GetModelStateError(ModelState));
            }

            try
            {
                _studentService.ReplaceStudent(number, AutoMap.Mapper.Map<StudentDTO>(editStudent));
                return Ok();
            }
            catch (DataErrorException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult EditStudent(StudentViewModel editStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorAnalyze.GetModelStateError(ModelState));
            }

            _studentService.EditStudent(AutoMap.Mapper.Map<StudentDTO>(editStudent));
            return Ok();
        }
    }
}
