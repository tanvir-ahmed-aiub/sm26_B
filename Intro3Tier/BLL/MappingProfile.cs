using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Department,DepartmentModel>();
            CreateMap<Department, DepartmentInfo>()
                .ForMember(d => d.CourseCount,
                s => s.MapFrom(s => s.Couses.Count))
                .ForMember(d => d.StudentCount,
                s => s.MapFrom(s => s.Students.Count));
        }
    }
}
