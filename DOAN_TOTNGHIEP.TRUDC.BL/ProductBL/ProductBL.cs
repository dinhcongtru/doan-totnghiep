using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.BL.ProductBL
{
    public class ProductBL : BaseBL<Product>, IProductBL
    {
        #region Field

        private IProductDL _productDL;
        #endregion

        #region Constructor

        public ProductBL(IProductDL productDL) : base(productDL)
        {
            _productDL = productDL;
        }

        #endregion
    }
}
