using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; }

        public int Qty { get; set; }

        public int Cid { get; set; }
    }
}
