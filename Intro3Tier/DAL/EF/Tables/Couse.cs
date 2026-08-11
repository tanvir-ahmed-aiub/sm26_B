using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Couse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DeptId { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
