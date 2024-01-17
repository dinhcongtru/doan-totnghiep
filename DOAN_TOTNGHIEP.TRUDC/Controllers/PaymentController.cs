using DOAN_TOTNGHIEP.TRUDC.BL.Configs;
using DOAN_TOTNGHIEP.TRUDC.BL.PaymentBL;
using DOAN_TOTNGHIEP.TRUDC.BL.VnpayBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.DL.PaymentDL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace DOAN_TOTNGHIEP.TRUDC.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentBL paymentBL;
        private readonly VnpayConfig vnpayConfig;

        public PaymentController(IPaymentBL paymentBL,
            IOptions<VnpayConfig> vnpayConfig)
        {
            this.paymentBL = paymentBL;
            this.vnpayConfig = vnpayConfig.Value;
        }

        /// <summary>
        /// Create payment to get link
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("vnpay-payment")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateVnpayPayment([FromBody]Payment request)
        {
            var paymentId = Guid.NewGuid().ToString();
            var reqIpAddress = HttpContext.Connection?.LocalIpAddress?.ToString();
            var vnpayPayRequest = new VnpayPayRequest(vnpayConfig.Version,
                                vnpayConfig.TmnCode, DateTime.Now, reqIpAddress ?? string.Empty, request.RequiredAmount ?? 0, request.PaymentCurrency ?? string.Empty,
                                "other", request.PaymentContent ?? string.Empty, vnpayConfig.ReturnUrl, paymentId ?? string.Empty);
            string paymentUrl = vnpayPayRequest.GetLink(vnpayConfig.PaymentUrl, vnpayConfig.HashSecret);
            return StatusCode(StatusCodes.Status200OK, paymentUrl);
        }

    }
}
