using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.BL.CustomerBL;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductBL;
using DOAN_TOTNGHIEP.TRUDC.Common;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using DOAN_TOTNGHIEP.TRUDC.Common.Enums;
using DOAN_TOTNGHIEP.TRUDC.DL.CustomerDL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductDL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOAN_TOTNGHIEP.TRUDC.Controllers
{
    [ApiController]
    public class CustomersController : BasesController<Customer>
    {

        #region Field

        private ICustomerBL _customerBL;

        #endregion

        #region Constructor 

        public CustomersController(ICustomerBL customerBL) : base(customerBL)
        {
            _customerBL = customerBL;
        }

        /// <summary>
        /// api goi khi customer them sp vao gio hang
        /// </summary>
        /// <returns></returns>
        [HttpPost("adtocart")]
        public IActionResult AddtoCart([FromBody] AdtoCart adtocart)
        {
            try
            {
                int? res = _customerBL.AddtoCart(adtocart);

                //Xử lý kết quả  trả về
                if (res != 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(HttpContext.TraceIdentifier));

                }
                else
                {

                    return StatusCode(StatusCodes.Status200OK, res);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });


            }
        }

        [HttpPost("logginCustomer")]
        public IActionResult LoginCustomer([FromBody] Customer customer)
        {
            try
            {
                var res = _customerBL.LoginCustomer(customer);

                if (res == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(HttpContext.TraceIdentifier));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });
            }
        }

        [HttpPost("loginCustomerBySocial")]
        public IActionResult loginSocial([FromBody] CustomerLoginSocal customer)
        {
            try
            {
                var res = _customerBL.LoginSocial(customer);

                if (res == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(HttpContext.TraceIdentifier));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });
            }
        }

        [HttpGet("productByCustomer/{Customer_id}")]
        public IActionResult GetProductByCustomer([FromRoute] Guid Customer_id) 
        {
            try
            {
                //Kết quả trả về
                var products = _customerBL.GetProductByCustomer(Customer_id);

                //Xử lý kết quả trả về
                if (products != null)
                {
                    return StatusCode(StatusCodes.Status200OK, products);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });
            }
        }
        [HttpDelete("deleteProuct/{Cart_item_id}")]
        public IActionResult DeleteProductOnCartByCustomer([FromRoute] int Cart_item_id) 
        {
            try
            {
                //Kết quả trả về
                int res = _customerBL.DeleteProductOnCartByCustomer(Cart_item_id);

                //Xử lý kết quả trả về
                if (res == 1)
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }

                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });

            }
        }

        [HttpPost("registerCustomer")]
        public IActionResult registerCustomer([FromBody] Customer customer)
        {
            try
            {
                var res = _customerBL.registerCustomer(customer);
                //Xử lý kết quả trả về
                if (res == 1)
                {
                    return StatusCode(StatusCodes.Status201Created,res);
                }

                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(HttpContext.TraceIdentifier));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });

            }           
        }

        [HttpPost("LogOutCustomer")]
        public IActionResult LogOutCustomer([FromBody] LogOutCustomer logoutcustomer) 
        {
            try
            {
                int res = _customerBL.LogOutCustomer(logoutcustomer);

                //Xử lý kết quả  trả về
                if (res != 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(HttpContext.TraceIdentifier));

                }
                else
                {

                    return StatusCode(StatusCodes.Status200OK, res);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });


            }
        }
    }
}
#endregion