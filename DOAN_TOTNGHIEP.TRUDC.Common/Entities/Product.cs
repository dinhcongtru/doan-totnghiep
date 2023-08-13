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

        /// <summary>
        /// chất liệu
        /// </summary>
        public string? chatlieu { get; set; }

        /// <summary>
        /// kiểu dáng
        /// </summary>
        public string? kieudang { get; set; }

        /// <summary>
        /// chi tiết
        /// </summary>
        public string? chitiet { get; set; }

        public string CategoryName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ColorName { get; set; }

        public string SizeName { get; set; }
    }
}
