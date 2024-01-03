using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class CustomerLoginSocal
    {
        [Key]
        public Guid Customer_id { get; set; }

        public string FullName { get; set; }

        [ValidateEmail("/^(([^<>()[\\]\\.,;:\\s@\\\"]+(\\.[^<>()[\\]\\.,;:\\s@\\\"]+)*)|(\\\".+\\\"))@(([^<>()[\\]\\.,;:\\s@\\\"]+\\.)+[^<>()[\\]\\.,;:\\s@\\\"]{2,})$/i;", "Email chưa đúng định dạng.")]
        [IsNotNullOrEmpty("Email không được trống.")]
        public string Email { get; set; }
    }
}
