using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class ProductRepo
    {
        PmsBSp26Context db;
        public ProductRepo(PmsBSp26Context db)
        {
            this.db = db;
        }
        public bool Create(Product c)
        {
            db.Products.Add(c);
            return db.SaveChanges() > 0;
        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }
        public List<Product> Get()
        {
            return db.Products.ToList();
        }
        public bool Update(Product c)
        {
            var exobj = Get(c.Id);
            db.Entry(exobj).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Products.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}
