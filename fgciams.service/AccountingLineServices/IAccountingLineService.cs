using fgciams.domain.clsAccountingLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.AccountingLineServices
{
    public interface IAccountingLineService
    {
        Task<AccountLineGroupModel> AddAccountLineGroup(AccountLineGroupModel accountLineGroup, string token);
        Task<AccountLineGroupModel> UpdateAccountLineGroup(AccountLineGroupModel accountLineGroup, string token);
        Task<List<AccountLineGroupModel>> LoadAccountLineGroup(string token);
    }
}
