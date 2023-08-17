using DOAN_TOTNGHIEP.TRUDC.Common;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using DOAN_TOTNGHIEP.TRUDC.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.BL.BaseBL
{
    public class BaseBL<T> : IBaseBL<T> 
    {
        #region Field

        private IBaseDL<T> _baseDL;
        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả danh sách bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy : DCTRU (10/11/2022)
        public IEnumerable<T> GetAllRecords()
        {
             var result = _baseDL.GetAllRecords();
            return result;
        }

        /// <summary>
        /// Lấy thông tin của 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn lấy</param>
        /// <returns>Thông tin của 1 bản ghi theo ID</returns>
        /// CreatedBy : DCTRU (10/11/2022)   
        public ServiceResponse GetRecordByID(Guid recordID)
        {
            T result = _baseDL.GetRecordByID(recordID);
            if (result != null)
            {
                return new ServiceResponse(true, result);
            }
            else return new ServiceResponse(false, null);

        }

        /// <summary>
        ///Thêm mới  một bản ghi
        /// </summary>
        /// <param name="record"></param>Thông tin bản ghi muốn thêm
        /// <returns>Trả về lỗi nếu validate false hoặc trả về số bản ghi bị ảnh hưởng trong database</returns>
        /// CreatedBy : DCTRU (10/11/2022) 
        public ServiceResponse InsertRecord(T record)
        {
            var result = ValidateData(null, record);

            if (result.Success == false)
            {
                return new ServiceResponse(false, result.Data);
            }

            //ValidateCustom();

            return new ServiceResponse(true, _baseDL.InsertRecord(record));
        }

        /// <summary>
        ///Thêm mới nhiều bản ghi
        /// </summary>
        /// <param name="record"></param>Thông tin bản ghi muốn thêm
        /// <returns>Trả về lỗi nếu validate false hoặc trả về số bản ghi bị ảnh hưởng trong database</returns>
        /// CreatedBy : DCTRU (10/11/2022) 
        public ServiceResponse InsertMultipleRecord(List<T> records)
        {
            foreach(T record in records)
            {
                var result = ValidateData(null, record);

                if (result.Success == false)
                {
                    return new ServiceResponse(false, result.Data);
                }

                //ValidateCustom();

                var res = _baseDL.InsertRecord(record);
                if (res == 0)
                {
                    return new ServiceResponse(false, records);
                }

            }
            return new ServiceResponse(true, records);
        }

        /// <summary>
        /// Sửa thông tin một bản ghi
        /// </summary>
        /// <param name="recordID"></param>ID bản ghi muốn sửa
        /// <param name="record"></param>Thông tin bản ghi muốn sửa
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : DCTRU (10/11/2022) 
        public ServiceResponse UpdateRecord(Guid recordID, T record)
        {
            var id = recordID;

            var result = ValidateData(recordID, record);
            if (result.Success == false)
            {
                return new ServiceResponse(false, result.Data);
            }
            return new ServiceResponse(true, _baseDL.UpdateRecord(recordID, record));
        }

        /// <summary>
        /// Xóa thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi </param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : DCTRU (10/11/2022)  
        public ServiceResponse DeleteRecordByID(Guid recordID)
        {
            int result = _baseDL.DeleteRecordByID(recordID);
            if (result > 0)
            {
                return new ServiceResponse(true, 1);
            }
            return new ServiceResponse(false, 0);
        }

        #endregion

        /// <summary>
        /// Validate thông tin khi thêm mới hoặc sửa bản ghi
        /// </summary>
        /// <param name="recordID"></param> Nếu sửa thì truyền vào ID bản ghi
        /// <param name="record"></param>Thông tin bản ghi
        /// <returns>Trả về true nếu validate thành công, ngược lại trả về false và lỗi gặp phải</returns>
        public ServiceResponse ValidateData(Guid? recordID, T record)
        {

            var properties = record.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propName = prop.Name;
                // lấy giá trị của property truyền lên
                var propValue = prop.GetValue(record);

                bool isExist = true;
                if (propValue == null || propValue.ToString().Trim() == "")
                {
                    isExist = false;
                }

                // Kiểm tra xem property có attribute là isNotNullOrEmpty không
                var IsNotNullOrEmpty = Attribute.IsDefined(prop, typeof(IsNotNullOrEmptyAttribute));

                // Kiểm tra xem property có attribute là isEmail không
                var validateEmail = Attribute.IsDefined(prop, typeof(ValidateEmailAttribute));


                //Kiểm tra xem property có attribute là OnlyNumber không
                var isOnlyNumber = Attribute.IsDefined(prop, typeof(IsNumberAttribute));

                //Validate nếu có atrribute bắt buộc nhập
                if (IsNotNullOrEmpty == true)
                {
                    var attribute = prop.GetCustomAttributes(typeof(IsNotNullOrEmptyAttribute), true).FirstOrDefault();


                    var errorMessage = (attribute as IsNotNullOrEmptyAttribute).ErrorMessage;
                    if (propValue == null || propValue.ToString().Trim() == "")
                    {
                        return new ServiceResponse(false, errorMessage);
                    }
                }

                //Validate nếu có attribute email
                if (validateEmail == true && isExist == true)
                {
                    var attribute = prop.GetCustomAttributes(typeof(ValidateEmailAttribute), true).FirstOrDefault();
                    var errorMessage = (attribute as ValidateEmailAttribute).ErrorMessage;
                    bool checkEmail = IsValidEmail(propValue?.ToString());
                    if (!checkEmail)
                    {
                        return new ServiceResponse(false, errorMessage);
                    }
                }


                //Validate nếu có attribute  là các trường nhập số
                if (isOnlyNumber == true && isExist == true)
                {
                    //lấy ra attribute
                    var attribute = prop.GetCustomAttributes(typeof(IsNumberAttribute), true).FirstOrDefault();

                    // lấy ra regex 
                    var regex = new Regex((attribute as IsNumberAttribute).Format);

                    var errorMessage = (attribute as IsNumberAttribute).ErrorMessage;

                    if (!regex.IsMatch(propValue.ToString()))
                    {
                        return new ServiceResponse(false, errorMessage);
                    }
                }
            }


            //Validate trùng mã
            foreach (var prop in properties)
            {
                var propName = prop.Name;
                // lấy giá trị của property truyền lên
                var propValue = prop.GetValue(record);

                //Kiểm tra xem property có attribute là không được phép trùng 
                var isUnique = Attribute.IsDefined(prop, typeof(UniqueAttribute));

                //Validate nếu có atrribute không được phép trùng
                if (isUnique == true)
                {
                    var attribute = prop.GetCustomAttributes(typeof(UniqueAttribute), true).FirstOrDefault();


                    var errorMessage = (attribute as UniqueAttribute).ErrorMessage;


                    if (recordID == null)
                    {
                        int isDuplicate = _baseDL.CheckDuplicateCodeInsert((string)propValue);
                        if (isDuplicate == 0)
                        {
                            return new ServiceResponse(false, errorMessage);
                        }
                    }
                    else
                    {
                        int isDuplicate = _baseDL.CheckDuplicateCodeUpdate((Guid)recordID, (string)propValue);
                        if (isDuplicate == 0)
                        {
                            return new ServiceResponse(false, errorMessage);

                        }
                    }
                    break;
                }
            }


            return new ServiceResponse(true, null);
        }

        public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
