using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.BL.UserBL
{
    public interface IUserBL : IBaseBL<User>
    {
        public ServiceResponse PostLoginDetails(User user);
    }
}
