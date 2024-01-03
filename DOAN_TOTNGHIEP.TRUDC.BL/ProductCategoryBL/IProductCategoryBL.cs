using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.BL.ProductCategoryBL
{
    public interface IProductCategoryBL : IBaseBL<ProductCategory>
    {
        public List<ProductCategory> GetAllCategories();
    }
}
