﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class LogOutCustomer
    {
      
        public Guid Customer_id { get; set; }
        
        public string Password { get; set; }
        
        public string FullName { get; set; }
       
        public string Email { get; set; }

        public string Phone { get; set; }

        public List<Product> product { get; set; } = new List<Product>();
    }
}
