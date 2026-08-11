using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class DepartmentInfo : DepartmentModel
    {
        public int CourseCount { get; set; }
        public int StudentCount { get; set; }
    }
}
