using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.DL.ProductDL
{
    public interface IProductDL : IBaseDL<Product>
    {
        public IEnumerable<Product> GetProductByID(Guid productID);
        public IEnumerable<Product> GetProductBestSeller();
        public IEnumerable<Product> GetProductByPagingAndFilter(string? keyword, int PageSize, int PageNumber, int[]? price, string[]? color, string[]? size);
        public Product InsertProduct(Product product);
        public Product UpdateProduct(Guid productID, Product product);
        public IEnumerable<Product> GetProductByCategory(Guid categoryID);
        public int PlaceOrderSingle(PlaceOrderSingle placeOrderSingle);
    }
}
