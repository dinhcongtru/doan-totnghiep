using Dapper;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Constants;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace DOAN_TOTNGHIEP.TRUDC.Controllers
{
    [ApiController]
    public class ProductsController : BasesController<Product>
    {
        #region Field

        private IProductBL _productBL;

        #endregion

        #region Constructor 

        public ProductsController(IProductBL productBL) : base(productBL)
        {
            _productBL = productBL;
        }

        #endregion
    }
}
