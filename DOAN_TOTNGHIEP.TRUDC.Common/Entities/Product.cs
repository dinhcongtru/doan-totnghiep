using System;
using System.Collections.Generic;
using DOAN_TOTNGHIEP.TRUDC.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    /// <summary>
    /// Sản phẩm
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID sản phẩm
        /// </summary>
        [Key]
        public Guid ProductID { get; set; }

        ///<summary>
        /// mã sản phẩm
        ///</summary>
        [IsNotNullOrEmpty("Mã sản phẩm không được trống.")]
        [Unique("Mã sản phẩm đã tồn tại trong hệ thống.")]
        public string ProductCode { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        [IsNotNullOrEmpty("Tên sản phẩm không được để trống.")]
        public string ProductName { get; set; }

        /// <summary>
        /// danh mục của sản phẩm
        /// </summary>
        [IsNotNullOrEmpty("Danh mục không được để trống.")]
        public Guid CategoryID { get; set; }

        public string ProductCategoryName { get; set; }

        public decimal ProductPrice { get; set; }

        public string Material { get; set; }

        public string SalePercent { get; set; }

        public string Description { get; set; }

        public string QuickDescription {  get; set; }

        public int TotalQuantity { get; set; }
        
        public string Status { get; set; }

        public int Quantity { get; set; }

        public Guid VariantID { get; set; }

        public string ProductColorName { get; set; }

        public Guid ProductColorID { get; set; }

        public Guid ProductSizeID { get; set; }

        public string ProductSizeName { get; set; }

        public string ProductImageUrl { get; set; }

        public Guid ProductImageID { get; set; }

        public List<ProductColor> listColors { get; set; } = new List<ProductColor>();

    }
}
