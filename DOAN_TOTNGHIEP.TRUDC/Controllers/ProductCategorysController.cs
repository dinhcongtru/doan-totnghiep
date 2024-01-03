using Dapper;
using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.BL.CustomerBL;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductCategoryBL;
using DOAN_TOTNGHIEP.TRUDC.Common;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using DOAN_TOTNGHIEP.TRUDC.Common.Enums;
using DOAN_TOTNGHIEP.TRUDC.DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace DOAN_TOTNGHIEP.TRUDC.Controllers
{
    [ApiController]
    public class ProductCategorysController : BasesController<ProductCategory>
    {
        #region Field

        private IProductCategoryBL _productCategoryBL;

        #endregion

        #region Constructor 

        public ProductCategorysController(IProductCategoryBL productCategoryBL) : base(productCategoryBL)
        {
            _productCategoryBL = productCategoryBL;
        }

        /// <summary>
        /// API xóa nhiều CATE theo danh sách ID
        /// </summary>
        /// <param name="listEmployeeID">danh sách ID của các product muốn xóa</param>
        /// <returns>Status Code 200</returns>
        [Authorize]
        [HttpPost("deleteBatch")]
        public IActionResult DeleteMultiple([FromBody] ListProductCategoryID listProductCategoryID)
        {


            MySqlTransaction transaction = null;

            var ids = new List<Guid>();

            foreach (Guid id in listProductCategoryID.ProductCategoryIDs)
            {
                ids.Add(id);
            }

            var str = string.Join("','", ids);

            //Chuẩn bị câu lệnh SQL
            string sql = $"DELETE FROM orderdetail WHERE ProductID IN(SELECT p.ProductID FROM product p WHERE p.CategoryID IN('{str}'));DELETE FROM productvariant WHERE ProductID IN(SELECT p.ProductID FROM product p WHERE p.CategoryID IN('{str}'));DELETE FROM productimage WHERE ProductID IN(SELECT p.ProductID FROM product p WHERE p.CategoryID IN('{str}')); DELETE FROM product WHERE CategoryID IN('{str}');DELETE FROM productcategory WHERE ProductCategoryID IN('{str}');";

            int numberOfRowsAffected = 0;
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                try
                {
                    transaction = mySqlConnection.BeginTransaction();
                    //Thực hiện gọi vào DB
                    numberOfRowsAffected = mySqlConnection.Execute(sql, transaction: transaction);
                    if (numberOfRowsAffected >= listProductCategoryID.ProductCategoryIDs.Count)
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
                return StatusCode(StatusCodes.Status200OK, listProductCategoryID);
            }
            return null;
            //return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllCategories()
        {
            try
            {
                //Kết quả trả về
                var res = _productCategoryBL.GetAllCategories();

                //Xử lý kết quả trả về
                if (res != null)
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
    }
}
#endregion