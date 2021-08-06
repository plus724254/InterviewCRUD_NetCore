using System.Collections.Generic;

namespace InterviewCRUD_NetCore.Repository.Models.DTO
{
    public class StudentCourseSelectionDTO
    {
        public string StudentNumber { get; set; }
        public string StudentName { get; set; }
        public List<CourseDTO> Courses { get; set; }
    }
}
