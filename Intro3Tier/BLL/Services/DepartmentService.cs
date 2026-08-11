using AutoMapper;
using BLL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DepartmentService
    {
        DepartmentRepo repo;
        IMapper mapper;
        public DepartmentService(DepartmentRepo repo, IMapper mapper) { 
            this.repo = repo;
            this.mapper = mapper;
        }
        public List<DepartmentModel> All() {
            var data = repo.All();
            var mapped = mapper.Map<List<DepartmentModel>>(data); ;
            return mapped;
        }

        public List<DepartmentInfo> GetFullInfo() { 
            var data  = repo.GetFullInfo();
            var mapped = mapper.Map<List<DepartmentInfo>>(data);
            return mapped;
        }
    }
}
