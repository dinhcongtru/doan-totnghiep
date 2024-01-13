using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Enums;
using DOAN_TOTNGHIEP.TRUDC.Common;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using System.Data;
using DOAN_TOTNGHIEP.TRUDC.DL;
using DOAN_TOTNGHIEP.TRUDC.Common.Constants;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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

        ///// <summary>
        ///// API lấy thông tin 1 bản ghi theo ID
        ///// </summary>
        ///// <returns>Thông tin bản ghi muốn lấy</returns>
        ///// CreatedBy: DCTRU (02/11/2022)
        [HttpGet("{recordID}")]
        public IActionResult GetRecordByID([FromRoute] Guid recordID)
        {
            try
            {
                //Kết quả trả về
                ServiceResponse res = _baseBL.GetRecordByID(recordID);

                //Xử lý kết quả trả về
                if (res.Success == true)
                {
                    return StatusCode(StatusCodes.Status200OK, res.Data);
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
        /// API thêm mới 1 record
        /// </summary>
        /// <param name="record"> Đối tượng record cần thêm mới</param>
        /// <returns> ID của record vừa thêm mới</returns>
        [HttpPost]
        public IActionResult InsertRecord([FromBody] T record)
        {
            try
            {

                //Kết quả trả về
                ServiceResponse res = _baseBL.InsertRecord(record);

                //Xử lý kết quả  trả về
                if (res.Success == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult((string)res.Data, (string)res.Data));

                }
                else
                {
                    int numberOfRowsAffected = (int)res.Data;
                    if (numberOfRowsAffected > 0)
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

        /// <summary>
        /// API sửa thông tin bản ghi theo ID
        /// </summary>
        /// <param name="employeeID"> ID nhân viên muốn sửa</param>
        /// <param name="employee">Đối tượng nhân viên muốn sửa</param>
        /// <returns>ID nhân viên vừa sửa</returns>
        /// CreatedBy: DCTRU (02/11/2022)
        [Authorize]
        [HttpPut("{recordID}")]
        public IActionResult UpdateRecord([FromRoute] Guid recordID, [FromBody] T record)

        {
            try
            {
                //Kết quả trả về
                ServiceResponse res = _baseBL.UpdateRecord(recordID, record);

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
        /// API xóa 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns> ID bản ghi vừa xóa</returns>
        /// CreatedBy: DCTRU (02/11/2022)
       
        [HttpDelete("{recordID}")]
        public IActionResult DeleteRecord([FromRoute] Guid recordID)
        {
            try
            {
                //Kết quả trả về
                ServiceResponse res = _baseBL.DeleteRecordByID(recordID);

                //Xử lý kết quả trả về
                if (res.Success == true)
                {
                    return StatusCode(StatusCodes.Status200OK, res.Data);
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
        /// Lấy mã nhân viên mới nhất
        /// </summary>
        /// <returns>mã nhân viên mới nhất</returns>
        [Authorize]
        [HttpGet("newCode")]
        public IActionResult GetNewCode()
        {
            try
            {
                var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString);

                // Chuẩn bị câu lệnh SQL
                string storedProcedureName = String.Format(Procedure.GET_NEW_CODE, typeof(T).Name);

                // Thực hiện gọi vào DB
                var newCode = mySqlConnection.QueryFirstOrDefault(storedProcedureName, commandType: CommandType.StoredProcedure);

                // Xử lý kết quả trả về 
                if (newCode != null)
                {
                    return StatusCode(StatusCodes.Status200OK, newCode);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
