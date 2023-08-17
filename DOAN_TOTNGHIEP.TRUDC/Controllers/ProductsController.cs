﻿using Dapper;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductBL;
using DOAN_TOTNGHIEP.TRUDC.Common;
using DOAN_TOTNGHIEP.TRUDC.Common.Constants;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace DOAN_TOTNGHIEP.TRUDC.Controllers
{
    [ApiController]
    public class ProductsController : BasesController<Product>
    {
        #region Field

        private IProductBL _productBL;

        #endregion

        #region Constructor 

        public ProductsController(IProductBL productBL) : base(productBL)
        {
            _productBL = productBL;
        }

        #endregion

        /// <summary>
        /// API lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy : DCTRU (13/08/2023)
        [HttpGet("products")]
        public IActionResult GetAllProduct()
        {
            try
            {
                //Kết quả trả về
                var products = _productBL.GetAllProduct();

                //Xử lý kết quả trả về
                if (products.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, products);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, products);
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
