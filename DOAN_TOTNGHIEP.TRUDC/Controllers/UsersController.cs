using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductBL;
using DOAN_TOTNGHIEP.TRUDC.BL.UserBL;
using DOAN_TOTNGHIEP.TRUDC.Common;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using DOAN_TOTNGHIEP.TRUDC.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DOAN_TOTNGHIEP.TRUDC.Controllers
{
  
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Field

        private IUserBL _userBL;

        IConfiguration _configuration;

        #endregion

        #region Constructor 

        public UsersController(IUserBL userBL, IConfiguration configuration)
        {
            _userBL = userBL;
            _configuration = configuration;
        }

        #endregion

        [HttpPost]
        [Route("PostLoginDetails")]
        public async Task<IActionResult> PostLoginDetails([FromBody] User _userData)
        {
            try
            {
                if (_userData != null)
                {
                    ServiceResponse resultLoginCheck = _userBL.PostLoginDetails(_userData);

                    if (resultLoginCheck.Success == false)
                    {
                        return BadRequest("Invalid Credentials");
                    }
                    else
                    {
                        _userData.UserMessage = "Login Success";

                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", _userData.UserID.ToString()),
                        new Claim("DisplayName", _userData.FullName),
                        new Claim("UserName", _userData.FullName),
                        new Claim("Email", _userData.Email)
                    };


                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn);


                        _userData.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                        return Ok(_userData);
                    }
                }
                else
                {
                    return BadRequest("No Data Posted");
                }
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
