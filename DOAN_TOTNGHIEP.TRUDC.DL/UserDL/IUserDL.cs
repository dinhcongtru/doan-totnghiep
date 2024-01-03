using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_TOTNGHIEP.TRUDC.DL.UserDL
{
    public interface IUserDL : IBaseDL<User>
    {
        public User PostLoginDetails(User user);
    }
}
