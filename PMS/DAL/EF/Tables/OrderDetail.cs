using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int Pid { get; set; }

    public int Oid { get; set; }

    public int Qty { get; set; }

    public decimal Price { get; set; }

    public virtual Order OidNavigation { get; set; } = null!;

    public virtual Product PidNavigation { get; set; } = null!;
}
