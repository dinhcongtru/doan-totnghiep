using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.DL.CustomerDL
{
    public interface ICustomerDL : IBaseDL<Customer>
    {
        public int? AdtoCart(AdtoCart adtoCart);

        public Customer LoginCustomer(Customer customer);

        public CustomerLoginSocal LoginSocial(CustomerLoginSocal customer);

        public IEnumerable<ProudctOnCart> GetProductByCustomer(Guid customerID);

        public int DeleteProductOnCartByCustomer(int cart_item_id);

        public int registerCustomer(Customer customer);

        public int LogOutCustomer(LogOutCustomer logOutCustomer);
    }
}
