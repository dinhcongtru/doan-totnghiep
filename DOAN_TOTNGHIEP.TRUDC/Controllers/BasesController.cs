using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Enums;
using DOAN_TOTNGHIEP.TRUDC.Common;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;

namespace DOAN_TOTNGHIEP.TRUDC.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor 

        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        #endregion

        #region Base Api

        /// <summary>
        /// API lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy : DCTRU (13/08/2023)
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            try
            {
                //Kết quả trả về
                var res = _baseBL.GetAllRecords();

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



        #endregion
    }
}
