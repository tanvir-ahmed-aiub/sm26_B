using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repos;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ProductService
    {
        ProductRepo repo;
        IMapper mapper;
        public ProductService(ProductRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public List<ProductModel> Get() { 
            var data = repo.Get();
            return mapper.Map<List<ProductModel>>(data);
        }
        public ProductModel Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<ProductModel>(data);
        }
        public bool Create(ProductModel model) {
            var mapped = mapper.Map<Product>(model);
            return repo.Create(mapped);
        }
        public bool Update(ProductModel model)
        {
            var mapped = mapper.Map<Product>(model);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {
            
            return repo.Delete(id);
        }
    }
}
