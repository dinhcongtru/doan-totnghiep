using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class Customer
    {
        [Key]
        public Guid Customer_id { get; set; }

        [IsNotNullOrEmpty("Mật khẩu không được trống.")]
        public string Password { get; set; }

        [IsNotNullOrEmpty("Tên không được trống.")]
        public string FullName { get; set; }

        [ValidateEmail("/^(([^<>()[\\]\\.,;:\\s@\\\"]+(\\.[^<>()[\\]\\.,;:\\s@\\\"]+)*)|(\\\".+\\\"))@(([^<>()[\\]\\.,;:\\s@\\\"]+\\.)+[^<>()[\\]\\.,;:\\s@\\\"]{2,})$/i;", "Email chưa đúng định dạng.")]
        public string Email { get; set; }

        [IsNotNullOrEmpty("Số Điện Thoại không được trống.")]
        [IsNumber("^[0-9]+$", "Số điện thoại phải là số.")]
        public string Phone { get; set; }
    }
}
