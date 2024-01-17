using DOAN_TOTNGHIEP.TRUDC.BL.Configs;
using DOAN_TOTNGHIEP.TRUDC.BL.PaymentBL;
using DOAN_TOTNGHIEP.TRUDC.BL.VnpayBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using DOAN_TOTNGHIEP.TRUDC.Common.Extensions;
using DOAN_TOTNGHIEP.TRUDC.DL.PaymentDL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Net;

namespace DOAN_TOTNGHIEP.TRUDC.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentBL paymentBL;
        private readonly IPaymentDL paymentDL;
        private readonly VnpayConfig vnpayConfig;

        public PaymentController(IPaymentBL paymentBL,
            IPaymentDL paymentDL,
            IOptions<VnpayConfig> vnpayConfig)
        {
            this.paymentBL = paymentBL;
            this.paymentDL = paymentDL;
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
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
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

        [HttpPost]
        [Route("vnpay-payment")]
        public async Task<IActionResult> VnpayPaymentReturn(
            [FromQuery]VnpayPayResponse request)
        {
            var resultData = new PaymentReturnDto();
            try
            {
                var isValidSignature = request.IsValidSignature(vnpayConfig.HashSecret);

                if (isValidSignature)
                {
                    
                    var payment = paymentDL.GetRecordByID(Guid.Parse(request.vnp_TxnRef));

                    if (payment != null)
                    {
                        if (request.vnp_ResponseCode == "00")
                        {
                            resultData.PaymentStatus = "00";
                            resultData.PaymentId = payment.Id.ToString();
                        }
                        else
                        {
                            resultData.PaymentStatus = "10";
                            resultData.PaymentMessage = "Payment process failed";
                        }

                        ///TODO: update payment result
                        ///TODO: Handle signature between BE and FE
                    }
                    else
                    {
                        resultData.PaymentStatus = "11";
                        resultData.PaymentMessage = "Can't find payment at payment service";
                    }

                    
                }
                else
                {
                    resultData.PaymentStatus = "99";
                    resultData.PaymentMessage = "Invalid signature in response";
                }

            }
            catch(Exception ex)
            {
                resultData.PaymentStatus = "99";
                resultData.PaymentMessage = "Internal server error";
                Console.WriteLine(ex.Message);
            }
            return Redirect($"{vnpayConfig.RedirectUrl}?{resultData.ToQueryString()}");
        }
    }
}
