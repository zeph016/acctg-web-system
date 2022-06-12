using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsUserAccount;

namespace fgciams.service.UserAccountServices
{
    public interface IUserAccountService
    {
        Task<UserAccount> AuthenticateToken(UserAccount userAccount, string token);
    }
}