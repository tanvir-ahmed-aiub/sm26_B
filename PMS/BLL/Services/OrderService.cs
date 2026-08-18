using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BLL.Services
{
    public class OrderService
    {
        OrderRepo odrepo;
        OrderDetailRepo detailrepo;
        IMapper mapper;

        public OrderService(OrderRepo odreo, OrderDetailRepo detailrepo, IMapper mapper)
        {
            this.odrepo = odreo;
            this.detailrepo = detailrepo;
            this.mapper = mapper;
        }
        public bool PlaceOrder(OrderPlaceModel model) {
            var o = new Order() {
                CusId = model.CusId,
                Total =0,
                Date = DateTime.Now,
                Status = "Ordered"
            };
            var data = odrepo.Create(o);
            double total = 0;
            foreach (var item in model.Products)
            {
                var odetail = new OrderDetail() { 
                    Pid = item.Id,
                    Price = (decimal)item.Price,
                    Qty = item.Qty,
                    Oid = data.Id
                };
                detailrepo.Create(odetail);
                total += item.Price* item.Qty;
                 
            }
            data.Total =(decimal) total;
            odrepo.Update(data);
            return true;
        }
        
    }
}
