using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class OrderRepo
    {
        PmsSm26BContext db;
        public OrderRepo(PmsSm26BContext db)
        {
            this.db = db;
        }
        public List<Order> Get()
        {
            return db.Orders.ToList();
        }
        public Order Get(int id)
        {
            return db.Orders.Find(id);

        }
        public Order Create(Order Order)
        {
            db.Orders.Add(Order);
            db.SaveChanges();
            return Order;

        }
        public bool Update(Order Order)
        {
            var ex = Get(Order.Id);
            ex.Status = Order.Status;
            ex.Date = Order.Date;
            ex.Total = Order.Total;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Orders.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
