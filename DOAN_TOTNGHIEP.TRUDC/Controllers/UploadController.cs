using DOAN_TOTNGHIEP.TRUDC.Common;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using DOAN_TOTNGHIEP.TRUDC.Common.Enums;
using Imagekit.Sdk;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOAN_TOTNGHIEP.TRUDC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ImagekitClient _imageKitClient;
        public UploadController(IConfiguration configuration)
        {
            // Tạo ImageKitClient với thông tin cấu hình
            _imageKitClient = new ImagekitClient(
                "public_nRH9GscPrNBNZXoLDNKUp8KD3uw=",
                "private_EqGWiWgU7U8E18xws0Q+qiXCTH0=",
                "https://ik.imagekit.io/mbtxd1r6m");
        }

        /// <summary>
        /// Upload ảnh
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadImage(List<IFormFile> files)
        {
            try
            {
                if (files.Count > 0)
                {
                    var url = new List<Result>();
                    foreach (IFormFile file in files)
                    {

                        // Gọi ImageKitService để upload ảnh lên ImageKit
                        // Chuyển IFormFile sang dạng byte array
                        byte[] fileBytes;
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            fileBytes = memoryStream.ToArray();
                        }

                        // Tạo đối tượng FileCreateRequest để truyền vào phương thức UploadAsync
                        var fileCreateRequest = new FileCreateRequest()
                        {
                            file = fileBytes,
                            fileName = file.FileName,
                            //folder = "/products/"
                        };

                        // Thực hiện yêu cầu upload ảnh lên ImageKit
                        var response = await _imageKitClient.UploadAsync(fileCreateRequest);
                        url.Add(response);

                    }
                    return StatusCode(StatusCodes.Status200OK, url);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        ErrorCode = ApiErorrCode.Exception,
                        DevMsg = Resources.DevMsg_Exception,
                        UserMsg = Resources.UserMsg_Exception,
                        MoreInfo = Resources.MoreInfo_Exception,
                        TraceID = HttpContext.TraceIdentifier
                    });
                }

                // Trả về đường dẫn (URL) của ảnh đã upload
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Xóa ảnh theo ID
        /// </summary>
        /// <param name="id">id ảnh</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage([FromRoute] string id)
        {

            try
            {
                if (id.Length > 0)
                {
                    // Thực hiện yêu cầu upload ảnh lên ImageKit
                    var response = await _imageKitClient.DeleteFileAsync(id);
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        ErrorCode = ApiErorrCode.Exception,
                        DevMsg = Resources.DevMsg_Exception,
                        UserMsg = Resources.UserMsg_Exception,
                        MoreInfo = Resources.MoreInfo_Exception,
                        TraceID = HttpContext.TraceIdentifier
                    });
                }

                // Trả về đường dẫn (URL) của ảnh đã upload
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });
            }
        }

        /**
         * Xóa nhiều ảnh 
         * Truyền vào 1 list ID ảnh
         */
        [HttpPost("delete-bulk")]
        public async Task<IActionResult> DeleteBulkImage([FromBody] List<string> ids)
        {
            try
            {
                if (ids.Count > 0)
                {
                    foreach (string id in ids)
                    {
                        var response = await _imageKitClient.DeleteFileAsync(id);
                    }
                    // Thực hiện yêu cầu xóa nhiều ảnh ImageKit
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        ErrorCode = ApiErorrCode.Exception,
                        DevMsg = Resources.DevMsg_Exception,
                        UserMsg = Resources.UserMsg_Exception,
                        MoreInfo = Resources.MoreInfo_Exception,
                        TraceID = HttpContext.TraceIdentifier
                    });
                }

                // Trả về đường dẫn (URL) của ảnh đã upload
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ApiErorrCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceID = HttpContext.TraceIdentifier
                });
            }
        }
    }

}
