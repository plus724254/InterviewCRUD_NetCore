using InterviewCRUD_NetCore.Repository.Entities;
using InterviewCRUD_NetCore.Repository.Models.DTO;
using System.Collections.Generic;

namespace InterviewCRUD_NetCore.Repository.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        StudentCourseSelectionDTO GetStudentCourses(string studentNumber);
        List<StudentCourseSelectionDTO> GetAllStudentCourses();
    }
}
