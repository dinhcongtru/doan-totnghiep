using DOAN_TOTNGHIEP.TRUDC.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using Dapper;
using DOAN_TOTNGHIEP.TRUDC.Common.Constants;
using MySqlConnector;
using System.ComponentModel.DataAnnotations;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;

namespace DOAN_TOTNGHIEP.TRUDC.DL.ProductDL
{
    public class ProductDL : BaseDL<Product>, IProductDL
    {
       
        /// <summary>
        /// Lấy thông tin của 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn lấy</param>
        /// <returns>Thông tin của 1 bản ghi theo ID</returns>
        /// CreatedBy : DCTRU (13/08/2023)
        public IEnumerable<Product> GetProductByID(Guid productID)
        {


            // Chuẩn bị câu lệnh SQL 
            string storedProcedureName = "Proc_Product_GetByID";

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"@ProductID", productID);

            var records = new List<Product>();
            // Thực hiện gọi vào DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                records = (List<Product>)mySqlConnection.Query<Product>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return records;
            }
        }

        public IEnumerable<Product> GetProductBestSeller()
        {
            var products = new List<Product>();
            // lấy ra proid từ order_detail
            var sql_ProID = $"SELECT ProductID FROM orderdetail";
            var proIDs = new List<Guid>();
            using(var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                proIDs = (List<Guid>)mySqlConnection.Query<Guid>(sql_ProID);
            }
            if(proIDs.Count > 0)
            {
                
                // lấy ra sp có trong order_detail
                // Chuẩn bị câu lệnh SQL 
                string storedProcedureName = "Proc_Product_GetByID";
                var str = string.Join("','", proIDs);
                // Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("@ProductIDs", str);
                using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                {
                    products = (List<Product>)mySqlConnection.Query<Product>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return products;                     
                }
                              
            }
            return products;
        }

        public IEnumerable<Product> GetProductByCategory(Guid categoryID)
        {
            // Chuẩn bị câu lệnh SQL 
            string storedProcedureName = "Proc_GetProductBy_category";

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"@ProductCategoryID", categoryID);

            var records = new List<Product>();
            // Thực hiện gọi vào DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                records = (List<Product>)mySqlConnection.Query<Product>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return records;
            }
        }

        public IEnumerable<Product> GetProductByPagingAndFilter(string? keyword, int PageSize, int PageNumber, int[]? price, string[]? color, string[]? size)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_Product_GetPaging";

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();

            parameters.Add("v_offset", (PageNumber - 1) * PageSize);
            parameters.Add("v_limit", PageSize);
            parameters.Add("v_soft", "ModifiedDate DESC");

            var lstCondition = new List<string>();
            string searchClause = "";
            if (keyword != null)
            {
                lstCondition.Add($"ProductCode LIKE '%{keyword}%'");
                lstCondition.Add($"ProductName LIKE '%{keyword}%'");             

            }    
            if (lstCondition.Count > 0)
            {
                searchClause = string.Join(" OR ", lstCondition);
            }

           
            var coditionPrice = new List<int>();
            if(price != null && price.Length > 0)
            {
                foreach (var p in price)
                {
                    coditionPrice.Add(p);
                }
                if (searchClause != "")
                {
                    searchClause += " " + "AND ProductPrice <=" + " " + string.Join(" OR ProductPrice <= ", coditionPrice);
                }
                else
                {
                    searchClause = "ProductPrice <=" + " " + string.Join(" OR ProductPrice <= ", coditionPrice);
                }
                
            }

            //color
            var coditionColor = new List<string>();
            if (color != null && color.Length > 0)
            {
                foreach (var p in color)
                {
                    coditionColor.Add(p);
                }
                if (searchClause != "")
                {
                    searchClause += " " + "AND p2.ProductColorID =" + " " + string.Join(" OR p2.ProductColorID = ", coditionColor);
                }
                else
                {
                    searchClause = "p2.ProductColorID =" + " " + string.Join(" OR p2.ProductColorID = ", coditionColor);
                }

            }

            // size
            var coditionSize = new List<string>();
            if (size != null && size.Length > 0)
            {
                foreach (var p in size)
                {
                    coditionSize.Add(p);
                }
                if (searchClause != "")
                {
                    searchClause += " " + "AND p2.ProductSizeID =" + " " + string.Join(" OR p2.ProductSizeID = ", coditionSize);
                }
                else
                {
                    searchClause = "p2.ProductSizeID =" + " " + string.Join(" OR p2.ProductSizeID = ", coditionSize);
                }

            }

            parameters.Add("v_search", searchClause);
            var records = new List<Product>();
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                records = (List<Product>)mySqlConnection.Query<Product>(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return records;
            }
        }

        public Product InsertProduct(Product product)
        {
            //Khai báo tên procedure
            string storedProcedureName = "Proc_Product_Insert";

            //Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();


            //Lấy ra các properties của class được truyền vào
            var properties = typeof(Product).GetProperties();

            var newRecordID = Guid.NewGuid();
            object propValue;

            foreach (var prop in properties)
            {
                if (prop.Name != "listColors")
                {
                    var propName = prop.Name;

                    // Kiểm tra xem có phải ID không
                    var isPrimaryKeyAttribute = Attribute.IsDefined(prop, typeof(KeyAttribute));

                    if (isPrimaryKeyAttribute == true)
                    {
                        propValue = newRecordID;
                        prop.SetValue(product, propValue);
                    }
                    else
                    {
                        propValue = prop.GetValue(product);
                    }
                    parameters.Add($"@{prop.Name}", propValue);
                }

            }


            // Khoởi tạo kết nối tới DB MySQL (Muộn nhất có thể)
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                //Thực hiện gọi vào DB
                mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return product;
            }
        }

        public Product UpdateProduct(Guid productID, Product product)
        {
            string storedProcedureName = "Proc_Product_Update";

            var parameters = new DynamicParameters();

            //Lấy ra các properties của class được truyền vào
            var properties = typeof(Product).GetProperties();

            object propValue;

            foreach (var prop in properties)
            {
                if (prop.Name != "listColors")
                {
                    // Kiểm tra xem có phải ID không
                    var isPrimaryKeyAttribute = Attribute.IsDefined(prop, typeof(KeyAttribute));

                    if (isPrimaryKeyAttribute == true)
                    {
                        propValue = productID;
                        prop.SetValue(product, propValue);
                    }
                    else
                    {
                        propValue = prop.GetValue(product);
                    }
                    parameters.Add($"@{prop.Name}", propValue);
                }
            }

            // Khoởi tạo kết nối tới DB MySQL (Muộn nhất có thể)
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                //Thực hiện gọi vào DB
                mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return product;
            }
        }

        public int PlaceOrderSingle(PlaceOrderSingle placeOrderSingle)
        {
            // thêm vào bảng order
            string randomCode = GenerateRandomCode(10);
            var inser_order = $"INSERT INTO `order` (OrderCode, CustomerID, FullName, Email, Phone, Status, OrderDate, TotalPrice, Note, Address, Shiping) VALUES ('{randomCode}', '{placeOrderSingle.Customer_id}', '{placeOrderSingle.FullName}', '{placeOrderSingle.Email}', '{placeOrderSingle.Phone}', 'Chờ xác nhận', NOW(), {placeOrderSingle.TotalPrice}, '{placeOrderSingle.Note}', '{placeOrderSingle.Address + " " + placeOrderSingle.Phuong + " " + placeOrderSingle.Quan + " " + placeOrderSingle.City}', {placeOrderSingle.Shiping});";
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                mySqlConnection.Execute(inser_order);
            }
            // lấy ra id order vừa thêm
            var order_id = $"SELECT OrderID FROM `order` WHERE OrderCode = '{randomCode}'";
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                int result = mySqlConnection.QueryFirstOrDefault<int>(order_id);
                //add order detail
                foreach (Product product in placeOrderSingle.Products)
                {
                    foreach (var size in product.variantProductModel)
                    {

                        var insert_order_detail = $"INSERT INTO orderdetail (OrderID, ProductID, Quantity, Price, VariantID) VALUES ({result}, '{product.ProductID}', {size.Quantity}, {product.ProductPrice}, '{size.VariantID}');";
                        mySqlConnection.Execute(insert_order_detail);
                        

                    }
                }

                return 1;

            }

        }

        static string GenerateRandomCode(int length)
        {
            const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            string randomCode = new string(Enumerable.Repeat(characters, length)
                                          .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomCode.ToUpper();
        }
    }
}
