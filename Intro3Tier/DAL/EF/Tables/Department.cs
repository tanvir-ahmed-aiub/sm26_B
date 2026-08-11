using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Couse> Couses { get; set; } = new List<Couse>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
