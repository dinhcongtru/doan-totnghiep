using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using DOAN_TOTNGHIEP.TRUDC.DL.CustomerDL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.BL.CustomerBL
{
    public class CustomerBL : BaseBL<Customer> , ICustomerBL
    {
        #region Field

        private ICustomerDL _customerDL;


        #endregion

        #region Constructor

        public CustomerBL(ICustomerDL customerDL) : base(customerDL)
        {
            _customerDL = customerDL;
        }

        public int? AddtoCart(AdtoCart adtoCart)
        {
            int? res = _customerDL.AdtoCart(adtoCart);
            if (res == 1)
            {
                return res;
            }
            return res;
        }

        public Customer LoginCustomer(Customer customer)
        {
        
            Customer result = _customerDL.LoginCustomer(customer);
           
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
            
        }

        public CustomerLoginSocal LoginSocial(CustomerLoginSocal customer)
        {
            CustomerLoginSocal result = _customerDL.LoginSocial(customer);

            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ProudctOnCart> GetProductByCustomer(Guid customerID)
        {
            var result = _customerDL.GetProductByCustomer(customerID);
            var products = new List<ProudctOnCart>();
            if (result != null)
            {
                foreach (var product in result)
                {
                    var exsitspro = products.Any(e => e.Cart_item_id == product.Cart_item_id);
                    if (exsitspro)
                    {
                        ProudctOnCart targetPro = products.FirstOrDefault(e => e.ProductID == product.ProductID);
                        if (targetPro.Cart_item_id == product.Cart_item_id)
                        {
                            if (targetPro.ProductColorName == product.ProductColorName && targetPro.ProductImageUrl == product.ProductImageUrl && targetPro.ProductSizeName == product.ProductSizeName && targetPro.Quantity != product.Quantity)
                            {
                                // công số lượng
                                targetPro.Quantity += product.Quantity;
                            } 
                        }
                    }
                    else
                    {
                        products.Add(product);
                    }
                }
               
            }
            else
            {
                return null;
            }
            return products;
        }


        public int DeleteProductOnCartByCustomer(int cart_item_id)
        {
            int result = _customerDL.DeleteProductOnCartByCustomer(cart_item_id);
            return result;
        }

        public int registerCustomer(Customer customer)
        {
            int res = _customerDL.registerCustomer(customer);
            return res;
        }

        public int LogOutCustomer(LogOutCustomer logOutCustomer)
        {
            int res = _customerDL.LogOutCustomer(logOutCustomer);
            return res;
        }
    }
}
#endregion