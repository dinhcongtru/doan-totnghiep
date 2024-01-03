using Dapper;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductBL;
using DOAN_TOTNGHIEP.TRUDC.Common;
using DOAN_TOTNGHIEP.TRUDC.Common.Constants;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using DOAN_TOTNGHIEP.TRUDC.Common.Enums;
using DOAN_TOTNGHIEP.TRUDC.DL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductDL;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("best_seller")]
        public IActionResult GetProductBestSeller() 
        {
            try
            {
                //Kết quả trả về
                var products = _productBL.GetProductBestSeller();

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

        /// <summary>
        /// API lấy thông tin 1 bản ghi theo ID
        /// </summary>
        /// <returns>Thông tin bản ghi muốn lấy</returns>
      
        [HttpGet("GetByID/{productID}")]
       
        public IActionResult GetProductByID([FromRoute] Guid productID)
        {
            try
            {
                //Kết quả trả về
                var res = _productBL.GetProductByID(productID);

                //Xử lý kết quả trả về
                if (res.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, res[0]);
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
        /// <summary>
        /// API xóa nhiều product theo danh sách ID
        /// </summary>
        /// <param name="listEmployeeID">danh sách ID của các product muốn xóa</param>
        /// <returns>Status Code 200</returns>
        [Authorize]
        [HttpPost("deleteBatch")]
        public IActionResult DeleteMultiple([FromBody] ListProductID listProductID)
        {
          

            MySqlTransaction transaction = null;

            var ids = new List<Guid>();

            foreach (Guid id in listProductID.productIDs)
            {
                ids.Add(id);
            }

            var str = string.Join("','", ids);

            //Chuẩn bị câu lệnh SQL
            string sql = $"DELETE FROM orderdetail WHERE ProductID IN ('{str}');DELETE FROM productvariant WHERE ProductID IN ('{str}');DELETE FROM productimage WHERE ProductID IN ('{str}');DELETE FROM product WHERE ProductID IN ('{str}');";

            int numberOfRowsAffected = 0;
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                try
                {
                    transaction = mySqlConnection.BeginTransaction();
                    //Thực hiện gọi vào DB
                    numberOfRowsAffected = mySqlConnection.Execute(sql, transaction: transaction);
                    if (numberOfRowsAffected >= listProductID.productIDs.Count)
                    {
                        transaction.Commit();

                    }
                    else
                    {

                        transaction.Rollback();
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
                finally
                {
                    mySqlConnection.Close();
                }
            }
            //Xử lý kết quả trả về

            //Thành công: Trả về Id nhân viên thêm thành công
            if (numberOfRowsAffected > 0)
            {
                return StatusCode(StatusCodes.Status200OK, listProductID);
            }
            return null;
            //return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        /// API thêm mới 1 record
        /// </summary>
        /// <param name="record"> Đối tượng record cần thêm mới</param>
        /// <returns> ID của record vừa thêm mới</returns>
        [Authorize]
        [HttpPost("create")]
        public IActionResult InsertProduct([FromBody] Product product)
        {
            try
            {

                //Kết quả trả về
                ServiceResponse res = _productBL.InsertProduct(product);

                //Xử lý kết quả  trả về
                if (res.Success == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult((string)res.Data, (string)res.Data));

                }
                else
                {
                    int numberOfRowsAffected = (int)res.Data;
                    if (numberOfRowsAffected > 0 && product != null)
                    {
                    
                        return StatusCode(StatusCodes.Status201Created, 1);
                    }

                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(HttpContext.TraceIdentifier));

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(HttpContext.TraceIdentifier));

            }
        }
        //private async Task<string> WriteFile(IFormFile file)
        //{
        //    string filename = "";
        //    try
        //    {
        //        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
        //        filename = DateTime.Now.Ticks.ToString() + extension;

        //        var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

        //        if (!Directory.Exists(filepath))
        //        {
        //            Directory.CreateDirectory(filepath);
        //        }

        //        var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
        //        using (var stream = new FileStream(exactpath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return filename;
        //}

        /// <summary>
        /// API sửa thông tin bản ghi theo ID
        /// </summary>
        /// <param name="employeeID"> ID nhân viên muốn sửa</param>
        /// <param name="employee">Đối tượng nhân viên muốn sửa</param>
        /// <returns>ID nhân viên vừa sửa</returns>
        /// CreatedBy: DCTRU (02/11/2022)
        [Authorize]
        [HttpPut("update/{productID}")]
        public IActionResult UpdateProduct([FromRoute] Guid productID, [FromBody] Product product)

        {
            try
            {
                //Kết quả trả về
                ServiceResponse res = _productBL.UpdateProduct(productID, product);

                //Xử lý kết quả trả 
                if (res.Success == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult((string)res.Data, (string)res.Data));

                }
                else
                {
                    int numberOfRowsAffected = (int)res.Data;
                    if (numberOfRowsAffected > 0)
                    {
                        return StatusCode(StatusCodes.Status200OK, 1);
                    }

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

        /// <summary>
        /// API lấy danh sách nhân viên theo bộ lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param>
        /// <param name="departmentID">ID của phòng ban muốn lọc</param>
        /// <param name="PositionID">ID của vị trí muốn lọc</param>
        /// <param name="limit">Số bản ghi muốn lấy</param>
        /// <param name="offset">Vị trí của bản ghi bắt đầu lấy</param>
        /// <returns>Danh sách nhân viên và tổng số bản ghi</returns>
        /// CreatedBy : DCTRU (02/11/2022)
        [HttpGet("filter")]
        public IActionResult GetProductByFilterAndPaging(
            [FromQuery] string? keyword,
            [FromQuery] int[]? price,
            [FromQuery] string[]? Flitercolor,
            [FromQuery] string[]? Filtersize,
            [FromQuery] int PageSize = 25,
            [FromQuery] int PageNumber = 1)
        {
            try
            {
                var res = _productBL.GetProductByFilterAndPaging(keyword, PageSize, PageNumber, price, Flitercolor, Filtersize);

                //Xử lý kết quả trả về             
                if (res.Count > 0)
                {

                    return StatusCode(StatusCodes.Status200OK, new PagingResult()
                    {
                        Data = res,
                        TotalCount = res.Count
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new PagingResult());
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

        [HttpGet("GetProductsBycategory/{productCategoryID}")]
        public IActionResult GetProductByCategory(Guid productCategoryID)
        {
            try
            {
                //Kết quả trả về
                var products = _productBL.GetProductByCategory(productCategoryID);

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

        [HttpPost("placeOrder")]
        public IActionResult PlaceOrderSingle(PlaceOrderSingle placeOrderSingle)
        {
            try
            {
                //Kết quả trả về
                ServiceResponse res = _productBL.PlaceOrderSingle(placeOrderSingle);

                //Xử lý kết quả  trả về
                if (res.Success == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult((string)res.Data, (string)res.Data));

                }
                else
                {
                    int numberOfRowsAffected = (int)res.Data;
                    if (numberOfRowsAffected > 0 && placeOrderSingle != null)
                    {

                        return StatusCode(StatusCodes.Status201Created, 1);
                    }

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
    }
}
