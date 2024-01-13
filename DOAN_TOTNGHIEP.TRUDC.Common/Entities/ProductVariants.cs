using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class ProductVariants
    {
        public Guid VariantID {  get; set; }

        public Guid ProductSizeID { get; set; }

        public string ProductSizeName { get; set; }

        public string ProductColorName { get; set; }

        public Guid ProductColorID { get; set; }

        public int Quantity { get; set; }
    }
}
