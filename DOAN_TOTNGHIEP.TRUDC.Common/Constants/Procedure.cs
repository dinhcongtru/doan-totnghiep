using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Constants
{
    public class Procedure
    {
        /// <summary>
        /// Fomat Procedure tất cả bản ghi
        /// </summary>
        public static string GET_ALL = "Proc_{0}_GetAll";

        /// <summary>
        /// Fomat Procedure lấy 1 bản ghi theo ID
        /// </summary>
        public static string GET_BY_ID = "Proc_{0}_GetByID";

        /// <summary>
        /// Fomat Procedure xóa 1 bản ghi theo ID
        /// </summary>
        public static string DELETE_BY_ID = "Proc_{0}_Delete";

        /// <summary>
        /// Fomat Procedure lấy mã bản ghi mới
        /// </summary>
        public static string GET_NEW_CODE = "Proc_{0}_NewCode";

        /// <summary>
        /// Fomat Procedure lấy danh sách bản ghi theo tìm kiếm và phân trang
        /// </summary>
        public static string GET_FILTER_AND_PADING = "Proc_{0}_GetPaging";

        /// <summary>
        /// Fomat Procedure Thêm 1 bản ghi 
        /// </summary>
        public static string INSERT = "Proc_{0}_Insert";

        /// <summary>
        /// Fomat Procedure sửa 1 bản ghi 
        /// </summary>
        public static string UPDATE = "Proc_{0}_Update";

        /// <summary>
        /// Fomat Procedure sửa 1 bản ghi khi thêm mới
        /// </summary>
        public static string INSERT_CHECK_DAPLICATE = "Proc_{0}_CheckDuplicateCode_Insert";


        public static string UPDATE_CHECK_DAPLICATE = "Proc_{0}_CheckDuplicateCode_Update";
    }
}
