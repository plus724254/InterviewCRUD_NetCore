using InterviewCRUD_NetCore.Repository.Entities;
using InterviewCRUD_NetCore.Repository.Models.DTO;
using System.Collections.Generic;

namespace InterviewCRUD_NetCore.Service.Services
{
    public interface ICourseService
    {
        void AddNewCourse(CourseDTO courseDTO);
        void DeleteCourse(string number);
        void EditCourse(CourseDTO courseDTO);
        List<Course> GetAllCourses();
        void ReplaceCourse(string sourceNumber, CourseDTO courseDTO);
    }
}