using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class PlaceOrderSingle
    {
        public Guid Customer_id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string CouponCode { get; set; }

        public string Note { get; set; }

        public string Phuong { get; set; }

        public string Quan { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Shiping { get; set; }

        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
