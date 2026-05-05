using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using System.Text;

namespace DAL.Repos
{
    public class CategoryRepo
    {
        PmsBSp26Context db;
        public CategoryRepo(PmsBSp26Context db) { 
            this.db = db;
        }
        public bool Create(Category c) { 
            db.Categories.Add   (c);
            return db.SaveChanges() > 0;
        }
        public Category Get(int id) { 
            return db.Categories.Find(id);
        }
        public List<Category> Get() { 
            return db.Categories.ToList();
        }
        public bool Update(Category c) {
            var exobj = Get(c.Id);
            db.Entry(exobj).CurrentValues.SetValues(c);
            return db.SaveChanges()>0;
        }
        public bool Delete(int id) {
            var exobj = Get(id);
            db.Categories.Remove(exobj);
            return db.SaveChanges()>0;  
        }
    }
}
