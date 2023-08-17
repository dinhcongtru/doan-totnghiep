using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class ProductSize
    {
        public Guid SizeID { get; set; }
        public string SizeName { get; set; }
        public int Quantity { get; set; }
        public bool selected { set; get; }
    }
}
