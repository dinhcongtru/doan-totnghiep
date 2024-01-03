using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.BL.ProductBL
{
    public interface IProductBL : IBaseBL<Product>
    {
        public List<Product> GetAllProduct();

        public List<Product> GetProductBestSeller();

        public List<Product> GetProductByID(Guid productID);

        public List<Product> GetProductByFilterAndPaging(string? keyword,int PageSize,int PageNumber, int[]? price, string[]? Filtercolor, string[]? Filtersize);

        public ServiceResponse InsertProduct(Product product);

        public ServiceResponse UpdateProduct(Guid productID, Product product);

        public List<Product> GetProductByCategory(Guid productCategoryID);

        public ServiceResponse PlaceOrderSingle(PlaceOrderSingle placeOrderSingle);
    }
}
