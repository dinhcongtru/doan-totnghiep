using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO
{
    /// <summary>
    /// Kết quả trả về của API lấy danh sách record theo bộ lọc và phân trang
    /// </summary>
    public class PagingResult
    {
       
        /// Danh sách nhân viên
        /// </summary>
        public List<Product> Data { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public long TotalCount { get; set; }

    }
}
