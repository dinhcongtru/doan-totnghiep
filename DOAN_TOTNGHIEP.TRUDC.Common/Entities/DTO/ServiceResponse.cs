using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO
{
    public class ServiceResponse
    {
        #region Field
        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        public static int ValidateRequestData { get; set; }

        /// <summary>
        /// Thành công trả về true hoặc false
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object? Data { get; set; }
        #endregion

        #region Constructor
        public ServiceResponse(bool success, object? data)
        {
            Success = success;
            Data = data;
        }
        #endregion
    }
}
