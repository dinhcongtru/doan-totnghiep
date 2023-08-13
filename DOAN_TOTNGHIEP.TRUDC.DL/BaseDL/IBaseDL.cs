
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.DL.BaseDL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Lấy tất cả danh sách bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy : DCTRU (10/11/2022)
        public IEnumerable<T> GetAllRecords();

        /// <summary>
        /// Lấy thông tin của 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn lấy</param>
        /// <returns>Thông tin của 1 bản ghi theo ID</returns>
        /// CreatedBy : DCTRU (10/11/2022)
        public T GetRecordByID(Guid recordID);

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record"></param>Thông tin bản ghi muốn thêm
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by : DCTRU (10/11/2022)
        public int InsertRecord(T record);

        /// <summary>
        /// Sửa thông thin một bản ghi theo ID
        /// </summary>
        /// <param name="recordID"></param> ID của bản ghi
        /// <param name="record"></param> Thông tin bản ghi
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : DCTRU(10/11/2022)
        public int UpdateRecord(Guid recordID, T record);

        /// <summary>
        /// Xóa thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi </param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Author:DCTRU (15/11/2022)
        public int DeleteRecordByID(Guid recordID);

        /// <summary>
        ///Check trùng mã bản ghi khi thêm mới
        /// </summary>
        /// <param name="recordCode"></param>Mã bản ghi muốn kiểm tra
        /// <returns>trả về 0 nếu trùng,1 nếu không trùng</returns>
        /// Author:DCTRU (15/11/2022)
        public int CheckDuplicateCodeInsert(string recordCode);

        /// <summary>
        ///Check trùng mã bản ghi khi sửa bản ghi
        /// </summary>
        /// <param name="recordID"></param>ID bản ghi muốn kiểm tra trùng mã
        /// <param name="recordCode"></param>Mã bản ghi muốn kiểm tra
        /// <returns>trả về 0 nếu trùng,1 nếu không trùng</returns>
        /// Author:DCTRU (15/11/2022)
        public int CheckDuplicateCodeUpdate(Guid recordID, string recordCode);
    }
}
