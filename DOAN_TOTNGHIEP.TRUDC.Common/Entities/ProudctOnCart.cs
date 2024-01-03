using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class ProudctOnCart
    {

        public int Cart_item_id { get; set; }   

        public Guid ProductID { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ProductImageUrl { get; set; }

        public string ProductColorName { get; set; }
        
        public string ProductSizeName { get; set; }
    }
}
