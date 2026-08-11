using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class DepartmentRepo
    {
        Sm26AContext db;
        public DepartmentRepo(Sm26AContext db)
        {
            this.db = db;
        }

        public List<Department> All() {
            var data = db.Departments.ToList();
            return data;
        }
        public Department Get(int id) {
            return db.Departments.Find(id);
        }
        public bool Create(Department d) {
            db.Departments.Add(d);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id) { 
            var data = Get(id);
            db.Departments.Remove(data);
            return db.SaveChanges() > 0;    
        }
        public List<Department> GetFullInfo() {
            var data = db.Departments.Include(d => d.Couses).
                Include(d => d.Students).ToList();
            return data;

        }

    }
}
