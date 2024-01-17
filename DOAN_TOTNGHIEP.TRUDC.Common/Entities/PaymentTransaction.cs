using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.Common.Entities
{
    /// <summary>
    /// Quản lý các giao dịch thanh toán với bên thứ ba
    /// </summary>
    public class PaymentTransaction
    {
        [Key]
        public Guid Id { get; set; }
        public string? TranMessage { get; set; } = string.Empty;
        public string? TranPayload { get; set; } = string.Empty;
        public string? TranStatus { get; set; } = string.Empty;
        public decimal? TranAmount { get; set; }
        public DateTime? TranDate { get; set; }
        /// <summary>
        /// Mã yêu cầu thanh toán
        /// </summary>
        public string? PaymentId { get; set; } = string.Empty;
        /// <summary>
        /// Mã đối soát với bên thứ ba
        /// </summary>
        public string? TranRefId { get; set; } = string.Empty;
    }
}
