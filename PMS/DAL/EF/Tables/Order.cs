using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Order
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public decimal Total { get; set; }

    public DateTime Date { get; set; }

    public int CusId { get; set; }

    public virtual Customer Cus { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
