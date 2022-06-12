using fgciams.domain.clsAccountingPOBilling;
using fgciams.domain.clsFilterParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.AccountingPOBillingServices
{
    public interface IAccountingPOBillingService
    {
        Task<List<AccountingPOBillingModel>> LoadAccountingBillingPO(FilterParameter filterParameter, string token);
    }
}
