using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ProductService
    {
        ProductRepo repo;
        Mapper mapper;
        public ProductService(ProductRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<ProductDTO> Get()
        {
            var data = repo.Get();
            var res = mapper.Map<List<ProductDTO>>(data);
            return res;

        }
        public ProductDTO Get(int id)
        {
            var data = repo.Get(id);
            var res = mapper.Map<ProductDTO>(data);
            return res;

        }
        public bool Create(ProductDTO c)
        {
            var converted = mapper.Map<Product>(c);
            return repo.Create(converted);
        }

        public bool Update(ProductDTO c)
        {
            var converted = mapper.Map<Product>(c);
            return repo.Update(converted);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
