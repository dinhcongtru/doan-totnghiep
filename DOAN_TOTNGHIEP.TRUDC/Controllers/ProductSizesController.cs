using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOAN_TOTNGHIEP.TRUDC.Controllers
{
    [ApiController]
    public class ProductSizesController : BasesController<ProductSize>
    {
        public ProductSizesController(IBaseBL<ProductSize> baseBL) : base(baseBL) { }
    }
}
