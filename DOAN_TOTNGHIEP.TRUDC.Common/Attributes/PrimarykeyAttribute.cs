using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common
{
    /// <summary>
    /// Attribute kiểm tra xem có null hoặc rỗng hay không
    /// </summary>
    public class IsNotNullOrEmptyAttribute : Attribute
    {
        #region Field
        /// <summary>
        /// Thông tin lỗi
        /// </summary>
        public string ErrorMessage { get; set; }
        #endregion

        #region Constructor
        public IsNotNullOrEmptyAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        #endregion
    }

    /// <summary>
    /// Attribute kiểm tra các trường nhập số
    /// </summary>
    public class IsNumberAttribute : Attribute
    {
        #region Field
        /// <summary>
        /// Format dữ liệu
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Thông tin lỗi
        /// </summary>
        public string ErrorMessage { get; set; }
        #endregion

        #region Constructor
        public IsNumberAttribute(string format, string errorMessage)
        {
            Format = format;
            ErrorMessage = errorMessage;
        }
        #endregion
    }

    /// <summary>
    /// Attribute kiểm tra xem có đúng định dạng email không
    /// </summary>
    public class ValidateEmailAttribute : Attribute
    {
        #region Field
        /// <summary>
        /// format dữ liệu
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Thông tin lỗi
        /// </summary>
        public string ErrorMessage { get; set; }
        #endregion

        #region Constructor
        public ValidateEmailAttribute(string format , string erorrMessage)
        {
            Format = format;
            ErrorMessage = erorrMessage;
        }
        #endregion
    }

    /// <summary>
    /// Attribute không được phép trùng đữ liệu
    /// </summary>
    public class UniqueAttribute: Attribute
    {
        #region Field
        /// <summary>
        /// Thông tin lỗi
        /// </summary>
        public string ErrorMessage { get; set; }
        #endregion

        #region Constructor
        public UniqueAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        #endregion
    }
}
