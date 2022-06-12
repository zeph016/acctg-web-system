using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsAccountingStatus;

namespace fgciams.service.AccountingStatusServices
{
    public interface IAccountingStatusService
    {
    #region Implementations
        Task<List<AccountingStatusModel>> LoadAccountingStatusList(string token);
        Task<AccountingStatusModel> AddAccountingStatus(AccountingStatusModel accountingStatus, string token);
        Task<AccountingStatusModel> UpdateAccountingStatus(AccountingStatusModel accountingStatus, string token);
        Task<AccountingStatusModel> GetAccountingStatusSingleValue(Int64 accountingId,string token);
    #endregion
    }
}
