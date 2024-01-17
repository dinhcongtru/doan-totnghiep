using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    /// <summary>
    /// Quản lý các yêu cầu thanh toán
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Mã giao dịch thanh toán để quản giao dịch
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Nội dung thanh toán
        /// </summary>
        public string PaymentContent { get; set; } = string.Empty;
        /// <summary>
        /// Loại tiền thanh toán, đối với VNPAY duy nhất tiền việt nam VND
        /// </summary>
        public string PaymentCurrency { get; set; } = string.Empty;
        /// <summary>
        /// Mã tham chiếu với đối tác thanh toán, thông thường trùng với mã đơn hàng
        /// </summary>
        public string PaymentRefId { get; set; } = string.Empty;
        
        /// <summary>
        /// Số tiền yêu cầu thanh toán
        /// </summary>
        public decimal? RequiredAmount { get; set; }
        /// <summary>
        /// Thời điểm tạo giao dịch thanh toán
        /// </summary>
        public DateTime? PaymentDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Thời điểm giao dịch thanh toán hết hạn
        /// </summary>
        public DateTime? ExpireDate { get; set; }
        /// <summary>
        /// Ngôn ngữ sử dụng trong giao dịch
        /// </summary>
        public string? PaymentLanguage { get; set; } = string.Empty;
        /// <summary>
        /// Đích thanh toán, có thể bỏ qua (thông thường ghi nhận ngân hàng thanh toán)
        /// </summary>
        public string? PaymentDestinationId { get; set; } = string.Empty;
        /// <summary>
        /// Trạng thái thanh toán và kết quả cuối cùng
        /// </summary>
        public string? PaymentStatus { get; set; } = string.Empty;
        public string? PaymentLastMessage { get; set; } = string.Empty;
    }
}
