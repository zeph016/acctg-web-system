using fgciams.domain.clsBank;
using fgciams.domain.clsFilterParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.BankServices
{
    public interface IBankService
    {
        Task<BankModel> AddBank(BankModel bankModel, string token);
        Task<BankModel> UpdateBank(BankModel bankModel, string token);
        Task<List<BankModel>> LoadBanks(string token);
        Task<BankModel> GetBank(Int64 Id, string token);
    }
}
