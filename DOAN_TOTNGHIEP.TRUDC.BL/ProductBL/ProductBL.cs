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

        public List<Product> GetAllProduct()
        {
            // Lấy tất cả kích cỡ, màu sác của các sản phảm
            var result = _productDL.GetAllRecords();
            if (result != null)
            {

                var products = new List<Product>();
                foreach (Product product in (List<Product>)result)
                {
                    // Kiểm tra xem sản phẩm đã có trong list chưa
                    bool exists = products.Any(item => item.ProductID == product.ProductID);
                    var color = new ProductColor();
                    var size = new ProductSize();
                    if (exists)
                    {
                        // Lấy ra sản phẩm đấy mếu đã tồn tại
                        Product targetItem = products.FirstOrDefault(item => item.ProductID == product.ProductID);
                        //lấy ra pro có cùng màu sắc
                        Product targetPro = products.FirstOrDefault(item => item.ProductID == product.ProductID);
                        if (targetItem != null && targetPro != null)
                        {
                            // Xử lý thêm màu sắc và kích cỡ cho sản phẩm
                            // kiểm tra xem sản phẩm có cùng màu sắc hay không , nếu cùng màu thì add thêm productSizes nếu không thì add thêm productColors
                           
                            if(targetPro.ColorID == product.ColorID)
                            {
                               foreach(var item in targetPro.listColors)
                                {
                                    if(item.ColorID == product.ColorID)
                                    {
                                        size.SizeName = product.SizeName;
                                        size.SizeID = product.SizeID;
                                        size.selected = false;
                                        size.Quantity = product.Quantity;
                                        item.sizeItem.Add(size);
                                    }
                                }
                            } else {
                                // nếu sản phẩm ko trùng id color thì thêm color

                                color.ColorName = product.ColorName;
                                color.ColorID = product.ColorID;
                                color.Price = product.Price;
                                color.selected = false;
                                size.SizeName = product.SizeName;
                                size.SizeID = product.SizeID;
                                size.selected = false;
                                size.Quantity = product.Quantity;
                                color.sizeItem.Add(size);
                                targetPro.listColors.Add(color);

                            }

                        }
                        
                    }
                    else
                    {
                        // Thêm sản phẩm vào trong list
                        
                        color.ColorID = product.ColorID;
                        color.ColorName = product.ColorName;
                        color.Price = product.Price;
                        color.selected = false;
                        size.SizeName = product.SizeName;
                        size.SizeID = product.SizeID;
                        size.selected = false;
                        size.Quantity = product.Quantity;
                        color.sizeItem.Add(size);
                        product.listColors.Add(color);
                        products.Add(product);
                    }

                }

                return products;
            }
            return new List<Product>();
            #endregion
        }
    }
}
