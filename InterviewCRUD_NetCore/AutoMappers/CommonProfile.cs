using AutoMapper;
using InterviewCRUD_NetCore.Models.ViewModels;
using InterviewCRUD_NetCore.Repository.Models.DTO;

namespace InterviewCRUD_NetCore.Tools.AutoMappers
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<StudentViewModel, StudentDTO>();
            CreateMap<CourseViewModel, CourseDTO>();
        }
    }
}