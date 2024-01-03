using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class AdtoCart
    {
        public Guid customer_id {  get; set; }

        public Guid Product_id { get; set; }

        public Guid Variant_id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }
}
