using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.BL.CustomerBL
{
    public interface ICustomerBL : IBaseBL<Customer>
    {
        public int? AddtoCart(AdtoCart adtoCart);

        public Customer LoginCustomer(Customer customer);

        public CustomerLoginSocal LoginSocial(CustomerLoginSocal customer);

        public IEnumerable<ProudctOnCart> GetProductByCustomer(Guid customerID);

        public int DeleteProductOnCartByCustomer(int cart_item_id);

        public int registerCustomer(Customer customer);
    }
}
