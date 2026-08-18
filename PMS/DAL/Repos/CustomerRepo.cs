using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class CustomerRepo
    {
        PmsSm26BContext db;
        public CustomerRepo(PmsSm26BContext db)
        {
            this.db = db;
        }
        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }
        public Customer Get(int id)
        {
            return db.Customers.Find(id);

        }
        public bool Create(Customer Customer)
        {
            db.Customers.Add(Customer);
            return db.SaveChanges() > 0;
        }
        public bool Update(Customer Customer)
        {
            var ex = Get(Customer.Id);
            ex.Name = Customer.Name;
            
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Customers.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
