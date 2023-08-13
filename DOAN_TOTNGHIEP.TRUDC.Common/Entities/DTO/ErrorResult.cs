using System;
using DOAN_TOTNGHIEP.TRUDC.Common.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO
{
    /// <summary>
    /// Kết quả trả về khi gọi Api gặp lỗi
    /// </summary>
    public class ErrorResult
    {
        #region Field
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public ApiErorrCode ErrorCode { get; set; }

        /// <summary>
        /// Message trả về cho dev
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Message trả về cho người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Thông tin chi tiết về lỗi
        /// </summary>
        public string MoreInfo { get; set; }  
        
        /// <summary>
        /// ID dùng để trace lỗi khi log lại
        /// </summary>
        public string TraceId { get; set; }
        #endregion
        #region Constructor
        public ErrorResult(string traceId)
        {
            ErrorCode = ApiErorrCode.Exception;
            DevMsg = Resources.DevMsg_Exception;
            UserMsg = Resources.UserMsg_Exception;
            MoreInfo = Resources.MoreInfo_Exception;
            TraceId = traceId;
        }
        public ErrorResult(string devMsg, string userMsg)
        {
            ErrorCode = ApiErorrCode.InvalidData;
            DevMsg = devMsg;
            UserMsg = userMsg;
            MoreInfo = "";
            TraceId = "";
        }
        #endregion
    }
}
