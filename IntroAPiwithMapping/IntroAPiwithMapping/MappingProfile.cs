using AutoMapper;
using IntroAPiwithMapping.EF.Tables;
using IntroAPiwithMapping.Models;

namespace IntroAPiwithMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Student,StudentModel>().ReverseMap();
            CreateMap<Student, StudentInfoModel>()
                .ForMember(dest => dest.DeptName,
                src => src.MapFrom(src => src.Dept.Name));
                

            CreateMap<Course,CourseModel>().ReverseMap();   

            CreateMap<Department,DepartmentModel>().ReverseMap();
            CreateMap<Department,DepartmentStudentModel>().ReverseMap();
            CreateMap<Department,DepartmentCourseModel>().ReverseMap();

            CreateMap<Department, DepartmentInfoModel>()
                .ForMember(dest => dest.CourseCount,
                src => src.MapFrom(src => src.Courses.Count))
                .ForMember(dest => dest.StudentCount,
                src => src.MapFrom(src => src.Students.Count));
        }
    }
}
