using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class OrderPlaceModel
    {
        public int CusId { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
