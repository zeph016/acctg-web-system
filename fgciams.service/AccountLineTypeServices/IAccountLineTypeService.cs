using fgciams.domain.clsAccountingLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.AccountLineTypeServices
{
    public interface IAccountLineTypeService 
    {
        Task<AccountLineTypeModel> AddAccountLineType(AccountLineTypeModel type, string token);
        Task<AccountLineTypeModel> UpdateAccountLineType(AccountLineTypeModel type, string token);
        Task<List<AccountLineTypeModel>> LoadAccountLineType(string token);
    }
}
