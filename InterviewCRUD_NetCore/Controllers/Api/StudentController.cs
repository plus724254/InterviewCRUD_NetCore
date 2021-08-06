using AutoMapper;
using InterviewCRUD_NetCore.Models.ViewModels;
using InterviewCRUD_NetCore.Repository.Models.CustomExceptions;
using InterviewCRUD_NetCore.Repository.Models.DTO;
using InterviewCRUD_NetCore.Service.Services;
using InterviewCRUD_NetCore.Tools;
using Microsoft.AspNetCore.Mvc;

namespace InterviewCRUD_NetCore.Controllers.Api
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
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
                _studentService.AddNewStudent(_mapper.Map<StudentDTO>(student));
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
                _studentService.ReplaceStudent(number, _mapper.Map<StudentDTO>(editStudent));
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

            _studentService.EditStudent(_mapper.Map<StudentDTO>(editStudent));
            return Ok();
        }
    }
}
