using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.DL.CustomerDL;
using DOAN_TOTNGHIEP.TRUDC.DL.PaymentDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.BL.PaymentBL
{
    public class PaymentBL : BaseBL<Payment>, IPaymentBL
    {
        private IPaymentDL _paymentDL;
        public PaymentBL(IPaymentDL paymentDL) : base(paymentDL)
        {
            _paymentDL = paymentDL;
        }
    }
}
