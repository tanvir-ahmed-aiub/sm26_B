using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace DAL.Repos
{
    public class ProductRepo
    {
        PmsSm26BContext db;
        public ProductRepo(PmsSm26BContext db) { 
            this.db = db;
        }
        public List<Product> Get() { 
            return db.Products.ToList();
        }
        public Product Get(int id) {
            return db.Products.Find(id);

        }
        public bool Create(Product product) { 
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }
        public bool Update(Product product) { 
            var ex = Get(product.Id);
            ex.Name = product.Name;
            ex.Price = product.Price;
            ex.Qty = product.Qty;
            return db.SaveChanges()>0;
        }
        public bool Delete(int id) {
            var ex = Get(id);
            db.Products.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
