using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    public class User
    {
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public string UserMessage { get; set; }
        public string AccessToken { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
