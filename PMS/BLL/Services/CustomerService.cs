using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CustomerService
    {
        CustomerRepo repo;
        IMapper mapper;
        public CustomerService(CustomerRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public List<CustomerModel> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<CustomerModel>>(data);
        }
        public CustomerModel Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<CustomerModel>(data);
        }
        public bool Create(CustomerModel model)
        {
            var mapped = mapper.Map<Customer>(model);
            return repo.Create(mapped);
        }
        public bool Update(CustomerModel model)
        {
            var mapped = mapper.Map<Customer>(model);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {

            return repo.Delete(id);
        }
    }
}
