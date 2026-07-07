using System;
using System.Collections.Generic;

namespace IntroEFDbFirst.EF.Tables;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Cgpa { get; set; }

    public string Address { get; set; } = null!;

    public int DeptId { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
