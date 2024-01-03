using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductBL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductDL;
using DOAN_TOTNGHIEP.TRUDC.DL.UserDL;


namespace DOAN_TOTNGHIEP.TRUDC.BL.UserBL
{
    public class UserBL : BaseBL<User>, IUserBL
    {

        #region Field

        private IUserDL _userDL;


        #endregion

        #region Constructor

        public UserBL(IUserDL userDL) : base(userDL)
        {
            _userDL = userDL;
        }

        public ServiceResponse PostLoginDetails(User user)
        {
            var result = _userDL.PostLoginDetails(user);

            if (result != null)
            {
                return new ServiceResponse(true, result);
            }
            else return new ServiceResponse(false, null);
        }
    }
}
#endregion