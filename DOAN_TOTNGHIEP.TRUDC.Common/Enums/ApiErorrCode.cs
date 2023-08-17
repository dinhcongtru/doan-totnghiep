using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Enums
{
    /// <summary>
    /// Enum sử dụng các lỗi sẩy ra khi gọi api
    /// </summary>
    public enum ApiErorrCode
    {
        /// <summary>
        /// gặp lỗi exception
        /// </summary>
        Exception = 1,

        /// <summary>
        /// gặp lỗi trùng mã
        /// </summary>
        DuplicateCode = 2,

        /// <summary>
        /// gặp lỗi dữ liệu đầu vào không hợp lệ
        /// </summary>
        InvalidData = 3,
    }
}
