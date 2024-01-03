using Dapper;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.DL.BaseDL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.DL.UserDL
{
    public class UserDL : BaseDL<User>, IUserDL
    {
      
        public User PostLoginDetails(User user)
        {
            // Chuẩn bị câu lệnh SQL 
            string storedProcedureName = "Proc_User_Login";

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"@Password", user.Password);
            parameters.Add($"@Email", user.Email);


            // Thực hiện gọi vào DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                var record = mySqlConnection.QueryFirstOrDefault<User>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return record;
            }
        }
    }
}
