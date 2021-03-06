
using AutoMapper;
using InterviewCRUD_NetCore.Models.ViewModels;
using InterviewCRUD_NetCore.Repository.Models.CustomExceptions;
using InterviewCRUD_NetCore.Repository.Models.DTO;
using InterviewCRUD_NetCore.Service.Services;
using InterviewCRUD_NetCore.Tools;
using InterviewCRUD_NetCore.Tools.AutoMappers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InterviewCRUD_NetCore.Controllers.Api
{
    [Route("api/Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(_courseService.GetAllCourses());
        }

        [HttpGet, Route("{id:int}")]
        public IActionResult GetCourse(string number)
        {
            return Ok(new CourseViewModel());
        }

        [HttpPost]
        public IActionResult AddCourse(CourseViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorAnalyze.GetModelStateError(ModelState));
            }

            try
            {
                _courseService.AddNewCourse(_mapper.Map<CourseDTO>(course));
                return Ok();
            }
            catch(DataErrorException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Route("{number}")]
        public IActionResult DeleteCourse(string number)
        {
            _courseService.DeleteCourse(number);
            return Ok();
        }

        [HttpPut, Route("{number}")]
        public IActionResult ReplaceCourse(string number, CourseViewModel editCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorAnalyze.GetModelStateError(ModelState));
            }

            try
            {
                _courseService.ReplaceCourse(number, _mapper.Map<CourseDTO>(editCourse));
                return Ok();
            }
            catch(DataErrorException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult EditCourse(CourseViewModel editCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorAnalyze.GetModelStateError(ModelState));
            }

            _courseService.EditCourse(_mapper.Map<CourseDTO>(editCourse));
            return Ok();
        }
    }
}