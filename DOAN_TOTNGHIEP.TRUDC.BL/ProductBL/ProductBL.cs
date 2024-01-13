using Dapper;
using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using DOAN_TOTNGHIEP.TRUDC.DL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductDL;
using Imagekit.Sdk;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.BL.ProductBL
{
    public class ProductBL : BaseBL<Product>, IProductBL
    {
        #region Field

        private IProductDL _productDL;
        private readonly ImagekitClient _imageKitClient;


        #endregion

        #region Constructor

        public ProductBL(IProductDL productDL) : base(productDL)
        {
            _productDL = productDL;
            // Tạo ImageKitClient với thông tin cấu hình
            _imageKitClient = new ImagekitClient(
                "public_nRH9GscPrNBNZXoLDNKUp8KD3uw=",
                "private_EqGWiWgU7U8E18xws0Q+qiXCTH0=",
                "https://ik.imagekit.io/mbtxd1r6m");
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
                    var image = new ProductImage();
                    if (exists)
                    {

                        // Lấy ra sản phẩm đấy mếu đã tồn tại
                        Product targetPro = products.FirstOrDefault(item => item.ProductID == product.ProductID);
                        if (targetPro != null)
                        {
                            // Xử lý thêm màu sắc và kích cỡ cho sản phẩm
                            // kiểm tra xem sản phẩm có cùng màu sắc hay không , nếu cùng màu thì add thêm productSizes nếu không thì add thêm productColors
                            if (targetPro.ProductColorID == product.ProductColorID)
                            {
                                foreach (var item in targetPro.listColors)
                                {

                                    if (item.ProductColorID == product.ProductColorID)
                                    {
                                        var exitsSize = item.sizeItem.Any(i => i.ProductSizeID == product.ProductSizeID);

                                        if (!exitsSize)
                                        {
                                            size.ProductSizeName = product.ProductSizeName;
                                            size.ProductSizeID = product.ProductSizeID;
                                            size.selected = false;
                                            size.VariantID = product.VariantID;
                                            size.Quantity = product.Quantity;
                                            item.sizeItem.Add(size);
                                        }

                                        // kiểm tra xem image đã có, lặp lại hay không , nếu ko lặp lại add images
                                        var exitsImg = item.imageItem.Any(i => i.ProductImageID == product.ProductImageID);
                                        if (!exitsImg)
                                        {
                                            // add image
                                            image.ProductImageID = product.ProductImageID;
                                            image.ProductImageUrl = product.ProductImageUrl;
                                            image.selected = false;
                                            item.imageItem.Add(image);
                                        }

                                    }

                                }
                            }
                            else
                            {
                                // nếu sản phẩm ko trùng id color và ko tồn tại trong listcolor thì add color
                                var colorExsit = targetPro.listColors.Any(item => item.ProductColorID == product.ProductColorID);
                                var targetColor = targetPro.listColors.FirstOrDefault(item => item.ProductColorID == product.ProductColorID);
                                if (!colorExsit)
                                {
                                    color.ProductColorName = product.ProductColorName;
                                    color.ProductColorID = product.ProductColorID;
                                    color.selected = false;
                                    size.ProductSizeName = product.ProductSizeName;
                                    size.ProductSizeID = product.ProductSizeID;
                                    size.selected = false;
                                    size.VariantID = product.VariantID;
                                    size.Quantity = product.Quantity;
                                    color.sizeItem.Add(size);
                                    image.selected = true;
                                    image.ProductImageUrl = product.ProductImageUrl;
                                    image.ProductImageID = product.ProductImageID;
                                    color.imageItem.Add(image);
                                    targetPro.listColors.Add(color);
                                }
                                else
                                // nếu tồn tại trong listColors thì add size
                                {
                                    var exitsSize = targetColor.sizeItem.Any(i => i.ProductSizeID == product.ProductSizeID);
                                    if (!exitsSize)
                                    {
                                        size.ProductSizeName = product.ProductSizeName;
                                        size.ProductSizeID = product.ProductSizeID;
                                        size.selected = false;
                                        size.Quantity = product.Quantity;
                                        size.VariantID = product.VariantID;
                                        targetColor.sizeItem.Add(size);
                                    }


                                    // nếu image ko tồn tại trong imgItem thì add image
                                    var exitsImg = targetColor.imageItem.Any(i => i.ProductImageID == product.ProductImageID);
                                    if (!exitsImg)
                                    {
                                        // add image
                                        image.ProductImageID = product.ProductImageID;
                                        image.ProductImageUrl = product.ProductImageUrl;
                                        image.selected = false;
                                        targetColor.imageItem.Add(image);
                                    }

                                }

                            }

                        }

                    }
                    else
                    {
                        // Thêm sản phẩm vào trong list

                        color.ProductColorID = product.ProductColorID;
                        color.ProductColorName = product.ProductColorName;
                        color.selected = false;
                        size.ProductSizeName = product.ProductSizeName;
                        size.ProductSizeID = product.ProductSizeID;
                        size.selected = false;
                        size.Quantity = product.Quantity;
                        size.VariantID = product.VariantID;
                        image.ProductImageUrl = product.ProductImageUrl;
                        image.ProductImageID = product.ProductImageID;
                        image.selected = true;
                        color.imageItem.Add(image);
                        color.sizeItem.Add(size);
                        product.listColors.Add(color);
                        products.Add(product);

                    }

                }
                foreach (var prod in products)
                {
                    foreach (var color in prod.listColors)
                    {
                        foreach (var size in color.sizeItem)
                        {
                            prod.TotalQuantity += size.Quantity;
                        }
                    }
                }
                return products;
            }
            return new List<Product>();
            #endregion
        }

        public List<Product> GetProductBestSeller()
        {
            // Lấy tất cả kích cỡ, màu sác của các sản phảm
            var result = _productDL.GetProductBestSeller();
            if (result != null)
            {

                var products = new List<Product>();
                foreach (Product product in (List<Product>)result)
                {
                    // Kiểm tra xem sản phẩm đã có trong list chưa
                    bool exists = products.Any(item => item.ProductID == product.ProductID);
                    var color = new ProductColor();
                    var size = new ProductSize();
                    var image = new ProductImage();
                    if (exists)
                    {

                        // Lấy ra sản phẩm đấy mếu đã tồn tại
                        Product targetPro = products.FirstOrDefault(item => item.ProductID == product.ProductID);
                        if (targetPro != null)
                        {
                            // Xử lý thêm màu sắc và kích cỡ cho sản phẩm
                            // kiểm tra xem sản phẩm có cùng màu sắc hay không , nếu cùng màu thì add thêm productSizes nếu không thì add thêm productColors
                            if (targetPro.ProductColorID == product.ProductColorID)
                            {
                                foreach (var item in targetPro.listColors)
                                {

                                    if (item.ProductColorID == product.ProductColorID)
                                    {
                                        var exitsSize = item.sizeItem.Any(i => i.ProductSizeID == product.ProductSizeID);

                                        if (!exitsSize)
                                        {
                                            size.ProductSizeName = product.ProductSizeName;
                                            size.ProductSizeID = product.ProductSizeID;
                                            size.selected = false;
                                            size.VariantID = product.VariantID;
                                            size.Quantity = product.Quantity;
                                            item.sizeItem.Add(size);
                                        }

                                        // kiểm tra xem image đã có, lặp lại hay không , nếu ko lặp lại add images
                                        var exitsImg = item.imageItem.Any(i => i.ProductImageID == product.ProductImageID);
                                        if (!exitsImg)
                                        {
                                            // add image
                                            image.ProductImageID = product.ProductImageID;
                                            image.ProductImageUrl = product.ProductImageUrl;
                                            image.selected = false;
                                            item.imageItem.Add(image);
                                        }

                                    }

                                }
                            }
                            else
                            {
                                // nếu sản phẩm ko trùng id color và ko tồn tại trong listcolor thì add color
                                var colorExsit = targetPro.listColors.Any(item => item.ProductColorID == product.ProductColorID);
                                var targetColor = targetPro.listColors.FirstOrDefault(item => item.ProductColorID == product.ProductColorID);
                                if (!colorExsit)
                                {
                                    color.ProductColorName = product.ProductColorName;
                                    color.ProductColorID = product.ProductColorID;
                                    color.selected = false;
                                    size.ProductSizeName = product.ProductSizeName;
                                    size.ProductSizeID = product.ProductSizeID;
                                    size.selected = false;
                                    size.VariantID = product.VariantID;
                                    size.Quantity = product.Quantity;
                                    color.sizeItem.Add(size);
                                    image.selected = true;
                                    image.ProductImageUrl = product.ProductImageUrl;
                                    image.ProductImageID = product.ProductImageID;
                                    color.imageItem.Add(image);
                                    targetPro.listColors.Add(color);
                                }
                                else
                                // nếu tồn tại trong listColors thì add size
                                {
                                    var exitsSize = targetColor.sizeItem.Any(i => i.ProductSizeID == product.ProductSizeID);
                                    if (!exitsSize)
                                    {
                                        size.ProductSizeName = product.ProductSizeName;
                                        size.ProductSizeID = product.ProductSizeID;
                                        size.selected = false;
                                        size.Quantity = product.Quantity;
                                        size.VariantID = product.VariantID;
                                        targetColor.sizeItem.Add(size);
                                    }


                                    // nếu image ko tồn tại trong imgItem thì add image
                                    var exitsImg = targetColor.imageItem.Any(i => i.ProductImageID == product.ProductImageID);
                                    if (!exitsImg)
                                    {
                                        // add image
                                        image.ProductImageID = product.ProductImageID;
                                        image.ProductImageUrl = product.ProductImageUrl;
                                        image.selected = false;
                                        targetColor.imageItem.Add(image);
                                    }

                                }

                            }

                        }

                    }
                    else
                    {
                        // Thêm sản phẩm vào trong list

                        color.ProductColorID = product.ProductColorID;
                        color.ProductColorName = product.ProductColorName;
                        color.selected = false;
                        size.ProductSizeName = product.ProductSizeName;
                        size.ProductSizeID = product.ProductSizeID;
                        size.selected = false;
                        size.Quantity = product.Quantity;
                        size.VariantID = product.VariantID;
                        image.ProductImageUrl = product.ProductImageUrl;
                        image.ProductImageID = product.ProductImageID;
                        image.selected = true;
                        color.imageItem.Add(image);
                        color.sizeItem.Add(size);
                        product.listColors.Add(color);
                        products.Add(product);

                    }

                }
                foreach (var prod in products)
                {
                    foreach (var color in prod.listColors)
                    {
                        foreach (var size in color.sizeItem)
                        {
                            prod.TotalQuantity += size.Quantity;
                        }
                    }
                }

                return products;
            }
            return new List<Product>();
        }

        public void AfterInsert(Product product)
        {
            if (product.listColors.Count > 0)
            {
                foreach (var color in product.listColors)
                {
                    for (var i = 0; i < color.sizeItem.Count; i++)
                    {
                        var sql = $"INSERT INTO productvariant (VariantID, ProductID, ProductSizeID, ProductColorID, Quantity) VALUES ('{Guid.NewGuid()}', '{product.ProductID}', '{color.sizeItem[i].ProductSizeID}', '{color.ProductColorID}', {color.sizeItem[i].Quantity});";

                        // Khoởi tạo kết nối tới DB MySQL (Muộn nhất có thể)
                        using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                        {
                            //Thực hiện gọi vào DB
                            mySqlConnection.Execute(sql);
                        }
                    }

                    for (var i = 0; i < color.imageItem.Count; i++)
                    {
                        var imageID = Guid.NewGuid();
                        var sql = $"INSERT INTO productimage (ProductImageID, ProductImageUrl, ProductID, ProductColorID) VALUES ('{imageID}', '{color.imageItem[i].ThumbnailUrl}','{product.ProductID}','{color.ProductColorID}');";
                        using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                        {
                            //Thực hiện gọi vào DB
                            mySqlConnection.Execute(sql);
                        }
                    }
                }
            }
        }

        public List<Product> GetProductByCategory(Guid productCategoryID)
        {
            // Lấy tất cả kích cỡ, màu sác của các sản phảm
            var result = _productDL.GetProductByCategory(productCategoryID);
            if (result != null)
            {

                var products = new List<Product>();
                foreach (Product product in (List<Product>)result)
                {
                    // Kiểm tra xem sản phẩm đã có trong list chưa
                    bool exists = products.Any(item => item.ProductID == product.ProductID);
                    var color = new ProductColor();
                    var size = new ProductSize();
                    var image = new ProductImage();
                    if (exists)
                    {

                        // Lấy ra sản phẩm đấy mếu đã tồn tại
                        Product targetPro = products.FirstOrDefault(item => item.ProductID == product.ProductID);
                        if (targetPro != null)
                        {
                            // Xử lý thêm màu sắc và kích cỡ cho sản phẩm
                            // kiểm tra xem sản phẩm có cùng màu sắc hay không , nếu cùng màu thì add thêm productSizes nếu không thì add thêm productColors
                            if (targetPro.ProductColorID == product.ProductColorID)
                            {
                                foreach (var item in targetPro.listColors)
                                {

                                    if (item.ProductColorID == product.ProductColorID)
                                    {
                                        var exitsSize = item.sizeItem.Any(i => i.ProductSizeID == product.ProductSizeID);

                                        if (!exitsSize)
                                        {
                                            size.ProductSizeName = product.ProductSizeName;
                                            size.ProductSizeID = product.ProductSizeID;
                                            size.selected = false;
                                            size.VariantID = product.VariantID;
                                            size.Quantity = product.Quantity;
                                            item.sizeItem.Add(size);
                                        }

                                        // kiểm tra xem image đã có, lặp lại hay không , nếu ko lặp lại add images
                                        var exitsImg = item.imageItem.Any(i => i.ProductImageID == product.ProductImageID);
                                        if (!exitsImg)
                                        {
                                            // add image
                                            image.ProductImageID = product.ProductImageID;
                                            image.ProductImageUrl = product.ProductImageUrl;
                                            image.selected = false;
                                            item.imageItem.Add(image);
                                        }

                                    }

                                }
                            }
                            else
                            {
                                // nếu sản phẩm ko trùng id color và ko tồn tại trong listcolor thì add color
                                var colorExsit = targetPro.listColors.Any(item => item.ProductColorID == product.ProductColorID);
                                var targetColor = targetPro.listColors.FirstOrDefault(item => item.ProductColorID == product.ProductColorID);
                                if (!colorExsit)
                                {
                                    color.ProductColorName = product.ProductColorName;
                                    color.ProductColorID = product.ProductColorID;
                                    color.selected = false;
                                    size.ProductSizeName = product.ProductSizeName;
                                    size.ProductSizeID = product.ProductSizeID;
                                    size.selected = false;
                                    size.VariantID = product.VariantID;
                                    size.Quantity = product.Quantity;
                                    color.sizeItem.Add(size);
                                    image.selected = true;
                                    image.ProductImageUrl = product.ProductImageUrl;
                                    image.ProductImageID = product.ProductImageID;
                                    color.imageItem.Add(image);
                                    targetPro.listColors.Add(color);
                                }
                                else
                                // nếu tồn tại trong listColors thì add size
                                {
                                    var exitsSize = targetColor.sizeItem.Any(i => i.ProductSizeID == product.ProductSizeID);
                                    if (!exitsSize)
                                    {
                                        size.ProductSizeName = product.ProductSizeName;
                                        size.ProductSizeID = product.ProductSizeID;
                                        size.selected = false;
                                        size.Quantity = product.Quantity;
                                        size.VariantID = product.VariantID;
                                        targetColor.sizeItem.Add(size);
                                    }


                                    // nếu image ko tồn tại trong imgItem thì add image
                                    var exitsImg = targetColor.imageItem.Any(i => i.ProductImageID == product.ProductImageID);
                                    if (!exitsImg)
                                    {
                                        // add image
                                        image.ProductImageID = product.ProductImageID;
                                        image.ProductImageUrl = product.ProductImageUrl;
                                        image.selected = false;
                                        targetColor.imageItem.Add(image);
                                    }

                                }

                            }

                        }

                    }
                    else
                    {
                        // Thêm sản phẩm vào trong list

                        color.ProductColorID = product.ProductColorID;
                        color.ProductColorName = product.ProductColorName;
                        color.selected = false;
                        size.ProductSizeName = product.ProductSizeName;
                        size.ProductSizeID = product.ProductSizeID;
                        size.selected = false;
                        size.Quantity = product.Quantity;
                        size.VariantID = product.VariantID;
                        image.ProductImageUrl = product.ProductImageUrl;
                        image.ProductImageID = product.ProductImageID;
                        image.selected = true;
                        color.imageItem.Add(image);
                        color.sizeItem.Add(size);
                        product.listColors.Add(color);
                        products.Add(product);

                    }

                }
                foreach (var prod in products)
                {
                    foreach (var color in prod.listColors)
                    {
                        foreach (var size in color.sizeItem)
                        {
                            prod.TotalQuantity += size.Quantity;
                        }
                    }
                }
                return products;
            }
            return new List<Product>();
        }

        public void AfterUpdate(Product product)
        {
            if (product.listColors.Count > 0)
            {
                foreach (var color in product.listColors)
                {
                    for (var i = 0; i < color.sizeItem.Count; i++)
                    {
                        var sql = $"UPDATE productvariant SET ProductSizeID = '{color.sizeItem[i].ProductSizeID}',ProductColorID = '{color.ProductColorID}',Quantity = {color.sizeItem[i].Quantity} WHERE VariantID = '{color.sizeItem[i].VariantID}';";

                        // Khoởi tạo kết nối tới DB MySQL (Muộn nhất có thể)
                        using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                        {
                            //Thực hiện gọi vào DB
                            mySqlConnection.Execute(sql);
                        }
                    }

                    for (var i = 0; i < color.imageItem.Count; i++)
                    {
                        var sql = $"UPDATE productimage SET ProductImageUrl = '{color.imageItem[i].ThumbnailUrl}',ProductColorID = '{color.ProductColorID}' WHERE ProductImageID = '{color.imageItem[i].ProductImageID}';";
                        using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                        {
                            //Thực hiện gọi vào DB
                            mySqlConnection.Execute(sql);
                        }
                    }
                }
            }

        }

        public List<Product> GetProductByID(Guid productID)
        {
            // Lấy tất cả kích cỡ, màu sác của các sản phảm
            var result = _productDL.GetProductByID(productID);
            if (result != null)
            {

                var products = new List<Product>();
                foreach (Product product in (List<Product>)result)
                {
                    // Kiểm tra xem sản phẩm đã có trong list chưa
                    bool exists = products.Any(item => item.ProductID == product.ProductID);
                    var color = new ProductColor();
                    var size = new ProductSize();
                    var image = new ProductImage();
                    if (exists)
                    {

                        // Lấy ra sản phẩm đấy mếu đã tồn tại
                        Product targetPro = products.FirstOrDefault(item => item.ProductID == product.ProductID);
                        if (targetPro != null)
                        {                 
                            // Xử lý thêm màu sắc và kích cỡ cho sản phẩm
                            // kiểm tra xem sản phẩm có cùng màu sắc hay không , nếu cùng màu thì add thêm productSizes nếu không thì add thêm productColors
                            if (targetPro.ProductColorID == product.ProductColorID)
                            {
                                foreach (var item in targetPro.listColors)
                                {

                                    if (item.ProductColorID == product.ProductColorID)
                                    {
                                        var exitsSize = item.sizeItem.Any(i => i.ProductSizeID == product.ProductSizeID);

                                        if (!exitsSize)
                                        {
                                            size.ProductSizeName = product.ProductSizeName;
                                            size.ProductSizeID = product.ProductSizeID;
                                            size.selected = false;
                                            size.VariantID = product.VariantID;
                                            size.Quantity = product.Quantity;
                                            item.sizeItem.Add(size);
                                        }

                                        // kiểm tra xem image đã có, lặp lại hay không , nếu ko lặp lại add images
                                        var exitsImg = item.imageItem.Any(i => i.ProductImageID == product.ProductImageID);
                                        if (!exitsImg)
                                        {
                                            // add image
                                            image.ProductImageID = product.ProductImageID;
                                            image.ProductImageUrl = product.ProductImageUrl;
                                            image.selected = false;
                                            item.imageItem.Add(image);
                                        }

                                    }

                                }
                            }
                            else
                            {
                                // nếu sản phẩm ko trùng id color và ko tồn tại trong listcolor thì add color
                                var colorExsit = targetPro.listColors.Any(item => item.ProductColorID == product.ProductColorID);
                                var targetColor = targetPro.listColors.FirstOrDefault(item => item.ProductColorID == product.ProductColorID);
                                if (!colorExsit)
                                {
                                    color.ProductColorName = product.ProductColorName;
                                    color.ProductColorID = product.ProductColorID;
                                    color.selected = false;
                                    size.ProductSizeName = product.ProductSizeName;
                                    size.ProductSizeID = product.ProductSizeID;
                                    size.selected = false;
                                    size.VariantID = product.VariantID;
                                    size.Quantity = product.Quantity;
                                    color.sizeItem.Add(size);
                                    image.selected = true;
                                    image.ProductImageUrl = product.ProductImageUrl;
                                    image.ProductImageID = product.ProductImageID;
                                    color.imageItem.Add(image);
                                    targetPro.listColors.Add(color);
                                }
                                else
                                // nếu tồn tại trong listColors thì add size
                                {
                                    var exitsSize = targetColor.sizeItem.Any(i => i.ProductSizeID == product.ProductSizeID);
                                    if (!exitsSize)
                                    {
                                        size.ProductSizeName = product.ProductSizeName;
                                        size.ProductSizeID = product.ProductSizeID;
                                        size.selected = false;
                                        size.Quantity = product.Quantity;
                                        size.VariantID = product.VariantID;
                                        targetColor.sizeItem.Add(size);
                                    }


                                    // nếu image ko tồn tại trong imgItem thì add image
                                    var exitsImg = targetColor.imageItem.Any(i => i.ProductImageID == product.ProductImageID);
                                    if (!exitsImg)
                                    {
                                        // add image
                                        image.ProductImageID = product.ProductImageID;
                                        image.ProductImageUrl = product.ProductImageUrl;
                                        image.selected = false;
                                        targetColor.imageItem.Add(image);
                                    }

                                }

                            }

                        }

                    }
                    else
                    {
                        // Thêm sản phẩm vào trong list

                        color.ProductColorID = product.ProductColorID;
                        color.ProductColorName = product.ProductColorName;
                        color.selected = false;
                        size.ProductSizeName = product.ProductSizeName;
                        size.ProductSizeID = product.ProductSizeID;
                        size.selected = false;
                        size.Quantity = product.Quantity;
                        size.VariantID = product.VariantID;
                        image.ProductImageUrl = product.ProductImageUrl;
                        image.ProductImageID = product.ProductImageID;
                        image.selected = true;
                        color.imageItem.Add(image);
                        color.sizeItem.Add(size);
                        product.listColors.Add(color);
                        products.Add(product);

                    }

                }
                foreach (var prod in products)
                {
                    foreach (var color in prod.listColors)
                    {
                        foreach (var size in color.sizeItem)
                        {
                            prod.TotalQuantity += size.Quantity;
                        }
                    }
                }
                return products;
            }
            return new List<Product>();
        }

        public List<Product> GetProductByFilterAndPaging(string? keyword,int PageSize,int PageNumber, int[]? price, string[]? Filtercolor, string[]? Filtersize)
        {
            var result = _productDL.GetProductByPagingAndFilter(keyword, PageSize, PageNumber, price, Filtercolor, Filtersize);

            if (result != null)
            {

                var products = new List<Product>();
                foreach (Product product in (List<Product>)result)
                {
                    // Kiểm tra xem sản phẩm đã có trong list chưa
                    bool exists = products.Any(item => item.ProductID == product.ProductID);
                    var color = new ProductColor();
                    var size = new ProductSize();
                    var image = new ProductImage();
                    if (exists)
                    {

                        // Lấy ra sản phẩm đấy mếu đã tồn tại
                        Product targetPro = products.FirstOrDefault(item => item.ProductID == product.ProductID);
                        if (targetPro != null)
                        {
                            // Xử lý thêm màu sắc và kích cỡ cho sản phẩm
                            // kiểm tra xem sản phẩm có cùng màu sắc hay không , nếu cùng màu thì add thêm productSizes nếu không thì add thêm productColors
                            if (targetPro.ProductColorID == product.ProductColorID)
                            {
                                foreach (var item in targetPro.listColors)
                                {

                                    if (item.ProductColorID == product.ProductColorID)
                                    {
                                        var exitsSize = item.sizeItem.Any(i => i.ProductSizeID == product.ProductSizeID);

                                        if (!exitsSize)
                                        {
                                            size.ProductSizeName = product.ProductSizeName;
                                            size.ProductSizeID = product.ProductSizeID;
                                            size.selected = false;
                                            size.VariantID = product.VariantID;
                                            size.Quantity = product.Quantity;
                                            item.sizeItem.Add(size);
                                        }

                                        // kiểm tra xem image đã có ,lặp lại hay không , nếu ko lặp lại add images
                                        var exitsImg = item.imageItem.Any(i => i.ProductImageID == product.ProductImageID);
                                        if (!exitsImg)
                                        {
                                            // add image
                                            image.ProductImageID = product.ProductImageID;
                                            image.ProductImageUrl = product.ProductImageUrl;
                                            image.selected = false;
                                            item.imageItem.Add(image);
                                        }

                                    }

                                }
                            }
                            else
                            {
                                // nếu sản phẩm ko trùng id color và ko tồn tại trong listcolor thì add color
                                var colorExsit = targetPro.listColors.Any(item => item.ProductColorID == product.ProductColorID);
                                var targetColor = targetPro.listColors.FirstOrDefault(item => item.ProductColorID == product.ProductColorID);
                                if (!colorExsit)
                                {
                                    color.ProductColorName = product.ProductColorName;
                                    color.ProductColorID = product.ProductColorID;
                                    color.selected = false;
                                    size.ProductSizeName = product.ProductSizeName;
                                    size.ProductSizeID = product.ProductSizeID;
                                    size.selected = false;
                                    size.VariantID = product.VariantID;
                                    size.Quantity = product.Quantity;
                                    color.sizeItem.Add(size);
                                    image.selected = true;
                                    image.ProductImageUrl = product.ProductImageUrl;
                                    image.ProductImageID = product.ProductImageID;
                                    color.imageItem.Add(image);
                                    targetPro.listColors.Add(color);
                                }
                                else
                                // nếu tồn tại trong listColors thì add size
                                {
                                    var exitsSize = targetColor.sizeItem.Any(i => i.ProductSizeID == product.ProductSizeID);
                                    if (!exitsSize)
                                    {
                                        size.ProductSizeName = product.ProductSizeName;
                                        size.ProductSizeID = product.ProductSizeID;
                                        size.selected = false;
                                        size.VariantID = product.VariantID;
                                        size.Quantity = product.Quantity;
                                        targetColor.sizeItem.Add(size);
                                    }


                                    // nếu image ko tồn tại trong imgItem thì add image
                                    var exitsImg = targetColor.imageItem.Any(i => i.ProductImageID == product.ProductImageID);
                                    if (!exitsImg)
                                    {
                                        // add image
                                        image.ProductImageID = product.ProductImageID;
                                        image.ProductImageUrl = product.ProductImageUrl;
                                        image.selected = false;
                                        targetColor.imageItem.Add(image);
                                    }

                                }

                            }

                        }

                    }
                    else
                    {
                        // Thêm sản phẩm vào trong list

                        color.ProductColorID = product.ProductColorID;
                        color.ProductColorName = product.ProductColorName;

                        color.selected = false;
                        size.ProductSizeName = product.ProductSizeName;
                        size.ProductSizeID = product.ProductSizeID;
                        size.selected = false;
                        size.VariantID = product.VariantID;
                        size.Quantity = product.Quantity;
                        image.ProductImageUrl = product.ProductImageUrl;
                        image.ProductImageID = product.ProductImageID;
                        image.selected = true;
                        color.imageItem.Add(image);
                        color.sizeItem.Add(size);
                        product.listColors.Add(color);
                        products.Add(product);

                    }

                }
                return products;
            }
            return new List<Product>();
        }

        public ServiceResponse InsertProduct(Product product)
        {
            var result = ValidateData(null, product);

            if (result.Success == false)
            {
                return new ServiceResponse(false, result.Data);
            }

            var res = _productDL.InsertProduct(product);
            if (res != null)
            {
                new ServiceResponse(true, 1);
                AfterInsert(product);

                return new ServiceResponse(true, 1);
            }

            //ValidateCustom();
            return new ServiceResponse(false, 0);
        }

        public ServiceResponse UpdateProduct(Guid productID, Product product)
        {
           
            var result = ValidateData(productID, product);
            if (result.Success == false)
            {
                return new ServiceResponse(false, result.Data);
            }

            var res = _productDL.UpdateProduct(productID,product);

            if (res != null)
            {
                new ServiceResponse(true, 1);
                AfterUpdate(product);
                return new ServiceResponse(true, 1);
            }

            //ValidateCustom();
            return new ServiceResponse(false, 0);
        }

        public ServiceResponse PlaceOrderSingle(PlaceOrderSingle placeOrderSingle)
        {
            var res = _productDL.PlaceOrderSingle(placeOrderSingle);
            if (res == 0)
            {
                return new ServiceResponse(false, 0);
            }else
            {
                return new ServiceResponse(true, 1);
            }
        }

        //public async void SaveOnImages(List<ProductImage> images)
        //{
        //    if(images.Count > 0)
        //    {
        //        var url = new List<Result>();
        //        foreach (ProductImage file in images)
        //        {

        //            // Gọi ImageKitService để upload ảnh lên ImageKit
        //            // Chuyển IFormFile sang dạng byte array
        //            byte[] fileBytes;
        //            using (var memoryStream = new MemoryStream())
        //            {
        //                await file.CopyToAsync(memoryStream);
        //                fileBytes = memoryStream.ToArray();
        //            }

        //            // Tạo đối tượng FileCreateRequest để truyền vào phương thức UploadAsync
        //            var fileCreateRequest = new FileCreateRequest()
        //            {
        //                file = fileBytes,
        //                fileName = file.FileName,
        //                //folder = "/products/"
        //            };

        //            // Thực hiện yêu cầu upload ảnh lên ImageKit
        //            var response = await _imageKitClient.UploadAsync(fileCreateRequest);
        //            url.Add(response);

        //        }
        //    }
        //}
    }
}
