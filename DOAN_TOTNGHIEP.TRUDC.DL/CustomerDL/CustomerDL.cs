using Dapper;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.DL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.DL.CustomerDL
{
    public class CustomerDL : BaseDL<Customer> ,ICustomerDL
    {
        public int? AdtoCart(AdtoCart adtoCart)
        {
            //kiểm tra xem cart_id ứng với customer đã tồn tại hay chưa 
            var sql_cartID = $"SELECT cart_id FROM cart WHERE customer_id = '{adtoCart.customer_id}'";
            int? cart_id;
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                 cart_id = mySqlConnection.QueryFirstOrDefault<int?>(sql_cartID);
            }
            // nếu cart id đã tồn tại thì tìm đến cart_item xem sản phẩm đã tồn tại trong giỏ hàng hay chưa
            if(cart_id != null)
            {
                var sql_cart_item = $"SELECT Cart_item_id FROM cart_item WHERE Cart_id = {cart_id} AND Product_id = '{adtoCart.Product_id}' AND Variant_id = '{adtoCart.Variant_id}'";
                int? cart_item_id;
                using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                {
                    cart_item_id = mySqlConnection.QueryFirstOrDefault<int?>(sql_cart_item);
                }
                //nếu tồn tại sản phẩm trong giỏ hàng kieem tra xem biến thể có trùng nhau ko , nếu trùng tăng số lượng ,, nếu ko add cart_item
                if (cart_item_id != null)
                {
                    //lấy ra số lượng có có cart_item
                    var Quantity_cart_item_exits = $"SELECT Quantity FROM cart_item WHERE Cart_item_id = {cart_item_id}";
                    int qty;
                    using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                    {
                         qty = mySqlConnection.QueryFirstOrDefault<int>(Quantity_cart_item_exits);
                    }
                    // update số lượng

                    var update_cart_item = $"UPDATE cart_item SET Quantity = {qty + adtoCart.Quantity} WHERE Cart_item_id = {cart_item_id}";
                    using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                    {
                       int numberOfRowsAffected = mySqlConnection.Execute(update_cart_item);
                    }
                }
                else
                {
                    // add cart_item
                    var insert_cart_item = $"INSERT INTO cart_item (Cart_id, Product_id, Variant_id, Quantity, Price) VALUES ({cart_id}, '{adtoCart.Product_id}', '{adtoCart.Variant_id}', {adtoCart.Quantity}, {adtoCart.Price})";
                    using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                    {
                        int numberOfRowsAffected = mySqlConnection.Execute(insert_cart_item);
                    }
                }
            }
            // nếu chưa tồn tại cart thì thêm cart
            else
            {
                var insert_cart = $"INSERT INTO cart (customer_id, CreatedDate) VALUES ('{adtoCart.customer_id}',CURDATE())";
                using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                {
                    int numberOfRowsAffected = mySqlConnection.Execute(insert_cart);
                  
                }
                // lấy ra cart_id vừa add
                var cart_id_sd = $"SELECT cart_id FROM cart WHERE customer_id = '{adtoCart.customer_id}'";
                int? cartID;
                using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                {
                    cartID = mySqlConnection.QueryFirstOrDefault<int?>(cart_id_sd);
                }
                    // add cart_item
                var insert_cart_item = $"INSERT INTO cart_item (Cart_id, Product_id, Variant_id, Quantity, Price) VALUES ({cartID}, '{adtoCart.Product_id}', '{adtoCart.Variant_id}', {adtoCart.Quantity}, {adtoCart.Price});";
                using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                {
                    int numberOfRowsAffected = mySqlConnection.Execute(insert_cart_item);
                }
            }

            return 1;
        }

        public Customer LoginCustomer(Customer customer)
        {
                      
            if (customer != null && customer.Password != "" || customer.FullName != "")
            {
                //kiểm trã xem cus đã tồn tại chưa , nếu chưa thông báo ng dùng chưa có tk nào hợp lệ

                var sql = $"SELECT Email FROM customer WHERE (Email = '{customer.Email}' AND Password = '{customer.Password}') OR (FullName = '{customer.FullName}' AND Password = '{customer.Password}')";

                
                using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                {
                    string result = mySqlConnection.QueryFirstOrDefault<string>(sql);
                    if (result != null) 
                    {
                        // mapping custom
                        // lấy ra custom tương ứng
                        var sql_cusLogin = $"SELECT * FROM customer WHERE (Email = '{customer.Email}' AND Password = '{customer.Password}') OR (FullName = '{customer.FullName}' AND Password = '{customer.Password}')";
                        Customer cusLogin = mySqlConnection.QueryFirstOrDefault<Customer>(sql_cusLogin);
                        return cusLogin;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public int registerCustomer(Customer customer)
        {
            //kiểm tra xem email đã tồn tại chưa

            var sql_query = $"SELECT Email FROM customer WHERE Email = '{customer.Email}'";
            var res = new Customer();
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                 res = mySqlConnection.QueryFirstOrDefault<Customer>(sql_query);

            }
            if(res == null)
            {
                //chưa có email đang ký => add customer
                var id = Guid.NewGuid();
                var insert = $"INSERT INTO customer (Customer_id, Password, FullName, Email, Phone, CreatedBY, CreatedDate, ModifiedDate, ModifiedBy, descrips_default) VALUES ('{id}', '{customer.Password}', '{customer.FullName}', '{customer.Email}', '{customer.Phone}', '', NOW(), NOW(), '', 0);";
                using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                {
                    int output = mySqlConnection.Execute(insert);
                    return output;
                }
            }
            return 0;
        }

        public CustomerLoginSocal LoginSocial(CustomerLoginSocal customer)
        {
            if (customer != null && customer.Email != "")
            {
                // kiểm tra xem custom đã tồn tại chưa
                var sql_custom_exsit = $"SELECT * FROM customer WHERE Email = '{customer.Email}'";
                var result = new CustomerLoginSocal();
                using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                {
                    result = mySqlConnection.QueryFirstOrDefault<CustomerLoginSocal>(sql_custom_exsit);
                }
                if(result != null)
                {
                    return result;
                }
                else
                {
                    // thêm vào db rồi trả về nó
                    var CusID = Guid.NewGuid();
                    var insert_custom = $"INSERT INTO customer (Customer_id, FullName, Email , descrips_default, CreatedBY, CreatedDate, ModifiedDate, ModifiedBy) VALUES ('{CusID}', '{customer.FullName}', '{customer.Email}', 1 , '', NOW(), NOW(), '')";
                    using(var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                    {
                        mySqlConnection.Execute(insert_custom);
                    }
                    var query_Cus = $"SELECT * FROM customer WHERE Customer_id = '{CusID}'";
                    using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                    {
                        CustomerLoginSocal cus = mySqlConnection.QueryFirstOrDefault<CustomerLoginSocal>(query_Cus);
                        return cus;
                    }
                }
            }
            return null;
        }

        public IEnumerable<ProudctOnCart> GetProductByCustomer(Guid customerID)
        {

            // kiểm tra xem customer đã mapping chưa
            var cus_exits = $"SELECT * FROM customer WHERE Customer_id = '{customerID}'";
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                Customer custom = mySqlConnection.QueryFirstOrDefault<Customer>(cus_exits);
                if (custom == null) return null;
               
            }
                var records = new List<ProudctOnCart>();

            // tìm ra cartid 
            var sql = $"SELECT cart_id FROM cart WHERE customer_id = '{customerID}'";
            int? cart_id;
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                cart_id = mySqlConnection.QueryFirstOrDefault<int?>(sql);
            }
            if (cart_id != null)
            {
                //tìm ra dữ liệu trong Cart_item từ cartid
                // Chuẩn bị câu lệnh SQL
                string storedProcedureName = "Proc_GetProductByCustomer";
                // Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("@Cart_id", cart_id);

                using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
                {
                    records = (List<ProudctOnCart>)mySqlConnection.Query<ProudctOnCart>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }

            return records;
        }

        public int DeleteProductOnCartByCustomer(int cart_item_id)
        {
            var sql = $"DELETE FROM cart_item WHERE Cart_item_id = {cart_item_id}";

            using(var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
               int result = mySqlConnection.Execute(sql);
                return result;
            }
        }

        public int LogOutCustomer(LogOutCustomer logOutCustomer)
        {
            //xóa tất cả các sản phẩm từ cart của customer
            var sql_cart_id = $"SELECT cart_id FROM cart WHERE customer_id = '{logOutCustomer.Customer_id}'";

            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                int cart_id = mySqlConnection.QueryFirstOrDefault<int>(sql_cart_id);
                if (cart_id != -1)
                {
                    // xóa tất cả record card_item
                    var delete_cart_item = $"DELETE FROM cart_item WHERE Cart_id = {cart_id}";
                    mySqlConnection.Execute(delete_cart_item);
                    // add lại các product tồn tại trc khi customer logout
                   
                    foreach (Product product in logOutCustomer.product)
                    {
                        foreach (ProductColor color in product.listColors)
                        {
                            for (int i = 0; i < color.sizeItem.Count; i++)
                            {
                              
                                var insert_cart_item = $"INSERT INTO cart_item (Cart_id, Product_id, Variant_id, Quantity, Price) VALUES ({cart_id}, '{product.ProductID}', '{color.sizeItem[i].VariantID}', {color.sizeItem[i].Quantity}, {product.ProductPrice});";
                                mySqlConnection.Execute(insert_cart_item);
                        
                            }
                        }
                    }
                    return 1;
                }
                
            }
            return 0;
        }
    }
}
