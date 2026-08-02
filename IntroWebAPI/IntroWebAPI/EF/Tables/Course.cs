using System;
using System.Collections.Generic;

namespace IntroWebAPI.EF.Tables;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DeptId { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
