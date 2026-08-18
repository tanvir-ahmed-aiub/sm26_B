using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; }

        public int Qty { get; set; }

    }
}
