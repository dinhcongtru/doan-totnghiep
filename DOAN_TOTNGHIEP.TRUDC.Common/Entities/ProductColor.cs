using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class ProductColor
    {
        public Guid ProductColorID { get; set; }
        public string ProductColorName { get; set; }
        public bool selected { get; set; }
        public List<ProductSize> sizeItem { get; set; } = new List<ProductSize>();
        public List<ProductImage> imageItem { get; set; } = new List<ProductImage>();
    }
}
