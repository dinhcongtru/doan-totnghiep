using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class ProductCategory
    {
        [Key]
        public Guid ProductCategoryID { get; set; }

        public string ProductCategoryName { get; set;}

        public string Status { get; set;}

        public Guid parent_category_id { get; set; }

        [IsNotNullOrEmpty("Mã category không được trống.")]
        [Unique("Mã category đã tồn tại trong hệ thống.")]
        public string ProductCategoryCode { get; set; }

       public List<ProductCategory> optionMenus { get; set; } = new List<ProductCategory>();
    }
}
