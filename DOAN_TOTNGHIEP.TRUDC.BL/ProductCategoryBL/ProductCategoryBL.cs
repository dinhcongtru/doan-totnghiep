using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.DL.BaseDL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductCategoryDL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DOAN_TOTNGHIEP.TRUDC.BL.ProductCategoryBL.ProductCategoryBL;

namespace DOAN_TOTNGHIEP.TRUDC.BL.ProductCategoryBL
{
    public class ProductCategoryBL : BaseBL<ProductCategory>, IProductCategoryBL
    {
        #region Field

        private IProductCategoryDL _productCategoryDL;

        #endregion

        public ProductCategoryBL(IProductCategoryDL productCategoryDL) : base(productCategoryDL)
        {
            _productCategoryDL = productCategoryDL;
        }

        public List<ProductCategory> GetAllCategories()
        {
            var res = _productCategoryDL.GetAllRecords();
            var categois = new List<ProductCategory>();
            if(res != null)
            {
                // lấy cate cấp 1 
                foreach (ProductCategory category in (List<ProductCategory>)res)
                {
                    
                    if (category.parent_category_id == Guid.Empty)
                    {
                        categois.Add(category);
                    } 
                }
                //kiểm tra xem cate cấp 1 là cha của những cate nào
                  foreach (ProductCategory cate in categois)
                   {
                        foreach (ProductCategory category in (List<ProductCategory>)res)
                        {

                            if (cate.ProductCategoryID == category.parent_category_id)
                            {
                                cate.optionMenus.Add(category);
                            }
                          

                        }

                        foreach (ProductCategory child in cate.optionMenus)
                        {
                            foreach (ProductCategory category in (List<ProductCategory>)res)
                            {

                                if (child.ProductCategoryID == category.parent_category_id)
                                {
                                    child.optionMenus.Add(category);
                                }
                            }
                        }


                }
                return categois;
            }
            else
            {
                return null;
            }
        }
    }
}
