using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class ProductColor
    {
        public Guid ColorID { get; set; }
        public decimal Price { get; set; }
        public string ColorName { get; set; }
        public bool selected { get; set; }
        public List<ProductSize> sizeItem { get; set; } = new List<ProductSize>();
    }
}
